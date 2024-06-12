using blogBlazor.Components.Auth.Token;
using blogBlazor.Components.DB;
using Newtonsoft.Json;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.Json.Serialization.Metadata;

namespace BaselineLDS.Model
{
    public class Wrapper
    {
        public List<string> Items { get; set; } = new List<string>();
    }
    public class Perfil
    {
        public class perfilyFuctionModel
        {
            [JsonProperty("id")]
            public int id { get; set; }
            [JsonProperty("description")]
            public string description { get; set; }
        }

        public class perfilFuctionModel
        {
            [JsonProperty("id")]
            public int id { get; set; }

            [JsonProperty("id")]
            public int id_Perfil { get; set; }

            [JsonProperty("id")]
            public int id_Function { get; set; }
        }

      

        DBConfiguration myDB = new DBConfiguration();//DB.ConfiguracionInicial();
        public String getPerfil()
        {
            List<String> lista = new List<String>();
            List<perfilyFuctionModel> listObject = new List<perfilyFuctionModel>();
            var  obj=new perfilyFuctionModel();
            JWT jwt = new JWT();
            try
            {
                myDB.DBOpen();
                lista = myDB.Select("SELECT * FROM [User_Perfil]", 2);
                //var wrapper = new Wrapper();
                //var wrapper = new Wrapper { Items = lista };
                myDB.DBClose();
                Console.WriteLine(lista.Count);
                for (int i = 0; i < lista.Count; i=2+i)
                {
                    obj = new perfilyFuctionModel { id= Convert.ToInt32(lista[0]), description = lista[1] };
                    listObject.Add(obj); ;
                }
                var json = System.Text.Json.JsonSerializer.Serialize(listObject);
                Console.WriteLine(json);
                if (lista.Count > 0)
                {
                    return json;
                }
                return "No se han encontrado perfiles";
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());

                return "Ha fallado algo en la base de datos";
            }
        }
    }
}
