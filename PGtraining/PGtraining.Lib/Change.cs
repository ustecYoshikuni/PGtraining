namespace PGtraining.Lib
{
    static public class Change
    {
        static public string YyyymmddToDateString(string date)
        {
            if (Lib.Check.IsAlphaNumericOnly(date.Substring(0, 7), true, 8))
            {
                var dateString = $"{date.Substring(0, 3)}/{date.Substring(4, 5)}{date.Substring(6, 7)}";
                return dateString;
            }

            return "";
        }
    }
}