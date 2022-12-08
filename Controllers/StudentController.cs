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
}