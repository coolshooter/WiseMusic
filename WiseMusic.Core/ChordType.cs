using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WiseMusic.Core
{
	public enum ChordType
	{
		/// <summary>
		/// Обычный аккорд, построенный на 3х нотах, входящих в тональность.
		/// </summary>
		Ordinary,

		/// <summary>
		/// Септаккорд.
		/// </summary>
		Seven,

		/// <summary>
		/// Нонаккорд.
		/// </summary>
		Nine,
	}
}
