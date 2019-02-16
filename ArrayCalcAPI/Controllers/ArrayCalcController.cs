﻿using System;
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
    /// <summary>
    /// Array Calc Controller.
    /// </summary>
    [RoutePrefix("api/arraycalc")]
    public class ArrayCalcController : ApiController
    {
        private IArrayOperations arrayOperations;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="arrayoperations"></param>
        public ArrayCalcController(IArrayOperations arrayoperations)
        {
            this.arrayOperations = arrayoperations;
        }

        /// <summary>
        /// Http Get method for reverse array.
        /// </summary>
        /// <param name="productIds">productIds</param>
        /// <returns>Reversed Array</returns>
        [HttpGet]
        [Route("Reverse")]
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


        /// <summary>
        /// Http get method for deleting array element at specified position.
        /// </summary>
        /// <param name="position">position</param>
        /// <param name="productIds">productIds</param>
        /// <returns>Modified Array</returns>
        [HttpGet]
        [Route("DeletePart")]
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
