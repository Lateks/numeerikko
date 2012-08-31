using System;
using System.Collections.Generic;

namespace Numeerikko
{
	public class NumberConverter
	{
		private static string[] numberConversions = new string[]
		{
			"nolla", "yksi", "kaksi", "kolme", "neljä", "viisi",
			"kuusi", "seitsemän", "kahdeksan", "yhdeksän", "kymmenen"
		};
		
		private static string[] bigNumberSuffixes = new string[]
		{
			"", "tuhat", "miljoona", "miljardi", "biljoona", "tuhat", "triljoona"
		};
		
		public NumberConverter()
		{
		}
		
		public string Convert(ulong number)
		{
			if (number >= 0 && number < 1000)
			{
				return ConvertTripleDigits((int) number);
			}
			else
			{
				return ConvertBigNumber(number);
			}
		}
		
		private string ConvertBigNumber(ulong number)
		{
			string result = "";
			List<int> groupedNumber = GroupNumber(number);

			int startIndex = groupedNumber.Count - 1;
			for (int i = startIndex; i >= 0; i--) {
				bool hasThousandsAsModifier = i == 4 && startIndex > i && groupedNumber[i+1] > 0;
				if (groupedNumber[i] != 0 || hasThousandsAsModifier) {
					int num = groupedNumber [i];
					string bignumSuffix = bigNumberSuffixes[i];
					
					if (num > 1) {
						result += ConvertTripleDigits(num);
						result += i > 1 && bignumSuffix != "tuhat" ? " " : "";
					}
					result += bignumSuffix;
					if ((num > 1 && i > 0) || (i == 4 && startIndex > i)) {
						result += bignumSuffix == "tuhat" ? "ta" : "a";
					} 
					result += " ";
				}
			}
			return result.Trim ();
		}
		
		private List<int> GroupNumber(ulong number)
		{
			string numberString = number.ToString();
			List<int> groups = new List<int>();
			
			int currentIndex = numberString.Length;
			while (currentIndex > 0)
			{
				currentIndex = currentIndex - 3;
				int groupLength = 3;
				if (currentIndex < 0)
				{
					groupLength = 3 + currentIndex;
					currentIndex = 0;
				}
				int numberGroup = Int32.Parse(numberString.Substring(currentIndex, groupLength));
				groups.Add(numberGroup);
			}
			return groups;
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
				throw new ArgumentException("I can only convert numbers that have up to three digits.");
			}
		}

		private string ConvertUpToDoubleDigits(int number)
		{
			if (number >= 0 && number <= 10)
			{
				return numberConversions[number];
			}
			else if (number > 10 && number < 20)
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

