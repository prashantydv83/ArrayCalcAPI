using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Text;
using ArrayCalcAPI.Service;

namespace ArrayCalcAPI.Controllers
{
    public class ArrayCalcController : ApiController
    {
        [HttpGet]
        public HttpResponseMessage Reverse([FromUri] int[] productIds)
        {
            if (productIds == null)
                return new HttpResponseMessage()
                {
                    Content = new StringContent("Invalid request", Encoding.UTF8, "text/html")
                };

            ArrayOperations.ReverseArray(productIds);

            return new HttpResponseMessage()
            {
                Content = new StringContent(string.Format("[{0}]", string.Join(", ", productIds)), Encoding.UTF8, "text/html")
            };
        }

        [HttpGet]
        public HttpResponseMessage DeletePart(int position, [FromUri] int[] productIds)
        {
            if (productIds == null)
                return new HttpResponseMessage()
                {
                    Content = new StringContent("", Encoding.UTF8, "text/html")
                };

            productIds = ArrayOperations.DeleteAtPosition(position, productIds);

            return new HttpResponseMessage()
            {
                Content = new StringContent(string.Format("[{0}]", string.Join(", ", productIds)), Encoding.UTF8, "text/html")
            };
        }
    }
}
