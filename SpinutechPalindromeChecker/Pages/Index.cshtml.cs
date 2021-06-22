using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using SpinutechPalindromeChecker.Extensions;

namespace SpinutechPalindromeChecker.Pages
{
    public class IndexModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        [Required(ErrorMessage = "You must enter a whole number with less than 20 digits.")]
        [RegularExpression(@"^([1-9]{1}\d{0,18})$", ErrorMessage = "You must enter a whole number with less than 20 digits.")]
        public ulong? palindrome { get; set; }

        public string[] palindromeResults { get; set; } = new string[] { };
        public bool isAPalindrome { get; set; } = true;

        public void OnGet(ulong palindrome)
        {
            //Prevents validation error on page load
            if (string.IsNullOrEmpty(Request.QueryString.ToString()))
            {
                ModelState["palindrome"].Errors.Clear();
            }
            //Use only one validation error since this is the only one needed
            else if (ModelState["palindrome"].Errors.Count > 0)
            {
                ModelState["palindrome"].Errors.Clear();
                ModelState["palindrome"].Errors.Add("You must enter a whole number with less than 20 digits.");
            }
            else if (ModelState["palindrome"].Errors.Count == 0)
            {
                string palindromeResponse = PalindromeCheckerExtension.TestIfPalindrome(this.palindrome.Value);
                palindromeResults = palindromeResponse.Split(",");

                if (palindromeResponse.Contains("palindrome-failure"))
                {
                    isAPalindrome = false;
                }
            }
        }
    }
}
