using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Quiz2.CodeVerify.Services
{
    public interface ICodeVerifyService
    {
        public void Add(string code);
        public App.Domain.Core.Quiz2.CodeVerify.Entities.CodeVerify GetCode();
    }
}
