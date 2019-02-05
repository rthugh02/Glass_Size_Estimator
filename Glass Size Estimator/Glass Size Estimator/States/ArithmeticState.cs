using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Glass_Size_Estimator
{
	// An abstract class for every arithmetic operation (+,-,/,*)
	public abstract class ArithmeticState : State
	{
		// Constructor
		public ArithmeticState(int stateNumber, int nextState, float value) : base(stateNumber, nextState)
		{
			this.Value = value;
		}

		// The value that will be used in the arithmetic operation
		public float Value { get; set; }
	}
}
