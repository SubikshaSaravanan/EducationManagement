// Controllers/StudentsController.cs
using EducationManagement.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

[Route("api/[controller]")]
[ApiController]
public class StudentsController : ControllerBase
{
    private readonly StudentContext _context;

    public StudentsController(StudentContext context)
    {
        _context = context;
    }

    [HttpGet("LeftJoin")]
    public async Task<IActionResult> GetStudentsWithClassesLeftJoin()
    {
        var result = await (from student in _context.Students
                            join cls in _context.Classes
                            on student.ClassId equals cls.ClassId into studentClassGroup
                            from studentClass in studentClassGroup.DefaultIfEmpty()
                            select new
                            {
                                student.Id,
                                student.Name,
                                student.Age,
                                ClassName = studentClass != null ? studentClass.ClassName : null
                            }).ToListAsync();

        return Ok(result);
    }

 
    [HttpGet("RightJoin")]
    public async Task<IActionResult> GetStudentsWithClassesRightJoin()
    {
        var result = await (from cls in _context.Classes
                            join student in _context.Students
                            on cls.ClassId equals student.ClassId into classStudentGroup
                            from classStudent in classStudentGroup.DefaultIfEmpty()
                            select new
                            {
                                StudentId = classStudent != null ? classStudent.Id : 0,
                                StudentName = classStudent != null ? classStudent.Name : null,
                                ClassId = cls.ClassId,
                                ClassName = cls.ClassName
                            }).ToListAsync();

        return Ok(result);
    }


    [HttpGet("GroupBy")]
    public async Task<IActionResult> GetStudentsGroupedByClass()
    {
        var result = await (from student in _context.Students
                            group student by student.ClassId into studentGroup
                            select new
                            {
                                ClassId = studentGroup.Key,
                                Students = studentGroup.ToList()
                            }).ToListAsync();

        return Ok(result);
    }


    [HttpGet("OrderBy")]
    public async Task<IActionResult> GetStudentsOrderedByName()
    {
        var result = await (from student in _context.Students
                            orderby student.Name
                            select student).ToListAsync();

        return Ok(result);
    }

}
