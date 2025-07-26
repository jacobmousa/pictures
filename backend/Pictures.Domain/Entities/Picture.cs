using System;
using System.ComponentModel.DataAnnotations;

namespace Pictures.Domain.Entities
{
    public class Picture
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; } = string.Empty;

        public DateTime? Date { get; set; }

        [MaxLength(250)]
        public string? Description { get; set; }

        [Required]
        public byte[] FileContent { get; set; } = Array.Empty<byte>();

        [Required]
        public string FileName { get; set; } = string.Empty;
    }
}
