using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Glass_Size_Estimator
{
	public class StockGlass
	{
		// Constructor
		public StockGlass(float width, float height)
		{
			this.Width = width;
			this.Height = height;
		}

		public float Width { get; set; } // The width of the stock glass
		public float Height { get; set; } // The height of the stock glass
	}
}
