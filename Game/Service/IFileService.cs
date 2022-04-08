namespace Game.Service
{
    public interface IFileService
    {
        string ReadFile(string path);
        string ReadFileCache(string path);
        void WriteToFile(string path, string updatedData);
    }
}