using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Glass_Size_Estimator
{
    // Implements set logic
    public class SetConditionalState : State
    {
        // Constructor
        public SetConditionalState(int stateNumber, int nextState, bool value) : base(stateNumber, nextState)
        {
            this.Value = value;
        }

        // The value that will be used in the set operation
        public bool Value { get; set; }

        /*
		 * PROCESS DESCRIPTION: Set the current value in the pipeline to the given value.
		 * INPUT: { Current Value (BOOL) }
		 * PARAMETERS: { Value (BOOL) }
		 * OUTPUT: { New Value (BOOL) }
		 */
        public override void Process()
        {
            this.Output = this.Value;
        }
    }
}
