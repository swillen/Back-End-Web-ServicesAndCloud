﻿using BookShopSystem.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using Microsoft.AspNet.Identity;
using BookShopSystem.Models;

namespace BookShopSystem.Services.Controllers
{
    public class PurchasesController : ApiController
    {
        //PUT /api/Books/buy/{id}
        [Route("api/Books/buy/{id}")]
        [Authorize]
        public IHttpActionResult CreatePurchase(int id)
        {
            var context = new BookShopSystemContext();
            var book = context.Books.Find(id);
            var currentUserId = this.User.Identity.GetUserId();
            var user = context.Users
                .First(u => u.Id == currentUserId);

            if (book == null)
            {
                return this.BadRequest("invalid book id");
            }

            var purchase = new Purchase()
            {
                Book = book,
                User = user,
                Price = book.Price,
                DateOfPurchase = DateTime.Now,
                IsRecalled = false
            };

            if (book.Copies == 0)
            {
                return this.BadRequest("no book's copies");
            }

            book.Copies = book.Copies - 1;
            context.Purchases.Add(purchase);
            context.SaveChanges();

            var purchaseResult = new
            {
                Price = purchase.Price,
                PurchaseDate = purchase.DateOfPurchase,
                IsRecalled = purchase.IsRecalled,
                PurchasePrice = purchase.Price,
                BookTitle = purchase.Book.Title
            };

            return this.Ok(purchaseResult);
        }

        // GET /api/User/{username}/Purchases
        [Route("api/User/{username}/Purchases")]
        [HttpPut]
        [Authorize]
        public IHttpActionResult GetsAppPurchaseData(string username)
        {
            var context = new BookShopSystemContext();
            var user = context.Users
                .FirstOrDefault(u => u.UserName == username);

            if (user == null)
            {
                return this.NotFound();
            }

            var userName = user.UserName;
            var purchases = user.Purchases.Select(p => new
            {
                p.Price,
                p.Book.Title,
                p.DateOfPurchase,
                p.IsRecalled,
            });

            var purchaseResult = new
            {
                UserName = username,
                Purchases = purchases
            };

            return this.Ok(purchaseResult);
        }
    }
}