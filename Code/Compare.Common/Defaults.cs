using System;

namespace Compare.Common
{
	// ==================================================== 
	public static class Defaults
	{
#if DEBUG
		public static int Loops = 5;
		public static bool Restricted = true;
		public static int PrintMax = 5;
#else	
		public static int Loops = 100;
		public static bool Restricted = false;
		public static int PrintMax = 0;
#endif
	}
}
