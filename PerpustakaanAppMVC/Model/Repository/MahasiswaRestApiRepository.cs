using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using PerpustakaanAppMVC.Model.Entity;
using RestSharp;

namespace PerpustakaanAppMVC.Model.Repository
{
    public class MahasiswaRestApiRepository
    {
        public int Create(Mahasiswa mhs)
        {
            string baseUrl = "http://latihan.coding4ever.net:5555/";
            var endpoint = "api/Mahasiswa";

            var client = new RestClient(baseUrl);

            var request = new RestRequest(endpoint, Method.POST);

            request.AddJsonBody(mhs);

            var response = client.Execute(request);

            var result = response.Content.IndexOf("1") > 0 ? 1 : 0;

            return result;
        }
        public int Update(Mahasiswa mhs)
        {
            string baseUrl = "http://latihan.coding4ever.net:5555/";
            string endpoint = "api/Mahasiswa/" + mhs.Npm;

            var client = new RestClient(baseUrl);
            var request = new RestRequest(endpoint, Method.PUT);
            request.AddJsonBody(mhs);

            var response = client.Execute(request);

            var result = response.Content.IndexOf("0") >= 0 ? 1 : 0;

            return result;
        }
        public int Delete(Mahasiswa mhs)
        {
            string baseUrl = "http://latihan.coding4ever.net:5555/";
            // include npm in the endpoint (assuming API expects DELETE at /api/Mahasiswa/{npm})
            var endpoint = "api/Mahasiswa/" + mhs.Npm;

            var client = new RestClient(baseUrl);

            var request = new RestRequest(endpoint, Method.DELETE);

            var response = client.Execute(request);

            var result = response.Content.IndexOf("1") > 0 ? 1 : 0;

            return result;
        }
        public List<Mahasiswa> ReadAll()
        {
            string baseUrl = "http://latihan.coding4ever.net:5555/";
            string endpoint = "api/Mahasiswa";

            var client = new RestClient(baseUrl);

            var request = new RestRequest(endpoint, Method.GET);

            var response = client.Execute<List<Mahasiswa>>(request);

            return response.Data;
        }
        public List<Mahasiswa> ReadByName(string nama)
        {
            string baseUrl = "http://latihan.coding4ever.net:5555/";
            string endpoint = "api/Mahasiswa?nama=" + nama;

            var client = new RestClient(baseUrl);

            var request = new RestRequest(endpoint, Method.GET);

            var response = client.Execute<List<Mahasiswa>>(request);

            return response.Data;
        }
        public List<Mahasiswa> ReadByNpm(string npm)
        {
            string baseUrl = "http://latihan.coding4ever.net:5555/";
            string endpoint = "api/Mahasiswa?npm=" + npm;

            var client = new RestClient(baseUrl);

            var request = new RestRequest(endpoint, Method.GET);

            var response = client.Execute<List<Mahasiswa>>(request);

            return response != null && response.Data != null ? response.Data : new List<Mahasiswa>();
        }
    }
}
