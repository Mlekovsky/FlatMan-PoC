using ReceiptAPI.Models;
using ReceiptAPI.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReceiptAPI.Services.Interface
{
    public interface IReceiptService
    {
        Task<ServiceResponse<List<Receipt>>> GetAllReceipts();

        Task<ServiceResponse<Receipt>> GetReceiptById(int id);

        Task<ServiceResponse<Receipt>> AddNewReceipt(Receipt receipt);
    }
}
