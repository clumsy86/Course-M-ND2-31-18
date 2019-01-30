using AutoMapper;
using ITNews.Domain.Contracts;
using ITNews.Web1.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITNews.Web1.Controllers
{
    public class CategoryController: Controller
    {
        private readonly ICategoryService categoryService;
        private readonly IMapper mapper;

        public CategoryController(IMapper mapper, ICategoryService categoryService)
        {
            this.mapper = mapper;
            this.categoryService = categoryService;
        }

        public ActionResult Get()
        {

            var categories = categoryService.GetCategories();
            var categoriesViewModel = mapper.Map<List<CategoryViewModel>>(categories);
            return PartialView (categoriesViewModel);
        }
    }
}
