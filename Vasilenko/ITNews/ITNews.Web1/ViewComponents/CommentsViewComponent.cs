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
    public class CommentsViewComponent:ViewComponent
    {
        private readonly ICommentService commentService;
        private readonly IMapper mapper;

        public CommentsViewComponent(IMapper mapper, ICommentService commentService)
        {
            this.mapper = mapper;
            this.commentService = commentService;
        }

        public IViewComponentResult Invoke(int id)
        {
            var comments = commentService.GetComments(id);
            if (comments != null)
            {
                var commentsViewModel = mapper.Map<List<CommentViewModel>>(comments);
                return View(commentsViewModel);
            }
            else
            {
                return null;
            }
        }
    }
}
