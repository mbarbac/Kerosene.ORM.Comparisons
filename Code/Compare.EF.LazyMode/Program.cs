using Compare.Common;
using Kerosene.ORM.DataDB;
using Kerosene.Tools;
using System;

namespace Compare.EF.LazyMode
{
	// ==================================================== 
	class Program
	{
		static void Main(string[] args)
		{
			DebugEx.IndentSize = 2;
			DebugEx.AutoFlush = true;
			DebugEx.AddConsoleListener();
			ConsoleEx.AskInteractive();

			DB.Prepare(restricted: Defaults.Restricted);
			Test_EFLazyMode.Calculate();

			ConsoleEx.ReadLine("\n=== Press [Enter] to finish... ");
		}
	}
}
