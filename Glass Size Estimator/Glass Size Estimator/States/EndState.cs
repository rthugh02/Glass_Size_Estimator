using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Glass_Size_Estimator
{
	// Implement end state
	public class EndState : State
	{
		// Constructor
		public EndState(int stateNumber, int nextState) : base(stateNumber, nextState)
		{
			// Do Nothing
		}

		/*
		 * PROCESS DESCRIPTION: Signal the end of the logic
		 * INPUT: { None }
		 * PARAMETERS: { None }
		 * OUTPUT: { None }
		 */
		public override void Process()
		{
			// Set the input to be the output by default
			this.Output = this.Input;
		}
	}
}
