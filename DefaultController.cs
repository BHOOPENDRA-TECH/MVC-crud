using CrudMVC.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CrudMVC.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Default
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult InsertMobile() // Calling when we first hit controller.  
        {
            return View();
        }
        [HttpPost]
        public ActionResult InsertMobile(Class1 MB) // Calling on http post (on Submit)  
        {
            if (ModelState.IsValid) //checking model is valid or not  
            {
                DataAccessLayer objDB = new DataAccessLayer(); //calling class DBdata  
                string result = objDB.InsertData(MB); // passing Value to DBClass from model  
                ViewData["result"] = result;
                ModelState.Clear(); //clearing model  
                return View();
            }
            else
            {
                ModelState.AddModelError("", "Error in saving data");
                return View();
            }
        }
        public ActionResult ShowAllMobileDetails(Class1 MB)
        {
            DataAccessLayer objDB = new DataAccessLayer(); //calling class DBdata  
            MB.StoreAllData = objDB.SelectAllData();
            return View(MB);
        }


        public ActionResult EDITMOBILEDATA(string id)
        {
            DataAccessLayer objDB = new DataAccessLayer();
            //calling class DBdata  
            DataSet ds = objDB.SelectAllDatabyID(id);
            Class1 MB = new Class1();
            MB.MobileID = Convert.ToInt32(ds.Tables[0].Rows[0]["MobileID"].ToString());
            MB.MobileName = ds.Tables[0].Rows[0]["MobileName"].ToString();
            MB.MobileIMEno = ds.Tables[0].Rows[0]["MobileIMEno"].ToString();
            MB.mobileprice = ds.Tables[0].Rows[0]["mobileprice"].ToString();
            MB.mobileManufacured = ds.Tables[0].Rows[0]["mobileManufacured"].ToString();
            return View(MB);
        }


        [HttpPost]
        public ActionResult EDITMOBILEDATA(Class1 MD)
        {
            DataAccessLayer objDB = new DataAccessLayer(); //calling class DBdata  
            string result = objDB.UpdateData(MD); // passing Value to DBClass from model  
            ViewData["resultUpdate"] = result; // for dislaying message after updating data.  
            return RedirectToAction("ShowAllMobileDetails", "Default");
        }

        public ActionResult DELETEMOBILEDATA(string id)
        {
            DataAccessLayer objDB = new DataAccessLayer();
            //calling class DBdata  
            DataSet ds = objDB.SelectAllDatabyID(id);
            Class1 MB = new Class1();
            MB.MobileID = Convert.ToInt32(ds.Tables[0].Rows[0]["MobileID"].ToString());
            MB.MobileName = ds.Tables[0].Rows[0]["MobileName"].ToString();
            MB.MobileIMEno = ds.Tables[0].Rows[0]["MobileIMEno"].ToString();
            MB.mobileprice = ds.Tables[0].Rows[0]["mobileprice"].ToString();
            MB.mobileManufacured = ds.Tables[0].Rows[0]["mobileManufacured"].ToString();
            return View(MB);
        }



        [HttpPost]
        public ActionResult DELETEMOBILEDATA(Class1 MD)
        {
            DataAccessLayer objDB = new DataAccessLayer();
            //calling class DBdata  
            string result = objDB.DeleteData(MD);
            return RedirectToAction("Default", "Mobilestore");
        }
    }
}