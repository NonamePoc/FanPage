using AutoMapper;
using FanPage.Api.JsonResponse;
using FanPage.Infrastructure.Interfaces.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FanPage.Api.Controllers.User
{
    [ApiController]
    [Route(Route)]
    public class FriendController : BaseController
    {
        private const string Route = "v1/friend";
        private readonly IFriend _friend;

        public FriendController(IFriend friend)
        {
            _friend = friend;
        }

        /// <summary>
        ///  Friend List
        /// </summary>
        /// <returns>list of the people who are in friend list of user</returns>
        [HttpGet]
        [Route("List")]
        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(JsonResponseContainer[]), 400)]
        [ProducesResponseType(typeof(JsonResponseContainer), 500)]
        [Authorize(AuthenticationSchemes = "Bearer")]
        public async Task<IActionResult> List()
        {
            var list = await _friend.FriendsList(HttpContext.Request);
            return Ok(list);
        }

        /// <summary>
        ///  Add Friend
        /// </summary>
        /// <param name="friendName">name of the user 1, wich user 2(who use method) want to be a friend with</param>
        /// <returns>status 200</returns>
        [HttpPost]
        [Route("Add")]
        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(JsonResponseContainer[]), 400)]
        [ProducesResponseType(typeof(JsonResponseContainer), 500)]
        [Authorize(AuthenticationSchemes = "Bearer")]
        public async Task<IActionResult> FriendAdd([FromQuery] string friendName)
        {
            await _friend.AddFriend(HttpContext.Request, friendName);
            return Ok();
        }

        /// <summary>
        ///  List of request that has been sended by user
        /// </summary>
        /// <returns>list of the people who get request for friendship from user</returns>
        [HttpGet]
        [Route("UserSend")]
        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(JsonResponseContainer[]), 400)]
        [ProducesResponseType(typeof(JsonResponseContainer), 500)]
        [Authorize(AuthenticationSchemes = "Bearer")]
        public async Task<IActionResult> UserSend()
        {
            var list = await _friend.GetFriendRequests(HttpContext.Request);
            return Ok(list);
        }

        /// <summary>
        ///  Cansel Send
        /// </summary>
        /// <param name="friendName=">Id of user 1 who get friend request from user 2(person who use method)</param>
        /// <returns>status 200</returns>
        [HttpDelete]
        [Route("Cancel")]
        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(JsonResponseContainer[]), 400)]
        [ProducesResponseType(typeof(JsonResponseContainer), 500)]
        [Authorize(AuthenticationSchemes = "Bearer")]
        public async Task<IActionResult> Cancel([FromQuery] string friendName)
        {
            _friend.CancelSend(HttpContext.Request, friendName);
            return Ok();
        }

        /// <summary>
        ///  List of request that have been sended to user
        /// </summary>
        /// <returns>list of people who want send request of friendship to user</returns>
        [HttpGet]
        [Route("SendToUser")]
        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(JsonResponseContainer[]), 400)]
        [ProducesResponseType(typeof(JsonResponseContainer), 500)]
        [Authorize(AuthenticationSchemes = "Bearer")]
        public async Task<IActionResult> SendToUser()
        {
            var list = await _friend.GetUserRequests(HttpContext.Request);
            return Ok(list);
        }

        /// <summary>
        ///  Accept of request
        /// </summary>
        /// <param name="friendName">name of user 1 who send friend request to user 2 </param>
        /// <returns>maked new friendship :3 </returns>
        [HttpPut]
        [Route("Accept")]
        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(JsonResponseContainer[]), 400)]
        [ProducesResponseType(typeof(JsonResponseContainer), 500)]
        [Authorize(AuthenticationSchemes = "Bearer")]
        public async Task<IActionResult> Accept([FromQuery] string friendName)
        {
            await _friend.AcceptFriend(HttpContext.Request, friendName);
            return Ok();
        }

        /// <summary>
        ///  Remove friend
        /// </summary>
        /// <param name="friendName">name of user 1 who is in friend list of user 2 </param>
        /// <returns>friendship end :( </returns>
        [HttpDelete]
        [Route("Remove")]
        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(JsonResponseContainer[]), 400)]
        [ProducesResponseType(typeof(JsonResponseContainer), 500)]
        [Authorize(AuthenticationSchemes = "Bearer")]
        public async Task<IActionResult> Remove([FromQuery]string friendName)
        {
            await _friend.RemoveFriend(HttpContext.Request, friendName);
            return Ok();
        }
    }
}