﻿using DataLayer.Tables;
using NetworkLibrary.NetworkLibrary.Http;

namespace AmoebaGameMatcherServer.Controllers
{
    public class SoftCurrencyDecrementType:IDecrementFactory
    {
        public CurrencyTypeEnum GetCurrencyTypeEnum()
        {
            return CurrencyTypeEnum.SoftCurrency;
        }

        public Decrement Create(ProductModel productModel)
        {
            return new Decrement
            {
                DecrementTypeId = DecrementTypeEnum.SoftCurrency,
                Amount = productModel.Cost
            };
        }
    }
}