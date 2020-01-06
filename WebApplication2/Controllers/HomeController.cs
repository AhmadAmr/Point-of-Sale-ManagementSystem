using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Web.Mvc;
using WebApplication2.Models;
using System.Data.SqlClient;


namespace WebApplication2.Controllers
{
    public partial class HomeController : Controller
    {
        add obj = new add();
        public ActionResult dashboard()
        {
            return View();
        }
        public ActionResult adduser()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult manageusers()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult addgroup()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult managegroup()
        {
            return View();
        }

        public ActionResult Order()
        {
            return View();
        }
        public ActionResult login()
        {
            return View();
        }
    }
    /// <summary>
    /// ////////////////////category///////////////////////////////////////
    /// </summary>
    public partial class HomeController : Controller
    {
        tableview obj1 = new tableview();
        catmodel catobj = new catmodel(); 
        // GET: category
        [HttpGet]
         public ActionResult category()
        {

            try
            {
                SqlConnection con = new SqlConnection("Data Source =.; Initial Catalog = cms; Integrated Security = True; MultipleActiveResultSets=True");
                SqlCommand cmd = new SqlCommand("select category_id,category_name,status from category", con);
                //cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader sdr = cmd.ExecuteReader();
                List<catmodel> objmodel = new List<catmodel>();
                while (sdr.Read())
                {
                    var details = new catmodel();
                    details.category_id = Convert.ToInt32(sdr["category_id"]);
                    details.Name = sdr["category_name"].ToString();
                    details.status = Convert.ToByte(sdr["status"]);
                    objmodel.Add(details);
                }
                con.Close();
                catobj.getdata = objmodel;
            }
            catch
            {
            }
            ModelState.Clear();

            return View("category", catobj);
        }
        [HttpPost]
        public ActionResult category([Bind] catmodel cat)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    obj.addcat(cat);
                    ModelState.Clear();
                }
            }
            catch (Exception ex)
            {

            }

            try
            {
                SqlConnection con = new SqlConnection("Data Source =.; Initial Catalog = cms; Integrated Security = True; MultipleActiveResultSets=True");
                SqlCommand cmd = new SqlCommand("select category_id,category_name,status from category", con);
                //cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader sdr = cmd.ExecuteReader();
                List<catmodel> objmodel = new List<catmodel>();
                while (sdr.Read())
                {
                    var details = new catmodel();
                    details.category_id =Convert.ToInt32( sdr["category_id"]);
                    details.Name = sdr["category_name"].ToString();
                    details.status = Convert.ToByte(sdr["status"]);
                    objmodel.Add(details);
                }
                con.Close();
                cat.getdata = objmodel;
            }
            catch
            {
            }
            ModelState.Clear();

            return View( "category",cat);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            Delete del = new Delete();
            del.DeleteCategory(id);
            return RedirectToAction("category");
        }

    }
    
    public partial class HomeController : Controller
    {
        catContext c = new catContext();
        storeContext b = new storeContext();
        // GET: category
        [HttpPost]
        public ActionResult addproduct(productmodel product)
        {
           
                if (ModelState.IsValid)
                {
                    obj.addproduct(product);
                    ModelState.Clear();
                }
            product.Catlist = new SelectList(c.GetMobileList(), "category_id", "category_name");
            product.Storelist= new SelectList(b.GetstoreList(), "store_id", "store_name");
            return View(product);
        }
        [HttpGet]
        public ActionResult addproduct()
        {
            productmodel product = new productmodel();
            product.Storelist = new SelectList(b.GetstoreList(), "store_id", "store_name");
            product.Catlist = new SelectList(c.GetMobileList(), "category_id", "category_name");
            return View(product);
        }
    }
    /// <summary>
    /// ///////////////store_view//////////////////////////////////
    /// </summary>
    public partial class HomeController : Controller
    {
        [HttpGet]
        public ActionResult store()
        {
            return View();
        }
        [HttpPost]
        public ActionResult store([Bind] storemodel store)
        {
            try
            {
                if (ModelState.IsValid)
                {
                   obj.addstore(store);
                }
            }
            catch (Exception ex)
            {

            }
            try
            {
                SqlConnection con = new SqlConnection("Data Source =.; Initial Catalog = cms; Integrated Security = True; MultipleActiveResultSets=True");
                SqlCommand cmd = new SqlCommand("st_getstore", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader sdr = cmd.ExecuteReader();
                List<storemodel> objmodel = new List<storemodel>();
                while (sdr.Read())
                {
                    var details = new storemodel();

                    details.Name = sdr["catname"].ToString();
                    details.status = Convert.ToByte(sdr["status"]);
                    objmodel.Add(details);
                }
                con.Close();
                store.getdata = objmodel;
            }
            catch
            {

            }
            return View("store", store);
         }
            
        }

    
    /// <summary>
    /// /////////////tableview//////////////////////////////////////
    /// </summary>
    public partial class HomeController : Controller
    {
        public ActionResult tables()
        {
            return View();
        }
        [HttpPost]
        public ActionResult tables([Bind] tablemodel table)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    obj.addtable(table);

                }
            }
            catch (Exception ex)
            {
            }
            try
            {
                SqlConnection con = new SqlConnection("Data Source =.; Initial Catalog = cms; Integrated Security = True; MultipleActiveResultSets=True");
                SqlCommand cmd = new SqlCommand("st_gettable", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader sdr = cmd.ExecuteReader();
                List<tablemodel> objmodel = new List<tablemodel>();
                while (sdr.Read())
                {
                    var details = new tablemodel();
                    
                    details.Name = sdr["tname"].ToString();
                    details.status = Convert.ToByte(sdr["status"]);
                    details.capacity = Convert.ToInt32(sdr["Capacity"]);
                    objmodel.Add(details);
                }
                con.Close();
                table.getdata = objmodel;
            }
            catch
            {

            }
            return View("tables",table);
        }
    

    }
    ////////////////////////////getdata from database//////////////////////////////////////////////////////
}