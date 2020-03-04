using ReceiptAPI.Models;
using ReceiptAPI.Models.Base;
using ReceiptAPI.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReceiptAPI.Services.Interface
{
    public interface IReceiptService
    {
        Task<ServiceResponse<List<ReceiptDto>>> GetAllReceipts();

        Task<ServiceResponse<ReceiptDto>> GetReceiptById(int id);

        Task<ServiceResponse<ReceiptDto>> AddNewReceipt(ReceiptDto receipt);
    }
}
