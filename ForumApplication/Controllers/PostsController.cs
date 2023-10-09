using AutoMapper;
using ForumApplication.API.Models;
using ForumApplication.API.Services;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ForumApplication.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]

    public class PostsController : ControllerBase
    {
        private readonly IForumApplicationRepository _forumApplicationRepository;
        private readonly IMapper _mapper;
        // DI 
        public PostsController(IForumApplicationRepository forumApplicationRepository, IMapper mapper)
        {
           _forumApplicationRepository = forumApplicationRepository ??
                throw new ArgumentNullException(nameof(forumApplicationRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            ;
        }
        // GET: api/<PostsController> to get all posts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PostWithoutCommentsDto>>> Get()
        {
            var postEntities = await _forumApplicationRepository.GetPostsAsync();

            return Ok(_mapper.Map<IEnumerable<PostWithoutCommentsDto>>(postEntities));
        }

        // GET api/<PostsController>/5 to get a single post including comments
        [HttpGet("{id}", Name = "GetPost")]        
        public async Task<ActionResult<PostDto>> Get(int id)
        {
            var post = await _forumApplicationRepository.GetPostAsync(id);
            if (post == null) { return NotFound(); }
            return Ok(_mapper.Map<PostDto>(post));
        }

        // POST api/<PostsController> add a post
        [HttpPost]
        public async Task<ActionResult<PostDto>> Create( CreatePostDto post)
        {
            var finalPost = _mapper.Map<ForumApplication.API.Entities.Post>(post);
            finalPost.CreatedTime = DateTime.UtcNow;
            await _forumApplicationRepository.AddPostAsync(finalPost);
            await _forumApplicationRepository.SaveChangesAsync();

            var createdPostToReturn = _mapper.Map<ForumApplication.API.Models.PostDto>(finalPost);
            return Ok( createdPostToReturn);

        }


        //PUT api/<PostsController>/5 edit a post
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, UpdatePostDto updatedPost)
        {
            var postEntity = await _forumApplicationRepository
                .GetPostAsync(id);

            if (postEntity == null) { return NotFound(); }
            postEntity.UpdatedTime = DateTime.UtcNow;
            _mapper.Map(updatedPost, postEntity);// overrrides destination object with those from source object
            await _forumApplicationRepository.SaveChangesAsync();

            return NoContent();

        }

        // future work edit a post partially

        //[HttpPatch("{id}")]
        //public async Task<ActionResult> PartiallyUpdatePointOfInterest(
        //    int id,
        //    JsonPatchDocument<UpdatePostDto> patchDocument
        //    )
        //{
        //    var postEntity = await _forumApplicationRepository.GetPostAsync(id);
        //    if (postEntity == null)
        //    { return NotFound(); }

        //    var postToPatch = _mapper.Map<UpdatePostDto>(postEntity);

        //    patchDocument.ApplyTo(postToPatch, ModelState);

        //    if (!ModelState.IsValid)
        //    { return BadRequest(ModelState); }

        //    if (!TryValidateModel(postToPatch))
        //    { return BadRequest(ModelState); }
        //    postEntity.UpdatedTime = DateTime.UtcNow;
        //    _mapper.Map(postToPatch, postEntity);

        //    await _forumApplicationRepository.SaveChangesAsync();
        //    return NoContent();

        //}



        // DELETE api/<PostsController>/5 delete a post
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)

        {
            var postEntity = await _forumApplicationRepository
                .GetPostAsync(id);
            if (postEntity == null)
            { return NotFound(); }

            _forumApplicationRepository.DeletePost(postEntity);
            await _forumApplicationRepository.SaveChangesAsync();
            return NoContent();
        }

    }
}
