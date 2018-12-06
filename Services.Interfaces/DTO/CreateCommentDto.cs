using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces.DTO
{
    public class CreateCommentDTO
    {
        public string ResourceId { get; set; }
        public string AuthorId { get; set; }
        public string Text { get; set; }
        public DateTime Date { get; set; }
    }
}
