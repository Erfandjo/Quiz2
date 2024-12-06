
using Quiz2.Entities;

namespace Quiz2.Contracts
{
    public interface ICodeVerifyRepository
    {
        public void Add(string code);
        public CodeVerify GetCode();
    }
}
