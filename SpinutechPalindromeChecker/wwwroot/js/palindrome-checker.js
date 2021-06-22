$(document).ready(function () {
    $('#submitPalindromeForm').on('keyup keypress', function (e) {
        var keyCode = e.keyCode || e.which;
        if (keyCode === 13) {
            e.preventDefault();
            return false;
        }
    });
    $("form button#client-side-palindrome").click(function (e) {
        e.preventDefault();
        var palindromeInput = $("#palindrome").val();
        var regExTest = new RegExp(/^([1-9]{1}\d{0,18})$/g);
        if (regExTest.test(palindromeInput)) {
            var isOrIsNotPalindrome = "IS";
            var successPalindrome = "SUCCESS!";
            var glyphForPalindromePalindrome = "<span class=\"glyphicon glyphicon-thumbs-up palindrome-glyph-success\" aria-hidden=\"true\"></span>";
            $.ajax({
                url: '/api/palindrome?input=' + palindromeInput,
                success: function (returnData) {
                    $("#serverSidePalindrome").remove();
                    $('#clientSidePalindrome').css("display", "block");
                    document.getElementById('mainPalindromeContainer').scrollIntoView();
                    if (returnData.resultsReturned) {
                        if (returnData.isAPalindrome) {
                            $('#api-content-1').html("<p>" + successPalindrome + "</p>" + glyphForPalindromePalindrome + "<p>" + returnData.submittedValue + " <em>" + isOrIsNotPalindrome + "</em> a palindrome!<p>");

                            $('#api-content-2').html("<p><div class=\"col-md-2\">Forward: </div><div class=\"col-md-10\">" + returnData.forwardPalindromeResults + "</div></p></div>");

                            $('#api-content-3').html("<p><div class=\"col-md-2\">Reverse: </div><div class=\"col-md-10\">" + returnData.reversePalindromeResults + "</div></p></div>");
                        } else {
                            isOrIsNotPalindrome = "IS NOT";
                            successPalindrome = "Sorry...";
                            glyphForPalindromePalindrome = "<span class=\"glyphicon glyphicon-thumbs-down palindrome-glyph-failure\" aria-hidden=\"true\"></span>";

                            $('#api-content-1').html("<p>" + successPalindrome + "</p>" + glyphForPalindromePalindrome + "<p>" + returnData.submittedValue + " <em>" + isOrIsNotPalindrome + "</em> a palindrome!<p>");

                            $('#api-content-2').html("<p><div class=\"col-md-2\">Forward: </div><div class=\"col-md-10\">" + returnData.forwardPalindromeResults + "</div></p></div>");

                            $('#api-content-3').html("<p><div class=\"col-md-2\">Reverse: </div><div class=\"col-md-10\">" + returnData.reversePalindromeResults + "</div></p></div>");
                        }
                    } else {
                        $('#api-content').text('Sorry, an error has occurred. Please make sure a whole number with less than 20 digits was entered and try again.')
                    }
                },
                error: function (xhr, status, error) {
                    $('#api-error').text('Sorry, an error has occurred. Please make sure a whole number with less than 20 digits was entered and try again.')
                }
            });
        }
    });
});
