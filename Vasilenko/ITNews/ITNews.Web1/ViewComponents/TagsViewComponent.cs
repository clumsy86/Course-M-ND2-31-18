using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ITNews.Web1.ViewComponents
{
    public class TagsViewComponent:ViewComponent
    {
        private readonly ICategoryService categoryService;
        private readonly IMapper mapper;

        public TagsViewComponent(IMapper mapper, ICategoryService categoryService)
        {
            this.mapper = mapper;
            this.categoryService = categoryService;
        }

        public IViewComponentResult Invoke()
        {
            var categories = categoryService.GetCategories();
            var categoriesViewModel = mapper.Map<List<CategoryViewModel>>(categories);
            return View(categoriesViewModel);
        }
    }
}
