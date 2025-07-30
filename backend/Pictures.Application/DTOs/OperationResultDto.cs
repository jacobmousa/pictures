using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pictures.Application.DTOs
{
    public class OperationResultDto
    {
        /// <summary>
        /// Indicates if the operation succeeded.
        /// </summary>
        public string? Error { get; set; }

        public int Id { get; set; }


        public static OperationResultDto Ok(int id) => new() { Id = id };
        public static OperationResultDto Fail(string error) => new() { Error = error };

    }
}
