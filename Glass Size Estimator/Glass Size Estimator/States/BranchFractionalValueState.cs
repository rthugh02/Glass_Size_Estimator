using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Glass_Size_Estimator
{
	// Implements branching depending on fractional portion of value in pipeline
	public class BranchFractionalValue : BranchValueState
	{
		// Constructor
		public BranchFractionalValue(int stateNumber, int nextState, int nextStateNumber, bool qualifier, float minimum, float maximum) : base(stateNumber, nextState, nextStateNumber, qualifier, minimum, maximum)
		{
			// Do nothing
		}

		/*
		 * PROCESS DESCRIPTION: Set the next state in the pipeline to the given value by analyzing the fractional portion of the input.
		 * INPUT: { Current Value (FLOAT) }
		 * PARAMETERS: { Next State Number (INT), Qualifier (BOOL), Minimum (FLOAT), Maximum (FLOAT) }
		 * OUTPUT: { None }
		 */
		public override void Process()
		{
			// Set the input to be the output by default
			this.Output = this.Input;

			// Determine whether or not the current value is within range
			bool result = (((float)this.Input - Math.Truncate((float)this.Input)) >= this.Minimum) && (((float)this.Input - Math.Truncate((float)this.Input)) <= this.Maximum);

			// Compare the results to the desired qualifer
			if (result == this.Qualifier)
			{
				// If the result matches the qualifier adjust the next state
				this.NextState = this.NextStateNumber;
			}
		}
	}
}
