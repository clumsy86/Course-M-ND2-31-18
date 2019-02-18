using AutoMapper;
using ITNews.Domain.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.SignalR;
using System.Security.Claims;
using System.Threading.Tasks;


namespace ITNews.Web1
{
    public class CommentHub:Hub
    {
        private readonly ICommentService commentService;

        public CommentHub(ICommentService commentService)
        {
            this.commentService = commentService;
        }
        public async Task SendMessage(string message, int postId, string userId)
        {
            await Clients.All.SendAsync("ReceiveMessage", message);

            if ((userId == null) || (message == null))
            {
                return;
            }
            else
            {
                commentService.Create(message, postId, userId);
            }
        }
    }
}
