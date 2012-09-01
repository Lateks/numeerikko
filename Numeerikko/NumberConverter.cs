/* Copyright (c) 2012, Laura Leppänen <laura.leppanen@iki.fi>
 * All rights reserved.
 *
 * Redistribution and use in source and binary forms, with or without
 * modification, are permitted provided that the following conditions are met:
 *
 * 1. Redistributions of source code must retain the above copyright notice, this
 *    list of conditions and the following disclaimer.
 * 2. Redistributions in binary form must reproduce the above copyright notice,
 *    this list of conditions and the following disclaimer in the documentation
 *    and/or other materials provided with the distribution.
 *
 * THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS" AND
 * ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED
 * WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE
 * DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT OWNER OR CONTRIBUTORS BE LIABLE FOR
 * ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES
 * (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES;
 * LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND
 * ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT
 * (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF THIS
 * SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.
 */
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

        public NumberConverter ()
        {
        }

        public string Convert(ulong number)
        {
            if (number >= 0 && number < 1000) {
                return ConvertTripleDigits ((int)number);
            } else {
                return ConvertBigNumber (number);
            }
        }

        private string ConvertBigNumber(ulong number)
        {
            string result = "";
            List<int> groupedNumber = GroupNumber (number);

            for (int i = groupedNumber.Count - 1; i >= 0; i--) {
                if (ShouldPrintNumber (groupedNumber, i)) {
                    int num = groupedNumber [i];
                    if (num > 1) {
                        result += ConvertTripleDigits (num);
                        result += ShouldPrintSpaceBeforeSuffix (i) ? " " : "";
                    }
                    result += bigNumberSuffixes [i];

                    if (num > 1 || HasThousandsAsModifier (groupedNumber, i)) {
                        result += InflectionalSuffixFor (i);
                    }
                    result += " ";
                }
            }
            return result.Trim ();
        }

        private string InflectionalSuffixFor(int suffixIndex)
        {
            if (suffixIndex == 0) {
                return "";
            }
            return bigNumberSuffixes [suffixIndex] == "tuhat" ? "ta" : "a";
        }

        private bool ShouldPrintSpaceBeforeSuffix(int suffixIndex)
        {
            return suffixIndex > 1 && bigNumberSuffixes [suffixIndex] != "tuhat";
        }

        private bool ShouldPrintNumber(List<int> groupedNumber, int index)
        {
            return groupedNumber [index] != 0 || HasThousandsAsModifier (groupedNumber, index);
        }

        private bool HasThousandsAsModifier(List<int> groupedNumber, int index)
        {
            return index == 4 && groupedNumber.Count - 1 > index &&
             groupedNumber [index + 1] > 0;
        }

        private List<int> GroupNumber(ulong number)
        {
            string numberString = number.ToString ();
            List<int> groups = new List<int> ();

            int currentIndex = numberString.Length;
            while (currentIndex > 0) {
                currentIndex = currentIndex - 3;
                int groupLength = 3;
                if (currentIndex < 0) {
                    groupLength = 3 + currentIndex;
                    currentIndex = 0;
                }
                int numberGroup = Int32.Parse (numberString.Substring (currentIndex, groupLength));
                groups.Add (numberGroup);
            }
            return groups;
        }

        private string ConvertTripleDigits(int number)
        {
            if (number >= 0 && number < 100) {
                return ConvertUpToDoubleDigits (number);
            } else if (number >= 100 && number < 1000) {
                string hundred = "sata";
                int firstDigit = number / 100;
                int rest = number % 100;

                string hundreds = firstDigit == 1 ? hundred
                                               : numberConversions [firstDigit] + hundred + "a";
                string doubleDigits = rest > 0 ? ConvertUpToDoubleDigits (rest) : "";
                return hundreds + doubleDigits;
            } else {
                throw new ArgumentException ("I can only convert numbers that have up to three digits.");
            }
        }

        private string ConvertUpToDoubleDigits(int number)
        {
            if (number >= 0 && number <= 10) {
                return numberConversions [number];
            } else if (number > 10 && number < 20) {
                return numberConversions [number - 10] + "toista";
            } else if (number >= 20 && number < 100) {
                int firstDigit = number / 10;
                int secondDigit = number % 10;
                string suffix = secondDigit > 0 ? numberConversions [secondDigit] : "";
                return numberConversions [firstDigit] + "kymmentä" + suffix;
            } else {
                throw new ArgumentException ("I can only convert numbers that have up to two digits.");
            }
        }
    }
}
