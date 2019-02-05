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
        }

        private void ProductLineSelector_SelectedIndexChanged(object sender, EventArgs e)
        {
            //retrieving productline object based on selectedItem
            string selectedItem = ProductLineSelector.SelectedItems[0].Text;
            ProductLine productLine = productLines.Where(n => n.Name.Equals(selectedItem)).First();

            //TODO: loop through inputs and examine their type, add corresponding element to input layout
            //TODO: Do the same for outputs
        }
    }
}
