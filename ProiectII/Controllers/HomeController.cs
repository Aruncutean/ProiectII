using ProiectII.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace ProiectII.Controllers
{
    public class HomeController : Controller
    {
        private ShopDBContext db = new ShopDBContext();
        private User user = new Models.User();

        private User userLogin = null;
        public ActionResult Index()
        {

            return View(db.Categories.ToList());
        }


        public ActionResult ListaCumparaturi(int? id)
        {
            if (id != null)
            {
                List<Product> product = db.Products.Where(s => s.Category.Id == id).ToList();

                return View(product);

            }
            else
                return View(db.Products.ToList());
        }




        public ActionResult SingUp(string FirstName, string LastName, string Email, string Password1,
            string Password2, string Phone)
        {

            if (FirstName != null)
            {
                if (ModelState.IsValid)
                {
                    User user = new User();
                    user.FirstName = FirstName;
                    user.LastName = LastName;
                    user.Email = Email;
                    user.Password = Password1;
                    user.Phone = Phone;

                    if (!Password1.Equals(Password2))
                    {
                        ViewBag.Message = "Password";
                        // return View("SingUp",user);
                    }
                    else if (Email.Equals(""))
                    {
                        ViewBag.Message = "Completeaza email";
                        // return View("SingUp",user);
                    }

                    else if (FirstName.Equals(""))
                    {
                        ViewBag.Message = "Completeaza Firs Name";
                        // return View("SingUp", user);
                    }
                    else if (LastName.Equals(""))
                    {
                        ViewBag.Message = "Completeaza Last Name";
                        // return View("SingUp", user);
                    }
                    else if (Phone.Equals(""))
                    {
                        ViewBag.Message = "Completeaza Phone";
                        // return View("SingUp", user);
                    }
                    else
                    {
                        var check = db.Users.FirstOrDefault(s => s.Email == Email);
                        if (check == null)
                        {
                            db.Configuration.ValidateOnSaveEnabled = false;

                             db.Users.Add(user);
                             db.SaveChanges();
                            return RedirectToAction("Index");

                        }
                        else
                        {
                            ViewBag.Message = "Email already exists";

                        }
                    }
                }
            }
            return View();



        }

        public ActionResult Login(String Email, string password)
        {

            if (ModelState.IsValid)
            {

                List<User> data = db.Users.Where(s => s.Email.Equals(Email) && s.Password.Equals(password)).ToList();

                if (data.Count() > 0)
                {
                    foreach (User u in data)
                    {
                        userLogin = new User();
                        userLogin.Email = u.Email;
                        userLogin.FirstName = u.FirstName;
                        userLogin.LastName = u.LastName;
                    }


                    TempData["buttonval1"] = userLogin.FirstName;
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["buttonval1"] = Email;
                    TempData["buttonval2"] = password;
                    return View();
                }

            }
            return View();
        }

        Product product;
        public ActionResult Detalii(int? id) //numai Maria stie ce ii aici 
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

        public ActionResult AddProdusCos(int? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            OrderItem order = new OrderItem();
            
            db.OrderItems.Add(order);
            if (product == null)
            {
                return HttpNotFound();
            }

            return RedirectToAction("Index");

        }

        public ActionResult CosCumparaturi(int? id)
        {

            return View();
        }

        public ActionResult Deconectare()
        {

            return RedirectToAction("Index");
        }


    }
}