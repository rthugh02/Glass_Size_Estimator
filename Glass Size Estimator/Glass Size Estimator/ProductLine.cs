using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Glass_Size_Estimator
{
	public class ProductLine
	{
		// Constructor
		public ProductLine(string name)
		{
			this.Name = name;
			Logic = new Dictionary<string, List<State>>();
		}

		public string Name { get; set; } // The name of the product line
		public List<IO> Input { get; set; } // The types of inputs that will be used for the product line
		public List<IO> Output { get; set; } // The types of outputs that will be used for the product line
		public Dictionary<string, List<State>> Logic { get; set; } // A collection of lists of states that will be used for the product line output calculations
	}
}
