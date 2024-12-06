using Newtonsoft.Json;
using Quiz2.Contracts;
using Quiz2.Entities;

namespace Quiz2.Repository
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

                if (!File.Exists(_path))
                    File.Create(_path);

            }
            else
            {
                _path = patch;
            }
            
        }

        public void Add(string code)
        {
            var cd = new CodeVerify()
            {
                Code = code,
                date = DateTime.Now,
            };
            var add = JsonConvert.SerializeObject(cd);
            File.WriteAllText(_path, add);
        }

        public CodeVerify GetCode()
        {
            var data = File.ReadAllText(_path);
            var result = JsonConvert.DeserializeObject<CodeVerify>(data);
            return result;
        }
    }
}
