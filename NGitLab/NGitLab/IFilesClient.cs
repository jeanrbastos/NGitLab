using NGitLab.Models;
using System.Collections.Generic;

namespace NGitLab
{
    public interface IFilesClient
    {
        void Create(FileUpsert file);
        void Update(FileUpsert file);
        void Delete(FileDelete file);

        FileData Get(string branch, string filePath);
    }
}