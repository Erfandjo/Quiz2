using App.Domain.Core.Quiz2.CodeVerify.Data.Repositories;
using App.Domain.Core.Quiz2.CodeVerify.Services;
using App.Infra.Data.Repos.File.Quiz2.CodeVerify.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Services.Quiz2.CodeVerify
{
    public class CodeVerifyService : ICodeVerifyService
    {
        private readonly ICodeVerifyRepository _codeVerifyRepository;

        public CodeVerifyService(ICodeVerifyRepository codeVerifyService)
        {
            _codeVerifyRepository = codeVerifyService;
        }
        public void Add(string code)
        {
            _codeVerifyRepository.Add(code);
        }

        public Core.Quiz2.CodeVerify.Entities.CodeVerify GetCode()
        {
            return _codeVerifyRepository.GetCode();
        }
    }
}
