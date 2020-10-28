using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using API.Models;
using API.Services;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryRepo _categoryRepo;
        private readonly IMapper _mapper;

        public CategoriesController(ICategoryRepo categoryRepo, IMapper mapper)
        {
            _categoryRepo = categoryRepo;
            _mapper = mapper;
        }

        [HttpDelete("DeleteCategory/{CategoryID}", Name = "DeleteCategory")]
        public async Task<IActionResult> DeleteCategory(Guid CategoryID)
        {
            var objFromRepo = _categoryRepo.GetCategory(CategoryID);
            if (objFromRepo == null)
            {
                return NotFound();
            }

            await _categoryRepo.DeleteCategoryAsync(objFromRepo);

            if (_categoryRepo.Save() == false)
            {
                throw new Exception($"Deleting Category {CategoryID} failed on save.");
            }

            return NoContent();
        }

        [HttpGet("GetCategoryById/{CategoryId}", Name = "GetCategoryById")]
        public async Task<IActionResult> GetCategoryById(Guid CategoryId)
        {
            var objFromRepo = await _categoryRepo.ListCategoryByIdAsync(CategoryId);

            var obj = _mapper.Map<IEnumerable<spSelectCategory>>(objFromRepo);

            if (obj == null) return NotFound();

            return Ok(obj);
        }

        [HttpGet("GetAllCategories", Name = "GetAllCategories")]
        public async Task<IActionResult> GetAllCategories()
        {
            var objFromRepo = await _categoryRepo.ListAllCategoriesAsync();

            var obj = _mapper.Map<IEnumerable<spSelectCategory>>(objFromRepo);

            if (obj == null) return NotFound();

            return Ok(obj);
        }

        [HttpPost("PostCategory", Name = "PostCategory")]
        public async Task<IActionResult> PostCategory([FromBody] CategoryForInsertModel model)
        {
            if (model == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return new UnprocessableEntityObjectResult(ModelState);
            }

            await _categoryRepo.AddCategoryAsync(model.CategoryName, model.Description);

            return Ok(model);
        }

        [HttpPut("PutCategory", Name = "PutCategory")]
        public async Task<IActionResult> PutCategory([FromBody] CategoryForUpdateModel model)
        {
            if (model == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return new UnprocessableEntityObjectResult(ModelState);
            }

            await _categoryRepo.UpdateCategoryAsync(model.CategoryID, model.CategoryName, model.Description);

            return Ok(model);
        }
    }
}
