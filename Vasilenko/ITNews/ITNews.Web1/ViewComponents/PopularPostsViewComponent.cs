using AutoMapper;
using ITNews.Domain.Contracts;
using ITNews.Web1.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITNews.Web1.ViewComponents
{
    public class PopularPostsViewComponent : ViewComponent
    {
        private readonly IPostService postService;
        private readonly IMapper mapper;

        public PopularPostsViewComponent(IMapper mapper, IPostService postService)
        {
            this.mapper = mapper;
            this.postService = postService;
        }


        public IViewComponentResult Invoke()
        {
            var posts = postService.GetPopularPosts();
            var postsViewModel = mapper.Map<List<PostViewModel>>(posts);
            return View(postsViewModel);
        }
    }
}
