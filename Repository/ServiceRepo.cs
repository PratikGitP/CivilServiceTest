using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Web;

using WebApplication1.Class;

namespace WebApplication1.Repository
{
    public class ServiceRepo
    {
        public IEnumerable<User> GetUsersByCity(string city)
        {
            string url = $"{ConfigurationManager.AppSettings["dpdtsTestUrl"]}/city/{city}/users";
            var users = GetData<IEnumerable<User>>(url);
            return users;
        }

        public IEnumerable<User> GetUsers()
        {
            string url = $"{ConfigurationManager.AppSettings["dpdtsTestUrl"]}/users";
            var allUsers = GetData<IEnumerable<User>>(url);
            return allUsers;
        }

        private T GetData<T>(string requestUri)
        {
            T returnT;
            using (HttpClient httpClient = new HttpClient())
            using (HttpRequestMessage reqMsg = new HttpRequestMessage(HttpMethod.Get, requestUri))
            {
                using (HttpResponseMessage response = httpClient.SendAsync(reqMsg).Result)
                {
                    if (response.IsSuccessStatusCode)
                    {
                        returnT = response.Content.ReadAsAsync<T>().Result;
                    }
                    else
                    {
                        Exception ex = new Exception(response.StatusCode.ToString());
                        //Log Exception;
                        throw ex;
                    }
                }
            }
            return returnT;
        }
        
    }
}