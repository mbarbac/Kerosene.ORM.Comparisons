using Compare.Common;
using Kerosene.ORM.ExampleDB;
using Kerosene.Tools;
using System;

namespace Compare.KRN.CoreRecords
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
			Test_CoreRecords.Calculate();
			Test_CoreConvertBy.Calculate();

			ConsoleEx.ReadLine("\n=== Press [Enter] to finish... ");
		}
	}
}
