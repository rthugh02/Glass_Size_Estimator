using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Glass_Size_Estimator
{
	// Implements truncating logic
	public class TruncateState : State
	{
		/*
		 * PROCESS DESCRIPTION: Truncate the given value.
		 * INPUT: { Current Value (FLOAT) }
		 * PARAMETERS: { None }
		 * OUTPUT: { New Value (FLOAT) }
		 */
		public override void Process()
		{
			this.Output = Math.Truncate((float)this.Input);
		}
	}
}
