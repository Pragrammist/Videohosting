namespace ApplicationServices.Dtos.Outputs
{
    public class FileOutputDto
    {
        public string Name { get; set; }
        public string FilePath { get; set; }
        public string MimeType { get; set; }
        public long Size { get; set; }
    }
}
