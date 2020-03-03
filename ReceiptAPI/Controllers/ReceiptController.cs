using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReceiptAPI.Models;
using ReceiptAPI.Services.Interface;

namespace ReceiptAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ReceiptController : ControllerBase
    {
        private readonly IReceiptService receiptService;

        public ReceiptController(IReceiptService receiptService)
        {
            this.receiptService = receiptService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await receiptService.GetAllReceipts());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await receiptService.GetReceiptById(id);
            if (result != null)
                return Ok(result);
            else
                return NotFound();
        }

        [HttpPost]
        public async Task <IActionResult> Add(Receipt receipt)
        {
            if (receipt != null)
            {
                return Ok(await receiptService.AddNewReceipt(receipt));
            }
            else
                return BadRequest();
        }
    }
}