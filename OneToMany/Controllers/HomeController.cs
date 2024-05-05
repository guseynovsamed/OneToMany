using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OneToMany.Data;
using OneToMany.Models;
using OneToMany.ViewModels;

namespace OneToMany.Controllers
{
	public class HomeController : Controller
	{
		private readonly AppDbContext _context;

		public HomeController(AppDbContext context)
		{
			_context = context;
		}

		public async Task<IActionResult> Index()
		{
			List<Slider> sliders = await _context.Sliders.ToListAsync();
			SliderInfo? sliderInfo = await _context.SliderInfos.FirstOrDefaultAsync();
			List<Category> categories = await _context.Categories.ToListAsync();
			List<Product> products = await _context.Products.Include(m=>m.ProductImages).ToListAsync();

			HomeVM model = new()
			{
				Sliders = sliders,
				SliderInfo = sliderInfo,
				Categories=categories,
				Products=products
			};

			return View(model);
		}
	}
}

