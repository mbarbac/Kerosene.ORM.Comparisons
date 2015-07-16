using Compare.Common;
using Kerosene.ORM.DataDB;
using Kerosene.ORM.Maps;
using Kerosene.Tools;
using System;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Compare.KRN.Maps.Eager
{
	// ==================================================== 
	public static class Test_MapsEager
	{
		static volatile object item = null;

		public static void Calculate()
		{
			ConsoleEx.WriteLine("\n====== {0}()", MethodBase.GetCurrentMethod().EasyName(chain: true));
			ConsoleEx.ReadLine("Press [Enter] to execute... ");

			DB.Prepare();

			using (var repo = Repo.Create())
			{
				var cmd = repo.Query<Employee>();
				ConsoleEx.WriteLine("\n> Command: {0}", cmd);

				int read = 0;
				Stopwatch watch = new Stopwatch();
				watch.Start(); for (int i = 0; i < Defaults.Loops; i++)
				{
					foreach (var obj in cmd)
					{
						item = obj; read++;
						if (read < Defaults.PrintMax) ConsoleEx.WriteLine("\t- Item: {0}", item);
					}
				}
				watch.Stop();

				var secs = ((double)watch.ElapsedMilliseconds) / 1000;
				var msPerRec = ((double)watch.ElapsedMilliseconds) / read;
				var recPerSec = read / secs;
#if DEBUG
				ConsoleEx.WriteLine();
#endif
				ConsoleEx.WriteLine("- Elapsed = {0} secs ({1} records)... {2} recs per sec."
					, secs.ToString("#,###.00")
					, read.ToString("#,###")
					, recPerSec.ToString("#,###.00"));
			}
		}
	}
}
