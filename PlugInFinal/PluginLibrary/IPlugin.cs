using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlugInFinal
{
    public interface IPlugin
    {
        string name();

        string description();

        string Execute(string input);
    }
}
