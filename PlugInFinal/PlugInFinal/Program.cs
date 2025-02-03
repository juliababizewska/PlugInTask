using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace PlugInFinal
{
    public class Program
    {

        private static List<IPlugin> plugins;

        static void Main(string[] args)
        {
            string command = args[0];

            plugins = LoadPlugins();

            if (command == "--help")
            {
                displayManual();
                return;
            }

            if (args.Length != 2)
            {
                Console.WriteLine("Error! Two arguments expected.");
                displayManual();
                return;
            }

            string argument = args[1];

            IPlugin plugin = plugins.Find(p => p.name() == command);
            if (plugin == null)
            {
                Console.WriteLine("Plugin not found, try again");
            }
            else
            {
                Console.WriteLine(plugin.Execute(argument));
            }

        }

        private static void displayManual()
        {
            Console.WriteLine("Syntax: PlugInFinal.exe {command} {input}");
            Console.WriteLine("Commands:");
            foreach (IPlugin plugin_it in plugins)
            {
                Console.WriteLine("\t" + plugin_it.name() + " -> " + plugin_it.description());
            }
        }

        public static List<IPlugin> LoadPlugins()
        {
            List<IPlugin> plugins = new List<IPlugin>();

            string pluginsPath = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\Plugins"));
            
            //Console.WriteLine($"Path to plugins folder: {pluginsPath}");
            
            foreach (string file in Directory.GetFiles(pluginsPath, "*.dll"))
            {
                try
                {
                    Assembly assembly = Assembly.LoadFrom(file);
                    Type[] types = assembly.GetTypes();
                    
                    foreach (var type in types)
                    {
                        if (type.IsInterface)
                        {
                            continue;
                        }

                        IPlugin plugin = (IPlugin)Activator.CreateInstance(type);
                        plugins.Add(plugin);

                    }

                }

                catch (Exception e)
                {
                    Console.WriteLine($"Error loading plugins: {e.Message}");
                    displayManual();
                }
            }
            
            return plugins;
        }

    }
}
