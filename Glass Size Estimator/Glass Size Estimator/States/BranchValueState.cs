using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Glass_Size_Estimator.States
{
	class BranchValueState : BranchState
	{
		// The minimum value that is required
		public float Minimum { get; set; }

		// The maximum value that is required
		public float Maximum { get; set; }

		/*
		 * PROCESS DESCRIPTION: Set the next state in the pipeline to the given value.
		 * INPUT: { Current Value (FLOAT) }
		 * PARAMETERS: { Next State Number (INT) }
		 * OUTPUT: { None }
		 */
		public override void Process()
		{
			// Determine whether or not the current value is within range
			bool result = (float)this.Input >= this.Minimum && (float)this.Input <= this.Maximum;

			// Compare the results to the desired qualifer
			if (result == this.Qualifier)
			{
				// If the result matches the qualifier adjust the next state
				this.NextState = this.NextStateNumber;
			}
		}
	}
}
