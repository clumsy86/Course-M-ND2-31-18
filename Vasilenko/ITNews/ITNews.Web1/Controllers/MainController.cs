using System.Collections.Generic;
using System.Security.Claims;
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
        private readonly IUserService userService;
        private readonly ICommentService commentService;
        private readonly IMapper mapper;

        public MainController(IPostService postService, IMapper mapper, ICategoryService categoryService,
            ITagService tagService, IPostTagService postTagService, IUserService userService, ICommentService commentService)
        {
            this.postService = postService;
            this.mapper = mapper;
            this.categoryService = categoryService;
            this.tagService = tagService;
            this.postTagService = postTagService;
            this.userService = userService;
            this.commentService = commentService;
        }

        // GET: Main
        public ActionResult Index()
        {
            var posts = postService.GetPublishedPosts();
            var postsViewModel = mapper.Map<List<MainPostViewModel>>(posts);
            foreach (var item in postsViewModel)
            {
                item.CommentsCount=commentService.GetCommentsCount(item.Id);
            }
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

        [HttpGet]
        public ActionResult Details(int id)
        {
            var post = postService.GetPostById(id);
            var postViewModel = mapper.Map<PostViewModel>(post);
            try
            {
                var userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
                ViewBag.UserId = userId;
                ViewBag.Username = userService.FindUsername(userId);
            }
            catch
            {
                ViewBag.Username = null;
            }
            return View(postViewModel);
        }

        public ActionResult TagLink(int tagId)
        {
            var postsTags = postTagService.GetPostsByTagId(tagId);

            ViewBag.TagName = tagService.GetTagNameById(tagId);

            List<MainPostViewModel> result = new List<MainPostViewModel>();

            foreach (var item in postsTags)
            {
                var post = postService.GetPostById(item.PostId);
                var postViewModel = mapper.Map<MainPostViewModel>(post);
                result.Add(postViewModel);
            }

            foreach (var item in result)
            {
                item.CommentsCount = commentService.GetCommentsCount(item.Id);
            }

            return View(result);
        }
    }
}