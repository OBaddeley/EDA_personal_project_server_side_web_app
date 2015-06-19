using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using ShopShopShop.Models;

namespace ShopShopShop.Controllers
{
    public class ProductsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Products
        public ActionResult Index()
        {
           
            if (User.Identity.IsAuthenticated)
            {
                return View(db.Products.ToList());
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
        }

        // Show Cart
        public ActionResult Cart()
        {
            if (User.Identity.IsAuthenticated)
            {
                //get currentuser id
                var currentUser = User.Identity.GetUserId();
                //the cart is made up of the the products in the products table where
                //the shoppers id matches the currentUser id
                var cart = db.Products.Where(p => p.Shoppers.Any(i => i.Id == currentUser));
                // show what is in the cart
                return View(cart);
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
               
        }


         //Add Product to Cart
        public ActionResult Add(int id) //pass in product id
        {
            //get current user id
            var currentUser = User.Identity.GetUserId();

            //get user from users db
            var user = db.Users.Single(u => u.Id == currentUser);

            //product they want using id passed in
            var product = db.Products.Single(p =>p.Id == id);
            //add to database
            
            user.Products.Add(product);
            //savechanges
            db.SaveChanges();

            //return to same page
            return RedirectToAction("Index");
        }

        //// Remove Product from Cart

        public ActionResult Remove(int id)  //pass in product id
        {
            //get current user id
            var currentUser = User.Identity.GetUserId();

            //get user from users db
            var user = db.Users.Single(u => u.Id == currentUser);

            //product they want using id passed in
            var product = db.Products.Single(p => p.Id == id);
            //remove from database
            user.Products.Remove(product);
            //savechanges
            db.SaveChanges();

            //return to cart page
            return RedirectToAction("Cart");
        }
        

        ////ClearCart - remove all items from cart

        public ActionResult ClearCart()
        {
            //get current user id
            var currentUser = User.Identity.GetUserId();

            //get user from users db
            var user = db.Users.Single(u => u.Id == currentUser);

            
            //remove everything from database
            //foreach (var product in user.Products)
            //{
            //    user.Products.Remove(product);
            //}
            var numOfProducts = user.Products.Count; 
            for (int i = 0; i < numOfProducts; i++)
            {
                user.Products.RemoveAt(0);
            }            
            //savechanges
            db.SaveChanges();

            //return to cart page
            return RedirectToAction("Cart");
        }


        public ActionResult Checkout()
        {
            ClearCart();
            return View();
        }


        // GET: Products/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // GET: Products/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Price")] Product product)
        {
            if (ModelState.IsValid)
            {
                db.Products.Add(product);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(product);
        }

        // GET: Products/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Price")] Product product)
        {
            if (ModelState.IsValid)
            {
                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(product);
        }

        // GET: Products/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Product product = db.Products.Find(id);
            db.Products.Remove(product);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
