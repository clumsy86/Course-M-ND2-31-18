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
        private readonly IProfilService profileService;
        private readonly IMapper mapper;

        public MainController(IPostService postService, IMapper mapper, ICategoryService categoryService,
            ITagService tagService, IPostTagService postTagService, IUserService userService, ICommentService commentService,
            IProfilService profileService)
        {
            this.postService = postService;
            this.mapper = mapper;
            this.categoryService = categoryService;
            this.tagService = tagService;
            this.postTagService = postTagService;
            this.userService = userService;
            this.commentService = commentService;
            this.profileService = profileService;
        }

        // GET: Main
        public ActionResult Index()
        {
            var posts = postService.GetPublishedPosts();
            var postsViewModel = mapper.Map<List<MainPostViewModel>>(posts);
            foreach (var item in postsViewModel)
            {
                var fullname = profileService.FindFullName(item.UserId);

                item.FullName = new FullNameViewModel{  FirstName = fullname.FirstName, LastName = fullname.LastName};

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
            var fullname = profileService.FindFullName(postViewModel.UserId);
            postViewModel.FullName = new FullNameViewModel { FirstName = fullname.FirstName, LastName = fullname.LastName };

            try
            {
                var userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
                ViewBag.UserId = userId;

                var fullnameGuest = profileService.FindFullName(userId);

                if (fullnameGuest != null)
                {
                    ViewBag.Username = fullnameGuest.FirstName+ " " + fullnameGuest.LastName;
                }
                else
                {
                    ViewBag.Username = userService.FindUsername(userId);
                }
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
                var fullname = profileService.FindFullName(item.UserId);
                item.FullName = new FullNameViewModel { FirstName = fullname.FirstName, LastName = fullname.LastName };
                item.CommentsCount = commentService.GetCommentsCount(item.Id);
            }

            return View(result);
        }
    }
}