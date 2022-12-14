using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Tryitter.Context;
using Tryitter.Models;
using Tryitter.Services;

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


  [HttpGet]
  public ActionResult<IEnumerable<Student>> Get()
  {
    //  Aula 49:

    try
    {
      //  Aula 48:

      var students = _context.Students.AsNoTracking().ToList();

      // if (students is null)
      // {
      //   return NotFound("Estudantes não encontrados");
      // }

      return students;
    }
    catch (Exception)
    {
      return StatusCode(StatusCodes.Status500InternalServerError, "Ocorreu um problema ao tratar a sua solicitação.");
    }
  }



  [HttpGet("{id:int}", Name = "ObterEstudante")]
  public ActionResult<Student> Get(int id)
  {
    var student = _context.Students.FirstOrDefault(s => s.StudentId == id);

    // if (student is null)
    // {
    //   return NotFound($"Estudante com o id = {id} não encontrado");
    // }

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

    var token = new TokenGenerator().Generate(student);

    return new CreatedAtRouteResult("ObterEstudante", new { id = student.StudentId }, new { student, token });
  }

  [HttpPut("{id:int}")]
  [Authorize(Policy = "student")]
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
  [Authorize(Policy = "student")]
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