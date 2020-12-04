using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using TESTEAO3.Util;
using cloudscribe.Web.Pagination;
using System.Data;
using System.Net;
using System.IO;

namespace TESTEAO3.Models
{
    public class Marcas
    {
        public string name { get; set; }
        public string fipe_name { get; set; }
        public int order { get; set; }
        public string key { get; set; }
        public int id { get; set; }
        public IHttpContextAccessor HttpContextAccessor { get; set; }


        public Marcas(IHttpContextAccessor httpContextAccessor)
        {

        }
        public List<Marcas> Listamarcas()
        {
            try
            {
                var requisicaoWeb = WebRequest.CreateHttp("http://fipeapi.appspot.com/api/1/carros/marcas.json");
                requisicaoWeb.Method = "GET";
                requisicaoWeb.UserAgent = "RequisicaoWebDemo";
                using (var resposta = requisicaoWeb.GetResponse())
                {
                    var streamDados = resposta.GetResponseStream();
                    StreamReader reader = new StreamReader(streamDados);
                    object objResponse = reader.ReadToEnd();
                    //=======================//
                    // MARCA                 //
                    //=======================//
                    var post = Newtonsoft.Json.JsonConvert.DeserializeObject<IEnumerable<Marcas>>(objResponse.ToString());
                    List<Marcas> lista = post.ToList();
                    return lista;
                }
            }
            catch
            {
                List<Marcas> lista = new List<Marcas>();
                return lista;
            }
        }
    }
}
