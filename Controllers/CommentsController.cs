using interactive_comments_section.Context;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace interactive_comments_section.Controllers {
    public class CommentsController : Controller {
        public IActionResult Index() {
            return View(_Data.View_All.OrderBy(i => i.commentId).ToList());
        }

        public readonly CommentsContext _Data;

        public CommentsController(CommentsContext Data) {
            _Data = Data;
        }
    }
}
