using System.Security.Cryptography;
using System.Text;

namespace PGtraining.Lib
{
    public static class Hash
    {
        private static byte[] byteArray;

        /// <summary>
        /// 文字列から SHA256 のハッシュ値を算出します。
        /// </summary>
        /// <param name="target">変換する文字列を指定します。</param>
        /// <returns>ハッシュ値を返します。</returns>
        private static string GetSha256(string target)
        {
            byte[] byteValue = Encoding.UTF8.GetBytes(target);
            var sha256 = SHA256Managed.Create();
            byte[] hash = sha256.ComputeHash(byteArray);
            var buf = new StringBuilder();
            foreach (var s in hash)
            {
                buf.AppendFormat("{0:x2}", s);
            }
            return buf.ToString();
        }
    }
}