using AutoMapper;
using FanPage.Api.JsonResponse;
using FanPage.Api.Models.Fanfic;
using FanPage.Api.ViewModels.Fanfic;
using FanPage.Application.Fanfic;
using FanPage.Infrastructure.Interfaces.Fanfic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FanPage.Api.Controllers.Fanfic
{
    [ApiController]
    [Route(Route)]
    public class FanficController : BaseController
    {
        private const string Route = "v1/fanfic";

        private readonly IFanfic _fanfic;

        private readonly IMapper _mapper;

        public FanficController(IFanfic fanfic, IMapper mapper)
        {
            _fanfic = fanfic;
            _mapper = mapper;
        }


        /// <summary>
        ///  Create new fanfic
        /// </summary>
        /// <param name="createModel"> Model create new fanfic</param>
        /// <returns></returns>
        [HttpPost]
        [Route("create")]
        [ProducesResponseType(200)]
        [ProducesResponseType(401)]
        [ProducesResponseType(typeof(JsonResponseContainer<FanficViewModel>), 200)]
        [ProducesResponseType(typeof(JsonResponseContainer[]), 400)]
        [ProducesResponseType(typeof(JsonResponseContainer), 500)]
        [Authorize(AuthenticationSchemes = "Bearer")]
        public async Task<IActionResult> Create([FromBody] CreateModel createModel)
        {
            var dto = _mapper.Map<CreateDto>(createModel);
            var retrieval = await _fanfic.CreateAsync(dto, HttpContext.Request);
            var response = _mapper.Map<FanficViewModel>(retrieval);
            return Ok(response);
        }

        /// <summary>
        ///  Update fanfic
        /// </summary>
        /// <param name="updateFanfic"> Update fanfic model </param>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("update")]
        [ProducesResponseType(200)]
        [ProducesResponseType(401)]
        [ProducesResponseType(typeof(JsonResponseContainer<FanficViewModel>), 200)]
        [ProducesResponseType(typeof(JsonResponseContainer[]), 400)]
        [ProducesResponseType(typeof(JsonResponseContainer), 500)]
        [Authorize(AuthenticationSchemes = "Bearer")]
        public async Task<IActionResult> Update([FromBody] UpdateModel updateFanfic, [FromQuery] int id)
        {
            var dto = _mapper.Map<UpdateDto>(updateFanfic);
            var retrieval = await _fanfic.UpdateAsync(id, dto, HttpContext.Request);
            var response = _mapper.Map<FanficViewModel>(retrieval);
            return Ok(response);
        }


        /// <summary>
        /// Delete fanfic from id 
        /// </summary>
        /// <param name="id"> id fanfic </param>
        /// <returns></returns>
        [HttpDelete]
        [Route("delete")]
        [ProducesResponseType(200)]
        [ProducesResponseType(401)]
        [ProducesResponseType(typeof(JsonResponseContainer[]), 400)]
        [ProducesResponseType(typeof(JsonResponseContainer), 500)]
        [Authorize(AuthenticationSchemes = "Bearer")]
        public async Task<IActionResult> Delete([FromQuery] int id)
        {
            await _fanfic.DeleteAsync(id, HttpContext.Request);
            return Ok();
        }
    }
}