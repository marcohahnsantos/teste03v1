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
    public class Modelos
    {
        public string fipe_marca { get; set; }
        public string name { get; set; }
        public string marca { get; set; }
        public string key { get; set; }
        public int id { get; set; }
        public string fipe_name { get; set; }
        public IHttpContextAccessor HttpContextAccessor { get; set; }


        public Modelos(IHttpContextAccessor httpContextAccessor)
        {

        }
        public List<Modelos> Listamodelos(string Modelo)
        {
            try
            {
                string path = "http://fipeapi.appspot.com/api/1/carros/veiculos/"+Modelo;
                var requisicaoWeb = WebRequest.CreateHttp(path);
                requisicaoWeb.Method = "GET";
                requisicaoWeb.UserAgent = "RequisicaoWeb";
                using (var resposta = requisicaoWeb.GetResponse())
                {
                    var streamDados = resposta.GetResponseStream();
                    StreamReader reader = new StreamReader(streamDados);
                    object objResponse = reader.ReadToEnd();
                    //=======================//
                    // MARCA                 //
                    //=======================//
                    var post = Newtonsoft.Json.JsonConvert.DeserializeObject<IEnumerable<Modelos>>(objResponse.ToString());
                    List<Modelos> lista = post.ToList();
                    return lista;
                }
            }
            catch
            {
                List<Modelos> lista = new List<Modelos>();
                return lista;
            }
        }
    }
}
