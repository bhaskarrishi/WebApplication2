using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using CalculateInventory.Models;

namespace WebApplication2.Controllers
{
    
    public class HomeController : Controller
    {
        //public List<string> tbl = new List<string>();
        string errormsg1;
        string errormsg2;
        bool errorcheck = false;
        public ActionResult Index()
        {   
            ViewBag.ItemList = "Order Management Page";
            ProductModel model = new ProductModel();
            return View(model);
            
            //string strName = Request["txtName"].ToString();
            //Console.WriteLine(strName);
        }

        // GET: Item
        public ActionResult InventoryUpdate()
        {
            ViewBag.ItemList = "Order Management Page";
            ProductModel model = new ProductModel();
            return View(model);
        }

        [HttpPost]
        public ActionResult CalculateInventoryResult(ProductModel model)
        {
            ViewBag.ItemList = "Order Management Page";
            string strName = Request["txtName"].ToString();
            string strQuantity = Request["txtQuantity"].ToString();
            float Qty = float.Parse(strQuantity);

            //string strQuantity = Request["txtQuantity"].ToString();
            string strPrice = Request["txtPrice"].ToString();
            float prc = float.Parse(strPrice);
            float TotQty = (Qty * prc );

            DataValidations(strName, Qty);
            //listadd(strName);

            //StringBuilder sb = new StringBuilder();
            //sb.Append("<table>");
            //foreach (var mem in tbl)
            //{
            //    sb.AppendFormat(@ViewBag.strName , @ViewBag.strQuantity , @ViewBag.strPrice , mem);
            //}
            //sb.Append("</table>");
            //ViewBag.sb = sb;

            //return Content(tbl);

            float Subtotal = TotQty;

            double Tax = (Subtotal * 0.15);
            double Total = (Tax + Subtotal);

            if (errorcheck == false)
            {
                ViewBag.strName = strName;
                ViewBag.strQuantity = strQuantity;
                ViewBag.strPrice = strPrice;
                ViewBag.TotQty = TotQty;
                ViewBag.Subtotal = Subtotal;
                ViewBag.Tax = Tax;
                ViewBag.Total = Total;

            }
            ViewBag.errormsg1 = errormsg1;
            ViewBag.errormsg2 = errormsg2;
            return View();

            //return Content(strQuantity);

            //decimal TotQty = Convert.ToDecimal(Request["txtQuantity"].ToString());
            //float TotQty = (model.Quantity * model.Price );
            //return View(model);
            //StringBuilder sbtotal = new StringBuilder();
            //sbtotal.Append("<b> Sub Total :</b> " + TotQty + "<br/>");
            //return Content(sbtotal.ToString());


            //       model.Message1 = (model.Name + "   " + model.Quantity);

            //List<string> tbl = new List<string>();
            //tbl.Add(model.Message1);
            //  ViewBag.Message1 = model.Message1;

            //       ViewBag.Message1 = model.Name;
            //       return View(model);
        }

        public void DataValidations (string strName , float Qty)
        {
            //if (strName == "Select Item")
            if ((strName != "Screws") && (strName != "Bolts") && (strName != "Scissors") && (strName != "Hammer") && (strName != "Screw driver"))
            {   
                errormsg1 = "Item field must be selected";
                errorcheck = true;
            }
            else if (Qty < 0 || Qty > 150)
            {
                errormsg2 = "Quantity field must be between 0 and 150";
                errorcheck = true;
            }
            else
            {
                errorcheck = false;
            }
            return ;
        }

        //public void listadd (string strNm)
        //{
        //    tbl.Add(strNm);
        //    ViewBag.tbl = tbl;
        //    //return (tbl);
        //}

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }

    }
}


