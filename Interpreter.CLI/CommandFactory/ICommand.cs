﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interpreter.CLI
{
	public interface ICommand
	{
		void Execute(string[] args, CommandManager manager);
	}
}
