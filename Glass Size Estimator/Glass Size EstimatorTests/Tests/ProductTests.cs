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

						// Add the product to the product list
						productList.Add(product);
					}
				}
			}
		}

		[TestMethod()]
		public void StockCardinalSeriesSemiFramelessSingleDoorsTest()
		{
			Dictionary<string, object> parameters = new Dictionary<string, object>();
			parameters.Add("ClearSweep", false);

			// --- CD 24 Tests --- //

			// Test (22" x 66 5/8")
			parameters.Add("OpeningWidth", 22.00f);
			parameters.Add("OpeningHeight", 66.625f);
			Assert.AreEqual(18.8125f, productList[0].Logic["ResultingWidth"].Process(22.00f, parameters));
			Assert.AreEqual(65.0f, productList[0].Logic["ResultingHeight"].Process(66.625f, parameters));
			Assert.AreEqual(WallJamb.ZD1028, productList[0].Logic["WallJamb"].Process(22.00f, parameters));
			parameters.Remove("OpeningWidth");
			parameters.Remove("OpeningHeight");

			// Test (23 1/16" x 66 5/8")
			parameters.Add("OpeningWidth", 23.0625f);
			parameters.Add("OpeningHeight", 66.625f);
			Assert.AreEqual(19.8125f, productList[0].Logic["ResultingWidth"].Process(23.0625f, parameters));
			Assert.AreEqual(65.0f, productList[0].Logic["ResultingHeight"].Process(66.625f, parameters));
			Assert.AreEqual(WallJamb.ZD1028, productList[0].Logic["WallJamb"].Process(23.0625f, parameters));
			parameters.Remove("OpeningWidth");
			parameters.Remove("OpeningHeight");

			// Test (24 1/8" x 66 5/8")
			parameters.Add("OpeningWidth", 24.125f);
			parameters.Add("OpeningHeight", 66.625f);
			Assert.AreEqual(20.8125f, productList[0].Logic["ResultingWidth"].Process(24.125f, parameters));
			Assert.AreEqual(65.0f, productList[0].Logic["ResultingHeight"].Process(66.625f, parameters));
			Assert.AreEqual(WallJamb.ZD1028, productList[0].Logic["WallJamb"].Process(23.125f, parameters));
			parameters.Remove("OpeningWidth");
			parameters.Remove("OpeningHeight");

			// Test (22 3/16" x 66 5/8")
			parameters.Add("OpeningWidth", 22.1875f);
			parameters.Add("OpeningHeight", 66.625f);
			Assert.AreEqual(18.8125f, productList[0].Logic["ResultingWidth"].Process(22.1875f, parameters));
			Assert.AreEqual(65.0f, productList[0].Logic["ResultingHeight"].Process(66.625f, parameters));
			Assert.AreEqual(WallJamb.ZD1006, productList[0].Logic["WallJamb"].Process(22.1875f, parameters));
			parameters.Remove("OpeningWidth");
			parameters.Remove("OpeningHeight");

			// Test (23 1/4" x 66 5/8")
			parameters.Add("OpeningWidth", 23.25f);
			parameters.Add("OpeningHeight", 66.625f);
			Assert.AreEqual(19.8125f, productList[0].Logic["ResultingWidth"].Process(23.25f, parameters));
			Assert.AreEqual(65.0f, productList[0].Logic["ResultingHeight"].Process(66.625f, parameters));
			Assert.AreEqual(WallJamb.ZD1006, productList[0].Logic["WallJamb"].Process(23.25f, parameters));
			parameters.Remove("OpeningWidth");
			parameters.Remove("OpeningHeight");

			// Test (24 9/16" x 66 5/8")
			parameters.Add("OpeningWidth", 24.5625f);
			parameters.Add("OpeningHeight", 66.625f);
			Assert.AreEqual(20.8125f, productList[0].Logic["ResultingWidth"].Process(24.5625f, parameters));
			Assert.AreEqual(65.0f, productList[0].Logic["ResultingHeight"].Process(66.625f, parameters));
			Assert.AreEqual(WallJamb.ZD1006, productList[0].Logic["WallJamb"].Process(24.5625f, parameters));
			parameters.Remove("OpeningWidth");
			parameters.Remove("OpeningHeight");

			// Test (22 3/4" x 66 5/8")
			parameters.Add("OpeningWidth", 22.75f);
			parameters.Add("OpeningHeight", 66.625f);
			Assert.AreEqual(19.8125f, productList[0].Logic["ResultingWidth"].Process(22.75f, parameters));
			Assert.AreEqual(65.0f, productList[0].Logic["ResultingHeight"].Process(66.625f, parameters));
			Assert.AreEqual(WallJamb.ZD1028, productList[0].Logic["WallJamb"].Process(22.75f, parameters));
			parameters.Remove("OpeningWidth");
			parameters.Remove("OpeningHeight");

			// Test (23 13/16" x 66 5/8")
			parameters.Add("OpeningWidth", 23.8125f);
			parameters.Add("OpeningHeight", 66.625f);
			Assert.AreEqual(20.8125f, productList[0].Logic["ResultingWidth"].Process(23.8125f, parameters));
			Assert.AreEqual(65.0f, productList[0].Logic["ResultingHeight"].Process(66.625f, parameters));
			Assert.AreEqual(WallJamb.ZD1028, productList[0].Logic["WallJamb"].Process(23.8125f, parameters));
			parameters.Remove("OpeningWidth");
			parameters.Remove("OpeningHeight");

			// Test (24 15/16" x 66 5/8")
			parameters.Add("OpeningWidth", 24.9375f);
			parameters.Add("OpeningHeight", 66.625f);
			Assert.AreEqual(21.8125f, productList[0].Logic["ResultingWidth"].Process(24.9375f, parameters));
			Assert.AreEqual(65.0f, productList[0].Logic["ResultingHeight"].Process(66.625f, parameters));
			Assert.AreEqual(WallJamb.ZD1028, productList[0].Logic["WallJamb"].Process(23.9375f, parameters));
			parameters.Remove("OpeningWidth");
			parameters.Remove("OpeningHeight");

			// --- CD 30 Tests --- //

			// Test (24 13/16" x 66 5/8")
			parameters.Add("OpeningWidth", 24.8125f);
			parameters.Add("OpeningHeight", 66.625f);
			Assert.AreEqual(21.8125f, productList[0].Logic["ResultingWidth"].Process(24.8125f, parameters));
			Assert.AreEqual(65.0f, productList[0].Logic["ResultingHeight"].Process(66.625f, parameters));
			Assert.AreEqual(WallJamb.ZD1028, productList[0].Logic["WallJamb"].Process(24.8125f, parameters));
			parameters.Remove("OpeningWidth");
			parameters.Remove("OpeningHeight");

			// Test (25" x 66 5/8")
			parameters.Add("OpeningWidth", 25.0f);
			parameters.Add("OpeningHeight", 66.625f);
			Assert.AreEqual(21.8125f, productList[0].Logic["ResultingWidth"].Process(25.0f, parameters));
			Assert.AreEqual(65.0f, productList[0].Logic["ResultingHeight"].Process(66.625f, parameters));
			Assert.AreEqual(WallJamb.ZD1028, productList[0].Logic["WallJamb"].Process(25.0f, parameters));
			parameters.Remove("OpeningWidth");
			parameters.Remove("OpeningHeight");

			// Test (26" x 66 5/8")
			parameters.Add("OpeningWidth", 26.0f);
			parameters.Add("OpeningHeight", 66.625f);
			Assert.AreEqual(22.8125f, productList[0].Logic["ResultingWidth"].Process(26.0f, parameters));
			Assert.AreEqual(65.0f, productList[0].Logic["ResultingHeight"].Process(66.625f, parameters));
			Assert.AreEqual(WallJamb.ZD1028, productList[0].Logic["WallJamb"].Process(26.0f, parameters));
			parameters.Remove("OpeningWidth");
			parameters.Remove("OpeningHeight");

			// Test (27" x 66 5/8")
			parameters.Add("OpeningWidth", 27.0f);
			parameters.Add("OpeningHeight", 66.625f);
			Assert.AreEqual(23.8125f, productList[0].Logic["ResultingWidth"].Process(27.0f, parameters));
			Assert.AreEqual(65.0f, productList[0].Logic["ResultingHeight"].Process(66.625f, parameters));
			Assert.AreEqual(WallJamb.ZD1028, productList[0].Logic["WallJamb"].Process(27.0f, parameters));
			parameters.Remove("OpeningWidth");
			parameters.Remove("OpeningHeight");

			// Test (28" x 66 5/8")
			parameters.Add("OpeningWidth", 28.0f);
			parameters.Add("OpeningHeight", 66.625f);
			Assert.AreEqual(24.8125f, productList[0].Logic["ResultingWidth"].Process(28.0f, parameters));
			Assert.AreEqual(65.0f, productList[0].Logic["ResultingHeight"].Process(66.625f, parameters));
			Assert.AreEqual(WallJamb.ZD1028, productList[0].Logic["WallJamb"].Process(28.0f, parameters));
			parameters.Remove("OpeningWidth");
			parameters.Remove("OpeningHeight");

			// Test (29" x 66 5/8")
			parameters.Add("OpeningWidth", 29.0f);
			parameters.Add("OpeningHeight", 66.625f);
			Assert.AreEqual(25.8125f, productList[0].Logic["ResultingWidth"].Process(29.0f, parameters));
			Assert.AreEqual(65.0f, productList[0].Logic["ResultingHeight"].Process(66.625f, parameters));
			Assert.AreEqual(WallJamb.ZD1028, productList[0].Logic["WallJamb"].Process(29.0f, parameters));
			parameters.Remove("OpeningWidth");
			parameters.Remove("OpeningHeight");

			// Test (30" x 66 5/8")
			parameters.Add("OpeningWidth", 30.0f);
			parameters.Add("OpeningHeight", 66.625f);
			Assert.AreEqual(26.8125f, productList[0].Logic["ResultingWidth"].Process(30.0f, parameters));
			Assert.AreEqual(65.0f, productList[0].Logic["ResultingHeight"].Process(66.625f, parameters));
			Assert.AreEqual(WallJamb.ZD1028, productList[0].Logic["WallJamb"].Process(30.0f, parameters));
			parameters.Remove("OpeningWidth");
			parameters.Remove("OpeningHeight");

			// Test (25 1/2" x 66 5/8")
			parameters.Add("OpeningWidth", 25.5f);
			parameters.Add("OpeningHeight", 66.625f);
			Assert.AreEqual(21.8125f, productList[0].Logic["ResultingWidth"].Process(25.5f, parameters));
			Assert.AreEqual(65.0f, productList[0].Logic["ResultingHeight"].Process(66.625f, parameters));
			Assert.AreEqual(WallJamb.ZD1006, productList[0].Logic["WallJamb"].Process(25.5f, parameters));
			parameters.Remove("OpeningWidth");
			parameters.Remove("OpeningHeight");

			// Test (26 1/2" x 66 5/8")
			parameters.Add("OpeningWidth", 26.5f);
			parameters.Add("OpeningHeight", 66.625f);
			Assert.AreEqual(22.8125f, productList[0].Logic["ResultingWidth"].Process(26.5f, parameters));
			Assert.AreEqual(65.0f, productList[0].Logic["ResultingHeight"].Process(66.625f, parameters));
			Assert.AreEqual(WallJamb.ZD1006, productList[0].Logic["WallJamb"].Process(26.5f, parameters));
			parameters.Remove("OpeningWidth");
			parameters.Remove("OpeningHeight");

			// Test (27 1/2" x 66 5/8")
			parameters.Add("OpeningWidth", 27.5f);
			parameters.Add("OpeningHeight", 66.625f);
			Assert.AreEqual(23.8125f, productList[0].Logic["ResultingWidth"].Process(27.5f, parameters));
			Assert.AreEqual(65.0f, productList[0].Logic["ResultingHeight"].Process(66.625f, parameters));
			Assert.AreEqual(WallJamb.ZD1006, productList[0].Logic["WallJamb"].Process(27.5f, parameters));
			parameters.Remove("OpeningWidth");
			parameters.Remove("OpeningHeight");

			// Test (28 1/2" x 66 5/8")
			parameters.Add("OpeningWidth", 28.5f);
			parameters.Add("OpeningHeight", 66.625f);
			Assert.AreEqual(24.8125f, productList[0].Logic["ResultingWidth"].Process(28.5f, parameters));
			Assert.AreEqual(65.0f, productList[0].Logic["ResultingHeight"].Process(66.625f, parameters));
			Assert.AreEqual(WallJamb.ZD1006, productList[0].Logic["WallJamb"].Process(28.5f, parameters));
			parameters.Remove("OpeningWidth");
			parameters.Remove("OpeningHeight");

			// Test (29 1/2" x 66 5/8")
			parameters.Add("OpeningWidth", 29.5f);
			parameters.Add("OpeningHeight", 66.625f);
			Assert.AreEqual(25.8125f, productList[0].Logic["ResultingWidth"].Process(29.5f, parameters));
			Assert.AreEqual(65.0f, productList[0].Logic["ResultingHeight"].Process(66.625f, parameters));
			Assert.AreEqual(WallJamb.ZD1006, productList[0].Logic["WallJamb"].Process(29.5f, parameters));
			parameters.Remove("OpeningWidth");
			parameters.Remove("OpeningHeight");

			// Test (30 1/2" x 66 5/8")
			parameters.Add("OpeningWidth", 30.5f);
			parameters.Add("OpeningHeight", 66.625f);
			Assert.AreEqual(26.8125f, productList[0].Logic["ResultingWidth"].Process(30.5f, parameters));
			Assert.AreEqual(65.0f, productList[0].Logic["ResultingHeight"].Process(66.625f, parameters));
			Assert.AreEqual(WallJamb.ZD1006, productList[0].Logic["WallJamb"].Process(30.5f, parameters));
			parameters.Remove("OpeningWidth");
			parameters.Remove("OpeningHeight");

			// Test (25 3/4" x 66 5/8")
			parameters.Add("OpeningWidth", 25.75f);
			parameters.Add("OpeningHeight", 66.625f);
			Assert.AreEqual(22.8125f, productList[0].Logic["ResultingWidth"].Process(25.75f, parameters));
			Assert.AreEqual(65.0f, productList[0].Logic["ResultingHeight"].Process(66.625f, parameters));
			Assert.AreEqual(WallJamb.ZD1028, productList[0].Logic["WallJamb"].Process(25.75f, parameters));
			parameters.Remove("OpeningWidth");
			parameters.Remove("OpeningHeight");

			// Test (26 3/4" x 66 5/8")
			parameters.Add("OpeningWidth", 26.75f);
			parameters.Add("OpeningHeight", 66.625f);
			Assert.AreEqual(23.8125f, productList[0].Logic["ResultingWidth"].Process(26.75f, parameters));
			Assert.AreEqual(65.0f, productList[0].Logic["ResultingHeight"].Process(66.625f, parameters));
			Assert.AreEqual(WallJamb.ZD1028, productList[0].Logic["WallJamb"].Process(26.75f, parameters));
			parameters.Remove("OpeningWidth");
			parameters.Remove("OpeningHeight");

			// Test (27 3/4" x 66 5/8")
			parameters.Add("OpeningWidth", 27.75f);
			parameters.Add("OpeningHeight", 66.625f);
			Assert.AreEqual(24.8125f, productList[0].Logic["ResultingWidth"].Process(27.75f, parameters));
			Assert.AreEqual(65.0f, productList[0].Logic["ResultingHeight"].Process(66.625f, parameters));
			Assert.AreEqual(WallJamb.ZD1028, productList[0].Logic["WallJamb"].Process(27.75f, parameters));
			parameters.Remove("OpeningWidth");
			parameters.Remove("OpeningHeight");

			// Test (28 3/4" x 66 5/8")
			parameters.Add("OpeningWidth", 28.75f);
			parameters.Add("OpeningHeight", 66.625f);
			Assert.AreEqual(25.8125f, productList[0].Logic["ResultingWidth"].Process(28.75f, parameters));
			Assert.AreEqual(65.0f, productList[0].Logic["ResultingHeight"].Process(66.625f, parameters));
			Assert.AreEqual(WallJamb.ZD1028, productList[0].Logic["WallJamb"].Process(28.75f, parameters));
			parameters.Remove("OpeningWidth");
			parameters.Remove("OpeningHeight");

			// Test (29 3/4" x 66 5/8")
			parameters.Add("OpeningWidth", 29.75f);
			parameters.Add("OpeningHeight", 66.625f);
			Assert.AreEqual(26.8125f, productList[0].Logic["ResultingWidth"].Process(29.75f, parameters));
			Assert.AreEqual(65.0f, productList[0].Logic["ResultingHeight"].Process(66.625f, parameters));
			Assert.AreEqual(WallJamb.ZD1028, productList[0].Logic["WallJamb"].Process(29.75f, parameters));
			parameters.Remove("OpeningWidth");
			parameters.Remove("OpeningHeight");

			// Test (30 3/4" x 66 5/8")
			parameters.Add("OpeningWidth", 30.75f);
			parameters.Add("OpeningHeight", 66.625f);
			Assert.AreEqual(27.8125f, productList[0].Logic["ResultingWidth"].Process(30.75f, parameters));
			Assert.AreEqual(65.0f, productList[0].Logic["ResultingHeight"].Process(66.625f, parameters));
			Assert.AreEqual(WallJamb.ZD1028, productList[0].Logic["WallJamb"].Process(30.75f, parameters));
			parameters.Remove("OpeningWidth");
			parameters.Remove("OpeningHeight");

			// --- CD 36 Tests --- //

			// Test (30 13/16" x 66 5/8")
			parameters.Add("OpeningWidth", 30.8125f);
			parameters.Add("OpeningHeight", 66.625f);
			Assert.AreEqual(27.8125f, productList[0].Logic["ResultingWidth"].Process(30.8125f, parameters));
			Assert.AreEqual(65.0f, productList[0].Logic["ResultingHeight"].Process(66.625f, parameters));
			Assert.AreEqual(WallJamb.ZD1028, productList[0].Logic["WallJamb"].Process(30.8125f, parameters));
			parameters.Remove("OpeningWidth");
			parameters.Remove("OpeningHeight");

			// Test (31" x 66 5/8")
			parameters.Add("OpeningWidth", 31.0f);
			parameters.Add("OpeningHeight", 66.625f);
			Assert.AreEqual(27.8125f, productList[0].Logic["ResultingWidth"].Process(31.0f, parameters));
			Assert.AreEqual(65.0f, productList[0].Logic["ResultingHeight"].Process(66.625f, parameters));
			Assert.AreEqual(WallJamb.ZD1028, productList[0].Logic["WallJamb"].Process(31.0f, parameters));
			parameters.Remove("OpeningWidth");
			parameters.Remove("OpeningHeight");

			// Test (32" x 66 5/8")
			parameters.Add("OpeningWidth", 32.0f);
			parameters.Add("OpeningHeight", 66.625f);
			Assert.AreEqual(28.8125f, productList[0].Logic["ResultingWidth"].Process(32.0f, parameters));
			Assert.AreEqual(65.0f, productList[0].Logic["ResultingHeight"].Process(66.625f, parameters));
			Assert.AreEqual(WallJamb.ZD1028, productList[0].Logic["WallJamb"].Process(32.0f, parameters));
			parameters.Remove("OpeningWidth");
			parameters.Remove("OpeningHeight");

			// Test (33" x 66 5/8")
			parameters.Add("OpeningWidth", 33.0f);
			parameters.Add("OpeningHeight", 66.625f);
			Assert.AreEqual(29.8125f, productList[0].Logic["ResultingWidth"].Process(33.0f, parameters));
			Assert.AreEqual(65.0f, productList[0].Logic["ResultingHeight"].Process(66.625f, parameters));
			Assert.AreEqual(WallJamb.ZD1028, productList[0].Logic["WallJamb"].Process(33.0f, parameters));
			parameters.Remove("OpeningWidth");
			parameters.Remove("OpeningHeight");

			// Test (34" x 66 5/8")
			parameters.Add("OpeningWidth", 34.0f);
			parameters.Add("OpeningHeight", 66.625f);
			Assert.AreEqual(30.8125f, productList[0].Logic["ResultingWidth"].Process(34.0f, parameters));
			Assert.AreEqual(65.0f, productList[0].Logic["ResultingHeight"].Process(66.625f, parameters));
			Assert.AreEqual(WallJamb.ZD1028, productList[0].Logic["WallJamb"].Process(34.0f, parameters));
			parameters.Remove("OpeningWidth");
			parameters.Remove("OpeningHeight");

			// Test (35" x 66 5/8")
			parameters.Add("OpeningWidth", 35.0f);
			parameters.Add("OpeningHeight", 66.625f);
			Assert.AreEqual(31.8125f, productList[0].Logic["ResultingWidth"].Process(35.0f, parameters));
			Assert.AreEqual(65.0f, productList[0].Logic["ResultingHeight"].Process(66.625f, parameters));
			Assert.AreEqual(WallJamb.ZD1028, productList[0].Logic["WallJamb"].Process(35.0f, parameters));
			parameters.Remove("OpeningWidth");
			parameters.Remove("OpeningHeight");

			// Test (36" x 66 5/8")
			parameters.Add("OpeningWidth", 36.0f);
			parameters.Add("OpeningHeight", 66.625f);
			Assert.AreEqual(32.8125f, productList[0].Logic["ResultingWidth"].Process(36.0f, parameters));
			Assert.AreEqual(65.0f, productList[0].Logic["ResultingHeight"].Process(66.625f, parameters));
			Assert.AreEqual(WallJamb.ZD1028, productList[0].Logic["WallJamb"].Process(36.0f, parameters));
			parameters.Remove("OpeningWidth");
			parameters.Remove("OpeningHeight");

			// Test (31 1/2" x 66 5/8")
			parameters.Add("OpeningWidth", 31.5f);
			parameters.Add("OpeningHeight", 66.625f);
			Assert.AreEqual(27.8125f, productList[0].Logic["ResultingWidth"].Process(31.5f, parameters));
			Assert.AreEqual(65.0f, productList[0].Logic["ResultingHeight"].Process(66.625f, parameters));
			Assert.AreEqual(WallJamb.ZD1006, productList[0].Logic["WallJamb"].Process(31.5f, parameters));
			parameters.Remove("OpeningWidth");
			parameters.Remove("OpeningHeight");

			// Test (32 1/2" x 66 5/8")
			parameters.Add("OpeningWidth", 32.5f);
			parameters.Add("OpeningHeight", 66.625f);
			Assert.AreEqual(28.8125f, productList[0].Logic["ResultingWidth"].Process(32.5f, parameters));
			Assert.AreEqual(65.0f, productList[0].Logic["ResultingHeight"].Process(66.625f, parameters));
			Assert.AreEqual(WallJamb.ZD1006, productList[0].Logic["WallJamb"].Process(32.5f, parameters));
			parameters.Remove("OpeningWidth");
			parameters.Remove("OpeningHeight");

			// Test (33 1/2" x 66 5/8")
			parameters.Add("OpeningWidth", 33.5f);
			parameters.Add("OpeningHeight", 66.625f);
			Assert.AreEqual(29.8125f, productList[0].Logic["ResultingWidth"].Process(33.5f, parameters));
			Assert.AreEqual(65.0f, productList[0].Logic["ResultingHeight"].Process(66.625f, parameters));
			Assert.AreEqual(WallJamb.ZD1006, productList[0].Logic["WallJamb"].Process(33.5f, parameters));
			parameters.Remove("OpeningWidth");
			parameters.Remove("OpeningHeight");

			// Test (34 1/2" x 66 5/8")
			parameters.Add("OpeningWidth", 34.5f);
			parameters.Add("OpeningHeight", 66.625f);
			Assert.AreEqual(30.8125f, productList[0].Logic["ResultingWidth"].Process(34.5f, parameters));
			Assert.AreEqual(65.0f, productList[0].Logic["ResultingHeight"].Process(66.625f, parameters));
			Assert.AreEqual(WallJamb.ZD1006, productList[0].Logic["WallJamb"].Process(34.5f, parameters));
			parameters.Remove("OpeningWidth");
			parameters.Remove("OpeningHeight");

			// Test (35 1/2" x 66 5/8")
			parameters.Add("OpeningWidth", 35.5f);
			parameters.Add("OpeningHeight", 66.625f);
			Assert.AreEqual(31.8125f, productList[0].Logic["ResultingWidth"].Process(35.5f, parameters));
			Assert.AreEqual(65.0f, productList[0].Logic["ResultingHeight"].Process(66.625f, parameters));
			Assert.AreEqual(WallJamb.ZD1006, productList[0].Logic["WallJamb"].Process(35.5f, parameters));
			parameters.Remove("OpeningWidth");
			parameters.Remove("OpeningHeight");

			// Test (36 1/2" x 66 5/8")
			parameters.Add("OpeningWidth", 36.5f);
			parameters.Add("OpeningHeight", 66.625f);
			Assert.AreEqual(32.8125f, productList[0].Logic["ResultingWidth"].Process(36.5f, parameters));
			Assert.AreEqual(65.0f, productList[0].Logic["ResultingHeight"].Process(66.625f, parameters));
			Assert.AreEqual(WallJamb.ZD1006, productList[0].Logic["WallJamb"].Process(36.5f, parameters));
			parameters.Remove("OpeningWidth");
			parameters.Remove("OpeningHeight");

			// Test (31 3/4" x 66 5/8")
			parameters.Add("OpeningWidth", 31.75f);
			parameters.Add("OpeningHeight", 66.625f);
			Assert.AreEqual(28.8125f, productList[0].Logic["ResultingWidth"].Process(31.75f, parameters));
			Assert.AreEqual(65.0f, productList[0].Logic["ResultingHeight"].Process(66.625f, parameters));
			Assert.AreEqual(WallJamb.ZD1028, productList[0].Logic["WallJamb"].Process(31.75f, parameters));
			parameters.Remove("OpeningWidth");
			parameters.Remove("OpeningHeight");

			// Test (32 3/4" x 66 5/8")
			parameters.Add("OpeningWidth", 32.75f);
			parameters.Add("OpeningHeight", 66.625f);
			Assert.AreEqual(29.8125f, productList[0].Logic["ResultingWidth"].Process(32.75f, parameters));
			Assert.AreEqual(65.0f, productList[0].Logic["ResultingHeight"].Process(66.625f, parameters));
			Assert.AreEqual(WallJamb.ZD1028, productList[0].Logic["WallJamb"].Process(32.75f, parameters));
			parameters.Remove("OpeningWidth");
			parameters.Remove("OpeningHeight");

			// Test (33 3/4" x 66 5/8")
			parameters.Add("OpeningWidth", 33.75f);
			parameters.Add("OpeningHeight", 66.625f);
			Assert.AreEqual(30.8125f, productList[0].Logic["ResultingWidth"].Process(33.75f, parameters));
			Assert.AreEqual(65.0f, productList[0].Logic["ResultingHeight"].Process(66.625f, parameters));
			Assert.AreEqual(WallJamb.ZD1028, productList[0].Logic["WallJamb"].Process(33.75f, parameters));
			parameters.Remove("OpeningWidth");
			parameters.Remove("OpeningHeight");

			// Test (34 3/4" x 66 5/8")
			parameters.Add("OpeningWidth", 34.75f);
			parameters.Add("OpeningHeight", 66.625f);
			Assert.AreEqual(31.8125f, productList[0].Logic["ResultingWidth"].Process(34.75f, parameters));
			Assert.AreEqual(65.0f, productList[0].Logic["ResultingHeight"].Process(66.625f, parameters));
			Assert.AreEqual(WallJamb.ZD1028, productList[0].Logic["WallJamb"].Process(34.75f, parameters));
			parameters.Remove("OpeningWidth");
			parameters.Remove("OpeningHeight");

			// Test (35 3/4" x 66 5/8")
			parameters.Add("OpeningWidth", 35.75f);
			parameters.Add("OpeningHeight", 66.625f);
			Assert.AreEqual(32.8125f, productList[0].Logic["ResultingWidth"].Process(35.75f, parameters));
			Assert.AreEqual(65.0f, productList[0].Logic["ResultingHeight"].Process(66.625f, parameters));
			Assert.AreEqual(WallJamb.ZD1028, productList[0].Logic["WallJamb"].Process(35.75f, parameters));
			parameters.Remove("OpeningWidth");
			parameters.Remove("OpeningHeight");

			// --- CD 24-72 Tests --- //

			// Test (23 1/16" x 69 5/8")
			parameters.Add("OpeningWidth", 23.0625f);
			parameters.Add("OpeningHeight", 69.625f);
			Assert.AreEqual(19.8125f, productList[0].Logic["ResultingWidth"].Process(23.0625f, parameters));
			Assert.AreEqual(68.0f, productList[0].Logic["ResultingHeight"].Process(69.625f, parameters));
			Assert.AreEqual(WallJamb.ZD1028, productList[0].Logic["WallJamb"].Process(23.0625f, parameters));
			parameters.Remove("OpeningWidth");
			parameters.Remove("OpeningHeight");

			// Test (24 1/8" x 69 5/8")
			parameters.Add("OpeningWidth", 24.125f);
			parameters.Add("OpeningHeight", 69.625f);
			Assert.AreEqual(20.8125f, productList[0].Logic["ResultingWidth"].Process(24.125f, parameters));
			Assert.AreEqual(68.0f, productList[0].Logic["ResultingHeight"].Process(69.625f, parameters));
			Assert.AreEqual(WallJamb.ZD1028, productList[0].Logic["WallJamb"].Process(23.125f, parameters));
			parameters.Remove("OpeningWidth");
			parameters.Remove("OpeningHeight");

			// Test (23 1/2" x 69 5/8")
			parameters.Add("OpeningWidth", 23.5f);
			parameters.Add("OpeningHeight", 69.625f);
			Assert.AreEqual(19.8125f, productList[0].Logic["ResultingWidth"].Process(23.5f, parameters));
			Assert.AreEqual(68.0f, productList[0].Logic["ResultingHeight"].Process(69.625f, parameters));
			Assert.AreEqual(WallJamb.ZD1006, productList[0].Logic["WallJamb"].Process(23.5f, parameters));
			parameters.Remove("OpeningWidth");
			parameters.Remove("OpeningHeight");

			// Test (24 1/2" x 69 5/8")
			parameters.Add("OpeningWidth", 24.5f);
			parameters.Add("OpeningHeight", 69.625f);
			Assert.AreEqual(20.8125f, productList[0].Logic["ResultingWidth"].Process(24.5f, parameters));
			Assert.AreEqual(68.0f, productList[0].Logic["ResultingHeight"].Process(69.625f, parameters));
			Assert.AreEqual(WallJamb.ZD1006, productList[0].Logic["WallJamb"].Process(23.5f, parameters));
			parameters.Remove("OpeningWidth");
			parameters.Remove("OpeningHeight");

			// Test (22 3/4" x 69 5/8")
			parameters.Add("OpeningWidth", 22.75f);
			parameters.Add("OpeningHeight", 69.625f);
			Assert.AreEqual(19.8125f, productList[0].Logic["ResultingWidth"].Process(22.75f, parameters));
			Assert.AreEqual(68.0f, productList[0].Logic["ResultingHeight"].Process(69.625f, parameters));
			Assert.AreEqual(WallJamb.ZD1028, productList[0].Logic["WallJamb"].Process(22.75f, parameters));
			parameters.Remove("OpeningWidth");
			parameters.Remove("OpeningHeight");

			// Test (23 3/4" x 69 5/8")
			parameters.Add("OpeningWidth", 23.75f);
			parameters.Add("OpeningHeight", 69.625f);
			Assert.AreEqual(20.8125f, productList[0].Logic["ResultingWidth"].Process(23.75f, parameters));
			Assert.AreEqual(68.0f, productList[0].Logic["ResultingHeight"].Process(69.625f, parameters));
			Assert.AreEqual(WallJamb.ZD1028, productList[0].Logic["WallJamb"].Process(23.75f, parameters));
			parameters.Remove("OpeningWidth");
			parameters.Remove("OpeningHeight");

			// Test (24 3/4" x 69 5/8")
			parameters.Add("OpeningWidth", 24.75f);
			parameters.Add("OpeningHeight", 69.625f);
			Assert.AreEqual(21.8125f, productList[0].Logic["ResultingWidth"].Process(24.75f, parameters));
			Assert.AreEqual(68.0f, productList[0].Logic["ResultingHeight"].Process(69.625f, parameters));
			Assert.AreEqual(WallJamb.ZD1028, productList[0].Logic["WallJamb"].Process(24.75f, parameters));
			parameters.Remove("OpeningWidth");
			parameters.Remove("OpeningHeight");

			// --- CD 30-72 Tests --- //

			// Test (24 13/16" x 69 5/8")
			parameters.Add("OpeningWidth", 24.8125f);
			parameters.Add("OpeningHeight", 69.625f);
			Assert.AreEqual(21.8125f, productList[0].Logic["ResultingWidth"].Process(24.8125f, parameters));
			Assert.AreEqual(68.0f, productList[0].Logic["ResultingHeight"].Process(69.625f, parameters));
			Assert.AreEqual(WallJamb.ZD1028, productList[0].Logic["WallJamb"].Process(24.8125f, parameters));
			parameters.Remove("OpeningWidth");
			parameters.Remove("OpeningHeight");

			// Test (25" x 69 5/8")
			parameters.Add("OpeningWidth", 25.0f);
			parameters.Add("OpeningHeight", 69.625f);
			Assert.AreEqual(21.8125f, productList[0].Logic["ResultingWidth"].Process(25.0f, parameters));
			Assert.AreEqual(68.0f, productList[0].Logic["ResultingHeight"].Process(69.625f, parameters));
			Assert.AreEqual(WallJamb.ZD1028, productList[0].Logic["WallJamb"].Process(25.0f, parameters));
			parameters.Remove("OpeningWidth");
			parameters.Remove("OpeningHeight");

			// Test (26" x 69 5/8")
			parameters.Add("OpeningWidth", 26.0f);
			parameters.Add("OpeningHeight", 69.625f);
			Assert.AreEqual(22.8125f, productList[0].Logic["ResultingWidth"].Process(26.0f, parameters));
			Assert.AreEqual(68.0f, productList[0].Logic["ResultingHeight"].Process(69.625f, parameters));
			Assert.AreEqual(WallJamb.ZD1028, productList[0].Logic["WallJamb"].Process(26.0f, parameters));
			parameters.Remove("OpeningWidth");
			parameters.Remove("OpeningHeight");

			// Test (27" x 69 5/8")
			parameters.Add("OpeningWidth", 27.0f);
			parameters.Add("OpeningHeight", 69.625f);
			Assert.AreEqual(23.8125f, productList[0].Logic["ResultingWidth"].Process(27.0f, parameters));
			Assert.AreEqual(68.0f, productList[0].Logic["ResultingHeight"].Process(69.625f, parameters));
			Assert.AreEqual(WallJamb.ZD1028, productList[0].Logic["WallJamb"].Process(27.0f, parameters));
			parameters.Remove("OpeningWidth");
			parameters.Remove("OpeningHeight");

			// Test (28" x 69 5/8")
			parameters.Add("OpeningWidth", 28.0f);
			parameters.Add("OpeningHeight", 69.625f);
			Assert.AreEqual(24.8125f, productList[0].Logic["ResultingWidth"].Process(28.0f, parameters));
			Assert.AreEqual(68.0f, productList[0].Logic["ResultingHeight"].Process(69.625f, parameters));
			Assert.AreEqual(WallJamb.ZD1028, productList[0].Logic["WallJamb"].Process(28.0f, parameters));
			parameters.Remove("OpeningWidth");
			parameters.Remove("OpeningHeight");

			// Test (29" x 69 5/8")
			parameters.Add("OpeningWidth", 29.0f);
			parameters.Add("OpeningHeight", 69.625f);
			Assert.AreEqual(25.8125f, productList[0].Logic["ResultingWidth"].Process(29.0f, parameters));
			Assert.AreEqual(68.0f, productList[0].Logic["ResultingHeight"].Process(69.625f, parameters));
			Assert.AreEqual(WallJamb.ZD1028, productList[0].Logic["WallJamb"].Process(29.0f, parameters));
			parameters.Remove("OpeningWidth");
			parameters.Remove("OpeningHeight");

			// Test (30" x 69 5/8")
			parameters.Add("OpeningWidth", 30.0f);
			parameters.Add("OpeningHeight", 69.625f);
			Assert.AreEqual(26.8125f, productList[0].Logic["ResultingWidth"].Process(30.0f, parameters));
			Assert.AreEqual(68.0f, productList[0].Logic["ResultingHeight"].Process(69.625f, parameters));
			Assert.AreEqual(WallJamb.ZD1028, productList[0].Logic["WallJamb"].Process(30.0f, parameters));
			parameters.Remove("OpeningWidth");
			parameters.Remove("OpeningHeight");

			// Test (25 1/2" x 69 5/8")
			parameters.Add("OpeningWidth", 25.5f);
			parameters.Add("OpeningHeight", 69.625f);
			Assert.AreEqual(21.8125f, productList[0].Logic["ResultingWidth"].Process(25.5f, parameters));
			Assert.AreEqual(68.0f, productList[0].Logic["ResultingHeight"].Process(69.625f, parameters));
			Assert.AreEqual(WallJamb.ZD1006, productList[0].Logic["WallJamb"].Process(25.5f, parameters));
			parameters.Remove("OpeningWidth");
			parameters.Remove("OpeningHeight");

			// Test (26 1/2" x 69 5/8")
			parameters.Add("OpeningWidth", 26.5f);
			parameters.Add("OpeningHeight", 69.625f);
			Assert.AreEqual(22.8125f, productList[0].Logic["ResultingWidth"].Process(26.5f, parameters));
			Assert.AreEqual(68.0f, productList[0].Logic["ResultingHeight"].Process(69.625f, parameters));
			Assert.AreEqual(WallJamb.ZD1006, productList[0].Logic["WallJamb"].Process(26.5f, parameters));
			parameters.Remove("OpeningWidth");
			parameters.Remove("OpeningHeight");

			// Test (27 1/2" x 69 5/8")
			parameters.Add("OpeningWidth", 27.5f);
			parameters.Add("OpeningHeight", 69.625f);
			Assert.AreEqual(23.8125f, productList[0].Logic["ResultingWidth"].Process(27.5f, parameters));
			Assert.AreEqual(68.0f, productList[0].Logic["ResultingHeight"].Process(69.625f, parameters));
			Assert.AreEqual(WallJamb.ZD1006, productList[0].Logic["WallJamb"].Process(27.5f, parameters));
			parameters.Remove("OpeningWidth");
			parameters.Remove("OpeningHeight");

			// Test (28 1/2" x 69 5/8")
			parameters.Add("OpeningWidth", 28.5f);
			parameters.Add("OpeningHeight", 69.625f);
			Assert.AreEqual(24.8125f, productList[0].Logic["ResultingWidth"].Process(28.5f, parameters));
			Assert.AreEqual(68.0f, productList[0].Logic["ResultingHeight"].Process(69.625f, parameters));
			Assert.AreEqual(WallJamb.ZD1006, productList[0].Logic["WallJamb"].Process(28.5f, parameters));
			parameters.Remove("OpeningWidth");
			parameters.Remove("OpeningHeight");

			// Test (29 1/2" x 69 5/8")
			parameters.Add("OpeningWidth", 29.5f);
			parameters.Add("OpeningHeight", 69.625f);
			Assert.AreEqual(25.8125f, productList[0].Logic["ResultingWidth"].Process(29.5f, parameters));
			Assert.AreEqual(68.0f, productList[0].Logic["ResultingHeight"].Process(69.625f, parameters));
			Assert.AreEqual(WallJamb.ZD1006, productList[0].Logic["WallJamb"].Process(29.5f, parameters));
			parameters.Remove("OpeningWidth");
			parameters.Remove("OpeningHeight");

			// Test (30 1/2" x 69 5/8")
			parameters.Add("OpeningWidth", 30.5f);
			parameters.Add("OpeningHeight", 69.625f);
			Assert.AreEqual(26.8125f, productList[0].Logic["ResultingWidth"].Process(30.5f, parameters));
			Assert.AreEqual(68.0f, productList[0].Logic["ResultingHeight"].Process(69.625f, parameters));
			Assert.AreEqual(WallJamb.ZD1006, productList[0].Logic["WallJamb"].Process(30.5f, parameters));
			parameters.Remove("OpeningWidth");
			parameters.Remove("OpeningHeight");

			// Test (25 3/4" x 69 5/8")
			parameters.Add("OpeningWidth", 25.75f);
			parameters.Add("OpeningHeight", 69.625f);
			Assert.AreEqual(22.8125f, productList[0].Logic["ResultingWidth"].Process(25.75f, parameters));
			Assert.AreEqual(68.0f, productList[0].Logic["ResultingHeight"].Process(69.625f, parameters));
			Assert.AreEqual(WallJamb.ZD1028, productList[0].Logic["WallJamb"].Process(25.75f, parameters));
			parameters.Remove("OpeningWidth");
			parameters.Remove("OpeningHeight");

			// Test (26 3/4" x 69 5/8")
			parameters.Add("OpeningWidth", 26.75f);
			parameters.Add("OpeningHeight", 69.625f);
			Assert.AreEqual(23.8125f, productList[0].Logic["ResultingWidth"].Process(26.75f, parameters));
			Assert.AreEqual(68.0f, productList[0].Logic["ResultingHeight"].Process(69.625f, parameters));
			Assert.AreEqual(WallJamb.ZD1028, productList[0].Logic["WallJamb"].Process(26.75f, parameters));
			parameters.Remove("OpeningWidth");
			parameters.Remove("OpeningHeight");

			// Test (27 3/4" x 69 5/8")
			parameters.Add("OpeningWidth", 27.75f);
			parameters.Add("OpeningHeight", 69.625f);
			Assert.AreEqual(24.8125f, productList[0].Logic["ResultingWidth"].Process(27.75f, parameters));
			Assert.AreEqual(68.0f, productList[0].Logic["ResultingHeight"].Process(69.625f, parameters));
			Assert.AreEqual(WallJamb.ZD1028, productList[0].Logic["WallJamb"].Process(27.75f, parameters));
			parameters.Remove("OpeningWidth");
			parameters.Remove("OpeningHeight");

			// Test (28 3/4" x 69 5/8")
			parameters.Add("OpeningWidth", 28.75f);
			parameters.Add("OpeningHeight", 69.625f);
			Assert.AreEqual(25.8125f, productList[0].Logic["ResultingWidth"].Process(28.75f, parameters));
			Assert.AreEqual(68.0f, productList[0].Logic["ResultingHeight"].Process(69.625f, parameters));
			Assert.AreEqual(WallJamb.ZD1028, productList[0].Logic["WallJamb"].Process(28.75f, parameters));
			parameters.Remove("OpeningWidth");
			parameters.Remove("OpeningHeight");

			// Test (29 3/4" x 69 5/8")
			parameters.Add("OpeningWidth", 29.75f);
			parameters.Add("OpeningHeight", 69.625f);
			Assert.AreEqual(26.8125f, productList[0].Logic["ResultingWidth"].Process(29.75f, parameters));
			Assert.AreEqual(68.0f, productList[0].Logic["ResultingHeight"].Process(69.625f, parameters));
			Assert.AreEqual(WallJamb.ZD1028, productList[0].Logic["WallJamb"].Process(29.75f, parameters));
			parameters.Remove("OpeningWidth");
			parameters.Remove("OpeningHeight");

			// Test (30 3/4" x 69 5/8")
			parameters.Add("OpeningWidth", 30.75f);
			parameters.Add("OpeningHeight", 69.625f);
			Assert.AreEqual(27.8125f, productList[0].Logic["ResultingWidth"].Process(30.75f, parameters));
			Assert.AreEqual(68.0f, productList[0].Logic["ResultingHeight"].Process(69.625f, parameters));
			Assert.AreEqual(WallJamb.ZD1028, productList[0].Logic["WallJamb"].Process(30.75f, parameters));
			parameters.Remove("OpeningWidth");
			parameters.Remove("OpeningHeight");

			// --- CD 36-72 Tests --- //

			// Test (30 13/16" x 69 5/8")
			parameters.Add("OpeningWidth", 30.8125f);
			parameters.Add("OpeningHeight", 69.625f);
			Assert.AreEqual(27.8125f, productList[0].Logic["ResultingWidth"].Process(30.8125f, parameters));
			Assert.AreEqual(68.0f, productList[0].Logic["ResultingHeight"].Process(69.625f, parameters));
			Assert.AreEqual(WallJamb.ZD1028, productList[0].Logic["WallJamb"].Process(30.8125f, parameters));
			parameters.Remove("OpeningWidth");
			parameters.Remove("OpeningHeight");

			// Test (31" x 69 5/8")
			parameters.Add("OpeningWidth", 31.0f);
			parameters.Add("OpeningHeight", 69.625f);
			Assert.AreEqual(27.8125f, productList[0].Logic["ResultingWidth"].Process(31.0f, parameters));
			Assert.AreEqual(68.0f, productList[0].Logic["ResultingHeight"].Process(69.625f, parameters));
			Assert.AreEqual(WallJamb.ZD1028, productList[0].Logic["WallJamb"].Process(31.0f, parameters));
			parameters.Remove("OpeningWidth");
			parameters.Remove("OpeningHeight");

			// Test (32" x 69 5/8")
			parameters.Add("OpeningWidth", 32.0f);
			parameters.Add("OpeningHeight", 69.625f);
			Assert.AreEqual(28.8125f, productList[0].Logic["ResultingWidth"].Process(32.0f, parameters));
			Assert.AreEqual(68.0f, productList[0].Logic["ResultingHeight"].Process(69.625f, parameters));
			Assert.AreEqual(WallJamb.ZD1028, productList[0].Logic["WallJamb"].Process(32.0f, parameters));
			parameters.Remove("OpeningWidth");
			parameters.Remove("OpeningHeight");

			// Test (33" x 69 5/8")
			parameters.Add("OpeningWidth", 33.0f);
			parameters.Add("OpeningHeight", 69.625f);
			Assert.AreEqual(29.8125f, productList[0].Logic["ResultingWidth"].Process(33.0f, parameters));
			Assert.AreEqual(68.0f, productList[0].Logic["ResultingHeight"].Process(69.625f, parameters));
			Assert.AreEqual(WallJamb.ZD1028, productList[0].Logic["WallJamb"].Process(33.0f, parameters));
			parameters.Remove("OpeningWidth");
			parameters.Remove("OpeningHeight");

			// Test (34" x 69 5/8")
			parameters.Add("OpeningWidth", 34.0f);
			parameters.Add("OpeningHeight", 69.625f);
			Assert.AreEqual(30.8125f, productList[0].Logic["ResultingWidth"].Process(34.0f, parameters));
			Assert.AreEqual(68.0f, productList[0].Logic["ResultingHeight"].Process(69.625f, parameters));
			Assert.AreEqual(WallJamb.ZD1028, productList[0].Logic["WallJamb"].Process(34.0f, parameters));
			parameters.Remove("OpeningWidth");
			parameters.Remove("OpeningHeight");

			// Test (31 1/2" x 69 5/8")
			parameters.Add("OpeningWidth", 31.5f);
			parameters.Add("OpeningHeight", 69.625f);
			Assert.AreEqual(27.8125f, productList[0].Logic["ResultingWidth"].Process(31.5f, parameters));
			Assert.AreEqual(68.0f, productList[0].Logic["ResultingHeight"].Process(69.625f, parameters));
			Assert.AreEqual(WallJamb.ZD1006, productList[0].Logic["WallJamb"].Process(31.5f, parameters));
			parameters.Remove("OpeningWidth");
			parameters.Remove("OpeningHeight");

			// Test (32 1/2" x 69 5/8")
			parameters.Add("OpeningWidth", 32.5f);
			parameters.Add("OpeningHeight", 69.625f);
			Assert.AreEqual(28.8125f, productList[0].Logic["ResultingWidth"].Process(32.5f, parameters));
			Assert.AreEqual(68.0f, productList[0].Logic["ResultingHeight"].Process(69.625f, parameters));
			Assert.AreEqual(WallJamb.ZD1006, productList[0].Logic["WallJamb"].Process(32.5f, parameters));
			parameters.Remove("OpeningWidth");
			parameters.Remove("OpeningHeight");

			// Test (33 1/2" x 69 5/8")
			parameters.Add("OpeningWidth", 33.5f);
			parameters.Add("OpeningHeight", 69.625f);
			Assert.AreEqual(29.8125f, productList[0].Logic["ResultingWidth"].Process(33.5f, parameters));
			Assert.AreEqual(68.0f, productList[0].Logic["ResultingHeight"].Process(69.625f, parameters));
			Assert.AreEqual(WallJamb.ZD1006, productList[0].Logic["WallJamb"].Process(33.5f, parameters));
			parameters.Remove("OpeningWidth");
			parameters.Remove("OpeningHeight");

			// Test (34 1/2" x 69 5/8")
			parameters.Add("OpeningWidth", 34.5f);
			parameters.Add("OpeningHeight", 69.625f);
			Assert.AreEqual(30.8125f, productList[0].Logic["ResultingWidth"].Process(34.5f, parameters));
			Assert.AreEqual(68.0f, productList[0].Logic["ResultingHeight"].Process(69.625f, parameters));
			Assert.AreEqual(WallJamb.ZD1006, productList[0].Logic["WallJamb"].Process(34.5f, parameters));
			parameters.Remove("OpeningWidth");
			parameters.Remove("OpeningHeight");

			// Test (31 3/4" x 69 5/8")
			parameters.Add("OpeningWidth", 31.75f);
			parameters.Add("OpeningHeight", 69.625f);
			Assert.AreEqual(28.8125f, productList[0].Logic["ResultingWidth"].Process(31.75f, parameters));
			Assert.AreEqual(68.0f, productList[0].Logic["ResultingHeight"].Process(69.625f, parameters));
			Assert.AreEqual(WallJamb.ZD1028, productList[0].Logic["WallJamb"].Process(31.75f, parameters));
			parameters.Remove("OpeningWidth");
			parameters.Remove("OpeningHeight");

			// Test (32 3/4" x 69 5/8")
			parameters.Add("OpeningWidth", 32.75f);
			parameters.Add("OpeningHeight", 69.625f);
			Assert.AreEqual(29.8125f, productList[0].Logic["ResultingWidth"].Process(32.75f, parameters));
			Assert.AreEqual(68.0f, productList[0].Logic["ResultingHeight"].Process(69.625f, parameters));
			Assert.AreEqual(WallJamb.ZD1028, productList[0].Logic["WallJamb"].Process(32.75f, parameters));
			parameters.Remove("OpeningWidth");
			parameters.Remove("OpeningHeight");

			// Test (33 3/4" x 69 5/8")
			parameters.Add("OpeningWidth", 33.75f);
			parameters.Add("OpeningHeight", 69.625f);
			Assert.AreEqual(30.8125f, productList[0].Logic["ResultingWidth"].Process(33.75f, parameters));
			Assert.AreEqual(68.0f, productList[0].Logic["ResultingHeight"].Process(69.625f, parameters));
			Assert.AreEqual(WallJamb.ZD1028, productList[0].Logic["WallJamb"].Process(33.75f, parameters));
			parameters.Remove("OpeningWidth");
			parameters.Remove("OpeningHeight");
		}
	}
}