using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pictures.Application.Dtos
{
    using Microsoft.AspNetCore.Http;
    using System.ComponentModel.DataAnnotations;

    namespace Pictures.Application.Dtos
    {
        public class UploadPictureRequest
        {
            [Required, MaxLength(50)]
            public string Name { get; set; } = null!;

            [MaxLength(250)]
            public string? Description { get; set; }

            public DateTime? Date { get; set; }

            [Required]
            public IFormFile File { get; set; } = null!;
        }
    }
}
