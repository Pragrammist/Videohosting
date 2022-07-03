using DomainLogic.Shared;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using MimeTypes;

namespace DomainLogic.Aggregates
{
    public class File : AggregateRootGuid
    {

        private string[] imgExts = new string[] { ".jpg", ".jpeg", ".png" };
        private string[] videoExts = new string[] { ".mp4" };
        protected string[] allowedFormats;
        protected File() { }
        private string[] UnionArrays(params string[][] arrs)
        {
            var res = new string[] { };
            foreach (var arr in arrs)
            {
                res = res.Union(arr).ToArray();
            }
            return res;
        }
        public File(Guid id, string filePath) : base(id)
        {
            allowedFormats = UnionArrays(imgExts, videoExts);
            SetFilePath(filePath);
            //SetMimeType(filePath);
        }
        public void SetFilePath(string filePath)
        {
            FilePath = filePath;
            SetMimeType(filePath);
            SetSize(filePath);
        }
        
        protected string SetMimeType(string filePath)
        {
            var ext = Path.GetExtension(filePath);

            if (!allowedFormats.Contains(ext))
                throw new Exception();
            
            

            MimeType = MimeTypeMap.GetMimeType(ext);
            return MimeType;
        }
        protected void SetName(string filePath)
        {
            Name = Path.GetFileName(filePath);
        }
        protected void SetSize(string filePath)
        {
            FileInfo fileInfo = new FileInfo(filePath);
            Size = fileInfo.Length;

        }
        protected void SetFileType(string mimeType) //dont check format cause it check in SetMimeType
        {
            foreach (var format in allowedFormats)
            {
                if (mimeType.Contains(format))
                {

                }
            }
            
        }

        public string Name { get; protected set; }
        public string FilePath { get; protected set; }
        public string MimeType { get; protected set; }
        public long Size { get; protected set; }

    }
}
