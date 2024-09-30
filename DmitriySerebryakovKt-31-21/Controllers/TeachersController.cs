using DmitriySerebryakovKt_31_21.Filters.TeacherFilters;
using DmitriySerebryakovKt_31_21.Interfaces.TeachersInterfaces;
using DmitriySerebryakovKt_31_21.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DmitriySerebryakovKt_31_21.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TeachersController : ControllerBase
    {
        private readonly ILogger<TeachersController> _logger;
        private readonly ITeacherService _teacherService;

        public TeachersController(ILogger<TeachersController> logger, ITeacherService teacherService)
        {
            _logger = logger;
            _teacherService = teacherService;
        }

        [HttpPost("GetTeachers")]
        public async Task<IActionResult> GetTeachersAsync(CancellationToken cansellationToken = default)
        {
            var teachers = await _teacherService.GetTeachersAsync(cansellationToken);
            return Ok(teachers);
        }

        [HttpPost("GetTeachersByDepartment")]
        public async Task<IActionResult> GetTeachersByDepartmentAsync(TeacherDepartmentFilter filter, CancellationToken cansellationToken = default)
        {
            var teachers = await _teacherService.GetTeachersByDepartmentAsync(filter, cansellationToken);
            return Ok(teachers);
        }

        [HttpPost("GetTeachersWithTeachingLoadAsync")]
        public async Task<IActionResult> GetTeachersWithTeachingLoadAsync(TeacherDepartmentDisciplineFilter filter, CancellationToken cansellationToken = default)
        {
            var teachers = await _teacherService.GetTeachersWithTeachingLoadAsync(filter, cansellationToken);
            return Ok(teachers);
        }
    }
}
