using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NLayer.Core.DTOs;
using NLayer.Core.Models;
using NLayer.Core.Services;

namespace NLayer.API.Controllers
{
    public class StudentsController : CustomBaseController
    {
        private readonly IMapper _mapper;
    
        private readonly IStudentService _service;
        public StudentsController(IMapper mapper, IService<Student> service, IStudentService studentService = null)
        {
            _mapper = mapper;
            _service = studentService;
        }

        [HttpGet("[action]")] //GET api/products/GetStudentsWithSchool
        public async Task<IActionResult> GetStudentsWithSchool()
        {
            return CreateActionResult(await _service.GetStudentsWithSchool());
        }





        [HttpGet] 
        public async Task<IActionResult> All()
        {
            var students = await _service.GetAllAsync();
            var studentsDtos = _mapper.Map<List<StudentDto>>(students.ToList());
            return CreateActionResult(CustomResponseDto<List<StudentDto>>.Success(200, studentsDtos));
        }

        [HttpGet("{id}")] //GET api/products/5  -- kullanıcıdan bir id bekliyoruz
        public async Task<IActionResult> GeyById(int id)
        {
            var student = await _service.GetByIdAsync(id);
            var studentDto = _mapper.Map<StudentDto>(student);
            return CreateActionResult(CustomResponseDto<StudentDto>.Success(200, studentDto));
        }


        [HttpPost] 
        public async Task<IActionResult> Save(StudentDto studentDto)
        {
            var student = await _service.AddAsync(_mapper.Map<Student> (studentDto));
            var studentsDto = _mapper.Map<StudentDto>(student);
            return CreateActionResult(CustomResponseDto<StudentDto>.Success(201, studentsDto));
        }

        [HttpPut]
        public async Task<IActionResult> Update(StudentUpdateDto studentDto)
        {
            await _service.UpdateAsync(_mapper.Map<Student>(studentDto)); //geriye bir şey dönmüyor
           //geriye bir şey dönmediği için NoContentDto classını dönüyorum
            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }

        [HttpDelete("{id}")] //DELETE api/products/5  -- kullanıcıdan bir id bekliyoruz
        public async Task<IActionResult> Remove(int id)
        {
            var student = await _service.GetByIdAsync(id);
            await _service.RemoveAsync(student);
            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }
    }
}
