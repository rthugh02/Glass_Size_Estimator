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
            foreach (var product in productLines)
            {
                ProductLineSelector.Items.Add(product.Name);
            }
            ProductLineSelector.ShowItemToolTips = true;
        }

        private void ProductLineSelector_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
