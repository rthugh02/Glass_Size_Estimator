using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Glass_Size_Estimator
{
	public class ProductLine
	{
		// Constructor
		public ProductLine(dynamic JSONProductLine)
		{
			this.Name = (string)JSONProductLine.Name;
			Logic = new Dictionary<string, StateMachine>();
			FloatInputs = new List<string>();
			EnumInputs = new List<Dictionary<string, List<string>>>();
			BoolInputs = new List<string>();
			IntInputs = new List<string>();
			FloatOutputs = new Dictionary<string, string>();
			EnumOutputs = new Dictionary<string, string>();
			BoolOutputs = new Dictionary<string, string>();
			CoordOutputs = new Dictionary<string, string>();

			// Retrieve each possible input field
			foreach (string input in JSONProductLine.Input)
			{
				if (input.Equals("OpeningWidth", StringComparison.OrdinalIgnoreCase) || input.Equals("OpeningHeight", StringComparison.OrdinalIgnoreCase))
					FloatInputs.Add(input);

				else if (input.Equals("ClearSweep", StringComparison.OrdinalIgnoreCase))
					BoolInputs.Add(input);

				else if (input.Equals("TwoHoles", StringComparison.OrdinalIgnoreCase))
					BoolInputs.Add(input);
			}

			// Retrieve each possible output field and its corresponding input field and type
			foreach (var output in JSONProductLine.Output)
			{
				if (((string)(output.Name)).Equals("ResultingWidth", StringComparison.OrdinalIgnoreCase) || ((string)(output.Name)).Equals("ResultingHeight", StringComparison.OrdinalIgnoreCase))
					FloatOutputs.Add((string)output.Name, (string)output.Input);

				else if (((string)(output.Name)).Equals("WallJamb", StringComparison.OrdinalIgnoreCase))
					EnumOutputs.Add((string)output.Name, (string)output.Input);

			}

			// Look at each logic tree for each possible output
			foreach (var logic in JSONProductLine.Logic)
			{
				// Create a new logic sequence
				List<State> states = new List<State>();

				// Look at each state in the logic tree
				for (int i = 0; i < logic.First.Count; i++)
				{
					var state = logic.First[i];
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
					states.Add(newState);
				}

				// Once the logic sequence is built add the logic to the product line
				Logic.Add((string)logic.Name, new StateMachine(states));
			}

			// Retrieve the stock glass category the product line belongs to
			GlassCategory = (string)JSONProductLine.Category;
		}

		public string Name { get; set; } // The name of the product line
		public List<string> FloatInputs { get; set; } //List of names of float input values

		public List<Dictionary<string, List<string>>> EnumInputs { get; set; } /*Each enum entry will have a name (key) and a list of choosable options (value) 
        therefore all enum inputs will be a list of dictionaries, 
        with each dictionary containing the name of the enum input and a list of the options to select */

		// Lists of inputs needed
		public List<string> BoolInputs { get; set; } // boolean inputs
		public List<string> IntInputs { get; set; } // integer inputs

		// Dictionary of outputs needed (string -> name of output | string -> name of input utilized)
		public Dictionary<string, string> FloatOutputs { get; set; } //As above, so below
		public Dictionary<string, string> BoolOutputs { get; set; }
		public Dictionary<string, string> EnumOutputs { get; set; }
		public Dictionary<string, string> CoordOutputs { get; set; }

		// The category of stock glass lines to look at
		public String GlassCategory;

		// A collection of state machines that will be used for the product line output calculations
		public Dictionary<string, StateMachine> Logic { get; set; }
	}
}
