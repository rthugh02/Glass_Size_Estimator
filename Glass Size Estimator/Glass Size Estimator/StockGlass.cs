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

		public override bool Equals(object obj)
		{
			var target = obj as StockGlass;

			return (this.Width == target.Width && this.Height == target.Height);
		}

		public override int GetHashCode()
		{
			var hashCode = 859600377;
			hashCode = hashCode * -1521134295 + Width.GetHashCode();
			hashCode = hashCode * -1521134295 + Height.GetHashCode();
			return hashCode;
		}
	}
}
