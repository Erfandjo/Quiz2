using App.Domain.Core.Quiz2.CodeVerify.Data.Repositories;
using Newtonsoft.Json;
using System.IO;



namespace App.Infra.Data.Repos.File.Quiz2.CodeVerify.Repositories
{
    public class CodeVerifyRepository : ICodeVerifyRepository
    {


        private string _path = string.Empty;


        public CodeVerifyRepository(string patch = null)
        {
            if (string.IsNullOrEmpty(patch))
            {
                if (!Directory.Exists("DataBase"))
                    Directory.CreateDirectory("DataBase");

                _path = $"Database/Code.json";

                if (!System.IO.File.Exists(_path))
                    System.IO.File.Create(_path);
          
            }
            else
            {
                _path = patch;
            }

        }

        public void Add(string code)
        {
            var cd = new App.Domain.Core.Quiz2.CodeVerify.Entities.CodeVerify()
            {
                Code = code,
                date = DateTime.Now,
            };
            var add = JsonConvert.SerializeObject(cd);
            System.IO.File.WriteAllText(_path, add);
          
        }

        public App.Domain.Core.Quiz2.CodeVerify.Entities.CodeVerify GetCode()
        {
            var data = System.IO.File.ReadAllText(_path);
            var result = JsonConvert.DeserializeObject<App.Domain.Core.Quiz2.CodeVerify.Entities.CodeVerify>(data);
            return result;
        }

    
    }
}
