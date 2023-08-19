﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using noon.Application.Services.ProductServices;
using noon.DTO.ProductDTO;

namespace noon.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService productService;

        public ProductController(IProductService productService)
        {
            this.productService = productService;
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetById(Guid id)
        {
            // 11111111-2222-3333-4444-555555555555
            var property = productService.GetById(id);
           
            return Ok(property);
        }

        //[HttpGet]
        //[Route("{items},{PageNumber}")]
        //public async Task<IActionResult> GetAll(int items, int PageNumber)
        //{
        //    var property = await productService.GetAllPropertyPagination(items, PageNumber);
        //    return Ok(property);
        //}

        [HttpGet]
        [Route("{items},{PageNumber}")]
        public IActionResult GetAll(int items, int PageNumber)
        {
            var property = productService.GetAll(items, PageNumber);
            return Ok(property);
        }


        [HttpGet]
        [Route("Search/{ProductName}")]
        public async Task<IActionResult> SearchByProductName(string ProductName)
        {
            // 11111111-2222-3333-4444-555555555555
            var property = await productService.SearchByProductName(ProductName);
            return Ok(property);
        }

        [HttpGet("reviews")]
        public async Task<IActionResult> GetUsersReviews(Guid ProductID)
        {
            var reviews = productService.GetReviewsByPrdId(ProductID);
            return Ok(reviews);
        }

        [HttpPost("CreateReview")]
        public async Task<IActionResult> CreateReview (UserReviewDTO userReviewDTO)
        {
            var review = productService.CreateUserReview(userReviewDTO);
            return Ok(review);
        }
        [HttpGet]
        [Route("category/{categoryId}")]

        public IActionResult GetProductsByCategoryId(int categoryId)
        {
            var products = productService.GetProductsByCategoryId(categoryId);
            return Ok(products);
        }


    }
}
