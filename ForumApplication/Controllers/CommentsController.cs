using AutoMapper;
using ForumApplication.API.Models;
using ForumApplication.API.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ForumApplication.API.Controllers
{
    [Route("api/posts/{postId}/[controller]")]
    [ApiController]
    [Produces("application/json")]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]

    public class CommentsController : ControllerBase
    {
        private readonly IForumApplicationRepository _forumApplicationRepository;
        private readonly IMapper _mapper; 

        // DI to use mapper and repository
        public CommentsController(IForumApplicationRepository forumApplicationRepository, IMapper mapper)
        {
            _forumApplicationRepository = forumApplicationRepository ??
                throw new ArgumentNullException(nameof(forumApplicationRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            ;

        }
        //GET: api/<CommentsController> to get all comments on a post
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CommentDto>>> Get(int postId)
        {
            if (! await _forumApplicationRepository.PostExistsAsync(postId))
            {
                return NotFound();
            }

            var commentOnPost = await _forumApplicationRepository.GetCommentsAsync(postId);
            
            return Ok(_mapper.Map<IEnumerable<CommentDto>>(commentOnPost));
        }

        // GET api/<CommentsController>/5 To get a specific comment 
        [HttpGet("{id}", Name = "GetComment")]
        public async Task<ActionResult<CommentDto>> Get(int postId, int commentId)
        {
            if (!await _forumApplicationRepository.PostExistsAsync(postId))
            {
                return NotFound();
            }

            var commentOnPost = await _forumApplicationRepository.GetCommentAsync(postId, commentId);
            if (commentOnPost == null) { return NotFound(); }

            return Ok(_mapper.Map<CommentDto>(commentOnPost));
        }

        // POST api/<CommentsController> to add a comment to a post
        [HttpPost]
        public async Task<ActionResult<CommentDto>> Create(int postId, CreateCommentDto comment)
        {

            if (!await _forumApplicationRepository.PostExistsAsync(postId)) { return NotFound(); }

            var finalComment = _mapper.Map<Entities.Comment>(comment);
            finalComment.CreatedTime = DateTime.UtcNow;
            await _forumApplicationRepository.AddCommmentforPostAsync(postId, finalComment);
            await _forumApplicationRepository.SaveChangesAsync();

            var createdCommentToReturn = _mapper.Map<Models.CommentDto>(finalComment);
            return Ok( createdCommentToReturn );

        }
        // To edit a comment 

        //// PUT api/<CommentsController>/5
        //[HttpPut("{id}")]d
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        // To delete a comment 
        //// DELETE api/<CommentsController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
