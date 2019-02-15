using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Glass_Size_Estimator
{
    public class BranchConditionalState : BranchState
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
		 * INPUT: { Current Value (BOOL) }
		 * PARAMETERS: { Next State Number (INT) }
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
