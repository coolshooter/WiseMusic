using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WiseMusic.Core
{
	public class NoteManager
	{
		public static string GetRusName(int note)
		{
			switch (note)
			{
				case 0:
					return "до";
				case 1:
					return "ре";
				case 2:
					return "ми";
				case 3:
					return "фа";
				case 4:
					return "соль";
				case 5:
					return "ля";
				case 6:
					return "си";
				default:
					throw new NotSupportedException();
			}
		}

		/// <summary>
		/// Получает все возможные обозначения ноты-знака 
		/// для западной и российской версии.
		/// </summary>
		/// <param name="useBInsteadOfH">Если true (стандарт США),
		/// то Bb = си бемоль, B и H (H для совместимости) = си.
		/// Если false (стандарт России и Германии), 
		/// то B и Bb (Bb для совместимости) = си бемоль, H = си.</param>
		public static List<string> GetNoteMarkNamesForChord(
			int note, Mark mark, bool useAmericanStyle)
		{
			List<string> res = new List<string>();

			if (note == 0)
			{
				/// до
				res.Add("C" + MarkManager.GetName(mark));

				/// добавляем си-диез для джаза
				if (mark == Mark.None)
					res.Add("B" + MarkManager.GetName(Mark.Sharp));

				return res;
			}
			else if (note == 1)
				/// ре
				return new List<string>() { "D" + MarkManager.GetName(mark) };
			else if (note == 2)
			{
				/// ми
				res.Add("E" + MarkManager.GetName(mark));

				/// добавляем фа-бемоль для джаза
				if (mark == Mark.None)
					res.Add("F" + MarkManager.GetName(Mark.Flat));

				else if (mark == Mark.Sharp)
					throw new NotSupportedException("Такой тональности нет (но см. такое обозначение в фа-тональностях)");

				return res;
			}
			else if (note == 3)
			{
				/// фа
				res.Add("F" + MarkManager.GetName(mark));

				/// добавляем ми-диез для джаза
				if (mark == Mark.None)
					res.Add("E" + MarkManager.GetName(Mark.Sharp));

				else if (mark == Mark.Flat)
					throw new NotSupportedException("Такой тональности нет (но см. такое обозначение в ми-тональностях)");

				return res;
			}
			else if (note == 4)
				/// соль
				return new List<string>() { "G" + MarkManager.GetName(mark) };
			else if (note == 5)
				/// ля
				return new List<string>() { "A" + MarkManager.GetName(mark) };
			else if (note == 6)
			{
				/// си

				if (!useAmericanStyle)
				{
					if (mark == Mark.Flat)
					{
						/// видел Bb на иностранных сайтах,
						/// это обозначение считаем очень точным
						/// для сравнения,
						/// ни с чем не спутываемым
						res.Add("B" + MarkManager.GetName(mark));

						/// в России и Германии
						res.Add("B");
					}
					else if (mark == Mark.None)
					{
						/// вроде бы везде должно обозначаться си именно так
						res.Add("H");
					}
					else
						throw new NotSupportedException("Такой тональности нет");
				}
				else
				{
					if (mark == Mark.Flat)
					{
						res.Add("B" + MarkManager.GetName(mark));
					}
					else if (mark == Mark.None)
					{
						/// на всякий случай, но оно нужно на 1 месте,
						/// чтобы сравнивать
						res.Add("H");
						/// а вот это важно
						res.Add("B");
					}
					else
						throw new NotSupportedException("Такой тональности нет");
				}

				return res;
			}
			else
				throw new NotSupportedException();
		}

		//public static string GetName(int note, Mark mark)
		//{
		//	switch (note)
		//	{
		//		case 0:
		//			return "C";
		//		case 1:
		//			return "D";
		//		case 2:
		//			return "E";
		//		case 3:
		//			return "F";
		//		case 4:
		//			return "G";
		//		case 5:
		//			return "A";
		//		case 6:
		//			if (mark == Mark.Flat)
		//				return "B";
		//			else if (mark == Mark.None)
		//				return "H";
		//			else
		//				/// несуществующая тональность СИ-диез
		//				return "B";

		//			break;
		//		default:
		//			throw new NotSupportedException();
		//	}
		//}

		/// <summary>
		/// Для иной записи.
		/// </summary>
		public static string GetNameForTonality(int note, Mark mark, Fret fret)
		{
			string res = "";

			switch (note)
			{
				case 0:
					res = "C";
					break;
				case 1:
					res = "D";
					break;
				case 2:
					res = "E";
					break;
				case 3:
					res = "F";
					break;
				case 4:
					res = "G";
					break;
				case 5:
					res = "A";
					break;
				case 6:
					if (mark == Mark.Flat)
						res = "B";
					else if (mark == Mark.None)
						res = "H";
					else
						/// несуществующая тональность СИ-диез
						res = "B";

						break;
				default:
					throw new NotSupportedException();
			}

			if (fret == Fret.Minor)
				res = res.ToLower();

			return res;
		}
	}
}
