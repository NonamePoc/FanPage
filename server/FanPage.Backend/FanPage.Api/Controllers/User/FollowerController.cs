﻿using FanPage.Api.JsonResponse;
using FanPage.Infrastructure.Interfaces.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FanPage.Api.Controllers.User
{
    [ApiController]
    [Route(Route)]
    public class FollowerController : BaseController
    {
        private const string Route = "v1/follower";
        private readonly IFollower _follower;

        public FollowerController(IFollower follower)
        {
            _follower = follower;
        }

        /// <summary>
        /// List of the follower
        /// </summary>
        /// <returns>list of the people who subscribe to user</returns>
        [HttpGet]
        [Route("List")]
        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(JsonResponseContainer[]), 400)]
        [ProducesResponseType(typeof(JsonResponseContainer), 500)]
        [Authorize(AuthenticationSchemes = "Bearer")]
        public async Task<IActionResult> FollowerList()
        {
            var list = await _follower.FollowerList(HttpContext.Request);
            return Ok(list);
        }

        /// <summary>
        ///  Subcribe
        /// </summary>
        /// <param name="userName">name of user who get subcriber</param>
        /// <returns> status 200</returns>
        [HttpPut]
        [Route("Subscribe")]
        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(JsonResponseContainer[]), 400)]
        [ProducesResponseType(typeof(JsonResponseContainer), 500)]
        [Authorize(AuthenticationSchemes = "Bearer")]
        public async Task<IActionResult> Subscribe([FromQuery]string userName)
        {
            await _follower.Subscribe(HttpContext.Request, userName);
            return Ok();
        }

        /// <summary>
        /// Unsubcribe
        /// </summary>
        /// <param name="userName">name of user from who you want unsubcribe</param>
        /// <returns> status 200</returns>
        [HttpDelete]
        [Route("Unsubcribe")]
        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(JsonResponseContainer[]), 400)]
        [ProducesResponseType(typeof(JsonResponseContainer), 500)]
        [Authorize(AuthenticationSchemes = "Bearer")]
        public async Task<IActionResult> Unsubscribe([FromQuery]string userName)
        {
            await _follower.Unsubscribe(HttpContext.Request, userName);
            return Ok();
        }
    }
}