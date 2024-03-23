using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interpreter.CLI
{
	public class CommandManager
	{
		public string FilePath { get; set; }

		public void LoadFile(string filePath)
		{
            Console.WriteLine($"Loading/Reloading file {filePath}");
            // Implement file loading logic here
        }
	}
}
