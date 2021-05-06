namespace Surzor.Application.Features.Responders.Queries
{
    public class ResponderExportVm
    {
        public string FileName { get; set; }
        public string FileType { get; set; }
        public byte[] Data { get; set; }
    }
}
