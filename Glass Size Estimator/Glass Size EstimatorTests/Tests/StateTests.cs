using Microsoft.VisualStudio.TestTools.UnitTesting;
using Glass_Size_Estimator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Glass_Size_Estimator.Tests
{
	// Tests for each individual state in the program
	[TestClass()]
	public class StateTests
	{
		[TestMethod()]
		public void SetValueTest()
		{
			List<State> states = new List<State>
			{
				new SetValueState(0, 1, 10.0f),
				new EndState(1, 2)
			};
			StateMachine stateMachine = new StateMachine(states);
			Assert.AreEqual(10.0f, stateMachine.Process(1.0f, null));
		}

		[TestMethod()]
		public void SetEnumTest()
		{
			List<State> states = new List<State>
			{
				new SetEnumState(0, 1, "ZD1028", "WallJamb"),
				new EndState(1, 2)
			};
			StateMachine stateMachine = new StateMachine(states);
			Assert.AreEqual(WallJamb.ZD1028, stateMachine.Process(null, null));
		}

		[TestMethod()]
		public void SetConditionalTest()
		{
			List<State> states = new List<State>
			{
				new SetConditionalState(0, 1, false),
				new EndState(1, 2)
			};
			StateMachine stateMachine = new StateMachine(states);
			Assert.AreEqual(false, stateMachine.Process(true, null));
		}

		[TestMethod()]
		public void AdditionStateTest()
		{
			List<State> states = new List<State>
			{
				new AdditionState(0, 1, 5.0f),
				new EndState(1, 2)
			};
			StateMachine stateMachine = new StateMachine(states);
			Assert.AreEqual(10.0f, stateMachine.Process(5.0f, null));
		}

		[TestMethod()]
		public void SubtractionStateTest()
		{
			List<State> states = new List<State>
			{
				new SubtractionState(0, 1, 5.0f),
				new EndState(1, 2)
			};
			StateMachine stateMachine = new StateMachine(states);
			Assert.AreEqual(10.75f, stateMachine.Process(15.75f, null));
		}

		[TestMethod()]
		public void MultiplicationStateTest()
		{
			List<State> states = new List<State>
			{
				new MultiplicationState(0, 1, 5.0f),
				new EndState(1, 2)
			};
			StateMachine stateMachine = new StateMachine(states);
			Assert.AreEqual(12.50f, stateMachine.Process(2.50f, null));
		}

		[TestMethod()]
		public void DivisionStateTest()
		{
			List<State> states = new List<State>
			{
				new DivisionState(0, 1, 5.0f),
				new EndState(1, 2)
			};
			StateMachine stateMachine = new StateMachine(states);
			Assert.AreEqual(1.0f, stateMachine.Process(5.0f, null));
		}

		[TestMethod()]
		public void RoundUpStateTest()
		{
			// Round Half
			List<State> states = new List<State>
			{
				new RoundUpState(0, 1, 0.5f),
				new EndState(1, 2)
			};
			StateMachine stateMachine = new StateMachine(states);
			Assert.AreEqual(2.50f, stateMachine.Process(2.40f, null));

			// Round Quarter
			states = new List<State>
			{
				new RoundUpState(0, 1, 0.25f),
				new EndState(1, 2)
			};
			stateMachine = new StateMachine(states);
			Assert.AreEqual(2.75f, stateMachine.Process(2.53f, null));

			// Round Eighth
			states = new List<State>
			{
				new RoundUpState(0, 1, 0.125f),
				new EndState(1, 2)
			};
			stateMachine = new StateMachine(states);
			Assert.AreEqual(2.625f, stateMachine.Process(2.53f, null));
		}

		[TestMethod()]
		public void RoundDownStateTest()
		{
			// Round Half
			List<State> states = new List<State>
			{
				new RoundDownState(0, 1, 0.5f),
				new EndState(1, 2)
			};
			StateMachine stateMachine = new StateMachine(states);
			Assert.AreEqual(2.00f, stateMachine.Process(2.40f, null));

			// Round Quarter
			states = new List<State>
			{
				new RoundDownState(0, 1, 0.25f),
				new EndState(1, 2)
			};
			stateMachine = new StateMachine(states);
			Assert.AreEqual(2.50f, stateMachine.Process(2.53f, null));

			// Round Eighth
			states = new List<State>
			{
				new RoundDownState(0, 1, 0.125f),
				new EndState(1, 2)
			};
			stateMachine = new StateMachine(states);
			Assert.AreEqual(2.625f, stateMachine.Process(2.63f, null));
		}

		[TestMethod()]
		public void BranchStateTest()
		{
			List<State> states = new List<State>
			{
				new BranchState(0, 1, 2, true),
				new SetValueState(1, 2, 5.0f),
				new EndState(2, 3)
			};
			StateMachine stateMachine = new StateMachine(states);
			Assert.AreEqual(2.0f, stateMachine.Process(2.0f, null));
		}

		[TestMethod()]
		public void BranchConditionalStateTest()
		{
			List<State> states = new List<State>
			{
				new BranchConditionalState(0, 1, 2, true, "Branch"),
				new SetValueState(1, 2, 5.0f),
				new EndState(2, 3)
			};
			StateMachine stateMachine = new StateMachine(states);
			Dictionary<string, object> parameters = new Dictionary<string, object>
			{
				{ "Branch", true }
			};
			Assert.AreEqual(2.0f, stateMachine.Process(2.0f, parameters));
		}

		[TestMethod()]
		public void BranchSeriesStateTest()
		{
			List<State> states = new List<State>
			{
				new BranchEnumState(0, 1, 2, true, "Series",new string[] { "ASE" }),
				new SetValueState(1, 2, 5.0f),
				new EndState(2, 3)
			};
			StateMachine stateMachine = new StateMachine(states);
			Dictionary<string, object> parameters = new Dictionary<string, object>
			{
				{ "Series", Series.ASE }
			};
			Assert.AreEqual(2.0f, stateMachine.Process(2.0f, parameters));
		}

		[TestMethod()]
		public void BranchConfigurationStateTest()
		{
			List<State> states = new List<State>
			{
				new BranchEnumState(0, 1, 2, true, "Configuration", new string[] { "NEO_PANEL" }),
				new SetValueState(1, 2, 5.0f),
				new EndState(2, 3)
			};
			StateMachine stateMachine = new StateMachine(states);
			Dictionary<string, object> parameters = new Dictionary<string, object>
			{
				{ "Configuration", Configuration.NEO_PANEL }
			};
			Assert.AreEqual(2.0f, stateMachine.Process(2.0f, parameters));
		}

		[TestMethod()]
		public void BranchValueStateTest()
		{
			List<State> states = new List<State>
			{
				new BranchValueState(0, 1, 2, true, 10.0f, 15.0f),
				new SetValueState(1, 2, 5.0f),
				new EndState(2, 3)
			};
			StateMachine stateMachine = new StateMachine(states);
			Assert.AreEqual(12.0f, stateMachine.Process(12.0f, null));
		}

		[TestMethod()]
		public void BranchFractionalValueStateTest()
		{
			List<State> states = new List<State>
			{
				new BranchFractionalValue(0, 1, 2, true, 0.75f, 0.8f),
				new SetValueState(1, 2, 5.0f),
				new EndState(2, 3)
			};
			StateMachine stateMachine = new StateMachine(states);
			Assert.AreEqual(12.76f, stateMachine.Process(12.76f, null));
		}

		[TestMethod()]
		public void BranchInputValueStateTest()
		{
			List<State> states = new List<State>
			{
				new BranchInputValueState(0, 1, 2, true, 10f, 10f, "Branch"),
				new SetValueState(1, 2, 5.0f),
				new EndState(2, 3)
			};
			StateMachine stateMachine = new StateMachine(states);
			Dictionary<string, object> parameters = new Dictionary<string, object>
			{
				{ "Branch", 10f }
			};
			Assert.AreEqual(2.0f, stateMachine.Process(2.0f, parameters));
		}

		[TestMethod()]
		public void TruncateStateTest()
		{
			List<State> states = new List<State>
			{
				new TruncateState(0, 1),
				new EndState(1, 2)
			};
			StateMachine stateMachine = new StateMachine(states);
			Assert.AreEqual(2.00f, stateMachine.Process(2.5232f, null));
		}
	}
}