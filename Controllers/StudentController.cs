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

  [HttpGet]
  public ActionResult<IEnumerable<Student>> Get()
  {
    var students = _context.Students.ToList();

    if(students is null)
    {
      return NotFound("Estudantes não encontrados");
    }
    return students;
  }

  [HttpGet("{id:int}", Name="ObterEstudante")]
  public ActionResult<Student> Get(int id)
  {
    var student = _context.Student.FirstOrDefault(s => s.StudentId == id);

    if(student is null)
    {
      return NotFound("Estudante não encontrado");
    }

    return student;
  }

  [HttpPost]
  public ActionResult Student(Student student)
  {
    if (student is null)
    {
      return BadRequest("Estudante inválido");
    }

    _context.Student.Add(student);
    _context.SaveChanges();

    return new CreatedAtRouteResult("ObterEstudante", new { id = student.StudentId }, student);
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
    var student = _context.Student.FirstOrDefault(s => s.StudentId == id);

    if (student is null)
    {
      return NotFound("Estudante não encontrado");
    }

    _context.Student.Remove(student);
    _context.SaveChanges();

    return Ok(student);
  }
}