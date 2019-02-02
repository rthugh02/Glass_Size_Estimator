using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Glass_Size_Estimator
{
	public class ProductLine
	{
		public string Name { get; set; }
		public List<IO> Input { get; set; }
		public List<IO> Output { get; set; }
		public List<State> Logic { get; set; }
	}
}
