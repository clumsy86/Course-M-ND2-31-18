using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ITNews.Domain.Contracts;
using ITNews.Web1.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ITNews.Web1.Controllers
{
    public class MainController : Controller
    {
        private readonly IPostService postService;
        private readonly ICategoryService categoryService;
        private readonly ITagService tagService;
        private readonly IMapper mapper;

        public MainController(IPostService postService, IMapper mapper, ICategoryService categoryService,
            ITagService tagService)
        {
            this.postService = postService;
            this.mapper = mapper;
            this.categoryService = categoryService;
            this.tagService = tagService;
        }

        // GET: Main
        public ActionResult Index()
        {
            var posts = postService.GetPublishedPosts();
            var postsViewModel = mapper.Map<List<PostViewModel>>(posts);
            return View(postsViewModel);
        }

        // GET: Main/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }
    }
}