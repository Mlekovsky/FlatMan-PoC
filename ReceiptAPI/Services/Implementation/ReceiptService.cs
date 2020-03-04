using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ReceiptAPI.EFContexts;
using ReceiptAPI.Models;
using ReceiptAPI.Models.Base;
using ReceiptAPI.Models.Dtos;
using ReceiptAPI.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReceiptAPI.Services.Implementation
{
    public class ReceiptService : IReceiptService
    {
        private readonly IMapper mapper;
        private readonly DataContext context;

        public ReceiptService(IMapper mapper, DataContext context)
        {
            this.mapper = mapper;
            this.context = context;
        }

        public async Task<ServiceResponse<ReceiptDto>> AddNewReceipt(ReceiptDto receipt)
        {
            ServiceResponse<ReceiptDto> response = new ServiceResponse<ReceiptDto>();
                       
            if (receipt != null)
            {
                var receiptDb = mapper.Map<Receipt>(receipt);

                await context.Receipts.AddAsync(receiptDb);
                await context.SaveChangesAsync();

                response.Data = mapper.Map<ReceiptDto>(await context.Receipts.Include(x => x.Products).FirstOrDefaultAsync(x => x.Id == receiptDb.Id));
                response.Success = true;
                response.Message = "OK";
            }

            return response;
        }

        public async Task<ServiceResponse<List<ReceiptDto>>> GetAllReceipts()
        {
            ServiceResponse<List<ReceiptDto>> response = new ServiceResponse<List<ReceiptDto>>();
            var receipts = await context.Receipts.Include(x => x.Products).ToListAsync();
            response.Data = receipts.Select(x => mapper.Map<ReceiptDto>(x)).ToList();
            response.Success = true;
            response.Message = "OK";

            return response;
        }

        public async Task<ServiceResponse<ReceiptDto>> GetReceiptById(int id)
        {
            ServiceResponse<ReceiptDto> response = new ServiceResponse<ReceiptDto>();

            var receiptDbo = await context.Receipts.Include(x => x.Products).FirstOrDefaultAsync(x => x.Id == id);
            var receipt = mapper.Map<ReceiptDto>(receiptDbo);

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
