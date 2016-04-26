using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WiseMusic.Core
{
	public class Song
	{
		public string DisplayName { get; set; }

		public string ChordSequenceText { get; set; }
		public string ChordTransitionsText { get; set; }

		public List<Tonality> ChordSequence { get; set; }

		/// <summary>
		/// С учетом септаккордов и нонаккордов.
		/// </summary>
		public List<Transition> SimpleChordTransitions { get; set; }

		/// <summary>
		/// Без учета септаккордов и нонаккордов.
		/// </summary>
		public List<Transition> SimpleTonalityTransitions { get; set; }

		public Song()
		{
		}

		public Song(string sequence, bool useAmericanStyle)
			: this("", sequence, useAmericanStyle, false)
		{
		}

		public Song(string displayName, string sequence,
			bool useAmericanStyle, bool russianLines)
		{
			DisplayName = displayName;

			ChordSequence = new List<Tonality>();
			SimpleChordTransitions = new List<Transition>();

			var res = Tonality.ParseSequence(sequence, useAmericanStyle, russianLines);

			List<Tonality> parsedSequence = res.Item1;
			ChordSequence = parsedSequence;

			ChordSequenceText = "";
			ChordSequence.ForEach(s => ChordSequenceText += 
				s.ChordNames[0] + " ");
			ChordSequenceText = ChordSequenceText.TrimEnd();

			var trans = Transition.GetAllSimpleChordAndTonalityTransitions(
				ChordSequence);

			SimpleChordTransitions = trans.Item1;
			SimpleTonalityTransitions = trans.Item2;

			ChordTransitionsText = "";
			SimpleChordTransitions.ForEach(
				t => ChordTransitionsText += t + "\n");
			ChordTransitionsText = ChordTransitionsText.TrimEnd();
		}

		/// <summary>
		/// Вначале списка будут идти наиболее подходящие и богатые 
		/// музыкальные произведения.
		/// </summary>
		public List<SongComparison> FindMatches(List<Song> songs)
		{
			List<SongComparison> res = new List<SongComparison>();

			foreach (Song target in songs)
			{
				if (target != this)
				{
					res.Add(new SongComparison(this, target));
					var comp = res.Last();
					comp.Compare();
				}
			}

			res.Sort(new Comparison<SongComparison>((s1, s2) =>
				{
					int localRes = SongComparison.CompareF(
						s1.TonalityTransitionsMatchPart,
						s2.TonalityTransitionsMatchPart);

					if (localRes == 0)
					{
						localRes = SongComparison.CompareF(
							s1.ChordTransitionsMatchPart,
							s2.ChordTransitionsMatchPart);
					}

					return localRes;
				}));

			return res;
		}

		public override string ToString()
		{
			return string.Format("{0}{1}", 
				!string.IsNullOrEmpty(DisplayName) ? DisplayName + ". " : "",
				ChordSequenceText);
		}
	}
}
