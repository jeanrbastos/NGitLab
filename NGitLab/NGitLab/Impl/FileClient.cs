using NGitLab.Models;
using System;

namespace NGitLab.Impl
{
    public class FileClient : IFilesClient
    {
        private readonly API _api;
        private readonly string _repoPath;

        public FileClient(API api, string repoPath)
        {
            _api = api;
            _repoPath = repoPath;
        }

        public void Create(FileUpsert file)
        {
            _api.Post().With(file).Stream(_repoPath + "/files", s => { });
        }

        public void Update(FileUpsert file)
        {
            _api.Put().With(file).Stream(_repoPath + "/files", s => { });
        }

        public void Delete(FileDelete file)
        {
            _api.Delete().With(file).Stream(_repoPath + "/files", s => { });
        }

        public FileData Get(string branch, string filePath)
        {
            return _api.Get()
                       .To<FileData>(_repoPath + String.Format("/files?ref={0}&file_path={1}", branch, filePath));
        }
    }
}