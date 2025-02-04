using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PlugInFinal;

namespace HelpPlugin
{
    public class Help : IPlugin
    {
        public string name()
        {
            return "--help";
        }
        public string description()
        {
            return "Displays manual";
        }
        public string Execute(string input)
        {
            string output = "";
            List<IPlugin> plugins = Program.LoadPlugins();
            Console.WriteLine("Syntax: PlugInFinal.exe {command} {input}");
            Console.WriteLine("Commands:");
            foreach (IPlugin plugin_it in plugins)
            {
                Console.WriteLine("\t" + plugin_it.name() + " -> " + plugin_it.description());
            }
            return output;

        }
    }
}
