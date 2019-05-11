﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OOPTut.Application.BazaarListItemServices;
using OOPTut.Application.BazaarListItemServices.Dto;
using System.Security.Claims;
using System.Threading.Tasks;

namespace OOPTut.Web.UI.Controllers
{
    [Authorize]
    public class BazaarListItemController : Controller
    {

        private readonly IBazaarListItemService _bazaarListItemService;

        public BazaarListItemController(IBazaarListItemService bazaarListItemService)
        {
            _bazaarListItemService = bazaarListItemService;
        }

        public async Task<IActionResult> Index(int id)
        {
            // 1- servis katmaninda GetAllByIdAsync diye bir metod olusturun ve bu metod gelen bazaarListId parametresine gore ilgili bazaarListItem'leri ceksin
            var list = await _bazaarListItemService.GetAllByIdAsync(id);
            ViewBag.BazaarListItemId = id;
            return View(list);
        }
        //[HttpGet("{id}")]
        public IActionResult Create(int id)
        {
            // Yeni bir CreateBazaarListItem sınıfını ayağa kaldır
            CreateBazaarListItem model = new CreateBazaarListItem();

            // model.BazaarListId'yi parametreden gelen id'ye eşitle
            model.BazaarListId = id;
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateAsync(int id, CreateBazaarListItem model)
        {
            if (ModelState.IsValid)
            {
                // CreateBazaarListItem model
                // model.CreatorUserId atamasını yap
                model.CreatorUserId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
                // oluşan model servis katmanina gonder
                var createdItem = await _bazaarListItemService.CreateAsync(model);
                return RedirectToAction("Index", new { id = model.BazaarListId });
            }
            return View(model);
        }
    }
}