using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationServices;
using ApplicationServices.Dtos.Inputs;

namespace VideoWebApp.Controllers
{
    public class CommentController : ControllerWithBaseLogic
    {
        ICommentAppService _commentAppService;

        public async Task<IActionResult> GetComments(Guid videoId)
        {
            var comments = await _commentAppService.GetVideoComments(videoId);

            return Json(comments);
        }
        public async Task<IActionResult> DeleteComment(Guid commentId)
        {
            var res = await _commentAppService.DeleteComment(commentId);


            return Json(res);
        }

        public async Task<IActionResult> AddComment([FromBody]CreateCommentDto comment)
        {
            var res = await _commentAppService.CreateComment(comment);


            return Json(res);
        }
        public async Task<IActionResult> AnswerComment(AnswerCommentDto answer)
        {
            var res = await _commentAppService.AnswerComment(answer);


            return Json(res);
        }
        public async Task<IActionResult> Like(Guid commentId, Guid userId)
        {
            var res = await _commentAppService.Like(userId, commentId);

            return Json(res);
        }
        public async Task<IActionResult> Dislike(Guid commentId, Guid userId)
        {
            var res = await _commentAppService.Dislike(userId , commentId);

            return Json(res);
        }
        public async Task<IActionResult> ChangeText(Guid commentId, string text)
        {
            var res = await _commentAppService.SetText(text, commentId);

            return Json(res);
        }
        public async Task<IActionResult> GetAnswers(Guid commentId)
        {
            var res = await _commentAppService.GetAnswers(commentId);

            return Json(res);
        }
    }
}
