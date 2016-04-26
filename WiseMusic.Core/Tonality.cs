using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WiseMusic.Core
{
	/// <summary>
	/// Тональность с элементами характеристик аккорда (септ-аккорд, нонаккорд).
	/// </summary>
    public class Tonality
    {
		/// <summary>
		/// Все возможныен обозначения тональности-аккорда,
		/// в обозначениях для гитары.
		/// На первом месте д.б. наиболее точное обозначение для сравнения, 
		/// которое нельзя спутать.
		/// </summary>
		public List<string> ChordNames { get; set; }

		/// <summary>
		/// Классическое обозначение тональности, урезано в возможностях.
		/// </summary>
		public string TonalityName { get; set; }

		public string RusName { get; set; }

		/// <summary>
		/// Нота, на которой построена тональность. 
		/// Представлена цифрой, чтобы было проще работать с ней.
		/// Значения: 
		/// 0 = "до".. 6 = "си".
		/// </summary>
		public int Note { get; set; }

		/// <summary>
		/// Знак (диез, бемоль или отсутствие).
		/// </summary>
		public Mark Mark { get; set; }

		/// <summary>
		/// Лад (мажор или минор).
		/// </summary>
		public Fret Fret { get; set; }

		public ChordType ChordT { get; set; }

		/// <summary>
		/// Номер полутона в октаве, считая от белой клавиши до.
		/// Считая от 0.
		/// </summary>
		public int HalfTone { get; private set; }

		public static List<Tonality> RusTonalities = GenerateAll(false);
		public static List<Tonality> USATonalities = GenerateAll(true);

		public Tonality(List<string> chordNames, 
			string tonalityName, 
			int note, Mark mark, Fret fret)
		{
			ChordNames = chordNames;
			TonalityName = tonalityName;
			Note = note;
			Mark = mark;
			Fret = fret;

			HalfTone = note * 2;
			
			if (note >= 3)
				HalfTone -= 1;

			if (mark == Core.Mark.Flat)
				HalfTone -= 1;
			else if (mark == Core.Mark.Sharp)
				HalfTone += 1;
		}

		/// <summary>
		/// Сравнение с учетом регистра
		/// (иногда регистр имеет значение + проще выделять 
		/// обозначения из текста).
		/// </summary>
		public bool Matches(string name)
		{
			return ChordNames.Contains(name) || name == TonalityName;
		}

		public bool MatchesRusName(string name)
		{
			return RusName.ToLower() == name.ToLower();
		}

		public bool ChordMatches(Tonality target)
		{
			return ChordNames[0] == target.ChordNames[0];
		}

		public static Tuple<List<Tonality>, List<string>>
			ParseSequence(string sequence, bool useAmericanStyle, bool russianLines)
		{
			List<Tonality> res = new List<Tonality>();
			List<string> failedNames = new List<string>();

			List<string> names;

			if (russianLines)
				/// пробел не считается разделителем
				names = sequence.Split(
					new char[] { ',', ';', '\\', '/', '|', '.', '\n', '\t', '\r' },
					StringSplitOptions.RemoveEmptyEntries).ToList();
			else
				names =	sequence.Split(
					new char[] { ' ', ',', ';', '\\', '/', '|', '.', '\n', '\t', '\r' },
					StringSplitOptions.RemoveEmptyEntries).ToList();

			foreach (string name in names)
			{
				List<Tonality> localizedTonalities = useAmericanStyle ? 
					USATonalities : RusTonalities;

				Tonality resT;
				
				if (russianLines)
					resT = localizedTonalities
						.FirstOrDefault(t => t.MatchesRusName(name));
				else
					resT = localizedTonalities
						.FirstOrDefault(t => t.Matches(name));

				if (resT != null)
					res.Add(resT);
				else
					failedNames.Add(name);
			}

			return new Tuple<List<Tonality>, List<string>>(
				res, failedNames);
		}

		public static bool IsValid(int note, Mark mark)
		{
			bool failed = (note == 0 && mark == Mark.Flat) ||
				(note == 2 && mark == Mark.Sharp) ||
				(note == 3 && mark == Mark.Flat) ||
				(note == 6 && mark == Mark.Sharp);

			return !failed;
		}

		public static List<Tonality> GenerateAll(bool useAmericanStyle)
		{
			List<Tonality> res = new List<Tonality>();

			List<int> notes = new List<int>() { 0, 1, 2, 3, 4, 5, 6 };

			List<Mark> marks = new List<Mark>() 
				{ Mark.None, Mark.Sharp, Mark.Flat };

			List<Fret> frets = new List<Fret>() { Fret.Major, Fret.Minor };

			List<ChordType> chordTypes = new List<ChordType>()
				{ ChordType.Ordinary, ChordType.Seven, ChordType.Nine };

			foreach (int note in notes)
			{
				string noteRus = NoteManager.GetRusName(note);

				foreach (Mark mark in marks)
				{
					if (IsValid(note, mark))
					{
						string markRus = MarkManager.GetRusName(mark);

						foreach (Fret fret in frets)
						{
							List<string> noteMarkNamesForChord =
								NoteManager.GetNoteMarkNamesForChord(
								note, mark, useAmericanStyle);

							string fretStr = FretManager.GetName(fret);
							string fretRus = FretManager.GetRusName(fret);

							string tonalityName =
								NoteManager.GetNameForTonality(note, mark, fret) +
								MarkManager.GetNameForTonality(mark, note) +
								"-" +
								FretManager.GetNameForTonality(fret);

							foreach (ChordType chordType in chordTypes)
							{
								string chordTypeStr =
									ChordTypeManager.GetName(chordType);
								string chordTypeRus =
									ChordTypeManager.GetRusName(chordType);

								List<string> chordNames = new List<string>();

								foreach (string noteMarkForChord in noteMarkNamesForChord)
								{
									chordNames.Add(noteMarkForChord + fretStr + chordTypeStr);
								}

								Tonality t = new Tonality(
									chordNames, tonalityName, note,
									mark, fret);

								t.ChordT = chordType;

								t.RusName = noteRus;
								if (!string.IsNullOrEmpty(markRus))
									t.RusName += "-" + markRus;
								t.RusName += " " + fretRus;
								if (!string.IsNullOrEmpty(chordTypeRus))
									t.RusName += " " + chordTypeRus;

								res.Add(t);
							}
						}
					}
				}
			}

			return res;
		}

		public override string ToString()
		{
			return string.Format("{0}; {1}; {2}", 
				RusName, ChordNames[0], TonalityName);
		}
    }
}
