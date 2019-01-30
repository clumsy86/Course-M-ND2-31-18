using System.Collections.Generic;
using System.Security.Claims;
using AutoMapper;
using ITNews.Domain.Contracts;
using ITNews.Domain.Contracts.Entities;
using ITNews.Web1.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ITNews.Web1.Controllers
{
    public class PostController : Controller
    {
        private readonly IPostService postService;
        private readonly ICategoryService categoryService;
        private readonly IMapper mapper;

        public PostController(IPostService postService, IMapper mapper, ICategoryService categoryService)
        {
            this.postService = postService;
            this.mapper = mapper;
            this.categoryService = categoryService;
        }
        // GET: Post
        public ActionResult Index()
        {
            var posts = postService.GetPosts();
            var postsViewModel = mapper.Map<List<PostViewModel>>(posts);
            return View(postsViewModel);
        }

        // GET: Post/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Post/Create
        public ActionResult Create()
        {
            ViewBag.value = @"<p>Please, enter your post </p>";
            var categories = categoryService.GetCategories();
            var categoriesViewModel = mapper.Map<List<CategoryViewModel>>(categories);
            ViewBag.Categories = new SelectList(categoriesViewModel, "Id", "Name");
            return View();
        }

        // POST: Post/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PostViewModel post)
        {
            //try
            //{
                var id = User.FindFirst(ClaimTypes.NameIdentifier).Value;

                if (ModelState.IsValid)
                {
                    var postDomainModel = mapper.Map<PostDomainModel>(post);
                    postService.CreatePost(postDomainModel, id);
                    return RedirectToAction(nameof(Index));
                }

                else
                {
                    return View();
                }
            //}
            //catch
            //{
            //    return RedirectToPage("https://localhost:44318/Identity/Account/Login");
            //}
               
        }

        // GET: Post/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Post/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Post/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Post/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}