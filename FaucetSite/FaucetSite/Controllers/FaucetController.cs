using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using FaucetSite.Lib;

namespace FaucetSite.Controllers

{
    [Route("api/[controller]")]
    public class FaucetController : Controller
    {
        private IWalletUtils walletUtils;

        public FaucetController(IConfiguration config)
        {
            walletUtils = new WalletUtils(config);
        }


        [Route("/Error")]
        public IActionResult Error()
        {
            ViewData["RequestId"] = Activity.Current?.Id ?? HttpContext.TraceIdentifier;
            return View();
        }

        [HttpPost("SendCoin")]
        public async Task<Transaction> SendCoin([FromBody] Recipient model)
        {
            return await walletUtils.SendCoin(model);
        }
    }
}
