using Newtonsoft.Json;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SideBarDemo.Models
{
    public class UserManager
    {
        public async static Task<object> GetAllUsers()
        {
            var http = new HttpClient();
            var response = await http.GetAsync("https://jsonplaceholder.typicode.com/users");
            var result = await response.Content.ReadAsStringAsync();
  
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                Debug.WriteLine("Success !!!");
                List<User> Users = JsonConvert.DeserializeObject<List<User>>(result);
                return Users;
            }
            else
            {
                Debug.WriteLine("Not Success !!!");
                return result;
            }
        }
    }

    public class Geo
    {
        [JsonProperty("lat")]
        public string Lat;

        [JsonProperty("lng")]
        public string Lng;
    }

    public class Address
    {
        [JsonProperty("street")]
        public string Street;

        [JsonProperty("suite")]
        public string Suite;

        [JsonProperty("city")]
        public string City;

        [JsonProperty("zipcode")]
        public string Zipcode;

        [JsonProperty("geo")]
        public Geo Geo;
    }

    public class Company
    {
        [JsonProperty("name")]
        public string Name;

        [JsonProperty("catchPhrase")]
        public string CatchPhrase;

        [JsonProperty("bs")]
        public string Bs;
    }

    public class User
    {
        [JsonProperty("id")]
        public int Id;

        [JsonProperty("name")]
        public string Name;

        [JsonProperty("username")]
        public string Username;

        [JsonProperty("email")]
        public string Email;

        [JsonProperty("address")]
        public Address Address;

        [JsonProperty("phone")]
        public string Phone;

        [JsonProperty("website")]
        public string Website;

        [JsonProperty("company")]
        public Company Company;
    }
}