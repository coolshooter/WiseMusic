using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WiseMusic.Core
{
	public class FretManager
	{
		public static string GetRusName(Fret fret)
		{
			switch (fret)
			{
				case Fret.Major:
					return "мажор";
				case Fret.Minor:
					return "минор";
				default:
					throw new NotSupportedException();
			}
		}

		public static string GetName(Fret fret)
		{
			switch (fret)
			{
				case Fret.Major:
					return "";
				case Fret.Minor:
					return "m";
				default:
					throw new NotSupportedException();
			}
		}

		public static string GetNameForTonality(Fret fret)
		{
			switch (fret)
			{
				case Fret.Major:
					return "dur";
				case Fret.Minor:
					return "moll";
				default:
					throw new NotSupportedException();
			}
		}

		public static string GetCode(Fret fret)
		{
			return fret.ToString();
			//return fret == Fret.Major ? "1" : "0";
		}
	}
}
