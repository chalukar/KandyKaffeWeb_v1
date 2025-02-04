using AutoMapper;
using KandyKaffe.Service.CategoryAPI.Models;
using KandyKaffe.Service.CategoryAPI.Models.Dto;
using KandyKaffe.Services.CategoryAPI.Models.Dto;
using KandyKaffe.Services.Categoty.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KandyKaffe.Services.CategoryAPI.Controllers
{
    [Route("api/category")]
    [ApiController]
    //[Authorize]
    public class CategoryAPIController : ControllerBase
    {
        private readonly AppDbContext _db;
        private ResponseDto _response;
        private IMapper _mapper;
        public CategoryAPIController(AppDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
            _response = new ResponseDto();
        }

        [HttpGet]
        //[Authorize(Roles = "ADMIN")]
        public ResponseDto GetAll()
        {
            try
            {
                IEnumerable<Category> objList = _db.Categories.ToList();
                _response.Result = _mapper.Map<IEnumerable<CategoryDto>>(objList);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }

        [HttpGet]
        [Route("{id:int}")]
        //[Authorize(Roles = "ADMIN")]
        public ResponseDto Get(int id)
        {
            try
            {
                Category obj = _db.Categories.First(u => u.Id == id);
                _response.Result = _mapper.Map<CategoryDto>(obj);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }

        [HttpGet]
        [Route("GetByCode/{code}")]
        [Authorize(Roles = "ADMIN")]
        public ResponseDto GetByCode(string code)
        {
            try
            {
                Category obj = _db.Categories.First(u => u.CategoryCode.ToLower() == code.ToLower());
                _response.Result = _mapper.Map<CategoryDto>(obj);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }

        [HttpPost]
        //[Authorize(Roles ="ADMIN")]
        public ResponseDto Post([FromBody] CategoryDto CategoryDto)
        {
            try
            {
                Category obj = _mapper.Map<Category>(CategoryDto);
                _db.Categories.Add(obj);
                _db.SaveChanges();
                _response.Result = _mapper.Map<CategoryDto>(obj);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }

        [HttpPut]
        //[Authorize(Roles = "ADMIN")]
        public ResponseDto Put([FromBody] CategoryDto CategoryDto)
        {
            try
            {
                Category obj = _mapper.Map<Category>(CategoryDto);
                _db.Categories.Update(obj);
                _db.SaveChanges();
                _response.Result = _mapper.Map<CategoryDto>(obj);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }

        [HttpDelete]
        [Route("{id:int}")]
        //[Authorize(Roles = "ADMIN")]
        public ResponseDto Delete(int id)
        {
            try
            {
                Category obj = _db.Categories.First(u => u.Id == id);
                _db.Categories.Remove(obj);
                _db.SaveChanges();
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }
    }
}
