using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Glass_Size_Estimator
{
    public partial class Main : Form
    {
        private List<ProductLine> productLines;
        public Main(List<ProductLine> ConfigProductLines)
        {
            productLines = ConfigProductLines;
            InitializeComponent();
        }

        private void ProductLineSelector_SelectedIndexChanged(object sender, EventArgs e)
        {
            /*TODO: Code that will run when a new product line is selected. Function should:
             * 1. Remove non-static UI elements and rebuild form with the required input boxes for measurements
             * as well as output boxes.
             */
        }
    }
}
