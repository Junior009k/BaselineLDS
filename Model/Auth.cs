using blogBlazor.Components.Auth.Token;
using Newtonsoft.Json;
using System.Security.Cryptography;
using System.Text;

namespace blogBlazor.Components.DB
{
    public class userModel
    {
        [JsonProperty("id")]
        public int id { get; set; }
        [JsonProperty("name")]
        public string name { get; set; }
        [JsonProperty("username")]
        public string username { get; set; }
        [JsonProperty("password")]
        public string password { get; set; }
    }
    public class Auth
    {
        private string name;
        private string username;
        private string password;

        DBConfiguration myDB = new DBConfiguration();//DB.ConfiguracionInicial();

        public void Register(userModel model)
        {
            try
            {
                myDB.DBOpen();
                myDB.Insert("insert into [dbo].[User]([name],username,[password]) values ('" + model.name + "','" + model.username + "','" + model.password + "')");
                myDB.DBClose();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        public String Authenticate(userModel model)
        {
            List<String> lista = new List<String>();
            JWT jwt= new JWT();
            try
            {
                myDB.DBOpen();
                lista = myDB.Select("SELECT * FROM [user] where username like '"+ model.username + "' and [password] like '"+ model.password +"'", 4);

                myDB.DBClose();
                var json = System.Text.Json.JsonSerializer.Serialize(lista);
                Console.WriteLine(json);

                if (lista.Count > 0) 
                {
                    return jwt.GenerateJSONWebToken(model);
                }
                return "Usuario No Autenticado"; 


            }

            catch (Exception e)
            {
                Console.WriteLine(e.ToString());

                return "Ha fallado la autenticacion";
            }
        }

        public string GetMD5(string str)
        {
            MD5 md5 = MD5CryptoServiceProvider.Create();
            ASCIIEncoding encoding = new ASCIIEncoding();
            byte[] stream = null;
            StringBuilder sb = new StringBuilder();
            stream = md5.ComputeHash(encoding.GetBytes(str));
            for (int i = 0; i < stream.Length; i++) sb.AppendFormat("{0:x2}", stream[i]);
            return sb.ToString();
        }
    }
}
