using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WiseMusic.Core
{
	/// <summary>
	/// Переход между тональностями.
	/// Может состоять из 2х и более тональностей.
	/// Можно считать просто последовательностью.
	/// </summary>
	public class Transition
	{
		public List<Tonality> Tonalities = new List<Tonality>();

		/// <summary>
		/// Если переход состоит из двух тональностей (аккордов),
		/// то свойство получает расстояние между ними в полутонах, 
		/// считая в направлении перехода.
		/// Если переход состоит из двух аккордов (обычный и септаккорд,
		/// например) одной и той же тональности, то расстояние будет равно 0.
		/// Всегда не меньше нуля.
		/// </summary>
		public int SimpleTranHalfToneDistance
		{
			get 
			{
				var t = Tonalities;

				if (t.Count == 2)
				{
					int res = t[1].HalfTone - t[0].HalfTone;

					if (res < 0)
						res += 12;

					return res;
				}
				else
					return -1;
			}
		}

		/// <summary>
		/// Если переход состоит из двух тональностей,
		/// то вернется код такого перехода (собственная кодировка для 
		/// простоты поиска и понимания).
		/// Иначе пустое значение.
		/// </summary>
		public string GetSimpleTranCode(bool useChordType)
		{
			string res = "";

			if (Tonalities.Count == 2)
			{
				if (useChordType)
				{
					res = string.Format("{0}:{1}{2}->{3}{4}",
						SimpleTranHalfToneDistance,
						FretManager.GetCode(Tonalities[0].Fret),
						ChordTypeManager.GetCode(Tonalities[0].ChordT),
						FretManager.GetCode(Tonalities[1].Fret),
						ChordTypeManager.GetCode(Tonalities[1].ChordT));
				}
				else
				{
					res = string.Format("{0}:{1}->{2}",
						SimpleTranHalfToneDistance,
						FretManager.GetCode(Tonalities[0].Fret),
						FretManager.GetCode(Tonalities[1].Fret));
				}
			}

			return res;
		}

		public Transition()
		{
		}

		public Transition(params Tonality[] tonalities)
		{
			Tonalities.AddRange(tonalities);
		}

		public bool EqualsChord(Transition transition)
		{
			if (Tonalities.Count == transition.Tonalities.Count)
			{
				for (int i = 0; i < Tonalities.Count; i++)
				{
					if (!Tonalities[i].ChordMatches(
						transition.Tonalities[i]))
						return false;
				}

				return true;
			}
			else
				return false;
		}

		public bool EqualsTonality(Transition transition)
		{
			if (Tonalities.Count == transition.Tonalities.Count)
			{
				for (int i = 0; i < Tonalities.Count; i++)
				{
					if (Tonalities[i].TonalityName != transition.Tonalities[i].TonalityName)
						return false;
				}

				return true;
			}
			else
				return false;
		}

		public static Tuple<List<Transition>, List<Transition>> 
			GetAllSimpleChordAndTonalityTransitions(
			List<Tonality> sequence)
		{
			List<Transition> res1 = new List<Transition>();
			List<Transition> res2 = new List<Transition>();

			for (int i = 0; i < sequence.Count - 1; i++)
			{
				if (!sequence[i].ChordMatches(sequence[i + 1]))
				{
					Transition tran = new Transition(
						sequence[i], sequence[i + 1]);

					if (!res1.Any(tr => tr.EqualsChord(tran)))
						res1.Add(tran);

					if (sequence[i].TonalityName != sequence[i + 1].TonalityName &&
						!res2.Any(tr => tr.EqualsTonality(tran)))
						res2.Add(tran);
				}
			}

			return new Tuple<List<Transition>,List<Transition>>(res1, res2);
		}

		public override string ToString()
		{
			string res = "";

			foreach (var ton in Tonalities)
			{
				res += ton.ChordNames[0] + "->";
			}

			res = res.TrimEnd('-', '>');

			return res;
		}
	}
}
