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
        private static List<Product> cosCumparaturi = null;
        private static User userLogin;
        private Boolean conectat = false;
        private MyModel myModel = new MyModel();

        public ActionResult Index()
        {

            LoginUsers();



            myModel.categories = db.Categories.ToList();

            return View(myModel);
        }



        public ActionResult ListaCumparaturi(int? id)
        {
            LoginUsers();
            if (id != null)
            {
                List<Product> product = db.Products.Where(s => s.Category.Id == id).ToList();

                myModel.products = product;

                return View(myModel);

            }
            else
            {
                myModel.products = db.Products.ToList();
                return View(myModel);
            }
        }



        public ActionResult SingUp(string FirstName, string LastName, string Email, string Password1,
            string Password2, string Phone)
        {
            LoginUsers();

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
                    user.Role = Roles.Client;

                    
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
            return View(myModel);



        }

        public ActionResult Login(string Email, string Password)
        {
            LoginUsers();
            if (ModelState.IsValid)
            {

                User data = db.Users.Where(s => s.Email.Equals(Email) && s.Password.Equals(Password)).FirstOrDefault() ;

                if (data!=null)
                {
                    userLogin = data;
                    conectat = true;
                    LoginUsers();
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["buttonval1"] = Email;
                    TempData["buttonval2"] = Password;
                    return View(myModel);
                }

            }
            return View(myModel);
        }


        public ActionResult Detalii(int? id) //numai Maria stie ce ii aici 
        {
            LoginUsers();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            myModel.product = product;
            return View(myModel);
        }

        public ActionResult AddProdusCos(int? id)
        {
            if (cosCumparaturi == null)
            {
                cosCumparaturi = new List<Product>();
            }
            LoginUsers();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Product product = db.Products.Find(id);


            if (product == null)
            {
                return HttpNotFound();
            }
            else
            {
                cosCumparaturi.Add(product);
            }


            return RedirectToAction("Index");

        }

        public ActionResult CosCumparaturi(int? id)
        {
            if (cosCumparaturi == null)
            {
                cosCumparaturi = new List<Product>();


            }
            LoginUsers();
            decimal pret = 0;
            for (int i = 0; i < cosCumparaturi.Count; i++)
            {
                pret += cosCumparaturi[i].Price;
            }
            myModel.price = pret;
            myModel.products = cosCumparaturi;
            return View(myModel);
        }

        public ActionResult Deconectare()
        {
            userLogin = null;
            cosCumparaturi = null;
            LoginUsers();
            return RedirectToAction("Index");
        }


        public ActionResult Cumpara()
        {
            LoginUsers();

            if (cosCumparaturi != null)
            {
                Order order = new Order();
                order.Amount = cosCumparaturi.Count;
                order.User = userLogin;
                order.Date = DateTime.Now;

                db.Orders.Add(order);
                db.SaveChanges();


                for (int i = 0; i < cosCumparaturi.Count; i++)
                {
                    OrderItem orderItem = new OrderItem();
                    orderItem.Price = (double)cosCumparaturi[i].Price;
                    orderItem.Product = cosCumparaturi[i];
                    
                    orderItem.Quantity = 1;
                    db.OrderItems.Add(orderItem);
                    db.SaveChanges();

                }

            }

            return RedirectToAction("Index");
        }


        public ActionResult RemoveProduse()
        {
            LoginUsers();

            myModel.products = db.Products.ToList();
            return View(myModel);
        }

      
        public ActionResult Remove(int ?id)
        {
            LoginUsers();
            Product product=db.Products.Find(id);
            db.Products.Remove(product);
           
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        public ActionResult AddProduse()
        {
            LoginUsers();
            return View(myModel);
        }

        public void LoginUsers()
        {
            MyModel.UserMY nume = new MyModel.UserMY();

            MyModel.UserMY rapoarte = new MyModel.UserMY();
            rapoarte.name = "Rapoarte";
            rapoarte.page = "Index";

            MyModel.UserMY AddProdus = new MyModel.UserMY();
            AddProdus.name = "Add Produs";
            AddProdus.page = "AddProduse";


            MyModel.UserMY RemoveProdus = new MyModel.UserMY();
            RemoveProdus.name = "Remove Produs";
            RemoveProdus.page = "RemoveProduse";
            List<MyModel.UserMY> l = new List<MyModel.UserMY>();


            if (userLogin == null)
            {
                nume.name = "Nu esti logat!";
                nume.page = "Index";
                l.Add(nume);
            }
            else
            {
                nume.name = userLogin.FirstName;
                nume.page = "Index";
                l.Add(nume);
                if (userLogin.Role == 0)
                {
                    l.Add(rapoarte);
                    l.Add(AddProdus);
                    l.Add(RemoveProdus);
                }
            }

            myModel.user = l;
        }
    }
}
