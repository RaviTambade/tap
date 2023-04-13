using CatalogService.Models;
using CatalogService.Services.Interfaces;
using CatalogService.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Globalization;
using Microsoft.Extensions.Caching.Memory;

namespace CatalogService.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class CategoriesController : ControllerBase
    {
        private readonly IMemoryCache _memoryCache;            //for caching inject the IMemoryCache interface into controller
        private readonly ILogger<CategoriesController> _logger;
        private readonly ICategoryService _categorysrv;
        public CategoriesController(ICategoryService categorysrv,ILogger<CategoriesController> logger,IMemoryCache memoryCache)
        {
            _memoryCache=memoryCache;
            _logger=logger;
            _categorysrv = categorysrv;
        }
        [HttpGet]
        [Route("getallcategories")]
        public async Task<IEnumerable<Category>> GetAllCategories()
        {
            var cacheKey="categoryList";          // Creating a cache key. As we know that data will be saved as key-value pair
            if(!_memoryCache.TryGetValue(cacheKey,out IEnumexrable<Category> categoryList))   //Checking if cache value is available for the specific key.categoryList=cachedValue.
            {
            categoryList =await _categorysrv.GetAll();
            _logger.LogInformation("Get all categories method invoked at  {DT}",  DateTime.UtcNow.ToLongTimeString());
              var cacheExpiryOptions = new MemoryCacheEntryOptions     //setting up cache options.
            //MemoryCacheEntryOptions  =defines properties of cache
            {
                AbsoluteExpiration = DateTime.Now.AddSeconds(50),
                Priority = CacheItemPriority.High,                //priority of keeping cache entry in the cache
                SlidingExpiration = TimeSpan.FromSeconds(20)      //after cache entry if there is no client request for 20 seconds the cache will be expired.
            };
            //setting cache entries
            _memoryCache.Set(cacheKey, categoryList, cacheExpiryOptions);
        }
        return categoryList;
        }
    


        [HttpGet]
        [Route("getdetails/{id}")]
        public async Task<Category> GetDetails(int id)
        {
            Category category =await _categorysrv.GetDetails(id);
            _logger.LogInformation("Get details of category method invoked at  {DT}",  DateTime.UtcNow.ToLongTimeString());
            return category;
        }
        [HttpPost]
        [Route("insert")]
        public async Task<bool> Insert([FromBody] Category category)
        {
            bool status =await _categorysrv.Insert(category);
            _logger.LogInformation("Insert category method invoked at  {DT}",  DateTime.UtcNow.ToLongTimeString());
            return status;
        }

        [HttpPut]
        [Route("update/{id}")]
        public async Task<bool> Update(int id, [FromBody] Category category)
        {
            Category oldCategory =await _categorysrv.GetDetails(id);
            if (oldCategory.CategoryId == 0)
            {
                return false;
            }
            category.CategoryId = id;
            bool status =await _categorysrv.Update(category);
            _logger.LogInformation("Update category method invoked at  {DT}",  DateTime.UtcNow.ToLongTimeString());
            return status;
        }
        [HttpDelete]
        [Route("delete/{id}")]
        public async Task<bool> Delete(int id)
        {
            bool status =await _categorysrv.Delete(id);
            _logger.LogInformation("Delete category method invoked at  {DT}",  DateTime.UtcNow.ToLongTimeString());
            return status;
        }
    }
}