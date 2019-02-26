using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Glass_Size_Estimator
{
	public class StockGlassLine
	{
		// Constructor
		public StockGlassLine()
		{
			this.AvailableStockGlass = new List<StockGlass>();
		}

		public List<StockGlass> AvailableStockGlass { get; set; } // A list of stock sizes available

		// Determine if the given glass measurement is available in the stock glass line
		public bool Contains(float width, float height)
		{
			StockGlass temp = new StockGlass(width, height);

			foreach (StockGlass stockGlass in AvailableStockGlass)
			{
				if (stockGlass.Equals(temp))
				{
					return true;
				}
			}

			return false;
		}
	}
}
