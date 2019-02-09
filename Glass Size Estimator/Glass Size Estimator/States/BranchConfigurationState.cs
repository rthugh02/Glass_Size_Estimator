using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Glass_Size_Estimator
{
	class BranchConfigurationState : BranchState
	{
		// Constructor
		public BranchConfigurationState(int stateNumber, int nextState, int nextStateNumber, bool qualifier, string[] configurationList) : base(stateNumber, nextState, nextStateNumber, qualifier)
		{
			foreach (string configuration in configurationList)
			{
				this.ConfigurationList.Add((Configuration)EnumFactory.GetEnum(configuration, "Configuration"));
			}
		}

		// The series that will be checked for
		public List<Configuration> ConfigurationList { get; set; }

		/*
		 * PROCESS DESCRIPTION: Set the next state in the pipeline to the given value.
		 * INPUT: { Current Value (FLOAT) }
		 * PARAMETERS: { Next State Number (INT) }
		 * OUTPUT: { None }
		 */
		public override void Process()
		{
			// Set the input to be the output by default
			this.Output = this.Input;

			// Determine whether or not the current input series is contained in the list of given series
			bool result = ConfigurationList.Contains((Configuration)this.Input);

			// Compare the results to the desired qualifer
			if (result == this.Qualifier)
			{
				// If the result matches the qualifier adjust the next state
				this.NextState = this.NextStateNumber;
			}
		}
	}
}
