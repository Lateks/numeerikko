using System;
using System.Collections.Generic;

namespace Numeerikko
{
	public class NumberConverter
	{
		private static Dictionary<int, string> numberConversions = new Dictionary<int, string>()
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
			{ 9, "yhdeksän" },
			{ 10, "kymmenen" }
		};
		
		public NumberConverter()
		{
		}
		
		public string Convert(int number)
		{
			if (number >= 0 && number < 1000)
			{
				return ConvertTripleDigits(number);
			}
			else
			{
				throw new NotImplementedException("This number is not supported.");
			}
		}
		
		private string ConvertTripleDigits(int number)
		{
			if (number >= 0 && number < 100)
			{
				return ConvertUpToDoubleDigits(number);
			}
			else if (number >= 100 && number < 1000)
			{
				string hundred = "sata";
				int firstDigit = number / 100;
				int rest = number % 100;
				
				string hundreds = firstDigit == 1 ? hundred
												  : numberConversions[firstDigit] + hundred + "a";
				string doubleDigits = rest > 0 ? ConvertUpToDoubleDigits(rest) : "";
				return hundreds + doubleDigits;
			}
			else
			{
				throw new NotImplementedException("I can only convert numbers that have up to three digits.");
			}
		}

		private string ConvertUpToDoubleDigits(int number)
		{
			if (number >= 0 && number <= 10)
			{
				return numberConversions[number];
			}
			if (number > 10 && number < 20)
			{
				return numberConversions[number - 10] + "toista";
			}
			else if (number >= 20 && number < 100)
			{
				int firstDigit = number / 10;
				int secondDigit = number % 10;
				string suffix = secondDigit > 0 ? numberConversions[secondDigit] : "";
				return numberConversions[firstDigit] + "kymmentä" + suffix;
			}
			else
			{
				throw new ArgumentException("I can only convert numbers that have up to two digits.");
			}
		}
	}
}

