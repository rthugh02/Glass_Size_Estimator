﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Glass_Size_Estimator
{
	class BranchSeriesState : BranchState
	{
		// Constructor
		public BranchSeriesState(int stateNumber, int nextState, int nextStateNumber, bool qualifier, string[] seriesList) : base(stateNumber, nextState, nextStateNumber, qualifier)
		{
			foreach (string series in seriesList)
			{
				this.SeriesList.Add((Series)EnumFactory.GetEnum(series, "Series"));
			}
		}

		// The series that will be checked for
		public List<Series> SeriesList { get; set; }

		/*
		 * PROCESS DESCRIPTION: Set the next state in the pipeline to the given value.
		 * INPUT: { Current Value (FLOAT) }
		 * PARAMETERS: { Next State Number (INT) }
		 * OUTPUT: { None }
		 */
		public override void Process()
		{
			// Determine whether or not the current input series is contained in the list of given series
			bool result = SeriesList.Contains((Series)this.Input);

			// Compare the results to the desired qualifer
			if (result == this.Qualifier)
			{
				// If the result matches the qualifier adjust the next state
				this.NextState = this.NextStateNumber;
			}
		}
	}
}
