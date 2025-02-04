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

        static List<IPlugin> plugins;


        public static List<IPlugin> getPlugins()
        {
            return plugins;
        }

        static void Main(string[] args)
        {
            plugins = LoadPlugins();
            string command = args[0];

            //foreach ( IPlugin plugin_test in plugins)
            //{
            //    Console.WriteLine(plugin_test.ToString());
            //}
            
            if (command == "--help")
            {
                IPlugin help = plugins.Find(p => p.name() == command);
                Console.WriteLine(help.Execute(""));
                return;
            }

            if (args.Length != 2)
            {
                Console.WriteLine("Error! Incorrect input. See --help to explore plugins.");
                return;
            }

            string argument = args[1];

            IPlugin plugin = plugins.Find(p => p.name() == command);
            if (plugin == null)
            {
                Console.WriteLine("Plugin not found, try again. See --help to explore plugins.");
            }
            else
            {
                Console.WriteLine(plugin.Execute(argument));
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
                }
            }
            
            return plugins;
        }

    }
}
