using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.Diagnostics;

namespace Glass_Size_Estimator
{
	static class Program
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);

			//Code Ran before window is brought to screen, this is where available JSON configs should be loaded

			string fextension = ".json";
			var myFiles = Directory.GetFiles(Directory.GetCurrentDirectory(), "*.*", SearchOption.AllDirectories)
			.Where(s => fextension.Contains(Path.GetExtension(s)));
			List<ProductLine> productList = new List<ProductLine>();

			foreach (var file in myFiles)
			{
				using (var stream = new StreamReader(file))//put a test file in your bin/Debug/ folder to see this in action
				{
					string json_data = stream.ReadToEnd();
					dynamic productListJson = JsonConvert.DeserializeObject<Object>(json_data); //A dynamic object has dynamic runtime properties that can be referenced even though the compiler doesn't know what they are

					foreach (var productLine in productListJson.ProductLines) // Look at each product line in the config
					{
						// Create a new product line
						ProductLine product = new ProductLine(productLine);

						foreach (var outputLogic in productLine.Logic) // Look at each logic tree for each possible output
						{
							// Create a new logic sequence
							List<State> logic = new List<State>();

							// Look at each state in the logic tree
							for (int i = 0; i < outputLogic.First.Count; i++)
							{
								var state = outputLogic.First[i];
								State newState;

								// (NOTE: By default, the next state is automatically the next state)
								// Constructors for arithmetic states 
								if ("Addition".Equals((string)state.Operation, StringComparison.OrdinalIgnoreCase))
								{
									newState = new AdditionState(i, i + 1, (float)state.Value);
								}
								else if ("Subtraction".Equals((string)state.Operation, StringComparison.OrdinalIgnoreCase))
								{
									newState = new SubtractionState(i, i + 1, (float)state.Value);
								}
								else if ("Multiplication".Equals((string)state.Operation, StringComparison.OrdinalIgnoreCase))
								{
									newState = new MultiplicationState(i, i + 1, (float)state.Value);
								}
								else if ("Division".Equals((string)state.Operation, StringComparison.OrdinalIgnoreCase))
								{
									newState = new DivisionState(i, i + 1, (float)state.Value);
								}
								// Constructors for rounding states
								else if ("RoundDown".Equals((string)state.Operation, StringComparison.OrdinalIgnoreCase))
								{
									newState = new RoundDownState(i, i + 1, (float)state.Interval);
								}
								else if ("RoundUp".Equals((string)state.Operation, StringComparison.OrdinalIgnoreCase))
								{
									newState = new RoundUpState(i, i + 1, (float)state.Interval);
								}
								// Constructors for branching states
								else if ("Branch".Equals((string)state.Operation, StringComparison.OrdinalIgnoreCase))
								{
									newState = new BranchState(i, i + 1, (int)state.NextState, true);
								}
								else if ("BranchConditional".Equals((string)state.Operation, StringComparison.OrdinalIgnoreCase))
								{
									newState = new BranchConditionalState(i, i + 1, (int)state.NextState, (bool)state.Qualifier, (string)state.ConditionalName);
								}
								else if ("BranchValue".Equals((string)state.Operation, StringComparison.OrdinalIgnoreCase))
								{
									newState = new BranchValueState(i, i + 1, (int)state.NextState, (bool)state.Qualifier, (float)state.Minimum, (float)state.Maximum);
								}
								else if ("BranchFractionalValue".Equals((string)state.Operation, StringComparison.OrdinalIgnoreCase))
								{
									newState = new BranchFractionalValue(i, i + 1, (int)state.NextState, (bool)state.Qualifier, (float)state.Minimum, (float)state.Maximum);
								}
								else if ("BranchSeries".Equals((string)state.Operation, StringComparison.OrdinalIgnoreCase))
								{
									newState = new BranchSeriesState(i, i + 1, (int)state.NextState, (bool)state.Qualifier, (string[])state.Series);
								}
								else if ("BranchConfiguration".Equals((string)state.Operation, StringComparison.OrdinalIgnoreCase))
								{
									newState = new BranchConfigurationState(i, i + 1, (int)state.NextState, (bool)state.Qualifier, (string[])state.Configurations);
								}
								// Constructor for set states
								else if ("SetValue".Equals((string)state.Operation, StringComparison.OrdinalIgnoreCase))
								{
									newState = new SetValueState(i, i + 1, (float)state.Value);
								}
								else if ("SetConditional".Equals((string)state.Operation, StringComparison.OrdinalIgnoreCase))
								{
									newState = new SetConditionalState(i, i + 1, (bool)state.Value);
								}
								else if ("SetEnum".Equals((string)state.Operation, StringComparison.OrdinalIgnoreCase))
								{
									newState = new SetEnumState(i, i + 1, (string)state.Value, (string)state.Category);
								}
								// Constructor for truncate state
								else if ("Truncate".Equals((string)state.Operation, StringComparison.OrdinalIgnoreCase))
								{
									newState = new TruncateState(i, i + 1);
								}
								// Constructor for end state
								else if ("End".Equals((string)state.Operation, StringComparison.OrdinalIgnoreCase))
								{
									newState = new EndState(i, i + 1);
								}
								// If 'Operation' does not match any existing state replace it with an end state
								else
								{
									newState = new EndState(i, i + 1);
								}

								// Once a new state is added append it onto the logic sequence
								logic.Add(newState);
							}

							// Once the logic sequence is built add the logic to the product line
							product.Logic.Add((string)outputLogic.Name, new StateMachine(logic));
						}

						// Once all of the logic has been parsed add the product to the product list
						productList.Add(product);
					}
				}
			}

			// Testing First Product Line Here (TODO: Move to a testing class later)
			Dictionary<string, bool> booleans = new Dictionary<string, bool>();
			booleans.Add("ClearSweep", false);
			Debug.WriteLine("Resulting Width " + (float)(productList[0].Logic["ResultingWidth"].Process(28.75f, booleans)));
			Debug.WriteLine("Resulting Height " + (float)(productList[0].Logic["ResultingHeight"].Process(66.625f, booleans)));
			Debug.WriteLine("Wall Jamb " + (productList[0].Logic["WallJamb"].Process(28.75f, booleans)).ToString());

			Application.Run(new Main(productList));
		}
	}
}
