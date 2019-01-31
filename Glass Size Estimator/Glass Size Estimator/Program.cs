using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace Glass_Size_Estimator
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Code Ran before window is brought to screen, this is where available JSON configs should be loaded 
            using (var stream = new StreamReader(@"test.json"))//put a test file in your bin/Debug/ folder to see this in action
            {
                string json_data = stream.ReadToEnd();
                ProductLine productLine = JsonConvert.DeserializeObject<ProductLine>(json_data);
            }
            Application.Run(new Form1());
        }
    }
}
