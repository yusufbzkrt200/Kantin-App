using Kantin.DATA.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Kantin.Api.Controllers
{
    public class BarcodeController : ApiController
    {
        [HttpGet]
        public Json Barcode()
        {
            return BarkodDatabase.Barcode;
        }



        [HttpPost]
        public bool SetBarcode(string Barkod)
        {
            BarkodDatabase.Barcode = Barkod;
            return true;
        }
    }
}
