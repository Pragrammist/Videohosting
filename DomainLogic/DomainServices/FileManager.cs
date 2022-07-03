using DomainLogic.Aggregates;
using DomainLogic.Interfaces.Repositories;
using System;
using DomainLogic.Specifications;
using System.Threading.Tasks;
using System.Linq;

namespace DomainLogic.DomainServices
{
    public class FileManager
    {
        IRepository<File, Guid> _fileRepository;

        public async Task<File> CreateInstance(File file)
        {
            var fileIsExists = await FileIsExist(file);

            if (fileIsExists)
                throw new Exception("file already exists");

            return file;
        }
        private async Task<bool> FileIsExist (File file) => (await _fileRepository.Get(new FileExistsSpecification(file.FilePath, file.Id))).FirstOrDefault() != null;
       
    }
}

