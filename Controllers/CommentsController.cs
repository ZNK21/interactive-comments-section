using interactive_comments_section.Context;
using interactive_comments_section.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Diagnostics;
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

        [HttpPost]
        public IActionResult New(string text) {

            var commentCount = _Data.View_All.Count();

            try {
                Comments ii = new Comments {
                    commentId = commentCount + 1,
                    text = text,
                    userId = 3,
                    votes = 0,
                    isReply = false,
                };

                _Data.Comments.Add(ii);
                _Data.SaveChanges();

                return Json(true);

            } catch (Exception ex) {
                Debug.WriteLine(ex);
            }

            return Json(false);
        }

        [HttpPost]
        public IActionResult Vote(int commentId, bool plus) {

            try {

                Comments comentarios = _Data.Comments.Find(commentId);

                if (comentarios != null) {

                    if (plus) {
                        comentarios.votes = comentarios.votes + 1;
                    } else {
                        comentarios.votes = comentarios.votes - 1;
                    }

                    _Data.Entry(comentarios).State = EntityState.Modified;
                    _Data.SaveChanges();

                    return Json(true);
                }

            } catch (Exception ex) {
                Debug.WriteLine(ex);
            }

            return Json(false);
        }

        [HttpPost]
        public IActionResult Reply(string text, int replyId) {

            var commentCount = _Data.View_All.Count();

            try {

                Comments ii = new Comments {
                    commentId = commentCount + 1,
                    text = text,
                    userId = 3,
                    votes = 0,
                    isReply = true,
                    replyId = replyId
                };

                _Data.Comments.Add(ii);
                _Data.SaveChanges();

                return Json(true);

            } catch (Exception ex) {
                Debug.WriteLine(ex);
            }

            return Json(false);
        }
    }
}
