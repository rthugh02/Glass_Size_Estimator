using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Glass_Size_Estimator
{
    public class State
    {
        public int StepNumber { get; set; } //Current step this state represents
        public int NextStep { get; set; } //Next step to go to after operation
        public string Input { get; set; } //Input to the state
        public string Operation { get; set; } //Operation to be performed, currently set to be string as a placeholder
        public int Constant { get; set; } //Constant to be used in operation, like dividing by 2
    }
}
