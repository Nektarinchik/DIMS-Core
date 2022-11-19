using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using DIMS_Core.BusinessLayer.Interfaces;
using DIMS_Core.BusinessLayer.Models;
using DIMS_Core.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;

namespace DIMS_Core.Controllers
{
    [Route("users")]
    public class UserProfileController : BaseController
    {
        private readonly IDirectionService _directionService;
        private readonly IUserProfileService _userProfileService;
        private readonly IVUserProfileService _vUserProfileService;

        public UserProfileController(IMapper mapper,
                                     IUserProfileService userProfileService,
                                     IVUserProfileService vUserProfileService,
                                     IDirectionService directionService,
                                     ILogger<UserProfileController> logger) : base(mapper, logger)
        {
            _userProfileService = userProfileService ?? throw new ArgumentNullException(nameof(userProfileService));
            _vUserProfileService = vUserProfileService ?? throw new ArgumentNullException(nameof(vUserProfileService));
            _directionService = directionService ?? throw new ArgumentNullException(nameof(directionService));
        }

        public async Task<ActionResult> Index()
        {
            var userProfileModels = await _vUserProfileService.GetAll();
            var userProfileViewModels = Mapper.Map<IReadOnlyCollection<VUserProfileViewModel>>(userProfileModels);

            return View(userProfileViewModels);
        }

        [HttpGet("details/{id:int}")]
        public async Task<ActionResult> Details(int id)
        {
            var userProfileModel = await _userProfileService.GetById(id);
            var userProfileViewModel = Mapper.Map<UserProfileViewModel>(userProfileModel);

            return View(userProfileViewModel);
        }

        [HttpGet("create")]
        public async Task<IActionResult> Create()
        {
            await AddDirectionsInViewBag();

            return View();
        }

        [HttpPost("create")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(UserProfileViewModel userProfileViewModel)
        {
            if (!ModelState.IsValid)
            {
                await AddDirectionsInViewBag();
                return View(userProfileViewModel);
            }

            var userProfileModel = Mapper.Map<UserProfileModel>(userProfileViewModel);
            var updatedUserProfileModel = await _userProfileService.Create(userProfileModel);
            if (updatedUserProfileModel is not null)
            {
                return RedirectToAction(nameof(Index));
            }

            await AddDirectionsInViewBag();

            return View(userProfileViewModel);
        }

        [HttpGet("edit/{id:int}")]
        public async Task<IActionResult> Edit(int id)
        {
            var userProfileModel = await _userProfileService.GetById(id);
            var userProfileViewModel = Mapper.Map<UserProfileViewModel>(userProfileModel);

            await AddDirectionsInViewBag();

            return View(userProfileViewModel);
        }

        [HttpPost("edit")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(UserProfileViewModel userProfileViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(userProfileViewModel);
            }

            var userProfileEntity = Mapper.Map<UserProfileModel>(userProfileViewModel);
            var userProfile = await _userProfileService.Update(userProfileEntity);
            if (userProfile != null)
            {
                return RedirectToAction(nameof(Index));
            }

            await AddDirectionsInViewBag();

            return View(userProfileViewModel);
        }

        [HttpGet("delete/{id:int}")]
        public IActionResult Delete(int id)
        {
            return View();
        }

        [HttpPost("delete/{id:int}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteUser(int id)
        {
            await _userProfileService.Delete(id);

            return RedirectToAction(nameof(Index));
        }

        private async Task AddDirectionsInViewBag()
        {
            ViewBag.Directions = new SelectList(await _directionService.GetAll(), nameof(DirectionModel.DirectionId), nameof(DirectionModel.Name));
        }
    }
}