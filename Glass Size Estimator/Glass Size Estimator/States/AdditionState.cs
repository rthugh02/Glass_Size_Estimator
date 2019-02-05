using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Glass_Size_Estimator
{
	// Implements addition logic
	public class AdditionState : ArithmeticState
	{
		// Constructor
		public AdditionState(int stateNumber, int nextState, float value) : base(stateNumber, nextState, value)
		{
			// Do nothing
		}

		/*
		 * PROCESS DESCRIPTION: Add the given value to the current value in the pipeline.
		 * INPUT: { Current Value (FLOAT) }
		 * PARAMETERS: { Value (FLOAT) }
		 * OUTPUT: { New Value (FLOAT) }
		 */
		public override void Process()
		{
			this.Output = (float)this.Input + this.Value;
		}
	}
}
