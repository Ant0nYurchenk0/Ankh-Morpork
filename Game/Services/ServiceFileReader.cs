using System.IO;
using System.Text;
using System.Collections.Generic;

namespace Game
{
    internal static class ServiceFile
    {
        private static Dictionary<string, string> _cache = new Dictionary<string, string>();
        public static string ReadFileCache(string path)
        {
            var content = string.Empty;
            if (_cache.TryGetValue(path, out var cachedContent)) return cachedContent;
            content = ReadFile(path).ToString();
            _cache.Add(path, content);
            return content;
        }
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
                writer.WriteAsync(updatedData);
            }
        }
    }
}
