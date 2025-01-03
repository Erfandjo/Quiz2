using App.Domain.Core.Quiz2.CodeVerify.AppServices;
using App.Domain.Core.Quiz2.CodeVerify.Services;
using App.Domain.Services.Quiz2.CodeVerify;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.AppServices.Quiz2.CodeVerify
{
    public class CodeVerifyAppService : ICodeVerifyAppService
    {
        private readonly ICodeVerifyService _codeVerifyService;

        public CodeVerifyAppService(ICodeVerifyService codeVerifyService)
        {
            _codeVerifyService = codeVerifyService;
        }



        public void GenerateCode()
        {
            Random random = new Random();
            var result = Convert.ToString(random.Next(random.Next(10000, 99999)));
            _codeVerifyService.Add(result);
        }
    }
}
