using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace Glass_Size_Estimator
{
	public class StateMachine
	{
		public StateMachine(List<State> states)
		{
			this.States = new List<State>();
			this.States = states;
		}

		public List<State> States { get; set; } // The list of states that belong to this state machine

		private int currentState = 0; // The index of the current state to be processed
		private int lastState = 0; // The index of the last state processed

		// Process the given input through the state machine and return the final resulting object
		public Object Process(Object input, Dictionary<string, bool> booleans)
		{
			// Reset the state machine to the first state
			currentState = 0;
			lastState = -1;

			do
			{
				// Move the input and booleans into the current state;
				if (lastState == -1)
				{
					States[currentState].Input = input;
					States[currentState].Booleans = booleans;
				}
				else
				{
					// Debug.WriteLine("Moving output to input: " + States[lastState].Output);
					States[currentState].Input = States[lastState].Output;
					States[currentState].Booleans = States[lastState].Booleans;
				}

				// Process the current state
				States[currentState].Process();

				// Set the next state
				lastState = currentState;
				// Debug.WriteLine("Last State is " + lastState);
				// Debug.WriteLine("Next State is " + States[currentState].NextState);
				currentState = States[currentState].NextState;

			} while (States[currentState].GetType() != typeof(EndState)); // Stop the loop when the end state is encountered

			// Return the value of the output in the state BEFORE the end state
			return States[lastState].Output;
		}
	}
}
