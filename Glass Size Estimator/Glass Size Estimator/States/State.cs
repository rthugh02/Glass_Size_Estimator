using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Glass_Size_Estimator
{
	// An abstract class for every possible state in a product line's logic
	public abstract class State
	{
		// Constructor
		public State(int stateNumber, int nextState)
		{
			this.StateNumber = stateNumber;
			this.NextState = nextState;
		}

		// These variables will be used to pass and send information between the states
		public Object Input { get; set; } // The input that will received by the state
		public Dictionary<string, bool> Booleans; // The list of conditionals that will be received by the state
		public Object Output { get; set; } // The output that will be sent to the next state

		public int StateNumber { get; set; } // The current step number of the state
		public int NextState { get; set; } // The next step to go to after processing

		public abstract void Process(); // Process the logic for the current state;
	}
}
