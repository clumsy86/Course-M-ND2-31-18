using System.Collections.Generic;
using AutoMapper;
using ITNews.Domain.Contracts;
using ITNews.Web1.Models;
using Microsoft.AspNetCore.Mvc;

namespace ITNews.Web1.Controllers
{
    public class MainController : Controller
    {
        private readonly IPostService postService;
        private readonly IPostTagService postTagService;
        private readonly ICategoryService categoryService;
        private readonly ITagService tagService;
        private readonly IMapper mapper;

        public MainController(IPostService postService, IMapper mapper, ICategoryService categoryService,
            ITagService tagService, IPostTagService postTagService)
        {
            this.postService = postService;
            this.mapper = mapper;
            this.categoryService = categoryService;
            this.tagService = tagService;
            this.postTagService = postTagService;
        }

        // GET: Main
        public ActionResult Index()
        {
            var posts = postService.GetPublishedPosts();
            var postsViewModel = mapper.Map<List<PostViewModel>>(posts);
            return View(postsViewModel);
        }

        [HttpPost]
        public ActionResult Search(string search)
        {
            if (search != null)
            {
                var posts = postService.Search(search);
                var postsViewModel = mapper.Map<List<SearchViewModel>>(posts);
                return View(postsViewModel);
            }
            else
            {
                return NotFound();
            }
        }

        // GET: Main/Details/5
        public ActionResult Details(int id)
        {
            var post = postService.FindPost(id);
            var postViewModel = mapper.Map<PostViewModel>(post);
            return View(postViewModel);
        }

        public ActionResult TagLink(int tagId)
        {
            var postsTags = postTagService.GetPostsByTagId(tagId);

            ViewBag.TagName = tagService.GetTagNameById(tagId);

            List<PostViewModel> result = new List<PostViewModel>();

            foreach (var item in postsTags)
            {
                var posts = postService.GetPostsById(item.PostId);
                var postsViewModel = mapper.Map<List<PostViewModel>>(posts);
                foreach (var post in postsViewModel)
                {
                    result.Add(post);
                }
            }

            return View(result);
        }
    }
}