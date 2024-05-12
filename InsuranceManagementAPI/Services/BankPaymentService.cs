using InsuranceManagementAPI.Data.Models;
using InsuranceManagementAPI.Data.Repository;
using InsuranceManagementAPI.Models;
using InsuranceManagementAPI.Models.Factories;
using Microsoft.AspNetCore.Mvc;
using System.Collections;

namespace InsuranceManagementAPI.Services
{
    public class BankPaymentService : IBankPaymentService
    {
        private readonly IBankPaymentFactory _bankPaymentFactory;
        private readonly IBankPaymentRepository _bankPaymentRepository;
        private readonly IFinalMRRepository _finalMRRepository;
        public BankPaymentService(IBankPaymentFactory bankPaymentFactory, IBankPaymentRepository bankPaymentRepository, IFinalMRRepository finalMRRepository)
        {
            _bankPaymentFactory = bankPaymentFactory;
            _bankPaymentRepository = bankPaymentRepository;
            _finalMRRepository = finalMRRepository;
        }

        public Task<bool> Update(BankPayment bankPayment)
        {
            BankPayment? response = null ;
            var bankPaymentDto = _bankPaymentFactory.CreateFrom(bankPayment);

            //var finalMr = _finalMRRepository.GetFinalMRByID(bankPaymentDto.FinalMRKey);
                

            var result = _bankPaymentRepository.Update(bankPaymentDto);
 

            //bankPaymentDto = await _bankPaymentRepository.GetBankPaymentByID(bankPaymentDto.BankPaymentKey);

            //response = _bankPaymentFactory.CreateFrom(bankPaymentDto);


            return result;
        }

    }
}
