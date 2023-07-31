﻿using BlazorEcommerce.Server.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlazorEcommerce.Server.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ProductController : ControllerBase
	{
		private readonly IProductService _productService;

		public ProductController(IProductService productService)
		{
			_productService = productService;
		}

		[HttpGet]
		public async Task<ActionResult<ServiceResponse<List<Product>>>> GetProducts()
		{

			var result = await _productService.GetProductsAsync();
			return Ok(result);
		}

		[HttpGet("{productId}")]
		public async Task<ActionResult<ServiceResponse<Product>>> GetProduct(int productId)
		{
			var result = await _productService.GetProductAsync(productId);
			return Ok(result);
		}
		
		[HttpGet("category/{categoryUrl}")]
		public async Task<ActionResult<ServiceResponse<List<Product>>>> GetProductsByCategory(string categoryUrl)
		{
			var result = await _productService.GetProductsByCategory(categoryUrl);
			return Ok(result);
		}
		
		[HttpGet("search/{searchText}/{page}")]
		public async Task<ActionResult<ServiceResponse<ProductSearchResultDTO>>> SearchProducts(string searchText, int page = 1)
		{
			var result = await _productService.SearchProducts(searchText, page);
			return Ok(result);
		}
		
		
		
		[HttpGet("searchSuggestions/{searchText}")]
		public async Task<ActionResult<ServiceResponse<List<Product>>>> GetSearchProductSuggestions(string searchText)
		{
			var result = await _productService.GetProductSearchSuggestions(searchText);
			return Ok(result);
		}
		
		[HttpGet("featuredProducts")]
		public async Task<ActionResult<ServiceResponse<List<Product>>>> GetFeaturedProducts()
		{
			var result = await _productService.GetFeaturedProducts();
			return Ok(result);
		}
	}
}
