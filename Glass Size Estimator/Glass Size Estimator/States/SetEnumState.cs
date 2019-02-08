using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Glass_Size_Estimator
{
	// Implements set logic
	class SetEnumState : State
	{
		// Constructor
		public SetEnumState(int stateNumber, int nextState, string value, string category) : base(stateNumber, nextState)
		{
			this.Value = value;
			this.Category = category;
		}

		// The value that will be used in the set operation
		public string Value { get; set; }

		// The category that the enum value belongs to
		public string Category { get; set; }

		/*
		 * PROCESS DESCRIPTION: Set the current value in the pipeline to the given value.
		 * INPUT: { Current Value (ENUM) }
		 * PARAMETERS: { Value (STRING), Category (STRING) }
		 * OUTPUT: { New Value (ENUM) }
		 */
		public override void Process()
		{
			this.Output = EnumFactory.GetEnum(this.Value, this.Category);
		}
	}
}
