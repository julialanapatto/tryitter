using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Tryitter.Context;
using Tryitter.Models;

namespace Tryitter.Controllers;

[Route("[controller]")]
[ApiController]
public class StudentController : ControllerBase
{
  private readonly AppDbContext _context;
  public StudentController(AppDbContext context)
  {
    _context = context;
  }


  [HttpGet("posts")]
  public ActionResult<IEnumerable<Student>> GetStudentsPosts()
  {
    var studentsPosts = _context.Students.Include(p => p.Post).Where(s => s.StudentId <=5).ToList();

    if(studentsPosts is null)
    {
      return NotFound("Estudantes não encontrados");
    }

    return studentsPosts;
  }

  [HttpGet]
  public ActionResult<IEnumerable<Student>> Get()
  {
    //  Aula 49:

    try
    {
      //  Aula 48:

      var students = _context.Students.AsNoTracking().ToList();

      if(students is null)
      {
        return NotFound("Estudantes não encontrados");
      }

      return students;
    }
    catch (Exception)
    {
      return StatusCode(StatusCodes.Status500InternalServerError, "Ocorreu um problema ao tratar a sua solisitação.");
    }
  }

  [HttpGet("{id:int}", Name="ObterEstudante")]
  public ActionResult<Student> Get(int id)
  {
    var student = _context.Students.FirstOrDefault(s => s.StudentId == id);

    if(student is null)
    {
      return NotFound($"Estudante com o id = {id} não encontrado");
    }

    return student;
  }

  [HttpPost]
  public ActionResult Post(Student student)
  {
    if (student is null)
    {
      return BadRequest("Estudante inválido");
    }

    _context.Students.Add(student);
    _context.SaveChanges();

    return new CreatedAtRouteResult("ObterEst udante", new { id = student.StudentId }, student);
  }

  [HttpPut("{id:int}")]
  public ActionResult Put(int id, Student student)
  {
    if (id != student.StudentId)
    {
      return BadRequest("Id inválido");
    }

    _context.Entry(student).State = EntityState.Modified;
    _context.SaveChanges();

    return Ok(student);
  }

  [HttpDelete("{id:int}")]
  public ActionResult Delete(int id)
  {
    var student = _context.Students.FirstOrDefault(s => s.StudentId == id);

    if (student is null)
    {
      return NotFound("Estudante não encontrado");
    }

    _context.Students.Remove(student);
    _context.SaveChanges();

    return Ok(student);
  }
}