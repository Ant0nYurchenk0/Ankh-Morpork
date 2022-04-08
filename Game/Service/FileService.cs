using System.IO;
using System.Text;
using System.Collections.Generic;
using System;
using Game.Constants;

namespace Game.Service
{
    public class FileService :IFileService
    {
        private static Dictionary<string, string> _cache = new Dictionary<string, string>();
        public string ReadFileCache(string path)
        {
            if (_cache.TryGetValue(path, out var content)) return content;
            content = ReadFile(path).ToString();
            _cache.Add(path, content);
            return content;
        }
        public string ReadFile(string path)
        {
            try
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
            catch
            {
                throw new ArgumentException(Message.FileAccessError);

            }
        }

        public void WriteToFile(string path, string updatedData)
        {
            try
            {
                using (var writer = new StreamWriter(path, false))
                {
                    writer.WriteAsync(updatedData);
                }
            }
            catch
            {
                throw new ArgumentException(Message.FileAccessError);
            }
        }
    }
}
