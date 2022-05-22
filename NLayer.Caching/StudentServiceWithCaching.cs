using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using NLayer.Core.DTOs;
using NLayer.Core.Models;
using NLayer.Core.Repositories;
using NLayer.Core.Services;
using NLayer.Core.UnitOfWorks;
using NLayer.Service.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Caching
{
    public class StudentServiceWithCaching : IStudentService
    {
        private const string CacheStudentKey = "studentsCache";
        private readonly IMapper _mapper;
        private readonly IMemoryCache _memoryCache;
        private readonly IStudentRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public StudentServiceWithCaching(IMapper mapper, IMemoryCache memoryCache, IStudentRepository repository, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _memoryCache = memoryCache;
            _repository = repository;
            _unitOfWork = unitOfWork;

            //cachedeki datayı almak istemediğim için _ koydum, sadece bu keyde cache var mı yok mu onu kontrol ettim.
            if(!_memoryCache.TryGetValue(CacheStudentKey, out _))
            {
                _memoryCache.Set(CacheStudentKey, _repository.GetStudentsWithSchool().Result);
                //constructorun içinde await kullanamadığımız için asenkronu senkrona dönüştürdüm result diyerek
            }
        }

        public async Task<Student> AddAsync(Student entity)
        {
            await _repository.AddAsync(entity);
            await _unitOfWork.CommitAsync();
            await CacheAllStudentsAsync();
            return entity;
        }

        public async Task<IEnumerable<Student>> AddRangeAsync(IEnumerable<Student> entities)
        {
            await _repository.AddRangeAsync(entities);
            await _unitOfWork.CommitAsync();
            await CacheAllStudentsAsync();
            return entities;
        }

        public Task<bool> AnyAsync(Expression<Func<Student, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Student>> GetAllAsync()
        {
            return Task.FromResult(_memoryCache.Get<IEnumerable<Student>>(CacheStudentKey));
        }

        public Task<Student> GetByIdAsync(int id)
        {
            var student = _memoryCache.Get<List<Student>>(CacheStudentKey).FirstOrDefault(x => x.Id == id);
            if (student == null)
            {
                throw new NotFoundException($"{typeof(Student).Name}({id}) not found");
            }
            return Task.FromResult(student);
            //await kullanmadığım için Task ile döndüm
        }

        public Task<List<StudentWithSchoolDto>> GetStudentsWithSchool()
        {
            var students = _memoryCache.Get<IEnumerable<Student>>(CacheStudentKey);
            var studentsWithSchoolDto = _mapper.Map<List<StudentWithSchoolDto>>(students);
            return Task.FromResult(studentsWithSchoolDto);
        }

        public async Task RemoveAsync(Student entity)
        {
            _repository.Remove(entity);
            await _unitOfWork.CommitAsync();
            await CacheAllStudentsAsync();
        }

        public async Task RemoveRangeAsync(IEnumerable<Student> entities)
        {
            _repository.RemoveRange(entities);
            await _unitOfWork.CommitAsync();
            await CacheAllStudentsAsync();
        }

        public async Task UpdateAsync(Student entity)
        {
            _repository.Update(entity);
            await _unitOfWork.CommitAsync();
            await CacheAllStudentsAsync();
        }

        public IQueryable<Student> Where(Expression<Func<Student, bool>> expression)
        {
            return _memoryCache.Get<List<Student>>(CacheStudentKey).Where(expression.Compile()).AsQueryable();
        }
        
        public async Task CacheAllStudentsAsync() // her çağrıldığında sıfırdan datayı çekip cacheliyor
        {
            _memoryCache.Set( CacheStudentKey, await _repository.GetAll().ToListAsync());
        }
    }
}
