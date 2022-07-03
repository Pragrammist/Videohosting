using ApplicationServices.Dtos.Inputs;
using ApplicationServices.Dtos.Outputs;
using System;
using System.IO;
using System.Threading.Tasks;

namespace ApplicationServices
{
    public interface IFileAppService
    {
        public Task<FileOutputDto> GetFile(GetFileDto getFileCriteries);
        public Task<FileOutputDto> CreateFile(FileCreateDto fileCreateData);
        public Task<FileOutputDto> DeleteFile(DeleteFile deleteFileCriteries);
        public Task<FileOutputDto> UpdateName(UpdateNameDto updateNameData);
        public Task<Stream> GetFileStream(Guid fileId);
    }
}
