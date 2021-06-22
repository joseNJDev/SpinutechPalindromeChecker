using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpinutechPalindromeChecker.Api.Models
{
    public class PalindromeCheckerApiModel
    {
        public bool resultsReturned { get; set; } = false;
        public ulong submittedValue { get; set; }
        public bool isAPalindrome { get; set; }
        public string forwardPalindromeResults { get; set; }
        public string reversePalindromeResults { get; set; }
    }
}
