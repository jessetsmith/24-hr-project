using System;
using _24HourProject.Models;
using _24HourProject.Data;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace _24HourProject.Services
{
    public class LikeService
    {
        private readonly Guid _userId;
        public LikeService(Guid userId) 
        {
            _userId = userId;
        }
        public bool CreateLike(LikeCreate model) 
        {
            var entity =
                new Like()
                {
                    OwnerId = _userId,
                    LikedPost = model.LikedPost,
                    Liker = model.Liker,
                };
            using (var ctx = new ApplicationDbContext()) 
            {
                ctx.Likes.Add(entity);
                return ctx.SaveChanges() == 1;
            }

        }
        public IEnumerable<LikeListItem> GetLikes()
        {
            using (var ctx = new ApplicationDbContext()) 
            {
                var query =
                    ctx
                       .Likes
                       .Where(e => e.OwnerId == _userId)//Is this wrong for Like?
                       .Select(
                                e =>
                                    new LikeListItem
                                    {
                                        LikedPost = e.LikedPost,
                                        Liker = e.Liker,
                                    }
                            );
                return query.ToArray();
            }
        }
        public LikeDetail GetLikeById(int id) 
        {
            using (var ctx = new ApplicationDbContext()) 
            {
                var entity =
                    ctx
                        .Likes
                        .Single(e => e.LikeId == id && e.OwnerId == _userId); //Missing does like need an id?
                    return
                        new LikeDetail
                        {
                            LikedPost = entity.LikedPost,
                            Liker = entity.Liker
                        };

            }
        }
        public bool UpdateLike (LikeEdit model) 
        {
            using (var ctx = new ApplicationDbContext()) 
            {
                var entity =
                    ctx
                        .Likes
                        .Single(e => e.LikeId == model.LikeId && e.OwnerId == _userId);

                entity.LikedPost = model.LikedPost;
                entity.Liker = model.Liker;

                return ctx.SaveChanges() == 1;
            }
        }
        public bool DeleteLike(int likeId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Likes
                        .Single(e => e.LikeId == likeId && e.OwnerId == _userId);

                ctx.Likes.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
