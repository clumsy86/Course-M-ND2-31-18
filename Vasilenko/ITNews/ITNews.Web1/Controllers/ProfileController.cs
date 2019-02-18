using System.Security.Claims;
using AutoMapper;
using ITNews.Domain.Contracts;
using ITNews.Domain.Contracts.Entities;
using ITNews.Web1.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ITNews.Web1.Controllers
{
    public class ProfileController : Controller
    {
        private readonly IMapper mapper;
        private readonly IUserService userService;
        private readonly IProfilService profileService;

        public ProfileController(IMapper mapper, IUserService userService, IProfilService profileService)
        {
            this.mapper = mapper;
            this.userService = userService;
            this.profileService = profileService;
        }
        // GET: Profile
        public ActionResult Index()
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var profile = profileService.FindProfile(userId);
            var profileViewModel = mapper.Map<ProfileViewModel>(profile);
            return View(profileViewModel);
        }

        [HttpPost]
        public void Index(ProfileViewModel profile)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var profileDomainModel = mapper.Map<ProfileDomainModel>(profile);
            profileService.EditProfile(profileDomainModel, userId);
        }

        // GET: Profile/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

     

        // GET: Profile/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Profile/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Profile/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Profile/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}