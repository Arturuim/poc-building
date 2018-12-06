using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.API.DTO
{
    public class CommentCreateDTO
    {
        public string ResourceId { get; set; }
        public string Text { get; set; }
        public DateTime Date { get; set; }
    }
}