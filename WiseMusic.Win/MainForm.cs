using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WiseMusic.Core;

namespace WiseMusic.Win
{
	public partial class MainForm : Form
	{
		SongsDB _db = new SongsDB();

		public MainForm()
		{
			InitializeComponent();

			foreach (Song song in _db.Songs)
			{
				lstSourceSongs.Items.Add(song.DisplayName);
			}

			lstSourceSongs.SelectedIndexChanged += LstSourceSongs_SelectedIndexChanged;
		}

		private void LstSourceSongs_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (lstSourceSongs.SelectedItems.Count > 0)
			{
				int songIndex = lstSourceSongs.SelectedIndices[0];
				Song selectedSong = _db.Songs[songIndex];

				var res = selectedSong.FindMatches(_db.Songs);

				rtxtResult.Clear();

                foreach (var resItem in res)
				{
					rtxtResult.Text += resItem + "\n";
				}

				rtxtChords.Clear();

				foreach (Tonality t in selectedSong.ChordSequence)
				{
					rtxtChords.Text += t.RusName + "\n";
				}
			}
		}
	}
}
