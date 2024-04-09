using AutoMapper;
using FanPage.Api.JsonResponse;
using FanPage.Api.Models.Fanfic;
using FanPage.Api.ViewModels.Fanfic;
using FanPage.Application.Fanfic;
using FanPage.Infrastructure.Implementations.Helper;
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

        private readonly IStorageHttp _storageHttp;

        public FanficController(IFanfic fanfic, IMapper mapper, IStorageHttp storageHttp)
        {
            _fanfic = fanfic;
            _mapper = mapper;
            _storageHttp = storageHttp;
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
        public async Task<IActionResult> Create([FromForm] CreateModel createModel)
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
        public async Task<IActionResult> Update(int id, [FromBody] UpdateModel updateFanfic)
        {
            var dto = _mapper.Map<UpdateDto>(updateFanfic);
            var retrieval = await _fanfic.UpdateAsync(id, dto, HttpContext.Request);
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
        [Route("banner")]
        [ProducesResponseType(200)]
        [ProducesResponseType(401)]
        [ProducesResponseType(typeof(JsonResponseContainer<FanficViewModel>), 200)]
        [ProducesResponseType(typeof(JsonResponseContainer[]), 400)]
        [ProducesResponseType(typeof(JsonResponseContainer), 500)]
        [Authorize(AuthenticationSchemes = "Bearer")]
        public async Task<IActionResult> NewBanner(int id, string image)
        {
            var resul = _fanfic.UpdateBanner(image, id, HttpContext.Request);
            return Ok(resul);
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
