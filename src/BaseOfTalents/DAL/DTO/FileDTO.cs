namespace DAL.DTO
{
    public class FileDTO : BaseEntityDTO
    {
        public string FilePath { get; set; }
        public string Description { get; set; }
        public long Size { get; set; }
    }
}
