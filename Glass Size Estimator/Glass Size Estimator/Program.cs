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

            string fextension = ".json";
            var myFiles = Directory.GetFiles(Directory.GetCurrentDirectory(), "*.*", SearchOption.AllDirectories)
            .Where(s => fextension.Contains(Path.GetExtension(s)));
            List<ProductLine> configsRead = new List<ProductLine>();
            foreach (var file in myFiles)
            {
                using (var stream = new StreamReader(file))//put a test file in your bin/Debug/ folder to see this in action
                {
                    string json_data = stream.ReadToEnd();
                    dynamic productList = JsonConvert.DeserializeObject<Object>(json_data); //A dynamic object has dynamic runtime properties that can be referenced even though the compiler doesn't know what they are
                    // Look at each product line in the config
                    foreach (var productLine in productList.ProductLines)
                    {
                        // Look at each logic tree for each possible output
                        foreach (var outputLogic in productLine.Logic)
                        {
                            // Look at each state in the logic tree
                            for (int i = 0; i < outputLogic.First.Count; i++)
                            {
                                var state = outputLogic.First[i];
                                if ((new List<string> { "Addition", "Subtraction", "Multiplication", "Division" }).Any(s => s.Equals((string)state.Operation, StringComparison.OrdinalIgnoreCase)))
                                {
                                    //As an example, if we read in this JSON object and loop through each of the states, we can test if they are an ArithmeticState with this conditional
                                    //For simplicity, assuming this is a subtraction state:
                                    SubtractionState sState = new SubtractionState();
                                    sState.StateNumber = i; // The state number is calculate based off the order of the operations in the JSON file
                                    sState.NextState = i + 1; // By default the next step will be the next operation
                                    sState.Value = (int)state.Value;

                                }
                            }
                        }
                    }
                    //configsRead.Add(productLine);
                }
            }


            Application.Run(new Main(configsRead));
        }
    }
}
