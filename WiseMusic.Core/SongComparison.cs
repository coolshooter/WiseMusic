using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WiseMusic.Core
{
	/// <summary>
	/// Сейчас просто оценка схожести 2х произведений по количество
	/// совпавших переходов тональностей с учетом транспозиции.
	/// В будущем хотелось бы также искать и по конкретным переходам,
	/// а также по последовательностям простых переходов.
	/// </summary>
	public class SongComparison
	{
		/// <summary>
		/// Равно 1, если композиции совпадают по 
		/// переходам *тональностей* с учетом возможной транспозиции.
		/// Больше 1, если все совпадают, и в искомой композиции 
		/// если какие-то еще.
		/// Меньше 1, если совпадают не все. 
		/// Пока что не учитываем количество повторений переходов
		/// (да и сложно его учесть).
		/// </summary>
		public double TonalityTransitionsMatchPart { get; set; }

		/// <summary>
		/// Может быть больше 100%.
		/// </summary>
		public double TonalityTransitionsMatchPercentage
		{
			get { return TonalityTransitionsMatchPart * 100; }
		}

		public int MatchedTonalityTransitions { get; set; }

		/// <summary>
		/// Этот параметр имеет более узкое применение, чем 
		/// <see cref="TonalityTransitionsMatchPart"/>.
		/// Равно 1, если композиции совпадают по 
		/// переходам *тональностей-аккордов* с учетом возможной транспозиции.
		/// Больше 1, если все совпадают, и в искомой композиции 
		/// если какие-то еще.
		/// Меньше 1, если совпадают не все. 
		/// </summary>
		public double ChordTransitionsMatchPart { get; set; }

		public int MatchedChordTransitions { get; set; }

		public int ModelTonalityTransitionsCount
		{
			get { return ModelSong.SimpleTonalityTransitions.Count; }
		}

		public int TargetTonalityTransitionsCount
		{
			get { return TargetSong.SimpleTonalityTransitions.Count; }
		}

		/// <summary>
		/// Композиция - эталон, которая заведомо нравится человеку
		/// и по которой он ищет другие песни.
		/// </summary>
		public Song ModelSong { get; set; }

		/// <summary>
		/// Найденная композиция.
		/// </summary>
		public Song TargetSong { get; set; }

		public SongComparison(Song modelSong, Song targetSong)
		{
			ModelSong = modelSong;
			TargetSong = targetSong;
		}

		public void Compare()
		{
			MatchedTonalityTransitions = 0;
			MatchedChordTransitions = 0;

			/// бежим по переходам между тональностями
			foreach (Transition modelTran in ModelSong.SimpleTonalityTransitions)
			{
				/// сравниваем переходы между тональностями
				bool matched = TargetSong.SimpleTonalityTransitions.Any(
					targetTran =>
						/// сравнение идет со специальным флагом
						targetTran.GetSimpleTranCode(false) ==
						modelTran.GetSimpleTranCode(false));

				if (matched)
					MatchedTonalityTransitions++;
			}

			/// бежим по переходам между аккордами
			foreach (Transition modelTran in ModelSong.SimpleChordTransitions)
			{
				/// сравниваем переходы между аккордами
				bool matched = TargetSong.SimpleChordTransitions.Any(
					targetTran =>
						/// сравнение идет со специальным флагом
						targetTran.GetSimpleTranCode(true) ==
						modelTran.GetSimpleTranCode(true));

				if (matched)
					MatchedChordTransitions++;
			}

			double a = MatchedTonalityTransitions;
			double b = ModelSong.SimpleTonalityTransitions.Count;
			double c = TargetSong.SimpleTonalityTransitions.Count;

			if (b == 0 || c == 0)
				TonalityTransitionsMatchPart = 0;
			else
			{
				TonalityTransitionsMatchPart = (2 * a) / (b + c);

				//if (a == b)
				//{
				//	/// то, насколько богаче найденная песня
				//	/// результат будет >= 1
				//	//TonalityTransitionsMatchPart = c / a;

				//	TonalityTransitionsMatchPart = 
				//		(2 * a) / (b + c);
				//}
				///// результат будет < 1
				//else if (a < b)
				//{
				//	/// то, насколько не совпали песни
				//	TonalityTransitionsMatchPart = a / b;
				//}
			}

			a = MatchedChordTransitions;
			b = ModelSong.SimpleChordTransitions.Count;
			c = TargetSong.SimpleChordTransitions.Count;

			if (b == 0 || c == 0)
				ChordTransitionsMatchPart = 0;
			else
			{
				ChordTransitionsMatchPart = (2 * a) / (b + c);
				///// результат будет >= 1
				//if (a == b)
				//{
				//	/// то, насколько богаче найденная песня
				//	ChordTransitionsMatchPart = c / a;
				//}
				///// результат будет < 1
				//else if (a < b)
				//{
				//	/// то, насколько не совпали песни
				//	ChordTransitionsMatchPart = a / b;
				//}
			}
		}

		public override string ToString()
		{
			return TargetSong.DisplayName + "; сходство = " +
				Math.Round(TonalityTransitionsMatchPercentage, 1) + "%";
		}

		public static int CompareF(double matchPart1, double matchPart2)
		{
			if (matchPart1 > matchPart2)
				return -1;
			else if (matchPart1 == matchPart2)
				return 0;
			else if (matchPart1 < matchPart2)
				return 1;
			else
				throw new Exception("Ошибка в сравнении");
		}
	}
}
