using Microsoft.AspNetCore.Mvc;
using Tryitter.ViewModels;
using Tryitter.Models;
using Tryitter.Repository;
using Tryitter.Services;

namespace Tryitter.Controllers;

[HttpPost]

public ActionResult<StudentViewModel> Authenticate([FromBody] Student student)
{
  StudentViewModel studentViewModel = new StudentViewModel();
  try
  {
    studentViewModel.Student = new StudentRepository().Get(student);

    if (studentViewModel.Student == null)
    {
      return NotFound("Student not found!");
    }

    studentViewModel.Token = new TokenGenerator().Generate();

    Student.Senha = string.Empty;
  } 
  catch (Exception ex)
  {
    return BadRequest(ex.Message);
  }
  return studentViewModel;
}