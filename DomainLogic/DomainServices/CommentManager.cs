using DomainLogic.Aggregates;
using DomainLogic.Interfaces.Repositories;
using System;
using System.Linq;
using DomainLogic.Interfaces;
using DomainLogic.Specifications.Relations;
using DomainLogic.Aggregates.Relations;
using System.Threading.Tasks;

namespace DomainLogic.DomainServices
{
    public class CommentManager
    {
        IRepository<Comment, Guid> _commentRepository;
        IRepository<Video, Guid> _videoRepository;
        IRepository<User, Guid> _userRepository;
        IRepository<UserAndCommentLike, Guid> _userAndCommentLikeRepository;
        IRepository<UserAndCommentDislike, Guid> _userAndCommentDislikeRepository;
        IRepository<UserAndCommentShared, Guid> _userAndCommentSharedRepository;
        IRepository<CommentAndAnswer, Guid> _commentAndAnswerRepository;
        IGuidGenerator _guidGenerator;


        public async Task<Comment> CreateInstance(Comment comment)
        {
            var videoIsExist = (await _videoRepository.GetByID(comment.VideoId)) != null;

            if (!videoIsExist)
                throw new Exception();

            var userIsExist = ( await _userRepository.GetByID(comment.AuthorId)) != null;
            if (!userIsExist)
                throw new Exception();

            


            return comment;
        }

        public async Task<UserAndCommentLike> LikeComment(Comment comment, User user)
        {
            var commentIsExsts = (await _commentRepository.GetByID(comment.Id)) != null;

            if (!commentIsExsts)
                throw new Exception();


            var userIsExists = _userRepository.GetByID(user.Id) != null;

            if (!userIsExists)
                throw new Exception();


            var likeIsExist = (await _userAndCommentLikeRepository.Get(new UserAndCommentExistsSpecification<UserAndCommentLike>(user.Id, comment.Id))).FirstOrDefault() != null;

            if (likeIsExist)
                return null;


            var like = new UserAndCommentLike(_guidGenerator.GenerateGuid(), user.Id, comment.Id);
            comment.IncreaseLikes();

            return like;
        }
        public async Task<UserAndCommentLike> UnLikeComment(Comment comment, User user)
        {
            var commentIsExsts = (await _commentRepository.GetByID(comment.Id)) != null;

            if (!commentIsExsts)
                throw new Exception();


            var userIsExists = _userRepository.GetByID(user.Id) != null;

            if (!userIsExists)
                throw new Exception();


            var like =  (await _userAndCommentLikeRepository.Get(new UserAndCommentExistsSpecification<UserAndCommentLike>(user.Id, comment.Id))).FirstOrDefault();


            if (like == null)
                return null;

            like.DeleteRelation();

            comment.DecreaseLikes();
            return like;
        }
        public async Task<UserAndCommentDislike> DislikeComment(Comment comment, User user)
        {
            var commentIsExsts = (await _commentRepository.GetByID(comment.Id)) != null;

            if (!commentIsExsts)
                throw new Exception();


            var userIsExists =  (await _userRepository.GetByID(user.Id)) != null;

            if (!userIsExists)
                throw new Exception();


            var dislikeIsExist = (await _userAndCommentDislikeRepository.Get(new UserAndCommentExistsSpecification<UserAndCommentDislike>(user.Id, comment.Id))).FirstOrDefault() != null;

            if (dislikeIsExist)
                return null;


            var like = new UserAndCommentDislike(_guidGenerator.GenerateGuid(), user.Id, comment.Id);

            if (like != null)
                return null;

            comment.IncreaseDislikes();

            return like;
        }
        public async Task<UserAndCommentDislike> UnDislikeComment(Comment comment, User user)
        {
            var commentIsExsts = (await _commentRepository.GetByID(comment.Id)) != null;

            if (!commentIsExsts)
                throw new Exception();


            var userIsExists =  (await _userRepository.GetByID(user.Id)) != null;

            if (!userIsExists)
                throw new Exception();


            var dislike =  (await _userAndCommentDislikeRepository.Get(new UserAndCommentExistsSpecification<UserAndCommentDislike>(user.Id, comment.Id))).FirstOrDefault();
            if (dislike == null)
            {
                return null;
            }


            comment.DecreaseDislikes();

            dislike.DeleteRelation();

            return dislike;
        }
        public async Task<UserAndCommentShared> Share(Comment comment, User user)
        {
            var commentIsExsts = (await _commentRepository.GetByID(comment.Id)) != null;

            if (!commentIsExsts)
                throw new Exception();


            var userIsExists =  (await _userRepository.GetByID(user.Id)) != null;

            if (!userIsExists)
                throw new Exception();


            var shareIsExist = (await _userAndCommentSharedRepository.Get(new UserAndCommentExistsSpecification<UserAndCommentShared>(user.Id, comment.Id))).FirstOrDefault() != null;

            if (shareIsExist)
                return null;


            var shared = new UserAndCommentShared(_guidGenerator.GenerateGuid(), user.Id, comment.Id);


            


            comment.IncreaseShared();

            return shared;
        }
        public async Task<CommentAndAnswer> AnswerToComment(Comment comment, Comment answer)
        {
            var commentIsExsts =  (await _commentRepository.GetByID(comment.Id)) != null;

            if (!commentIsExsts)
                throw new Exception();


            var answerIsExists =  (await _commentRepository.GetByID(answer.Id)) != null;

            if (!answerIsExists)
                throw new Exception();

            var answerIsExist = (await _commentAndAnswerRepository.Get(new CommentAndAnswerExistsSpecification<CommentAndAnswer>(answer.Id, comment.Id))).FirstOrDefault() != null;

            if (answerIsExist)
                throw new Exception();

            var res = new CommentAndAnswer(_guidGenerator.GenerateGuid(), comment.Id, answer.Id);



            return res;
        }
    }
}

