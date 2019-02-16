using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Text;
using ArrayCalcService;
using ArrayCalcContracts;

namespace ArrayCalcAPI.Controllers
{
    public class ArrayCalcController : ApiController
    {
        private IArrayOperations arrayOperations;

        public ArrayCalcController(IArrayOperations arrayoperations)
        {
            this.arrayOperations = arrayoperations;
        }

        [HttpGet]
        public HttpResponseMessage Reverse([FromUri] int[] productIds)
        {
            if (productIds == null)
                return new HttpResponseMessage()
                {
                    Content = new StringContent("Invalid request", Encoding.UTF8, "text/html")
                };

            arrayOperations.ReverseArray(productIds);

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

            productIds = arrayOperations.DeleteAtPosition(position, productIds);

            return new HttpResponseMessage()
            {
                Content = new StringContent(string.Format("[{0}]", string.Join(", ", productIds)), Encoding.UTF8, "text/html")
            };
        }
    }
}
