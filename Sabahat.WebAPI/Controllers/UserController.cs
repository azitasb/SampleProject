using Newtonsoft.Json;
using Sabahat.Business;
using Sabahat.Business.Users;
using Sabahat.Common;
using Sabahat.Data.Users;
using Sabahat.WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
//using System.Web.Http;
using System.Web.Mvc;

namespace Sabahat.WebAPI.Controllers
{
    public class UserController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult GetUsers()
        {
            try
            {
                var result = ServiceHandler.CallApi(Constants.Uri.GetUsersAddress, null, Common.HttpRequest.HttpGet);

                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ActionResult New()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Insert(UserModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                    throw new Exception("Eingabedaten sind ungültig");

                var content = new FormUrlEncodedContent(new[]
                    {
                        new KeyValuePair<string, string>("name", model.Name),
                        new KeyValuePair<string, string>("lastName", model.LastName),
                        new KeyValuePair<string, string>("zipCode", model.ZipCode),
                        new KeyValuePair<string, string>("city", model.City),
                        new KeyValuePair<string, string>("jobLevel", model.JobLevel)
                    });
                var result = ServiceHandler.CallApi(Constants.Uri.GetUsersAddress, content, Common.HttpRequest.HttpPost);

                return Json(new { hasError = false, data = result }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { hasError = true, data = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}
