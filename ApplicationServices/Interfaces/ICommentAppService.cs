using ApplicationServices.Dtos.Inputs;
using ApplicationServices.Dtos.Outputs;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApplicationServices
{
    public interface ICommentAppService
    {
        public Task<IEnumerable<CommentOutputDto>> GetAnswers(Guid commentId, int page = 0);
        public Task<CommentOutputDto> SetText(string text, Guid commentId);
        public Task<CommentOutputDto> Get(GetCommentDto commentGetCreteries);
        public Task<CommentOutputDto> CreateComment(CreateCommentDto createCommentData);
        public Task<CommentOutputDto> AnswerComment(AnswerCommentDto answerCommentData);
        public Task<CommentOutputDto> DeleteComment(Guid id);
        public Task<CommentOutputDto> Like(Guid userId, Guid commentId);
        public Task<CommentOutputDto> Dislike(Guid userId, Guid commentId);
        public Task<CommentOutputDto> Share(Guid userId, Guid commentId);
        public Task<CommentOutputDto> RemoveLike(Guid userId, Guid commentId);
        public Task<CommentOutputDto> RemoveDislike(Guid userId, Guid commentId);
        public Task<IEnumerable<CommentOutputDto>> GetVideoComments(Guid videoId, int page = 0);
    }
}
