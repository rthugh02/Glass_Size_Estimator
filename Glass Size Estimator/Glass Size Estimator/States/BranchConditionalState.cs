using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Glass_Size_Estimator
{
	// Implements branching depending on boolean conditional
	public class BranchConditionalState : BranchState
	{
		// Constructor
		public BranchConditionalState(int stateNumber, int nextState, int nextStateNumber, bool qualifier, string conditionalName) : base(stateNumber, nextState, nextStateNumber, qualifier)
		{
			this.ConditionalName = conditionalName;
		}

		// The name of the conditional to be look at in the parameters
		public string ConditionalName { get; set; }

		/*
		 * PROCESS DESCRIPTION: Set the next state in the pipeline to the given value after looking at a conditional value
		 * INPUT: { Current Value (BOOL) }
		 * PARAMETERS: { Next State Number (INT), Qualifier (BOOL), Conditional Name (STRING) }
		 * OUTPUT: { None }
		 */
		public override void Process()
		{
			// Set the input to be the output by default
			this.Output = this.Input;

			// Find the requested boolean in the dictionary
			if (Parameters.ContainsKey(this.ConditionalName))
			{
				bool result = (bool)Parameters[this.ConditionalName];

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
