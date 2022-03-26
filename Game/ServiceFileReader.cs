using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    internal static class ServiceFile
    {
        public static string ReadFile(string path)
        {
            var result = new StringBuilder();
            using (var reader = new StreamReader(File.OpenRead(path)))
            {
                var line = string.Empty;
                while ((line = reader.ReadLine()) != null)
                {
                    result.Append("\n" + line);
                }
            }
            return result.ToString();
        }

        internal static void WriteToFile(string path, string updatedData)
        {
            using (var writer = new StreamWriter(path, false))
            {
                writer.Write(updatedData);
            }   
        }
    }
}
