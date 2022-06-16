using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace interactive_comments_section.Entities {
    [Table("Comment")]
    public class Comments {
        [Key()]
        public int commentId { get; set; }
        public string text { get; set; }
        public int userId { get; set; }
        public int votes { get; set; }
        public bool isReply { get; set; }
        public int? replyId { get; set; }
    }
}
