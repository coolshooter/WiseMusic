using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WiseMusic.Core
{
	public class MarkManager
	{
		public static string GetRusName(Mark mark)
		{
			switch (mark)
			{
				case Mark.None:
					return "";
				case Mark.Sharp:
					return "диез";
				case Mark.Flat:
					return "бемоль";
				default:
					throw new NotSupportedException();
			}
		}

		public static string GetName(Mark mark)
		{
			switch (mark)
			{
				case Mark.None:
					return "";
				case Mark.Sharp:
					return "#";
				case Mark.Flat:
					return "b";
				default:
					throw new NotSupportedException();
			}
		}

		public static string GetNameForTonality(Mark mark, int note)
		{
			string res = "";

			switch (mark)
			{
				case Mark.None:
					break;
				case Mark.Sharp:
					/// для МИ и СИ это будет обозначением несуществующей
					/// тональности
					res = "is";
					break;
				case Mark.Flat:
					if (note == 0 || note == 1 || note == 3 || note == 4)
						/// ДО "C", РЕ "D", ФА (F) - но для нее нет бемоля,
						/// поэтому обозначение будет отражать отсутствующую
						/// тональность,
						/// СОЛЬ (G)
						res = "es";
					else if (note == 2 || note == 5)
						/// если МИ (E) или ЛЯ (A)
						res = "s";
					else if (note == 6)
						/// си-бемоль будет обозначен как "B" в итоге
						res = "";
					else
						throw new NotSupportedException();
					break;

				default:
					throw new NotSupportedException();
			}

			return res;
		}
	}
}
