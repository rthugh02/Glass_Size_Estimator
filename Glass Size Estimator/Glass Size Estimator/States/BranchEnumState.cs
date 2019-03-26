using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Glass_Size_Estimator
{
	// Implements branching depending on configuration
	public class BranchEnumState : BranchState
	{
		// Constructor
		public BranchEnumState(int stateNumber, int nextState, int nextStateNumber, bool qualifier, string enumCategory, string[] enumList) : base(stateNumber, nextState, nextStateNumber, qualifier)
		{
			this.EnumCategory = enumCategory;
			this.EnumList = new List<Object>();
			foreach (string enumString in enumList)
			{
				this.EnumList.Add(EnumFactory.GetEnum(enumString, enumCategory));
			}
		}

		// The category of enum used
		public string EnumCategory { get; set; }

		// The series that will be checked for
		public List<Object> EnumList { get; set; }

		/*
		 * PROCESS DESCRIPTION: Set the next state in the pipeline to the given value.
		 * INPUT: { None }
		 * PARAMETERS: { Next State Number (INT), Qualifier (BOOL), Enum Category (STRING), Enum List (STRING[]) }
		 * OUTPUT: { None }
		 */
		public override void Process()
		{
			// Set the input to be the output by default
			this.Output = this.Input;

			// Determine whether or not the current input configuration is contained in the list of given series
			bool result = false;
			if (EnumCategory.Equals("Configuration", StringComparison.OrdinalIgnoreCase))
			{
				result = EnumList.Contains((Configuration)this.Parameters["Configuration"]);
			}
			else if (EnumCategory.Equals("GlassType", StringComparison.OrdinalIgnoreCase))
			{
				result = EnumList.Contains((GlassType)this.Parameters["GlassType"]);
			}
			else if (EnumCategory.Equals("Series", StringComparison.OrdinalIgnoreCase))
			{
				result = EnumList.Contains((Series)this.Parameters["Series"]);
			}
			else if (EnumCategory.Equals("WallJamb", StringComparison.OrdinalIgnoreCase))
			{
				result = EnumList.Contains((WallJamb)this.Parameters["WallJamb"]);
			}

			// Compare the results to the desired qualifer
			if (result == this.Qualifier)
			{
				// If the result matches the qualifier adjust the next state
				this.NextState = this.NextStateNumber;
			}
		}
	}
}
