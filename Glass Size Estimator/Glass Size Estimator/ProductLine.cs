using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Glass_Size_Estimator
{
	// This class represents a product line in the application
	public class ProductLine
	{
		// Product Line constructor
		// This function is provided a json object corresponding to one product line, which is then parsed by the following code
		public ProductLine(dynamic JSONProductLine)
		{
			// Set the name of the product line
			this.Name = (string)JSONProductLine.Name;

			// Initialize all of the lists and dictionaries required by the product line
			Logic = new Dictionary<string, StateMachine>();
			FloatInputs = new List<string>();
			EnumInputs = new Dictionary<string, List<string>>();
			BoolInputs = new List<string>();
			IntInputs = new List<string>();
			FloatOutputs = new Dictionary<string, string>();
			EnumOutputs = new Dictionary<string, string>();
			BoolOutputs = new Dictionary<string, string>();
			// CoordOutputs = new Dictionary<string, string>(); NOT IMPLEMENTED

			// Retrieve each possible input field
			foreach (var input in JSONProductLine.Input)
			{
                // Add float inputs
                if (((string)(input.Type)).Equals("Float", StringComparison.OrdinalIgnoreCase))
                    FloatInputs.Add(((string)(input.Name)));

                // Add boolean inputs
                else if (((string)(input.Type)).Equals("Boolean", StringComparison.OrdinalIgnoreCase))
                    BoolInputs.Add(((string)(input.Name)));

                // TODO: Add enum inputs
                else if (((string)(input.Type)).Equals("Enum", StringComparison.OrdinalIgnoreCase))
                    EnumInputs.Add((string)input.Name, input.Options.ToObject(typeof(List<string>)));
                //EnumInputs.Add(((string)(input.Name)));

                // Add integer inputs
                else if (((string)(input.Type)).Equals("Integer", StringComparison.OrdinalIgnoreCase))
                    IntInputs.Add(((string)(input.Name)));
			}

			// Retrieve each possible output field and its corresponding input field and type
			foreach (var output in JSONProductLine.Output)
			{
				// Add float outputs
				if (((string)(output.Type)).Equals("Float", StringComparison.OrdinalIgnoreCase))
					FloatOutputs.Add((string)output.Name, (string)output.Input);

				// Add boolean outputs
				else if (((string)(output.Type)).Equals("Boolean", StringComparison.OrdinalIgnoreCase))
					BoolOutputs.Add((string)output.Name, (string)output.Input);

				// Add enum outputs
				else if (((string)(output.Type)).Equals("Enum", StringComparison.OrdinalIgnoreCase))
					EnumOutputs.Add((string)output.Name, (string)output.Input);

				// Add integer outputs
				else if (((string)(output.Type)).Equals("Integer", StringComparison.OrdinalIgnoreCase))
					IntOutputs.Add((string)output.Name, (string)output.Input);

			}

			// Look at each logic tree for each output in the product line
			foreach (var logic in JSONProductLine.Logic)
			{
				// Create a new logic sequence
				List<State> states = new List<State>();

				// Look at each state in the logic tree
				for (int i = 0; i < logic.First.Count; i++)
				{
					var state = logic.First[i];
					State newState;

					// NOTE: By default, the next state is automatically the next state

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
					else if ("BranchEnum".Equals((string)state.Operation, StringComparison.OrdinalIgnoreCase))
					{
						newState = new BranchEnumState(i, i + 1, (int)state.NextState, (bool)state.Qualifier, (string)state.EnumCategory, (string[])state.EnumList);
					}
					else if ("BranchInputValue".Equals((string)state.Operation, StringComparison.OrdinalIgnoreCase))
					{
						newState = new BranchInputValueState(i, i + 1, (int)state.NextState, (bool)state.Qualifier, (float)state.Minimum, (float)state.Maximum, (string)state.InputName);
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
					states.Add(newState);
				}

				// Once the logic sequence is built add the logic to the product line
				Logic.Add((string)logic.Name, new StateMachine(states));
			}

			// Retrieve the stock glass category the product line belongs to
			GlassCategory = (string)JSONProductLine.Category;
		}

		// The name of the product line
		public string Name { get; set; }

		// Lists of inputs needed by the product line
		public List<string> FloatInputs { get; set; } // float inputs
		public List<string> BoolInputs { get; set; } // boolean inputs
		public List<string> IntInputs { get; set; } // integer inputs
		public Dictionary<string, List<string>> EnumInputs { get; set; } /*Each enum entry will have a name (key) and a list of choosable options (value) 
        therefore all enum inputs will be a list of dictionaries, 
        with each dictionary containing the name of the enum input and a list of the options to select */

		// Dictionary of outputs needed by the product line
		// NOTE: string -> name of output | string -> name of input that will be modified by the application and returned
		public Dictionary<string, string> FloatOutputs { get; set; } //As above, so below
		public Dictionary<string, string> BoolOutputs { get; set; }
		public Dictionary<string, string> IntOutputs { get; set; }
		public Dictionary<string, string> EnumOutputs { get; set; }
		// public Dictionary<string, string> CoordOutputs { get; set; } NOT IMPLEMENTED

		// The category of stock glass lines to look at
		public String GlassCategory;

		// A collection of state machines that will be used for the product line output calculations
		public Dictionary<string, StateMachine> Logic { get; set; }
	}
}
