﻿using System;
using OneToMany.Models;

namespace OneToMany.ViewModels
{
	public class HomeVM
	{
		public List<Slider> Sliders { get; set; }
		public SliderInfo SliderInfo { get; set; }
		public List<Category> Categories { get; set; }
		public List<Product> Products { get; set; }
	}
}

