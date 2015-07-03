using Compare.Common;
using Kerosene.ORM.ExampleDB;
using Kerosene.Tools;
using System;

namespace Compare.KRN.Maps.Eager
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
			Test_MapsEager.Calculate();

			ConsoleEx.ReadLine("\n=== Press [Enter] to finish... ");
		}
	}
}
