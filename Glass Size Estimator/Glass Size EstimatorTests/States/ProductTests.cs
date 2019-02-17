using Microsoft.VisualStudio.TestTools.UnitTesting;
using Glass_Size_Estimator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;

namespace Glass_Size_Estimator.Tests
{
	// Tests for each individual state in the program
	[TestClass()]
	public class ProductTests
	{
		List<ProductLine> productList = new List<ProductLine>();

		// Generate the list of product lines
		[TestInitialize()]
		public void InitializeTest()
		{
			//Code Ran before window is brought to screen, this is where available JSON configs should be loaded

			string fextension = ".json";
			var myFiles = Directory.GetFiles(Directory.GetCurrentDirectory(), "*.*", SearchOption.AllDirectories)
			.Where(s => fextension.Contains(Path.GetExtension(s)));

			foreach (var file in myFiles)
			{
				using (var stream = new StreamReader(file))//put a test file in your bin/Debug/ folder to see this in action
				{
					string json_data = stream.ReadToEnd();
					dynamic productListJson = JsonConvert.DeserializeObject<Object>(json_data); //A dynamic object has dynamic runtime properties that can be referenced even though the compiler doesn't know what they are

					foreach (var productLine in productListJson.ProductLines) // Look at each product line in the config
					{
						// Create a new product line
						ProductLine product = new ProductLine(productLine);

						foreach (var outputLogic in productLine.Logic) // Look at each logic tree for each possible output
						{
							// Create a new logic sequence
							List<State> logic = new List<State>();

							// Look at each state in the logic tree
							for (int i = 0; i < outputLogic.First.Count; i++)
							{
								var state = outputLogic.First[i];
								State newState;

								// (NOTE: By default, the next state is automatically the next state)
								// Constructors for arithmetic states 
								if ("Addition".Equals((string)state.Operation, StringComparison.OrdinalIgnoreCase))
								{
									newState = new AdditionState(i, i + 1, (float)state.Value);
								}
								else if ("Subtraction".Equals((string)state.Operation, StringComparison.OrdinalIgnoreCase))
								{
									newState = new SubtractionState(i, i + 1, (float)state.Value);
								}
								else if ("Multiplication".Equals((string)state.Operation, StringComparison.OrdinalIgnoreCase))
								{
									newState = new MultiplicationState(i, i + 1, (float)state.Value);
								}
								else if ("Division".Equals((string)state.Operation, StringComparison.OrdinalIgnoreCase))
								{
									newState = new DivisionState(i, i + 1, (float)state.Value);
								}
								// Constructors for rounding states
								else if ("RoundDown".Equals((string)state.Operation, StringComparison.OrdinalIgnoreCase))
								{
									newState = new RoundDownState(i, i + 1, (float)state.Interval);
								}
								else if ("RoundUp".Equals((string)state.Operation, StringComparison.OrdinalIgnoreCase))
								{
									newState = new RoundUpState(i, i + 1, (float)state.Interval);
								}
								// Constructors for branching states
								else if ("Branch".Equals((string)state.Operation, StringComparison.OrdinalIgnoreCase))
								{
									newState = new BranchState(i, i + 1, (int)state.NextState, true);
								}
								else if ("BranchConditional".Equals((string)state.Operation, StringComparison.OrdinalIgnoreCase))
								{
									newState = new BranchConditionalState(i, i + 1, (int)state.NextState, (bool)state.Qualifier, (string)state.ConditionalName);
								}
								else if ("BranchValue".Equals((string)state.Operation, StringComparison.OrdinalIgnoreCase))
								{
									newState = new BranchValueState(i, i + 1, (int)state.NextState, (bool)state.Qualifier, (float)state.Minimum, (float)state.Maximum);
								}
								else if ("BranchFractionalValue".Equals((string)state.Operation, StringComparison.OrdinalIgnoreCase))
								{
									newState = new BranchFractionalValue(i, i + 1, (int)state.NextState, (bool)state.Qualifier, (float)state.Minimum, (float)state.Maximum);
								}
								else if ("BranchSeries".Equals((string)state.Operation, StringComparison.OrdinalIgnoreCase))
								{
									newState = new BranchSeriesState(i, i + 1, (int)state.NextState, (bool)state.Qualifier, (string[])state.Series);
								}
								else if ("BranchConfiguration".Equals((string)state.Operation, StringComparison.OrdinalIgnoreCase))
								{
									newState = new BranchConfigurationState(i, i + 1, (int)state.NextState, (bool)state.Qualifier, (string[])state.Configurations);
								}
								// Constructor for set states
								else if ("SetValue".Equals((string)state.Operation, StringComparison.OrdinalIgnoreCase))
								{
									newState = new SetValueState(i, i + 1, (float)state.Value);
								}
								else if ("SetConditional".Equals((string)state.Operation, StringComparison.OrdinalIgnoreCase))
								{
									newState = new SetConditionalState(i, i + 1, (bool)state.Value);
								}
								else if ("SetEnum".Equals((string)state.Operation, StringComparison.OrdinalIgnoreCase))
								{
									newState = new SetEnumState(i, i + 1, (string)state.Value, (string)state.Category);
								}
								// Constructor for truncate state
								else if ("Truncate".Equals((string)state.Operation, StringComparison.OrdinalIgnoreCase))
								{
									newState = new TruncateState(i, i + 1);
								}
								// Constructor for end state
								else if ("End".Equals((string)state.Operation, StringComparison.OrdinalIgnoreCase))
								{
									newState = new EndState(i, i + 1);
								}
								// If 'Operation' does not match any existing state replace it with an end state
								else
								{
									newState = new EndState(i, i + 1);
								}

								// Once a new state is added append it onto the logic sequence
								logic.Add(newState);
							}

							// Once the logic sequence is built add the logic to the product line
							product.Logic.Add((string)outputLogic.Name, new StateMachine(logic));
						}

						// Once all of the logic has been parsed add the product to the product list
						productList.Add(product);
					}
				}
			}
		}

		[TestMethod()]
		public void StockCardinalSeriesSemiFramelessSingleDoorsTest()
		{
			// Testing First Product Line Here (TODO: Move to a testing class later)
			Dictionary<string, object> parameters = new Dictionary<string, object>();
			parameters.Add("ClearSweep", false);

			// --- CD 24 Tests --- //

			// Test (22" x 66 5/8")
			Assert.AreEqual(18.8125f, productList[0].Logic["ResultingWidth"].Process(22.00f, parameters));
			Assert.AreEqual(65.0f, productList[0].Logic["ResultingHeight"].Process(66.625f, parameters));
			Assert.AreEqual(WallJamb.ZD1028, productList[0].Logic["WallJamb"].Process(22.00f, parameters));

			// Test (23 1/16" x 66 5/8")
			Assert.AreEqual(19.8125f, productList[0].Logic["ResultingWidth"].Process(23.0625f, parameters));
			Assert.AreEqual(65.0f, productList[0].Logic["ResultingHeight"].Process(66.625f, parameters));
			Assert.AreEqual(WallJamb.ZD1028, productList[0].Logic["WallJamb"].Process(23.0625f, parameters));

			// Test (24 1/8" x 66 5/8")
			Assert.AreEqual(20.8125f, productList[0].Logic["ResultingWidth"].Process(24.125f, parameters));
			Assert.AreEqual(65.0f, productList[0].Logic["ResultingHeight"].Process(66.625f, parameters));
			Assert.AreEqual(WallJamb.ZD1028, productList[0].Logic["WallJamb"].Process(23.125f, parameters));

			// Test (22 3/16" x 66 5/8")
			Assert.AreEqual(18.8125f, productList[0].Logic["ResultingWidth"].Process(22.1875f, parameters));
			Assert.AreEqual(65.0f, productList[0].Logic["ResultingHeight"].Process(66.625f, parameters));
			Assert.AreEqual(WallJamb.ZD1006, productList[0].Logic["WallJamb"].Process(22.1875f, parameters));

			// Test (23 1/4" x 66 5/8")
			Assert.AreEqual(19.8125f, productList[0].Logic["ResultingWidth"].Process(23.25f, parameters));
			Assert.AreEqual(65.0f, productList[0].Logic["ResultingHeight"].Process(66.625f, parameters));
			Assert.AreEqual(WallJamb.ZD1006, productList[0].Logic["WallJamb"].Process(23.25f, parameters));

			// Test (24 9/16" x 66 5/8")
			Assert.AreEqual(20.8125f, productList[0].Logic["ResultingWidth"].Process(24.5625f, parameters));
			Assert.AreEqual(65.0f, productList[0].Logic["ResultingHeight"].Process(66.625f, parameters));
			Assert.AreEqual(WallJamb.ZD1006, productList[0].Logic["WallJamb"].Process(23.5625f, parameters));

			// Test (22 3/4" x 66 5/8")
			Assert.AreEqual(19.8125f, productList[0].Logic["ResultingWidth"].Process(22.75f, parameters));
			Assert.AreEqual(65.0f, productList[0].Logic["ResultingHeight"].Process(66.625f, parameters));
			Assert.AreEqual(WallJamb.ZD1028, productList[0].Logic["WallJamb"].Process(22.75f, parameters));

			// Test (23 13/16" x 66 5/8")
			Assert.AreEqual(20.8125f, productList[0].Logic["ResultingWidth"].Process(23.8125f, parameters));
			Assert.AreEqual(65.0f, productList[0].Logic["ResultingHeight"].Process(66.625f, parameters));
			Assert.AreEqual(WallJamb.ZD1028, productList[0].Logic["WallJamb"].Process(23.8125f, parameters));

			// Test (24 15/16" x 66 5/8")
			Assert.AreEqual(21.8125f, productList[0].Logic["ResultingWidth"].Process(24.9375f, parameters));
			Assert.AreEqual(65.0f, productList[0].Logic["ResultingHeight"].Process(66.625f, parameters));
			Assert.AreEqual(WallJamb.ZD1028, productList[0].Logic["WallJamb"].Process(23.9375f, parameters));

			// --- CD 30 Tests --- //

			// Test (24 13/16" x 66 5/8")
			Assert.AreEqual(21.8125f, productList[0].Logic["ResultingWidth"].Process(24.8125f, parameters));
			Assert.AreEqual(65.0f, productList[0].Logic["ResultingHeight"].Process(66.625f, parameters));
			Assert.AreEqual(WallJamb.ZD1028, productList[0].Logic["WallJamb"].Process(24.8125f, parameters));

			// Test (25" x 66 5/8")
			Assert.AreEqual(21.8125f, productList[0].Logic["ResultingWidth"].Process(25.0f, parameters));
			Assert.AreEqual(65.0f, productList[0].Logic["ResultingHeight"].Process(66.625f, parameters));
			Assert.AreEqual(WallJamb.ZD1028, productList[0].Logic["WallJamb"].Process(25.0f, parameters));

			// Test (26" x 66 5/8")
			Assert.AreEqual(22.8125f, productList[0].Logic["ResultingWidth"].Process(26.0f, parameters));
			Assert.AreEqual(65.0f, productList[0].Logic["ResultingHeight"].Process(66.625f, parameters));
			Assert.AreEqual(WallJamb.ZD1028, productList[0].Logic["WallJamb"].Process(26.0f, parameters));

			// Test (27" x 66 5/8")
			Assert.AreEqual(23.8125f, productList[0].Logic["ResultingWidth"].Process(27.0f, parameters));
			Assert.AreEqual(65.0f, productList[0].Logic["ResultingHeight"].Process(66.625f, parameters));
			Assert.AreEqual(WallJamb.ZD1028, productList[0].Logic["WallJamb"].Process(27.0f, parameters));

			// Test (28" x 66 5/8")
			Assert.AreEqual(24.8125f, productList[0].Logic["ResultingWidth"].Process(28.0f, parameters));
			Assert.AreEqual(65.0f, productList[0].Logic["ResultingHeight"].Process(66.625f, parameters));
			Assert.AreEqual(WallJamb.ZD1028, productList[0].Logic["WallJamb"].Process(28.0f, parameters));

			// Test (29" x 66 5/8")
			Assert.AreEqual(25.8125f, productList[0].Logic["ResultingWidth"].Process(29.0f, parameters));
			Assert.AreEqual(65.0f, productList[0].Logic["ResultingHeight"].Process(66.625f, parameters));
			Assert.AreEqual(WallJamb.ZD1028, productList[0].Logic["WallJamb"].Process(29.0f, parameters));

			// Test (30" x 66 5/8")
			Assert.AreEqual(26.8125f, productList[0].Logic["ResultingWidth"].Process(30.0f, parameters));
			Assert.AreEqual(65.0f, productList[0].Logic["ResultingHeight"].Process(66.625f, parameters));
			Assert.AreEqual(WallJamb.ZD1028, productList[0].Logic["WallJamb"].Process(30.0f, parameters));

			// Test (25 1/2" x 66 5/8")
			Assert.AreEqual(21.8125f, productList[0].Logic["ResultingWidth"].Process(25.5f, parameters));
			Assert.AreEqual(65.0f, productList[0].Logic["ResultingHeight"].Process(66.625f, parameters));
			Assert.AreEqual(WallJamb.ZD1006, productList[0].Logic["WallJamb"].Process(25.5f, parameters));

			// Test (26 1/2" x 66 5/8")
			Assert.AreEqual(22.8125f, productList[0].Logic["ResultingWidth"].Process(26.5f, parameters));
			Assert.AreEqual(65.0f, productList[0].Logic["ResultingHeight"].Process(66.625f, parameters));
			Assert.AreEqual(WallJamb.ZD1006, productList[0].Logic["WallJamb"].Process(26.5f, parameters));

			// Test (27 1/2" x 66 5/8")
			Assert.AreEqual(23.8125f, productList[0].Logic["ResultingWidth"].Process(27.5f, parameters));
			Assert.AreEqual(65.0f, productList[0].Logic["ResultingHeight"].Process(66.625f, parameters));
			Assert.AreEqual(WallJamb.ZD1006, productList[0].Logic["WallJamb"].Process(27.5f, parameters));

			// Test (28 1/2" x 66 5/8")
			Assert.AreEqual(24.8125f, productList[0].Logic["ResultingWidth"].Process(28.5f, parameters));
			Assert.AreEqual(65.0f, productList[0].Logic["ResultingHeight"].Process(66.625f, parameters));
			Assert.AreEqual(WallJamb.ZD1006, productList[0].Logic["WallJamb"].Process(28.5f, parameters));

			// Test (29 1/2" x 66 5/8")
			Assert.AreEqual(25.8125f, productList[0].Logic["ResultingWidth"].Process(29.5f, parameters));
			Assert.AreEqual(65.0f, productList[0].Logic["ResultingHeight"].Process(66.625f, parameters));
			Assert.AreEqual(WallJamb.ZD1006, productList[0].Logic["WallJamb"].Process(29.5f, parameters));

			// Test (30 1/2" x 66 5/8")
			Assert.AreEqual(26.8125f, productList[0].Logic["ResultingWidth"].Process(30.5f, parameters));
			Assert.AreEqual(65.0f, productList[0].Logic["ResultingHeight"].Process(66.625f, parameters));
			Assert.AreEqual(WallJamb.ZD1006, productList[0].Logic["WallJamb"].Process(30.5f, parameters));

			// Test (25 3/4" x 66 5/8")
			Assert.AreEqual(22.8125f, productList[0].Logic["ResultingWidth"].Process(25.75f, parameters));
			Assert.AreEqual(65.0f, productList[0].Logic["ResultingHeight"].Process(66.625f, parameters));
			Assert.AreEqual(WallJamb.ZD1028, productList[0].Logic["WallJamb"].Process(25.75f, parameters));

			// Test (26 3/4" x 66 5/8")
			Assert.AreEqual(23.8125f, productList[0].Logic["ResultingWidth"].Process(26.75f, parameters));
			Assert.AreEqual(65.0f, productList[0].Logic["ResultingHeight"].Process(66.625f, parameters));
			Assert.AreEqual(WallJamb.ZD1028, productList[0].Logic["WallJamb"].Process(26.75f, parameters));

			// Test (27 3/4" x 66 5/8")
			Assert.AreEqual(24.8125f, productList[0].Logic["ResultingWidth"].Process(27.75f, parameters));
			Assert.AreEqual(65.0f, productList[0].Logic["ResultingHeight"].Process(66.625f, parameters));
			Assert.AreEqual(WallJamb.ZD1028, productList[0].Logic["WallJamb"].Process(27.75f, parameters));

			// Test (28 3/4" x 66 5/8")
			Assert.AreEqual(25.8125f, productList[0].Logic["ResultingWidth"].Process(28.75f, parameters));
			Assert.AreEqual(65.0f, productList[0].Logic["ResultingHeight"].Process(66.625f, parameters));
			Assert.AreEqual(WallJamb.ZD1028, productList[0].Logic["WallJamb"].Process(28.75f, parameters));

			// Test (29 3/4" x 66 5/8")
			Assert.AreEqual(26.8125f, productList[0].Logic["ResultingWidth"].Process(29.75f, parameters));
			Assert.AreEqual(65.0f, productList[0].Logic["ResultingHeight"].Process(66.625f, parameters));
			Assert.AreEqual(WallJamb.ZD1028, productList[0].Logic["WallJamb"].Process(29.75f, parameters));

			// Test (30 3/4" x 66 5/8")
			Assert.AreEqual(27.8125f, productList[0].Logic["ResultingWidth"].Process(30.75f, parameters));
			Assert.AreEqual(65.0f, productList[0].Logic["ResultingHeight"].Process(66.625f, parameters));
			Assert.AreEqual(WallJamb.ZD1028, productList[0].Logic["WallJamb"].Process(30.75f, parameters));

			// --- CD 36 Tests --- //

			// Test (30 13/16" x 66 5/8")
			Assert.AreEqual(27.8125f, productList[0].Logic["ResultingWidth"].Process(30.8125f, parameters));
			Assert.AreEqual(65.0f, productList[0].Logic["ResultingHeight"].Process(66.625f, parameters));
			Assert.AreEqual(WallJamb.ZD1028, productList[0].Logic["WallJamb"].Process(30.8125f, parameters));

			// Test (31" x 66 5/8")
			Assert.AreEqual(27.8125f, productList[0].Logic["ResultingWidth"].Process(31.0f, parameters));
			Assert.AreEqual(65.0f, productList[0].Logic["ResultingHeight"].Process(66.625f, parameters));
			Assert.AreEqual(WallJamb.ZD1028, productList[0].Logic["WallJamb"].Process(31.0f, parameters));

			// Test (32" x 66 5/8")
			Assert.AreEqual(28.8125f, productList[0].Logic["ResultingWidth"].Process(32.0f, parameters));
			Assert.AreEqual(65.0f, productList[0].Logic["ResultingHeight"].Process(66.625f, parameters));
			Assert.AreEqual(WallJamb.ZD1028, productList[0].Logic["WallJamb"].Process(32.0f, parameters));

			// Test (33" x 66 5/8")
			Assert.AreEqual(29.8125f, productList[0].Logic["ResultingWidth"].Process(33.0f, parameters));
			Assert.AreEqual(65.0f, productList[0].Logic["ResultingHeight"].Process(66.625f, parameters));
			Assert.AreEqual(WallJamb.ZD1028, productList[0].Logic["WallJamb"].Process(33.0f, parameters));

			// Test (34" x 66 5/8")
			Assert.AreEqual(30.8125f, productList[0].Logic["ResultingWidth"].Process(34.0f, parameters));
			Assert.AreEqual(65.0f, productList[0].Logic["ResultingHeight"].Process(66.625f, parameters));
			Assert.AreEqual(WallJamb.ZD1028, productList[0].Logic["WallJamb"].Process(34.0f, parameters));

			// Test (35" x 66 5/8")
			Assert.AreEqual(31.8125f, productList[0].Logic["ResultingWidth"].Process(35.0f, parameters));
			Assert.AreEqual(65.0f, productList[0].Logic["ResultingHeight"].Process(66.625f, parameters));
			Assert.AreEqual(WallJamb.ZD1028, productList[0].Logic["WallJamb"].Process(35.0f, parameters));

			// Test (36" x 66 5/8")
			Assert.AreEqual(32.8125f, productList[0].Logic["ResultingWidth"].Process(36.0f, parameters));
			Assert.AreEqual(65.0f, productList[0].Logic["ResultingHeight"].Process(66.625f, parameters));
			Assert.AreEqual(WallJamb.ZD1028, productList[0].Logic["WallJamb"].Process(36.0f, parameters));

			// Test (31 1/2" x 66 5/8")
			Assert.AreEqual(27.8125f, productList[0].Logic["ResultingWidth"].Process(31.5f, parameters));
			Assert.AreEqual(65.0f, productList[0].Logic["ResultingHeight"].Process(66.625f, parameters));
			Assert.AreEqual(WallJamb.ZD1006, productList[0].Logic["WallJamb"].Process(31.5f, parameters));

			// Test (32 1/2" x 66 5/8")
			Assert.AreEqual(28.8125f, productList[0].Logic["ResultingWidth"].Process(32.5f, parameters));
			Assert.AreEqual(65.0f, productList[0].Logic["ResultingHeight"].Process(66.625f, parameters));
			Assert.AreEqual(WallJamb.ZD1006, productList[0].Logic["WallJamb"].Process(32.5f, parameters));

			// Test (33 1/2" x 66 5/8")
			Assert.AreEqual(29.8125f, productList[0].Logic["ResultingWidth"].Process(33.5f, parameters));
			Assert.AreEqual(65.0f, productList[0].Logic["ResultingHeight"].Process(66.625f, parameters));
			Assert.AreEqual(WallJamb.ZD1006, productList[0].Logic["WallJamb"].Process(33.5f, parameters));

			// Test (34 1/2" x 66 5/8")
			Assert.AreEqual(30.8125f, productList[0].Logic["ResultingWidth"].Process(34.5f, parameters));
			Assert.AreEqual(65.0f, productList[0].Logic["ResultingHeight"].Process(66.625f, parameters));
			Assert.AreEqual(WallJamb.ZD1006, productList[0].Logic["WallJamb"].Process(34.5f, parameters));

			// Test (35 1/2" x 66 5/8")
			Assert.AreEqual(31.8125f, productList[0].Logic["ResultingWidth"].Process(35.5f, parameters));
			Assert.AreEqual(65.0f, productList[0].Logic["ResultingHeight"].Process(66.625f, parameters));
			Assert.AreEqual(WallJamb.ZD1006, productList[0].Logic["WallJamb"].Process(35.5f, parameters));

			// Test (36 1/2" x 66 5/8")
			Assert.AreEqual(32.8125f, productList[0].Logic["ResultingWidth"].Process(36.5f, parameters));
			Assert.AreEqual(65.0f, productList[0].Logic["ResultingHeight"].Process(66.625f, parameters));
			Assert.AreEqual(WallJamb.ZD1006, productList[0].Logic["WallJamb"].Process(36.5f, parameters));

			// Test (31 3/4" x 66 5/8")
			Assert.AreEqual(28.8125f, productList[0].Logic["ResultingWidth"].Process(31.75f, parameters));
			Assert.AreEqual(65.0f, productList[0].Logic["ResultingHeight"].Process(66.625f, parameters));
			Assert.AreEqual(WallJamb.ZD1028, productList[0].Logic["WallJamb"].Process(31.75f, parameters));

			// Test (32 3/4" x 66 5/8")
			Assert.AreEqual(29.8125f, productList[0].Logic["ResultingWidth"].Process(32.75f, parameters));
			Assert.AreEqual(65.0f, productList[0].Logic["ResultingHeight"].Process(66.625f, parameters));
			Assert.AreEqual(WallJamb.ZD1028, productList[0].Logic["WallJamb"].Process(32.75f, parameters));

			// Test (33 3/4" x 66 5/8")
			Assert.AreEqual(30.8125f, productList[0].Logic["ResultingWidth"].Process(33.75f, parameters));
			Assert.AreEqual(65.0f, productList[0].Logic["ResultingHeight"].Process(66.625f, parameters));
			Assert.AreEqual(WallJamb.ZD1028, productList[0].Logic["WallJamb"].Process(33.75f, parameters));

			// Test (34 3/4" x 66 5/8")
			Assert.AreEqual(31.8125f, productList[0].Logic["ResultingWidth"].Process(34.75f, parameters));
			Assert.AreEqual(65.0f, productList[0].Logic["ResultingHeight"].Process(66.625f, parameters));
			Assert.AreEqual(WallJamb.ZD1028, productList[0].Logic["WallJamb"].Process(34.75f, parameters));

			// Test (35 3/4" x 66 5/8")
			Assert.AreEqual(32.8125f, productList[0].Logic["ResultingWidth"].Process(35.75f, parameters));
			Assert.AreEqual(65.0f, productList[0].Logic["ResultingHeight"].Process(66.625f, parameters));
			Assert.AreEqual(WallJamb.ZD1028, productList[0].Logic["WallJamb"].Process(35.75f, parameters));

			// --- CD 24-72 Tests --- //

			// Test (23 1/16" x 69 5/8")
			Assert.AreEqual(19.8125f, productList[0].Logic["ResultingWidth"].Process(23.0625f, parameters));
			Assert.AreEqual(68.0f, productList[0].Logic["ResultingHeight"].Process(69.625f, parameters));
			Assert.AreEqual(WallJamb.ZD1028, productList[0].Logic["WallJamb"].Process(23.0625f, parameters));

			// Test (24 1/8" x 69 5/8")
			Assert.AreEqual(20.8125f, productList[0].Logic["ResultingWidth"].Process(24.125f, parameters));
			Assert.AreEqual(68.0f, productList[0].Logic["ResultingHeight"].Process(69.625f, parameters));
			Assert.AreEqual(WallJamb.ZD1028, productList[0].Logic["WallJamb"].Process(23.125f, parameters));

			// Test (23 1/2" x 69 5/8")
			Assert.AreEqual(19.8125f, productList[0].Logic["ResultingWidth"].Process(23.5f, parameters));
			Assert.AreEqual(68.0f, productList[0].Logic["ResultingHeight"].Process(69.625f, parameters));
			Assert.AreEqual(WallJamb.ZD1006, productList[0].Logic["WallJamb"].Process(23.5f, parameters));

			// Test (24 1/2" x 69 5/8")
			Assert.AreEqual(20.8125f, productList[0].Logic["ResultingWidth"].Process(24.5f, parameters));
			Assert.AreEqual(68.0f, productList[0].Logic["ResultingHeight"].Process(69.625f, parameters));
			Assert.AreEqual(WallJamb.ZD1006, productList[0].Logic["WallJamb"].Process(23.5f, parameters));

			// Test (22 3/4" x 69 5/8")
			Assert.AreEqual(19.8125f, productList[0].Logic["ResultingWidth"].Process(22.75f, parameters));
			Assert.AreEqual(68.0f, productList[0].Logic["ResultingHeight"].Process(69.625f, parameters));
			Assert.AreEqual(WallJamb.ZD1028, productList[0].Logic["WallJamb"].Process(22.75f, parameters));

			// Test (23 3/4" x 69 5/8")
			Assert.AreEqual(20.8125f, productList[0].Logic["ResultingWidth"].Process(23.75f, parameters));
			Assert.AreEqual(68.0f, productList[0].Logic["ResultingHeight"].Process(69.625f, parameters));
			Assert.AreEqual(WallJamb.ZD1028, productList[0].Logic["WallJamb"].Process(23.75f, parameters));

			// Test (24 3/4" x 69 5/8")
			Assert.AreEqual(21.8125f, productList[0].Logic["ResultingWidth"].Process(24.75f, parameters));
			Assert.AreEqual(68.0f, productList[0].Logic["ResultingHeight"].Process(69.625f, parameters));
			Assert.AreEqual(WallJamb.ZD1028, productList[0].Logic["WallJamb"].Process(24.75f, parameters));

			// --- CD 30-72 Tests --- //

			// Test (24 13/16" x 69 5/8")
			Assert.AreEqual(21.8125f, productList[0].Logic["ResultingWidth"].Process(24.8125f, parameters));
			Assert.AreEqual(68.0f, productList[0].Logic["ResultingHeight"].Process(69.625f, parameters));
			Assert.AreEqual(WallJamb.ZD1028, productList[0].Logic["WallJamb"].Process(24.8125f, parameters));

			// Test (25" x 69 5/8")
			Assert.AreEqual(21.8125f, productList[0].Logic["ResultingWidth"].Process(25.0f, parameters));
			Assert.AreEqual(68.0f, productList[0].Logic["ResultingHeight"].Process(69.625f, parameters));
			Assert.AreEqual(WallJamb.ZD1028, productList[0].Logic["WallJamb"].Process(25.0f, parameters));

			// Test (26" x 69 5/8")
			Assert.AreEqual(22.8125f, productList[0].Logic["ResultingWidth"].Process(26.0f, parameters));
			Assert.AreEqual(68.0f, productList[0].Logic["ResultingHeight"].Process(69.625f, parameters));
			Assert.AreEqual(WallJamb.ZD1028, productList[0].Logic["WallJamb"].Process(26.0f, parameters));

			// Test (27" x 69 5/8")
			Assert.AreEqual(23.8125f, productList[0].Logic["ResultingWidth"].Process(27.0f, parameters));
			Assert.AreEqual(68.0f, productList[0].Logic["ResultingHeight"].Process(69.625f, parameters));
			Assert.AreEqual(WallJamb.ZD1028, productList[0].Logic["WallJamb"].Process(27.0f, parameters));

			// Test (28" x 69 5/8")
			Assert.AreEqual(24.8125f, productList[0].Logic["ResultingWidth"].Process(28.0f, parameters));
			Assert.AreEqual(68.0f, productList[0].Logic["ResultingHeight"].Process(69.625f, parameters));
			Assert.AreEqual(WallJamb.ZD1028, productList[0].Logic["WallJamb"].Process(28.0f, parameters));

			// Test (29" x 69 5/8")
			Assert.AreEqual(25.8125f, productList[0].Logic["ResultingWidth"].Process(29.0f, parameters));
			Assert.AreEqual(68.0f, productList[0].Logic["ResultingHeight"].Process(69.625f, parameters));
			Assert.AreEqual(WallJamb.ZD1028, productList[0].Logic["WallJamb"].Process(29.0f, parameters));

			// Test (30" x 69 5/8")
			Assert.AreEqual(26.8125f, productList[0].Logic["ResultingWidth"].Process(30.0f, parameters));
			Assert.AreEqual(68.0f, productList[0].Logic["ResultingHeight"].Process(69.625f, parameters));
			Assert.AreEqual(WallJamb.ZD1028, productList[0].Logic["WallJamb"].Process(30.0f, parameters));

			// Test (25 1/2" x 69 5/8")
			Assert.AreEqual(21.8125f, productList[0].Logic["ResultingWidth"].Process(25.5f, parameters));
			Assert.AreEqual(68.0f, productList[0].Logic["ResultingHeight"].Process(69.625f, parameters));
			Assert.AreEqual(WallJamb.ZD1006, productList[0].Logic["WallJamb"].Process(25.5f, parameters));

			// Test (26 1/2" x 69 5/8")
			Assert.AreEqual(22.8125f, productList[0].Logic["ResultingWidth"].Process(26.5f, parameters));
			Assert.AreEqual(68.0f, productList[0].Logic["ResultingHeight"].Process(69.625f, parameters));
			Assert.AreEqual(WallJamb.ZD1006, productList[0].Logic["WallJamb"].Process(26.5f, parameters));

			// Test (27 1/2" x 69 5/8")
			Assert.AreEqual(23.8125f, productList[0].Logic["ResultingWidth"].Process(27.5f, parameters));
			Assert.AreEqual(68.0f, productList[0].Logic["ResultingHeight"].Process(69.625f, parameters));
			Assert.AreEqual(WallJamb.ZD1006, productList[0].Logic["WallJamb"].Process(27.5f, parameters));

			// Test (28 1/2" x 69 5/8")
			Assert.AreEqual(24.8125f, productList[0].Logic["ResultingWidth"].Process(28.5f, parameters));
			Assert.AreEqual(68.0f, productList[0].Logic["ResultingHeight"].Process(69.625f, parameters));
			Assert.AreEqual(WallJamb.ZD1006, productList[0].Logic["WallJamb"].Process(28.5f, parameters));

			// Test (29 1/2" x 69 5/8")
			Assert.AreEqual(25.8125f, productList[0].Logic["ResultingWidth"].Process(29.5f, parameters));
			Assert.AreEqual(68.0f, productList[0].Logic["ResultingHeight"].Process(69.625f, parameters));
			Assert.AreEqual(WallJamb.ZD1006, productList[0].Logic["WallJamb"].Process(29.5f, parameters));

			// Test (30 1/2" x 69 5/8")
			Assert.AreEqual(26.8125f, productList[0].Logic["ResultingWidth"].Process(30.5f, parameters));
			Assert.AreEqual(68.0f, productList[0].Logic["ResultingHeight"].Process(69.625f, parameters));
			Assert.AreEqual(WallJamb.ZD1006, productList[0].Logic["WallJamb"].Process(30.5f, parameters));

			// Test (25 3/4" x 69 5/8")
			Assert.AreEqual(22.8125f, productList[0].Logic["ResultingWidth"].Process(25.75f, parameters));
			Assert.AreEqual(68.0f, productList[0].Logic["ResultingHeight"].Process(69.625f, parameters));
			Assert.AreEqual(WallJamb.ZD1028, productList[0].Logic["WallJamb"].Process(25.75f, parameters));

			// Test (26 3/4" x 69 5/8")
			Assert.AreEqual(23.8125f, productList[0].Logic["ResultingWidth"].Process(26.75f, parameters));
			Assert.AreEqual(68.0f, productList[0].Logic["ResultingHeight"].Process(69.625f, parameters));
			Assert.AreEqual(WallJamb.ZD1028, productList[0].Logic["WallJamb"].Process(26.75f, parameters));

			// Test (27 3/4" x 69 5/8")
			Assert.AreEqual(24.8125f, productList[0].Logic["ResultingWidth"].Process(27.75f, parameters));
			Assert.AreEqual(68.0f, productList[0].Logic["ResultingHeight"].Process(69.625f, parameters));
			Assert.AreEqual(WallJamb.ZD1028, productList[0].Logic["WallJamb"].Process(27.75f, parameters));

			// Test (28 3/4" x 69 5/8")
			Assert.AreEqual(25.8125f, productList[0].Logic["ResultingWidth"].Process(28.75f, parameters));
			Assert.AreEqual(68.0f, productList[0].Logic["ResultingHeight"].Process(69.625f, parameters));
			Assert.AreEqual(WallJamb.ZD1028, productList[0].Logic["WallJamb"].Process(28.75f, parameters));

			// Test (29 3/4" x 69 5/8")
			Assert.AreEqual(26.8125f, productList[0].Logic["ResultingWidth"].Process(29.75f, parameters));
			Assert.AreEqual(68.0f, productList[0].Logic["ResultingHeight"].Process(69.625f, parameters));
			Assert.AreEqual(WallJamb.ZD1028, productList[0].Logic["WallJamb"].Process(29.75f, parameters));

			// Test (30 3/4" x 69 5/8")
			Assert.AreEqual(27.8125f, productList[0].Logic["ResultingWidth"].Process(30.75f, parameters));
			Assert.AreEqual(68.0f, productList[0].Logic["ResultingHeight"].Process(69.625f, parameters));
			Assert.AreEqual(WallJamb.ZD1028, productList[0].Logic["WallJamb"].Process(30.75f, parameters));

			// --- CD 36-72 Tests --- //

			// Test (30 13/16" x 69 5/8")
			Assert.AreEqual(27.8125f, productList[0].Logic["ResultingWidth"].Process(30.8125f, parameters));
			Assert.AreEqual(68.0f, productList[0].Logic["ResultingHeight"].Process(69.625f, parameters));
			Assert.AreEqual(WallJamb.ZD1028, productList[0].Logic["WallJamb"].Process(30.8125f, parameters));

			// Test (31" x 69 5/8")
			Assert.AreEqual(27.8125f, productList[0].Logic["ResultingWidth"].Process(31.0f, parameters));
			Assert.AreEqual(68.0f, productList[0].Logic["ResultingHeight"].Process(69.625f, parameters));
			Assert.AreEqual(WallJamb.ZD1028, productList[0].Logic["WallJamb"].Process(31.0f, parameters));

			// Test (32" x 69 5/8")
			Assert.AreEqual(28.8125f, productList[0].Logic["ResultingWidth"].Process(32.0f, parameters));
			Assert.AreEqual(68.0f, productList[0].Logic["ResultingHeight"].Process(69.625f, parameters));
			Assert.AreEqual(WallJamb.ZD1028, productList[0].Logic["WallJamb"].Process(32.0f, parameters));

			// Test (33" x 69 5/8")
			Assert.AreEqual(29.8125f, productList[0].Logic["ResultingWidth"].Process(33.0f, parameters));
			Assert.AreEqual(68.0f, productList[0].Logic["ResultingHeight"].Process(69.625f, parameters));
			Assert.AreEqual(WallJamb.ZD1028, productList[0].Logic["WallJamb"].Process(33.0f, parameters));

			// Test (34" x 69 5/8")
			Assert.AreEqual(30.8125f, productList[0].Logic["ResultingWidth"].Process(34.0f, parameters));
			Assert.AreEqual(68.0f, productList[0].Logic["ResultingHeight"].Process(69.625f, parameters));
			Assert.AreEqual(WallJamb.ZD1028, productList[0].Logic["WallJamb"].Process(34.0f, parameters));

			// Test (31 1/2" x 69 5/8")
			Assert.AreEqual(27.8125f, productList[0].Logic["ResultingWidth"].Process(31.5f, parameters));
			Assert.AreEqual(68.0f, productList[0].Logic["ResultingHeight"].Process(69.625f, parameters));
			Assert.AreEqual(WallJamb.ZD1006, productList[0].Logic["WallJamb"].Process(31.5f, parameters));

			// Test (32 1/2" x 69 5/8")
			Assert.AreEqual(28.8125f, productList[0].Logic["ResultingWidth"].Process(32.5f, parameters));
			Assert.AreEqual(68.0f, productList[0].Logic["ResultingHeight"].Process(69.625f, parameters));
			Assert.AreEqual(WallJamb.ZD1006, productList[0].Logic["WallJamb"].Process(32.5f, parameters));

			// Test (33 1/2" x 69 5/8")
			Assert.AreEqual(29.8125f, productList[0].Logic["ResultingWidth"].Process(33.5f, parameters));
			Assert.AreEqual(68.0f, productList[0].Logic["ResultingHeight"].Process(69.625f, parameters));
			Assert.AreEqual(WallJamb.ZD1006, productList[0].Logic["WallJamb"].Process(33.5f, parameters));

			// Test (34 1/2" x 69 5/8")
			Assert.AreEqual(30.8125f, productList[0].Logic["ResultingWidth"].Process(34.5f, parameters));
			Assert.AreEqual(68.0f, productList[0].Logic["ResultingHeight"].Process(69.625f, parameters));
			Assert.AreEqual(WallJamb.ZD1006, productList[0].Logic["WallJamb"].Process(34.5f, parameters));

			// Test (31 3/4" x 69 5/8")
			Assert.AreEqual(28.8125f, productList[0].Logic["ResultingWidth"].Process(31.75f, parameters));
			Assert.AreEqual(68.0f, productList[0].Logic["ResultingHeight"].Process(69.625f, parameters));
			Assert.AreEqual(WallJamb.ZD1028, productList[0].Logic["WallJamb"].Process(31.75f, parameters));

			// Test (32 3/4" x 69 5/8")
			Assert.AreEqual(29.8125f, productList[0].Logic["ResultingWidth"].Process(32.75f, parameters));
			Assert.AreEqual(68.0f, productList[0].Logic["ResultingHeight"].Process(69.625f, parameters));
			Assert.AreEqual(WallJamb.ZD1028, productList[0].Logic["WallJamb"].Process(32.75f, parameters));

			// Test (33 3/4" x 69 5/8")
			Assert.AreEqual(30.8125f, productList[0].Logic["ResultingWidth"].Process(33.75f, parameters));
			Assert.AreEqual(68.0f, productList[0].Logic["ResultingHeight"].Process(69.625f, parameters));
			Assert.AreEqual(WallJamb.ZD1028, productList[0].Logic["WallJamb"].Process(33.75f, parameters));
		}
	}
}