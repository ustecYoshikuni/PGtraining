namespace PGtraining.Lib
{
    static public class Change
    {
        static public string YyyymmddToDateString(string date)
        {
            if (Lib.Check.IsAlphaNumericOnly(date.Substring(0, 8), true, 8))
            {
                var dateString = $"{date.Substring(0, 4)}/{date.Substring(4, 2)}/{date.Substring(6, 2)}";
                return dateString;
            }

            return "";
        }
    }
}