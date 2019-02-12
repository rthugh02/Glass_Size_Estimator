using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Glass_Size_Estimator
{
    public partial class Main : Form
    {
        private List<ProductLine> productLines;
        public Main(List<ProductLine> ConfigProductLines)
        {
            productLines = ConfigProductLines;
            InitializeComponent();
            foreach (var product in productLines)
            {
                ProductLineSelector.Items.Add(product.Name);
            }
        }

        private void ProductLineSelector_SelectedIndexChanged(object sender, EventArgs e)
        {
            //retrieving productline object based on selectedItem
            if (ProductLineSelector.SelectedItems.Count == 0)
                return;
            string selectedItem = ProductLineSelector.SelectedItems[0].Text;
            ProductLine productLine = productLines.Where(n => n.Name.Equals(selectedItem)).First();

            //TODO: loop through inputs and examine their type, add corresponding element to input layout
            //TODO: Do the same for outputs

            foreach (var property in productLine.GetType().GetProperties()) //Getting the properties of the ProductLine type to Loop through
            {
                var value = property.GetValue(productLine); //Getting the value of the given property from the actual ProductLine object

                if ((value is List<string> || value is List<Dictionary<string, List<string>>>) && ((List<string>)Convert.ChangeType(value, typeof(List<string>))).Count > 0) //If the value of the property is a List<string> and has a count > 0:
                {
                    List<string> elementsToAdd = ((List<string>)Convert.ChangeType(value, typeof(List<string>)));

                    if (property.Name.Equals("FloatInputs", StringComparison.OrdinalIgnoreCase))
                    {
                        foreach (string elementTitle in elementsToAdd)
                        {
                            Label title = new Label();
                            title.Text = elementTitle + ":";
                            title.Anchor = AnchorStyles.Bottom;
                            TextBox inputTextBox = new TextBox();
                            inputTextBox.Anchor = AnchorStyles.Bottom;
                            InputLayoutPanel.Controls.Add(title);
                            InputLayoutPanel.Controls.Add(inputTextBox);
                        }
                    }
                    else if (property.Name.Equals("BoolInputs", StringComparison.OrdinalIgnoreCase))
                    {
                        foreach(string elementTitle in elementsToAdd)
                        {
                            Label title = new Label();
                            title.Text = elementTitle + ":";
                            title.Anchor = AnchorStyles.Bottom;
                            CheckBox inputCheckBox = new CheckBox();
                            inputCheckBox.Anchor = AnchorStyles.Bottom;
                            InputLayoutPanel.Controls.Add(title);
                            InputLayoutPanel.Controls.Add(inputCheckBox);
                        }
                    }
                    else if(property.Name.Equals("EnumInputs", StringComparison.OrdinalIgnoreCase))
                    {
                        foreach (string elementTitle in elementsToAdd)
                        {
                            Label title = new Label();
                            title.Text = elementTitle + ":";
                            title.Anchor = AnchorStyles.Bottom;

                            //TODO: figure out how to build a drop down for each of the Enums, ListBox maybe? Or some other Control
                            //ListBox inputListBox = new ListBox();
                            //InputLabel.Anchor = AnchorStyles.Bottom;
                            //InputLayoutPanel.Controls.Add(title);
                            //InputLayoutPanel.Controls.Add(inputListBox);
                        }
                    }
                }
            }
        }
    }
}
