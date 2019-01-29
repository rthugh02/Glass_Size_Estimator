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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            TableLayoutPanel layoutPanel = new TableLayoutPanel();
            layoutPanel.Size = new Size(620, 100);
            layoutPanel.Location = new Point(10, 20);

            layoutPanel.AutoSizeMode = AutoSizeMode.GrowAndShrink;

            layoutPanel.Controls.Add(new Label { Text = "Testing" });

            this.Controls.Add(layoutPanel);
        }
    }
}
