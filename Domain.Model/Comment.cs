namespace Domain.Model
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Comment
    {
        public string CommentId { get; set; }
        public string ResourceId { get; set; }
        public string AuthorId { get; set; }
        public string Text { get; set; }
        public DateTime Date { get; set; }
        public bool IsApproved { get; set; }
        public string ApproverId  { get; set; }
    }
}
