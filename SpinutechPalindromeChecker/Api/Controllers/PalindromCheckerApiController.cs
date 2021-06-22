using Microsoft.AspNetCore.Mvc;
using SpinutechPalindromeChecker.Api.Models;
using SpinutechPalindromeChecker.Extensions;
using System;

namespace SpinutechPalindromeChecker.Api.Controllers
{
    public class PalindromCheckerApiController : Controller
    {
        public bool isAPalindrome = true;

        public string palindromeResponse = "";

        [Route ("api/palindrome")]
        public JsonResult AjaxMethod(ulong input)
        {
            palindromeResponse = PalindromeCheckerExtension.TestIfPalindrome(input);

            if (palindromeResponse.Contains("palindrome-failure"))
            {
                isAPalindrome = false;
            }

            string[] palindromeResults = palindromeResponse.Split(",");

            PalindromeCheckerApiModel palindromeCheckerApiModel = new PalindromeCheckerApiModel
            {
                isAPalindrome = this.isAPalindrome,
                submittedValue = input,
                forwardPalindromeResults = palindromeResults[0],
                reversePalindromeResults = palindromeResults[1]
            };

            if(palindromeResponse != "")
            {
                palindromeCheckerApiModel.resultsReturned = true;
            }

            return Json(palindromeCheckerApiModel);
        }
    }
}