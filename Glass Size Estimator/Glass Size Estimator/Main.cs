using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.Diagnostics;

namespace Glass_Size_Estimator
{
	public partial class Main : Form
	{
		private List<ProductLine> productLines;
		private Dictionary<string, StockGlassLine> stockGlassLines;
		private ProductLine selectedProduct;

		public Main(List<ProductLine> ConfigProductLines, Dictionary<string, StockGlassLine> ConfigStockGlassLines)
		{
			productLines = ConfigProductLines;
			stockGlassLines = ConfigStockGlassLines;
			InitializeComponent();
			foreach (var product in productLines)
			{
				ProductLineSelector.Items.Add(product.Name);
			}
		}

		// Update the displayed fields whenever a new product line is selected
		private void ProductLineSelector_SelectedIndexChanged(object sender, EventArgs e)
		{
			// Retrieving productline object based on selectedItem
			if (ProductLineSelector.SelectedItems.Count == 0)
				return;
			string selectedItem = ProductLineSelector.SelectedItems[0].Text;
			ProductLine productLine = productLines.Where(n => n.Name.Equals(selectedItem)).First();

			//TODO: loop through inputs and examine their type, add corresponding element to input layout
			//TODO: Do the same for outputs

			foreach (var property in productLine.GetType().GetProperties()) //Getting the properties of the ProductLine type to Loop through
			{
				var value = property.GetValue(productLine); //Getting the value of the given property from the actual ProductLine object

				// Generate input fields (these values are List<string>)
				if (value is List<string> && ((List<string>)Convert.ChangeType(value, typeof(List<string>))).Count > 0) //If the value of the property is a List<string> and has a count > 0:
				{
					List<string> elementsToAdd = ((List<string>)Convert.ChangeType(value, typeof(List<string>)));

					// Add float inputs for the selected product
					if (property.Name.Equals("FloatInputs", StringComparison.OrdinalIgnoreCase))
					{
						foreach (string elementTitle in elementsToAdd)
						{
							AddFloatInput(elementTitle);
						}
					}

					// Add boolean inputs for the selected product
					else if (property.Name.Equals("BoolInputs", StringComparison.OrdinalIgnoreCase))
					{
						foreach (string elementTitle in elementsToAdd)
						{
							AddBoolInput(elementTitle);
						}
					}

                    else if (property.Name.Equals("EnumInputs", StringComparison.OrdinalIgnoreCase))
                    {
                        int i = 0;
                        foreach (string elementTitle in elementsToAdd)
                        {
                            AddEnumInput(elementTitle, i++);
                        }
                    }
				}

				// Generate output fields (these values are Dictionary<string,string>)
				else if (value is Dictionary<string, string>)
				{
					Dictionary<string, string> outputToAdd = (Dictionary<string, string>)value;
					foreach (KeyValuePair<string, string> kvp in outputToAdd)
					{
						// Add float outputs for the selected product
						if (property.Name.Equals("FloatOutputs", StringComparison.OrdinalIgnoreCase))
						{
							AddFloatOutput(kvp.Key);
						}
						// Add enum outputs for the selected product
						else if (property.Name.Equals("EnumOutputs", StringComparison.OrdinalIgnoreCase))
						{
							AddEnumOutput(kvp.Key);
						}
					}
				}
			}

			// By default, add a boolean field to indicate whether the resulting measurements are in stock
			AddBoolOutput("Can Use Stock Glass?");

			// Update the selected product line
			selectedProduct = productLine;
		}

        // Run through the state logic whenever the estimate button is pressed
        private void EstimateButton_Click(object sender, EventArgs e)
		{
			if (this.selectedProduct == null)
				return;

			// === Dictionaries used to store user parameters, input fields, and output fields ===
			Dictionary<string, object> inputs = new Dictionary<string, object>(); // All inputs and parameters are include in this one dictionary

			Dictionary<string, float> floatoutputs = new Dictionary<string, float>();
			Dictionary<string, bool> booloutputs = new Dictionary<string, bool>();
			Dictionary<string, string> enumoutputs = new Dictionary<string, string>();

			// === Retrieve Input Fields ===
			string inputTitle = null;
			string textBoxInput = null;
			float f_input;
			foreach (dynamic control in InputLayoutPanel.Controls)
			{
				if (control is Label)
				{
					inputTitle = control.Text;
				}
				else if (control is TextBox)
				{
					textBoxInput = control.Text;
					if (float.TryParse(textBoxInput, out f_input))
					{
						inputs.Add(inputTitle, f_input);
					}
				}
				// Add all checkbox input fields as parameters
				else if (control is CheckBox)
				{
					inputs.Add(inputTitle, control.Checked);
				}
			}

			// === Process state machine ===

			// Process each output field that belongs to the product line
			foreach (var kvp in selectedProduct.FloatOutputs)
			{
				floatoutputs.Add(kvp.Key, (float)this.selectedProduct.Logic[kvp.Key].Process(inputs[selectedProduct.FloatOutputs[kvp.Key]], inputs));
			}
			foreach (var kvp in selectedProduct.BoolOutputs)
			{
				booloutputs.Add(kvp.Key, (bool)this.selectedProduct.Logic[kvp.Key].Process(inputs[selectedProduct.BoolOutputs[kvp.Key]], inputs));
			}
			foreach (var kvp in selectedProduct.EnumOutputs)
			{
				enumoutputs.Add(kvp.Key, this.selectedProduct.Logic[kvp.Key].Process(inputs[selectedProduct.EnumOutputs[kvp.Key]], inputs).ToString());
			}

			bool displayDialog = false;
			string walljamb = null;

			// === Print output fields ===
			string outputTitle = null;
			foreach (dynamic control in OutputLayoutPanel.Controls)
			{
				if (control is Label)
				{
					outputTitle = control.Text;
				}
				// Add output to float or enum text fields
				else if (control is TextBox)
				{
					// Check if the output title belongs to the float outputs
					if (floatoutputs.ContainsKey(outputTitle))
					{
						control.Text = floatoutputs[outputTitle].ToString();
					}
					// Check if the output title belongs to the enum outputs
					else if (enumoutputs.ContainsKey(outputTitle))
					{
						control.Text = enumoutputs[outputTitle].ToString();
						displayDialog = control.Text != "ZD1006" && outputTitle == "WallJamb";
						walljamb = control.Text;

					}
					// Check if the output title belongs to the enum outputs
					else if (booloutputs.ContainsKey(outputTitle))
					{
						control.Text = booloutputs[outputTitle].ToString();
					}
				}
				// Output whether or not the resulting dimensions exist in stock inventory list
				else if (control is CheckBox && outputTitle.Equals("Can Use Stock Glass?"))
				{
					bool inStock = false;
					foreach (string stockGlassLineName in GetStockGlassListName(selectedProduct, inputs))
					{
						if (stockGlassLines[stockGlassLineName].Contains(floatoutputs["ResultingWidth"], floatoutputs["ResultingHeight"]))
						{
							inStock = true;
							break;
						}
					}
					control.Checked = inStock;
				}
			}
			if (displayDialog)
				DisplayWalljambAlert(walljamb);

		}

		private void DisplayWalljambAlert(string walljamb)
		{
			Form dialog = new Form
			{
				Height = 350,
				Width = 400,
				StartPosition = FormStartPosition.CenterScreen
			};
			Label label = new Label
			{
				Height = 28,
				Width = 600,
				Location = new System.Drawing.Point(10, 100),
				Font = new System.Drawing.Font("Arial", 16, System.Drawing.FontStyle.Bold),
				Text = "Alert: WallJamb to use is a " + walljamb,
				ForeColor = System.Drawing.Color.Red
			};
			dialog.Controls.Add(label);
			dialog.ShowDialog();
		}

		// Reset the displayed fields
		private void ResetButton_Click(object sender, EventArgs e)
		{
			foreach (dynamic control in InputLayoutPanel.Controls)
			{
				if (control is TextBox)
					control.Text = "";
				else if (control is CheckBox)
					control.Checked = false;
			}
			foreach (dynamic control in OutputLayoutPanel.Controls)
			{
				if (control is TextBox)
					control.Text = "";
				else if (control is CheckBox)
					control.Checked = false;
			}
		}

		// Add a boolean output field, represented by a checkbox
		private void AddBoolOutput(string elementTitle)
		{
			Label title = new Label
			{
				Text = elementTitle,
				AutoSize = true
			};
			CheckBox inputCheckBox = new CheckBox
			{
				Anchor = AnchorStyles.Left | AnchorStyles.Right,
				AutoCheck = false
			};
			OutputLayoutPanel.Controls.Add(title);
			OutputLayoutPanel.Controls.Add(inputCheckBox);
		}

		// Add a float output field, represented by a textbox containing numbers
		private void AddFloatOutput(string elementTitle)
		{
			Label title = new Label
			{
				Text = elementTitle,
				AutoSize = true
			};
			TextBox inputTextBox = new TextBox
			{
				Anchor = AnchorStyles.Left | AnchorStyles.Right,
				ReadOnly = true
			};
			OutputLayoutPanel.Controls.Add(title);
			OutputLayoutPanel.Controls.Add(inputTextBox);
		}

		// Add a enum output field, represented by a textbox with the name of the enum
		private void AddEnumOutput(string elementTitle)
		{
			Label title = new Label
			{
				Text = elementTitle,
				AutoSize = true
			};
			TextBox inputTextBox = new TextBox
			{
				Anchor = AnchorStyles.Left | AnchorStyles.Right,
				ReadOnly = true
			};
			OutputLayoutPanel.Controls.Add(title);
			OutputLayoutPanel.Controls.Add(inputTextBox);
		}

		// Add a boolean input field, represented by a checkbox
		private void AddBoolInput(string elementTitle)
		{
			Label title = new Label
			{
				Text = elementTitle,
				AutoSize = true
			};
			CheckBox inputCheckBox = new CheckBox
			{
				Anchor = AnchorStyles.Left | AnchorStyles.Right
			};
			InputLayoutPanel.Controls.Add(title);
			InputLayoutPanel.Controls.Add(inputCheckBox);
		}

		// Add a float input field, represented by a textbox that the user can input numbers into
		private void AddFloatInput(string elementTitle)
		{
			Label title = new Label
			{
				Text = elementTitle,
				AutoSize = true
			};
			TextBox inputTextBox = new TextBox
			{
				Anchor = AnchorStyles.Left | AnchorStyles.Right
			};
			InputLayoutPanel.Controls.Add(title);
			InputLayoutPanel.Controls.Add(inputTextBox);
		}
        //Add an Enum input field, represented by a ComboBox
        private void AddEnumInput(string elementTitle, int index)
        {
            Label title = new Label
            {
                Text = elementTitle,
                AutoSize = true
            };
            ComboBox inputComboBox = new ComboBox
            {
                DataSource = new { }

            };

            throw new NotImplementedException("Under Development");
        }

        // Generate a the name of the applicable stock glass list
        private List<string> GetStockGlassListName(ProductLine product, Dictionary<string, object> parameters)
		{
			// Filter the stock glass list based on glass category
			List<string> stockGlassLists = stockGlassLines.Where(pair => pair.Key.Contains(product.GlassCategory)).Select(pair => pair.Key).ToList();

			// Filter the stock glass list based on two holes parameter, if present
			if (parameters.ContainsKey("TwoHoles") && (bool)parameters["TwoHoles"])
			{
				stockGlassLists = stockGlassLists.Where(list => list.Contains("TwoHoles")).ToList();
			}
			// Remove elements from the list with holes if not specified
			else
			{
				stockGlassLists = stockGlassLists.Where(list => !list.Contains("TwoHoles")).ToList();
			}

			return stockGlassLists;
		}
	}
}
