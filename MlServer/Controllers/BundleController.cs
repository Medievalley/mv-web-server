﻿using DataTransferObjects.BundleDTOs;
using Domain.BundleService;
using Microsoft.AspNetCore.Mvc;

namespace WebServerApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BundleController : ControllerBase
    {
        private readonly IBundleService _bundleService;

        public BundleController(IBundleService bundleService)
        {
            _bundleService = bundleService ?? throw new ArgumentNullException(nameof(bundleService));
        }

        [HttpPost]
        public async Task<ActionResult> CreateBundle(CreateBundleDto bundleDTO)
        {
            if (await _bundleService.CreateBundle(bundleDTO))
                return Ok();
            return BadRequest();
        }

        [HttpPut]
        public async Task<ActionResult> UpdateBundle(UpdateBundleDto bundleDTO)
        {
            if(await _bundleService.UpdateBundle(bundleDTO))
                return Ok();
            return BadRequest();
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteBundle(Guid bundleId)
        {
            if (await _bundleService.DeleteBundle(bundleId))
                return Ok();
            return BadRequest();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GetBundleDto>> GetBundle(Guid bundleId)
        {
            GetBundleDto bundleDTO = await _bundleService.GetBundle(bundleId);
            return Ok(bundleDTO);
        }

        [HttpGet]
        public async Task<ActionResult<GetBundleDto>> GetBundles()
        {
            List<GetBundleDto> bundleDTOs = await _bundleService.GetBundles();
            return Ok(bundleDTOs);
        }
    }
}
