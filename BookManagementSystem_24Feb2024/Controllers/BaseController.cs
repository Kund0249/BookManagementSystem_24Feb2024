using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.NewtonsoftJson;
using Newtonsoft.Json;

namespace BookManagementSystem_24Feb2024.Controllers
{
    public enum MessagetType
    {
        success, error, info, warrning
    }
    public class BaseController : Controller
    {
        public void Notify(string Title, string Message, MessagetType type)
        {
            string messagetype = string.Empty;
            switch (type)
            {
                case MessagetType.success:
                    messagetype = "success";
                    break;
                case MessagetType.error:
                    messagetype = "error";
                    break;
                case MessagetType.info:
                    messagetype = "info";
                    break;
                case MessagetType.warrning:
                    messagetype = "warning";
                    break;
                default:
                    break;
            }

            var message = new
            {
                Message = Message,
                Title = Title,
                Type = messagetype
            };
            var JsonMessage = JsonConvert.SerializeObject(message);
            //{"Message" : "Record Saved","Title":"Success","Type" : "success"}
           // var JS = "";//new JavaScriptSerializer();
           TempData["Message"] = JsonMessage;
        }

    }
}
