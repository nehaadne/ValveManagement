using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValveManagement.Common.Models
{
    public class BaseResponseStatus
    {
        /// <summary>
        /// Status Code for the response
        /// </summary>
        public string? StatusCode { get; set; }
        /// <summary>
        /// Status Message for the response
        /// </summary>
        public string? StatusMessage { get; set; }

        /// <summary>
        /// Response Data to be shared
        /// </summary>
        public object? ResponseData { get; set; }
        public object? ResponseData1 { get; set; }

        public static explicit operator BaseResponseStatus(ActionResult v)
        {
            throw new NotImplementedException();
        }
    }
}
