using AutoMapper;
using NLayer.Core.DTOs;
using NLayer.Core.Models;
using NLayer.Core.Repositories;
using NLayer.Core.Services;
using NLayer.Core.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Service.Services
{
    
    public class StudentServiceWithNoCaching : Service<Student>, IStudentService
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IMapper _mapper;
        public StudentServiceWithNoCaching(IGenericRepository<Student> repository, IUnitOfWork unitOfWork = null, IStudentRepository studentRepository = null, IMapper mapper = null) : base(repository, unitOfWork)
        {
            _studentRepository = studentRepository;
            _mapper = mapper;
        }

        public async Task<CustomResponseDto<List<StudentWithSchoolDto>>> GetStudentsWithSchool()
        {
            var student = await _studentRepository.GetStudentsWithSchool();
            var studentsDto = _mapper.Map<List<StudentWithSchoolDto>>(student);
            return CustomResponseDto<List<StudentWithSchoolDto>>.Success(200,studentsDto);
        }
    }
}
