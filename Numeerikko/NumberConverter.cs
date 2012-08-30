using System;
using System.Collections.Generic;

namespace Numeerikko
{
	public class NumberConverter
	{
		private static Dictionary<int, string> digits = new Dictionary<int, string>()
		{
			{ 0, "nolla" },
			{ 1, "yksi" },
			{ 2, "kaksi" },
			{ 3, "kolme" },
			{ 4, "neljä" },
			{ 5, "viisi" },
			{ 6, "kuusi" },
			{ 7, "seitsemän" },
			{ 8, "kahdeksan" },
			{ 9, "yhdeksän" }
		};
		
		public NumberConverter()
		{
		}
		
		public string Convert(int number)
		{
			if (number >= 0 && number < 10)
			{
				return digits[number];
			}
			else if (number > 10 && number < 20)
			{
				return digits[number - 10] + "toista";
			}
			else
			{
				throw new NotImplementedException("This number is not supported.");
			}
		}
	}
}

