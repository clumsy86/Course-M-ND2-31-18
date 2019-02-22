using ITNews.Domain.Contracts;
using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;


namespace ITNews.Web1
{
    public class CommentHub:Hub
    {
        private readonly ICommentService commentService;

        private readonly ILikeService likeService;

        public CommentHub(ICommentService commentService, ILikeService likeService)
        {
            this.commentService = commentService;
            this.likeService = likeService;
        }
        public async Task SendMessage(string message, int postId, string userId)
        {
            var hash = message.GetHashCode() + userId.GetHashCode();          

            if ((userId == null) || (message == null))
            {
                return;
            }
            else
            {
                var commentId = commentService.Create(message, postId, userId);

                await Clients.All.SendAsync("ReceiveMessage", message, hash, commentId);
            }

        }

        public async Task SendLike(int commentId, string userId, string buttonId)
        {
            if (userId == null)
            {
                return;
            }
            else
            {
                var addedLike = likeService.IsAddedLike(commentId, userId);

                if (addedLike)
                {
                    var action = true;

                    await Clients.Caller.SendAsync("ReceiveAction", action, buttonId);
                }
                else
                {
                    var action = false;

                    await Clients.Caller.SendAsync("ReceiveAction", action, buttonId);
                }
            }
        }
    }
}
