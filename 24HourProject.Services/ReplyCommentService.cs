using _24HourProject.Data;
using _24HourProject.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24HourProject.Services
{
    public class ReplyCommentService
    {
        private readonly Guid _userId;

        public ReplyCommentService(Guid userId)
        {
            _userId = userId;
        }
        public bool CreateReplyComment(ReplyCommentCreate model)
        {
            var entity =
                new Reply()
                {
                    OwnerId = _userId,
                    Text = model.Text,
                    Author = model.Author,
                    CommentPost = model.CommentPost
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Replies.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<ReplyCommentListItem> GetReplyComments()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Replies
                        .Where(e => e.OwnerId == _userId)
                        .Select(
                            e =>
                                new ReplyCommentListItem
                                {
                                    ReplyCommentId = e.ReplyCommentId,
                                    Text = e.Text,
                                    CreatedUtc = e.CreatedUtc
                                }
                        );

                return query.ToArray();
            }
        }
        public ReplyCommentDetail GetReplyCommentById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Replies
                        .Single(e => e.ReplyCommentId == id && e.OwnerId == _userId);
                return
                    new ReplyCommentDetail
                    {
                        ReplyCommentId = entity.ReplyCommentId,
                        Text = entity.Text,
                        CreatedUtc = entity.CreatedUtc,
                        ModifiedUtc = entity.ModifiedUtc
                    };
            }
        }
        public bool UpdateReplyComment(ReplyCommentEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Replies
                        .Single(e => e.ReplyCommentId == model.ReplyCommentId && e.OwnerId == _userId);

                entity.Text = model.Text;
                entity.ModifiedUtc = DateTimeOffset.UtcNow;

                return ctx.SaveChanges() == 1;
            }
        }
        public bool DeleteReplyComment(int replyCommentId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Replies
                        .Single(e => e.ReplyCommentId == replyCommentId && e.OwnerId == _userId);

                ctx.Replies.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
