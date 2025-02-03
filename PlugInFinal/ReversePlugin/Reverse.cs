using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PlugInFinal;


namespace ReversePlugin
{
    public class Reverse : IPlugin
    {
        public string name()
        {
            return "--reverse";
        }

        public string description()
        {
            return "Reverses given input";
        }
        public string Execute(string input)
        {
            string output = "";
            int inputLen = input.Length;
            for (int i = inputLen-1; i >= 0; i--)
            {
                output += input[i];
            }

            return output;
        }
    }
}
