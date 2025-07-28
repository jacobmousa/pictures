using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;

namespace Pictures.Application.DTOs
{
    public class PictureUploadDto
    {
        [Required(ErrorMessage = "Picture name is required.")]
        [MaxLength(50, ErrorMessage = "Picture name must not exceed 50 characters.")]
        public string Name { get; set; } = string.Empty;

        [MaxLength(250, ErrorMessage = "Description must not exceed 250 characters.")]
        public string? Description { get; set; }

        public DateTime? Date { get; set; }

        [Required(ErrorMessage = "File is required.")]
        public IFormFile File { get; set; } = default!;
    }
}
