using MauiAppTest.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MauiAppTest.API
{
    public static class APIService
    {
        public static User testidc = new User();
        public static async void GetUsers()
        {
            var HttpClient = new HttpClient();
            var Response = await HttpClient.GetStringAsync("http://192.168.0.145:7175/api/User");
            var fuckthisshit = JsonConvert.DeserializeObject<User>(Response);
            testidc.Email = fuckthisshit.Email;
        }
        //public async Task<User> GetUsers()
        //{
        //    var HttpClient = new HttpClient();
        //    var Response = await HttpClient.GetStringAsync("http://192.168.0.145:7175/api/User");

        //    return JsonConvert.DeserializeObject<User>(Response);
        //}
    }
}
