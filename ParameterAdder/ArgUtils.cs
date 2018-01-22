using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParameterAdder
{
    public static class ArgUtils
    {
        public static Args ParseArgs(string[] args)
        {
            if (args.Length != 3 && args.Length != 4)
            {
                throw new Exception("Invalid number of arguments supplied.");
            }

            var arguments = new Args
            {
                SectionName = args[0],
                ParameterName = args[1],
                DefaultParameterValue = args[2]
            };

            if (args.Length == 4)
            {
                arguments.ApplicationRoot = args[3];
            }
            else
            {
                arguments.ApplicationRoot = Directory.GetCurrentDirectory();
            };

            return arguments;
        }
    }
}
