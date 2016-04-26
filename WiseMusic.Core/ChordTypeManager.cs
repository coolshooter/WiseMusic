using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WiseMusic.Core
{
	public class ChordTypeManager
	{
		public static string GetRusName(ChordType chordType)
		{
			switch (chordType)
			{
				case ChordType.Ordinary:
					return "";
				case ChordType.Seven:
					return "септаккорд";
				case ChordType.Nine:
					return "нонаккорд";
				default:
					throw new NotSupportedException();
			}
		}

		public static string GetName(ChordType chordType)
		{
			switch (chordType)
			{
				case ChordType.Ordinary:
					return "";
				case ChordType.Seven:
					return "7";
				case ChordType.Nine:
					return "9";
				default:
					throw new NotSupportedException();
			}
		}

		public static string GetCode(ChordType type)
		{
			switch (type)
			{
				case ChordType.Ordinary:
					return "";
				case ChordType.Seven:
					return "7";
				case ChordType.Nine:
					return "9";
				default:
					throw new NotSupportedException();
			}
		}
	}
}
