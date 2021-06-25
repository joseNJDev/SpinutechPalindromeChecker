using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SpinutechPalindromeChecker.Extensions
{
    public class PalindromeCheckerExtension
    {

        public string TestIfPalindrome(ulong submittedNumber)
        {
            string returnPalindrome = "";
            string forwardFirstHalf = "";
            string forwardSecondHalf = "";
            string reverseFirstHalf = "";
            string reverseSecondHalf = "";
            string middleNumber = "";

            List<ulong> SplitIntoDigits = new List<ulong>();

            while (submittedNumber > 0)
            {
                SplitIntoDigits.Add(submittedNumber % 10);
                submittedNumber = submittedNumber / 10;
            }
            SplitIntoDigits.Reverse();
            int numberOfDigits = SplitIntoDigits.Count();

            if (numberOfDigits % 2 != 0)
            {
                middleNumber = "<span class=\"palindrome-success\">" + SplitIntoDigits[numberOfDigits / 2].ToString() + "</span>";
                SplitIntoDigits.RemoveAt(numberOfDigits / 2);
                numberOfDigits = SplitIntoDigits.Count();
            }

            for(int i = 0; i < numberOfDigits / 2; i++)
            {
                if(SplitIntoDigits[i] == SplitIntoDigits[numberOfDigits - (i + 1)])
                {
                    forwardFirstHalf += "<span class=\"palindrome-success\">" + SplitIntoDigits[i].ToString() + "</span>";
                    forwardSecondHalf = forwardSecondHalf.Insert(0, "<span class=\"palindrome-success\">" + SplitIntoDigits[numberOfDigits - (i + 1)].ToString() + "</span>");

                   reverseFirstHalf += "<span class=\"palindrome-success\">" + SplitIntoDigits[numberOfDigits - (i + 1)].ToString() + "</span>";
                   reverseSecondHalf = reverseSecondHalf.Insert(0, "<span class=\"palindrome-success\">" + SplitIntoDigits[i].ToString() + "</span>");

                } else
                {
                    forwardFirstHalf += "<span class=\"palindrome-failure\">" + SplitIntoDigits[i].ToString() + "</span>";
                    forwardSecondHalf = forwardSecondHalf.Insert(0, "<span class=\"palindrome-failure\">" + SplitIntoDigits[numberOfDigits - (i + 1)].ToString() + "</span>");

                    reverseFirstHalf += "<span class=\"palindrome-failure\">" + SplitIntoDigits[numberOfDigits - (i + 1)].ToString() + "</span>";
                    reverseSecondHalf = reverseSecondHalf.Insert(0, "<span class=\"palindrome-failure\">" + SplitIntoDigits[i].ToString() + "</span>");

                }
            }

            return returnPalindrome = forwardFirstHalf + middleNumber + forwardSecondHalf + "," + reverseFirstHalf + middleNumber + reverseSecondHalf;
        }
    }
}
