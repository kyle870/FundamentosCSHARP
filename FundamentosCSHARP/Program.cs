using FundamentosCSHARP.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace FundamentosCSHARP
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            //Cerveza cerveza = new Cerveza(10);

            //Serialización de JSON a objeto
            /*string mijson = JsonSerializer.Serialize(cerveza);
            File.WriteAllText("Objeto.txt", mijson);*/

            //Desserialziación de objeto a JSON

            /* string miJson = File.ReadAllText("Objeto.txt");
             Cerveza cerveza1 = JsonSerializer.Deserialize<Cerveza>(miJson);*/

            //HTTP GET
            //string url = "https://jsonplaceholder.typicode.com/posts";

            /*HttpClient client = new HttpClient();

            var httpResponse = await client.GetAsync(url);

            if (httpResponse.IsSuccessStatusCode)
            {
                var content = await httpResponse.Content.ReadAsStringAsync();
                var posts = JsonSerializer.Deserialize<List<Models.Post>>(content);
            }*/

            //HTTP POST
            string url = "https://jsonplaceholder.typicode.com/posts/99";
            var client = new HttpClient();

            Post post = new Post()
            {
                userId = 50,
                body = "Hola como van",
                title = "Titulo del saludo"
            };

            var data = JsonSerializer.Serialize<Post>(post);
            HttpContent content = new StringContent(data, System.Text.Encoding.UTF8, "application/json");

            //hacer solicitud POST
            var httpResponse = await client.PostAsync(url, content);

            if (httpResponse.IsSuccessStatusCode)
            {
                var result = await httpResponse.Content.ReadAsStringAsync();

                var postResult = JsonSerializer.Deserialize<Post>(result);
            }
        }    
    }
}
