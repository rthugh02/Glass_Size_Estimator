﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Glass_Size_Estimator.States
{
	// Implements branching logic
	class BranchState : State
	{
		// The value that will be used in the set operation
		public int NextStateNumber { get; set; }

		// The logic value that will be required to modify change the next state sequence
		public bool Qualifier { get; set; }

		/*
		 * PROCESS DESCRIPTION: Set the next state in the pipeline to the given value.
		 * INPUT: { None }
		 * PARAMETERS: { Next State Number (INT) }
		 * OUTPUT: { None }
		 */
		public override void Process()
		{
			this.NextState = this.NextStateNumber;
		}
	}
}
