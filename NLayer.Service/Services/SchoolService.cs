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
    public class SchoolService : Service<School>, ISchoolService
    {
        private readonly ISchoolRepository _schoolRepository;
        private readonly IMapper _mapper;
        public SchoolService(IGenericRepository<School> repository, IUnitOfWork unitOfWork = null, ISchoolRepository schoolRepository = null, IMapper mapper = null) : base(repository, unitOfWork)
        {
            _schoolRepository = schoolRepository;
            _mapper = mapper;
        }

        public async Task<CustomResponseDto<SchoolWithStudentsDto>> GetSingleSchoolByIdWithStudentsAsync(int schoolId)
        {
            var school = await _schoolRepository.GetSingleSchoolByIdWithStudentsAsync(schoolId);
            var schoolDto = _mapper.Map<SchoolWithStudentsDto>(school);
            return CustomResponseDto<SchoolWithStudentsDto>.Success(200,schoolDto);
        }
    }
}
