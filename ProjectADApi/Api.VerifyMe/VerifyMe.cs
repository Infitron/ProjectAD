using Api.VerifyMe.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Api.VerifyMe
{
    public class VerifyMe
    {
        readonly Dictionary<WantToVerity, DefaultVerificationFactory> _verifyMeFactoryDictionary;

        public VerifyMe()
        {
            _verifyMeFactoryDictionary = new Dictionary<WantToVerity, DefaultVerificationFactory>();

            foreach (WantToVerity wantToVerify in Enum.GetValues(typeof(WantToVerity)))
            {
                var factory = (DefaultVerificationFactory)Activator.CreateInstance(Type.GetType("Api.VerifyMe.Factory." + Enum.GetName(typeof(WantToVerity), wantToVerify) + "VerificationFactory"));
                _verifyMeFactoryDictionary.Add(wantToVerify, factory);
            }
        }

        public IVerificationManager StartVerification(WantToVerity WantToVefify, object WhatToVerify)
            =>  _verifyMeFactoryDictionary[WantToVefify].CreateInstance(WhatToVerify);
    }
}
