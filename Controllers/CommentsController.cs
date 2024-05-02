using AutoMapper;
using EntityFramework.DTOs;
using EntityFramework.Entities;
using Microsoft.AspNetCore.Mvc;

namespace EntityFramework.Controllers
{
    [ApiController]
    [Route("api/movies/{movieId:int}/comments")]
    public class CommentsController :  ControllerBase
    {
        private readonly AplicationDBConext context;
        private readonly IMapper mapper;
        public CommentsController(AplicationDBConext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult> Post(int movieId, CreationCommentDTO commentCreation)
        {
            var comment = mapper.Map<Comment>(commentCreation);
            comment.MovieId = movieId;

            context.Add(comment);
            await context.SaveChangesAsync();
            return Ok();

        }
    }
}
