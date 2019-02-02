using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Glass_Size_Estimator.States
{
	class RoundDownState : State
	{
		// The interval the current value will be round up to (i.e. nearest quarter -> .25; nearest eighth -> .125)
		public float Interval { get; set; }

		/*
		 * PROCESS DESCRIPTION: Round up the current value in the pipeline
		 * INPUT: { Current Value (FLOAT) }
		 * PARAMETERS: { Interval (FLOAT) }
		 * OUTPUT: { New Value (FLOAT) }
		 */
		public override void Process()
		{
			// For explanation see "The Ultimate Rounding Function" - http://rajputyh.blogspot.com/2014/09/the-ultimate-rounding-function.html
			this.Output = Math.Floor((float)this.Input / this.Interval + 0.5f) * this.Interval;
		}
	}
}
