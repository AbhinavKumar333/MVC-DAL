using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UserDAL;

namespace UserApp.Controllers
{
    public class UserController : Controller
    {
        CrudRepository repo;
        public UserController()
        {
            repo = new CrudRepository();
        }
        // GET: User
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult UserRegister()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddUser(user u)
        {
            bool result = repo.Register(u);
            if (result) { ViewBag.Msg = "User Added Successfully!"; }
            else { ViewBag.ErrorMsg = "Error occured while adding user"; }
            return View("UserRegister");
        }
        [HttpGet]
        public ActionResult ViewAllUsers()
        {
            List<UserDAL.user> dal = repo.ViewAll();
            List<Models.user> mvc = new List<Models.user>();
            foreach(var u in dal)
            {
                Models.user temp = new Models.user();
                temp.userId = u.userId;
                temp.userName = u.userName;
                temp.Email = u.Email;
                temp.Phone = u.Phone;
                temp.Password = u.Password;
                mvc.Add(temp);
            }
            return View(mvc);
        }
        [HttpGet]
        public ActionResult ViewUser(int id)
        {
            UserDAL.user dal = repo.View(id);
            Models.user mvc = new Models.user();
            mvc.userId = dal.userId;
            mvc.userName = dal.userName;
            mvc.Phone = dal.Phone;
            mvc.Email = dal.Email;
            mvc.Password = dal.Password;
            return View(mvc);
        }
        [HttpGet]
        public ActionResult EditUser(int id)
        {
            UserDAL.user dal = repo.View(id);
            Models.user mvc = new Models.user();
            mvc.userId = dal.userId;
            mvc.userName = dal.userName;
            mvc.Phone = dal.Phone;
            mvc.Email = dal.Email;
            mvc.Password = dal.Password;
            return View(mvc);
        }
        [HttpPost]
        public ActionResult EditConfirm(Models.user mvc)
        {
            UserDAL.user dal = repo.View(mvc.userId);
            dal.userId = mvc.userId;
            dal.userName = mvc.userName;
            dal.Phone = mvc.Phone;
            dal.Email = mvc.Email;
            dal.Password = mvc.Password;
            bool result = repo.Update(dal);
            if (result) { ViewBag.Msg = "Updated Successfully!"; }
            else { ViewBag.ErrorMsg = "Update Failed"; }
            return View("EditUser");
        }
        [HttpGet]
        public ActionResult DeleteUser(int id)
        {
            UserDAL.user dal = repo.View(id);
            Models.user mvc = new Models.user();
            mvc.userId = dal.userId;
            mvc.userName = dal.userName;
            mvc.Phone = dal.Phone;
            mvc.Email = dal.Email;
            mvc.Password = dal.Password;
            return View(mvc);
        }
        [HttpPost,ActionName("DeleteUser")]
        public ActionResult DeleteConfirmed(int id)
        {
            repo.Delete(id);
            return RedirectToAction("ViewAllUsers");
        }
        public ActionResult LoginUser()
        {
            return View();
        }
        public ActionResult LoginConfirmed(user u)
        {
            bool result = repo.Login(u.Email, u.Password);
            if (result)
            {
                Session["Email"] = u.Email;
                return RedirectToAction("ViewAllUsers");
            }
            else
            {
                ViewBag.Msg = "Check Credentials!";
                return View("LoginUser");
            }
        }
        public ActionResult LogoutUser()
        {
            Session.Clear();
            return View("LoginUser");
        }
    }
}