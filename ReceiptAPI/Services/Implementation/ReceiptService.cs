using ReceiptAPI.Models;
using ReceiptAPI.Models.Base;
using ReceiptAPI.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReceiptAPI.Services.Implementation
{
    public class ReceiptService : IReceiptService
    {
        private static List<Receipt> receipts = new List<Receipt>
        {
            new Receipt
            {
                 Id = 1,
                 Products = new List<Product>
                {
                    new Product
                    {
                        Id = 1,
                        Name = "Produkt1",
                        Value = 5.10m
                    },
                    new Product
                    {
                        Id = 2,
                        Name = "Produkt2",
                        Value = 4.10m
                    },
                }
            },
            new Receipt
            {
                 Id = 2,
                 Products = new List<Product>
                {
                    new Product
                    {
                        Id = 3,
                        Name = "Produkt3",
                        Value = 2.20m
                    },
                    new Product
                    {
                        Id = 4,
                        Name = "Produkt4",
                        Value = 3m
                    },
                }
            },
        };

        public async Task<ServiceResponse<Receipt>> AddNewReceipt(Receipt receipt)
        {
            ServiceResponse<Receipt> response = new ServiceResponse<Receipt>();

            if (receipt != null)
            {
                receipts.Add(receipt);
                response.Data = receipt;
                response.Success = true;
                response.Message = "OK";
            }

            return response;
        }

        public async Task<ServiceResponse<List<Receipt>>> GetAllReceipts()
        {
            ServiceResponse<List<Receipt>> response = new ServiceResponse<List<Receipt>>();
            response.Data = receipts;
            response.Success = true;
            response.Message = "OK";

            return response;
        }

        public async Task<ServiceResponse<Receipt>> GetReceiptById(int id)
        {
            ServiceResponse<Receipt> response = new ServiceResponse<Receipt>();

            var receipt = receipts.FirstOrDefault(x => x.Id == id);

            if (receipt != null)
            {
                response.Data = receipt;
                response.Message = "OK";
                response.Success = true;
            }
            else
            {
                response.Data = null;
                response.Message = "Receipt not found!";
                response.Success = false;
            }

            return response;
        }
    }
}
