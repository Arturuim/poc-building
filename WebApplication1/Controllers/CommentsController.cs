using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;
using AutoMapper;
using Services.Interfaces;
using Services.Interfaces.DTO;
using WebApplication1.API.DTO;

namespace WebApplication1.Controllers
{
    public class CommentsController : ApiController
    {

        private readonly ICommentsService _commentsService;

        public CommentsController(ICommentsService commentsService)
        {
            _commentsService = commentsService;
        }

        public IHttpActionResult Post([FromBody]CommentCreateDTO createComment)
        {
            this._commentsService.AddComment(Mapper.Map<CreateCommentDTO>(createComment));
            return  new StatusCodeResult(HttpStatusCode.NoContent, this.Request);
        }

        public IHttpActionResult Get(string id)
        {
            return Ok(this._commentsService.GetCommentsById(id));
        }
    }
}
