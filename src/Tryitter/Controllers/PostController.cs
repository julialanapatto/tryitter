using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Tryitter.Context;
using Tryitter.Models;

namespace Tryitter.Controllers;

[Route("[controller]")]
public class PostController : ControllerBase
{
  private readonly AppDbContext _context;
  public PostController(AppDbContext context)
  {
    _context = context;
  }

  [HttpGet]
  public ActionResult<IEnumerable<Post>> Get()
  {
    var posts = _context.Post.AsNoTracking().Take(10).ToList();

    if (posts is null)
    {
      return NotFound("Posts não encontrados");
    }
    return posts;
  }


  [HttpGet("{id:int}", Name = "ObterPost")]
  public ActionResult<Post> Get(int id)
  {
    var post = _context.Post.FirstOrDefault(p => p.PostId == id);

    if (post is null)
    {
      return NotFound("Post não encontrado");
    }

    return post;
  }

  // Get post por id do estudante
  [HttpGet("Student")]
  public ActionResult<IEnumerable<Post>> GetPostsByStudentId(int id)
  {
    var posts = _context.Post.Where(x => x.StudentId == id).AsNoTracking().ToList();
    if (posts is null)
    {
      return NotFound("Nenhum Post Encontrado");
    }
    return posts;
  }

  [HttpPost]
 // [Authorize(Policy = "student")]
  public ActionResult Post(Post post)
  {
    if (post is null)
    {
      return BadRequest("Post inválido");
    }

    _context.Post.Add(post);
    _context.SaveChanges();

    return new CreatedAtRouteResult("ObterPost", new { id = post.PostId }, post);
  }


  [HttpPut("{id:int}")]
  // [Authorize(Policy = "student")]
  public ActionResult Put(int id, Post post)
  {
    if (id != post.PostId)
    {
      return BadRequest("Id inválido");
    }

    _context.Entry(post).State = EntityState.Modified;
    _context.SaveChanges();

    return Ok(post);
  }


  [HttpDelete("{id:int}")]
 // [Authorize(Policy = "student")]
  public ActionResult Delete(int id)
  {
    var post = _context.Post.FirstOrDefault(p => p.PostId == id);

    if (post is null)
    {
      return NotFound("Post não encontrado");
    }

    _context.Post.Remove(post);
    _context.SaveChanges();

    return Ok(post);
  }
}