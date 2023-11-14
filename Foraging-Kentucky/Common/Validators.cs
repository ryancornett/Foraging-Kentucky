using System.Text.RegularExpressions;

namespace Foraging_Kentucky.Common;

public static class Validators
{
    // Allowed: 6-30 characters, underscore, a-z, A-Z, 0-9
    public static bool ValidateUsername(string username)
    {
        bool isUsernameValid = Regex.IsMatch(username, @"^[a-zA-Z0-9_]{6,30}$");
        return isUsernameValid;
    }
    public static bool ValidateEmail(string email)
    {
        bool isEmailValid = Regex.IsMatch(email, @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", RegexOptions.IgnoreCase);
        return isEmailValid;
    }
}
