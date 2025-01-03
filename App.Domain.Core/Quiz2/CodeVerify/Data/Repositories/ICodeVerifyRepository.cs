using App.Domain.Core.Quiz2.CodeVerify.Entities;

namespace App.Domain.Core.Quiz2.CodeVerify.Data.Repositories
{
    public interface ICodeVerifyRepository
    {
        public void Add(string code);
        public App.Domain.Core.Quiz2.CodeVerify.Entities.CodeVerify GetCode();
    }
}
