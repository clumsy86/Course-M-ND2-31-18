using AutoMapper;
using ITNews.Domain.Contracts;
using ITNews.Web1.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;


namespace ITNews.Web1.ViewComponents
{
    public class CommentsViewComponent:ViewComponent
    {
        private readonly ICommentService commentService;
        private readonly IMapper mapper;
        private readonly IProfilService profileService;

        public CommentsViewComponent(IMapper mapper, ICommentService commentService, IProfilService profileService)
        {
            this.mapper = mapper;
            this.commentService = commentService;
            this.profileService = profileService;
        }

        public IViewComponentResult Invoke(int id)
        {
            var comments = commentService.GetComments(id);
            if (comments != null)
            {
                var commentsViewModel = mapper.Map<List<CommentViewModel>>(comments);

                foreach (var item in commentsViewModel)
                {
                    var fullname = profileService.FindFullName(item.UserId);

                    item.FullName = new FullNameViewModel { FirstName = fullname.FirstName, LastName = fullname.LastName };
                }
                return View(commentsViewModel);
            }
            else
            {
                return null;
            }
        }
    }
}
