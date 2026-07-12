namespace MissTortas.Desktop.Services.Shared
{
    public class Validation
    {
        public static string ValidateAndSanitize(string str, int lo, int hi)
        {
            if (string.IsNullOrEmpty(str) || str.Length < lo || str.Length > hi)
            {
                throw new FormatException($"Input: {str} is not valid. Must have a length between {lo} and {hi}");
            }
            return str.Trim();
        }
    }
}
