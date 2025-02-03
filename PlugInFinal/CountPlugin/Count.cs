using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PlugInFinal;


namespace CountPlugin
{
    public class Count : IPlugin
    {
        public string name()
        {
            return "--count";
        }    

        public string description()
        {
            return "Returns the length of the input";
        }

        public string Execute(string input)
        {
            return input.Length.ToString();
        }
    }
}
