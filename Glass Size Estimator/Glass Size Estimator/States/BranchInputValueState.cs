using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Glass_Size_Estimator
{
	// Implements branching depending on given input's value
	public class BranchInputValueState : BranchState
	{
		// Constructor
		public BranchInputValueState(int stateNumber, int nextState, int nextStateNumber, bool qualifier, float minimum, float maximum, string inputName) : base(stateNumber, nextState, nextStateNumber, qualifier)
		{
			this.InputName = inputName;
			this.Minimum = minimum;
			this.Maximum = maximum;
		}

		// The name of the conditional to be look at in the parameters
		public string InputName { get; set; }

		// The minimum value that is required
		public float Minimum { get; set; }

		// The maximum value that is required
		public float Maximum { get; set; }

		/*
		 * PROCESS DESCRIPTION: Set the next state in the pipeline to the given value.
		 * INPUT: { None }
		 * PARAMETERS: { Next State Number (INT), Qualifier (BOOL), Minimum (FLOAT), Maximum (FLOAT), Input Name (STRING) }
		 * OUTPUT: { None }
		 */
		public override void Process()
		{
			// Set the input to be the output by default
			this.Output = this.Input;

			// Find the requested input value in the dictionary
			if (Parameters.ContainsKey(this.InputName))
			{
				// Determine whether or not the current input value is within range
				bool result = (float)Parameters[this.InputName] >= this.Minimum && (float)Parameters[this.InputName] <= this.Maximum;

				// Compare the results to the desired qualifer
				if (result == this.Qualifier)
				{
					// If the result matches the qualifier adjust the next state
					this.NextState = this.NextStateNumber;
				}
			}
			// TODO: How to deal with the specified input value is not present
			else
			{
                throw new KeyNotFoundException();
			}
		}
	}
}
