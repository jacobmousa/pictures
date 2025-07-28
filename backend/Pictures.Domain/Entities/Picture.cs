using System;

namespace Pictures.Domain.Entities
{
    public class Picture
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public DateTime? Date { get; set; }
        public byte[] FileContent { get; set; } = Array.Empty<byte>();
        public string FileName { get; set; }
    }
}
