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
		public ProductLine(dynamic JSONProductLine)
		{
			this.Name = (string)JSONProductLine.Name;
			Logic = new Dictionary<string, StateMachine>();
			FloatInputs = new List<string>();
			EnumInputs = new List<string>();
			BoolInputs = new List<string>();
			IntInputs = new List<string>();
			FloatOutputs = new List<string>();
			EnumOutputs = new List<string>();
			BoolOutputs = new List<string>();
			CoordOutputs = new List<string>();

			foreach (string i in JSONProductLine.Input)
			{
				if (i.Equals("OpeningWidth", StringComparison.OrdinalIgnoreCase) || i.Equals("OpeningHeight", StringComparison.OrdinalIgnoreCase))
					FloatInputs.Add(i);

				else if (i.Equals("ClearSweep", StringComparison.OrdinalIgnoreCase))
					BoolInputs.Add(i);

			}
		}

		public string Name { get; set; } // The name of the product line
		public List<IO> Input { get; set; } // The types of inputs that will be used for the product line
		public List<string> FloatInputs { get; set; } //List of names of float input values
		public List<string> EnumInputs { get; set; } //List for enum inputs needed
		public List<string> BoolInputs { get; set; } //List for boolean inputs needed
		public List<string> IntInputs { get; set; } //List for int inputs needed
		public List<string> FloatOutputs { get; set; } //As above, so below
		public List<string> BoolOutputs { get; set; }
		public List<string> EnumOutputs { get; set; }
		public List<string> CoordOutputs { get; set; }
		public List<IO> Output { get; set; } // The types of outputs that will be used for the product line
		public Dictionary<string, StateMachine> Logic { get; set; } // A collection of state machines that will be used for the product line output calculations
	}
}
