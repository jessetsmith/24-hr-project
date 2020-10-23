using _24HourProject.Models;
using _24HourProject.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace _24HourProject.WebAPI.Controllers
{
    [Authorize]
    public class ReplyController : ApiController
    {
        private ReplyCommentService CreateReplyCommentService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var replyCommentService = new ReplyCommentService(userId);
            return replyCommentService;
        }
        public IHttpActionResult Get()
        {
            ReplyCommentService replyCommentService = CreateReplyCommentService();
            var replyComments = replyCommentService.GetReplyComments();
            return Ok(replyComments);
        }
        public IHttpActionResult Post(ReplyCommentCreate replyComment)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateReplyCommentService();

            if (!service.CreateReplyComment(replyComment))
                return InternalServerError();

            return Ok();
        }
        public IHttpActionResult Get(int id)
        {
            ReplyCommentService replyCommentService = CreateReplyCommentService();
            var replyComment = replyCommentService.GetReplyCommentById(id);
            return Ok(replyComment);
        }
        public IHttpActionResult Put(ReplyCommentEdit replyComment)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateReplyCommentService();

            if (!service.UpdateReplyComment(replyComment))
                return InternalServerError();

            return Ok();
        }
        public IHttpActionResult Delete(int id)
        {
            var service = CreateReplyCommentService();

            if (!service.DeleteReplyComment(id))
                return InternalServerError();

            return Ok();
        }
    }
}
