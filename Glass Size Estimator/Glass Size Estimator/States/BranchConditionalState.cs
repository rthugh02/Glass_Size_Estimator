using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Glass_Size_Estimator
{
	class BranchConditionalState : BranchState
	{
		// Constructor
		public BranchConditionalState(int stateNumber, int nextState, int nextStateNumber, bool qualifier, string conditionalName) : base(stateNumber, nextState, nextStateNumber, qualifier)
		{
			this.ConditionalName = conditionalName;
		}

		// The minimum value that is required
		public string ConditionalName { get; set; }

		/*
		 * PROCESS DESCRIPTION: Set the next state in the pipeline to the given value.
		 * INPUT: { Current Value (FLOAT) }
		 * PARAMETERS: { Next State Number (INT) }
		 * OUTPUT: { None }
		 */
		public override void Process()
		{
			// Find the requested boolean in the dictionary
			if (Booleans.ContainsKey(this.ConditionalName))
			{
				bool result = Booleans[this.ConditionalName];

				// Compare the results to the desired qualifer
				if (result == this.Qualifier)
				{
					// If the result matches the qualifier adjust the next state
					this.NextState = this.NextStateNumber;
				}
			}
			// TODO: How to deal with the specified conditional is not present
			else
			{
				throw new Exception();
			}
		}
	}
}
