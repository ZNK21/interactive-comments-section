using System.ComponentModel.DataAnnotations;

namespace interactive_comments_section.Entities {
    public class View_All {
        [Key()]
        public int userId { get; set; }
        public int commentId { get; set; }
        public string text { get; set; }
        public int votes { get; set; }
        public bool isReply { get; set; }
        public int? replyId { get; set; }
        public byte? photo { get; set; }
        public string username { get; set; }
        public string name { get; set; }
    }
}
