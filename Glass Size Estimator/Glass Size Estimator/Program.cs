using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.Diagnostics;

namespace Glass_Size_Estimator
{
	static class Program
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);

			//Code Ran before window is brought to screen, this is where available JSON configs should be loaded

			// Retrieve all json files in the current directory
			string fextension = ".json";
			var myFiles = Directory.GetFiles(Directory.GetCurrentDirectory(), "*.*", SearchOption.AllDirectories)
			.Where(s => fextension.Contains(Path.GetExtension(s)));

			// Initialize the list of products
			List<ProductLine> productList = new List<ProductLine>();

			// Initialize the list of stock glass
			Dictionary<string, StockGlassLine> stockGlassList = new Dictionary<string, StockGlassLine>();

			// Analyze each file
			foreach (var file in myFiles)
			{
				// Parse the product line logic
				if (file.Contains("product_line_config.json"))
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
				// Parse the stock glass line inventory
				else if (file.Contains("stock_glass_line_config.json"))
				{
					using (var stream = new StreamReader(file))//put a test file in your bin/Debug/ folder to see this in action
					{
						string json_data = stream.ReadToEnd();
						dynamic stockGlassListJson = JsonConvert.DeserializeObject<Object>(json_data); //A dynamic object has dynamic runtime properties that can be referenced even though the compiler doesn't know what they are

						foreach (var stockGlassLine in stockGlassListJson) // Look at each stock glass line in the config
						{
							// Create a new stock glass line
							StockGlassLine stockLine = new StockGlassLine();

							foreach (var size in stockGlassLine.First) // Add each possible size to the stock glass line
							{
								stockLine.AvailableStockGlass.Add(new StockGlass((float)size.Width, (float)size.Height));
							}

							// Once all of the sizes have been added, add the stock glass line to the product list
							stockGlassList.Add((string)stockGlassLine.Name, stockLine);
						}
					}
				}
			}

			// Start the application
			Application.Run(new Main(productList, stockGlassList));
		}
	}
}
