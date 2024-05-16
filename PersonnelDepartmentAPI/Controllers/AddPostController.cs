using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PersonnelDepartmentAPI.Classes;

namespace PersonnelDepartmentAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddPostController : ControllerBase
    {
        private DepartmentPersonnelContext dataBase;

        public AddPostController() 
        {
            dataBase = new();
        }

        [HttpPost("AddWorkerPost")]
        public async void AddPost(PostDTO postDTO)
        {
            if (postDTO != null)
            {
                dataBase.Posts.Add(postDTO.Convert());
                await dataBase.SaveChangesAsync();
            }
        }

        [HttpGet("GetPosts")]
        public async Task<ActionResult<List<PostDTO>>> GetPosts()
        {
            return Ok(await dataBase.Posts.Select(s=>s.Convert()).ToListAsync());
        }

        [HttpGet("GetPost")]
        public async Task<ActionResult<PostDTO>> GetPost(int id)
        {
            var post = await dataBase.Posts.FirstOrDefaultAsync(s => s.Id == id);
            return Ok(post.Convert());
        }
        [HttpPost("DeletePost")]
        public async Task<ActionResult> DeletePost(int id)
        {
            Console.WriteLine(id);
            var delPost = await dataBase.Posts.FirstOrDefaultAsync(s=>s.Id==id);
            if(delPost == null)
                return NotFound();
            dataBase.Entry(delPost).State = EntityState.Deleted;

            await dataBase.SaveChangesAsync();
            return Ok();
        }
    }
}
