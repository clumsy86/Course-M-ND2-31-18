﻿using AutoMapper;
using ITNews.Domain.Contracts;
using ITNews.Web1.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ITNews.Web1.Controllers
{
    public class AdminController : Controller
    {
        private readonly IUserService userService;
        private readonly IMapper mapper;
        private readonly IProfilService profileService;

        public AdminController(IUserService userService, IMapper mapper, IProfilService profileService)
        {
            this.userService = userService;
            this.mapper = mapper;
            this.profileService = profileService;
        }

        // GET: Admin
        public ActionResult Index()
        {
            var profilesDomainModel = profileService.GetProfiles();
            var profilesViewModel = mapper.Map<List<ProfileViewModel>>(profilesDomainModel);
            return View(profilesViewModel);
        }

        [HttpGet]
        public ActionResult Block(int profileId)
        {
            var profile = profileService.FindProfileById(profileId);
            var profileViewModel = mapper.Map<ProfileViewModel>(profile);
            return View(profileViewModel);
        }

        [HttpPost]
        public void Block (ProfileViewModel profile)
        {


        }

        public ActionResult Delete(string userId)
        {
            if (userId != null)
            {
                userService.DeleteUser(userId);

                return RedirectToAction(nameof(AdminController.Index));
            }
            else
            {
                return RedirectToAction(nameof(AdminController.Index));
            }

        }
    }
}