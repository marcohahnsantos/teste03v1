using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PagedList;
using PagedList.Core.Mvc;
using cloudscribe.Web.Pagination;
using TESTEAO3.Models;
using System.ComponentModel.DataAnnotations;
using TESTEAO3.Util;
using System.Net.Http;
using TESTEAO3.Models;
using System.Net;
using System.IO;
using Newtonsoft.Json;

namespace TESTEAO3.Controllers
{
    public class CadastroController : Controller
    {
        IHttpContextAccessor HttpContextAccessor;
        private const int DefaultPageSize = 8;
        static HttpClient client = new HttpClient();

        public CadastroController(IHttpContextAccessor httpContextAccessor)
        {
            HttpContextAccessor = httpContextAccessor;
        }
        public IActionResult IndexVeiculos()
        {
            Cadastro objConta = new Cadastro(HttpContextAccessor);
            ViewBag.ListaCadastro = objConta.ListVeiculos();
            return View();
        }

        public IActionResult IndexEmpresa()
        {
            Cadastro objConta = new Cadastro(HttpContextAccessor);
            ViewBag.ListaCadastro = objConta.ListaEmpresas();
            return View();
        }
        
        public IActionResult MenuCadastro()
        {
            return View();
        }
        public IActionResult RegistrarVeiculo(int? id, int? Marca)
        {
            Marcas objMarcas = new Marcas(HttpContextAccessor);
            Modelos objModelos = new Modelos(HttpContextAccessor);
            if (id != null)
            {
                Cadastro objTransacao = new Cadastro(HttpContextAccessor);
                ViewBag.Registro = objTransacao.CarregaRegistroVeiculo(id);
                ViewBag.ListaModelos = objModelos.Listamodelos($"{Validacoes.IdMarcaVeiculo}.json");
                ViewBag.Editar = "SIM";
            }
            ViewBag.ListaVeiculos = objMarcas.Listamarcas();
            if (id == null)
            {
                if (Marca != null)
                {
                    ViewBag.ListaModelos = objModelos.Listamodelos($"{Marca}.json");
                }
                else
                {
                    ViewBag.ListaModelos = objModelos.Listamodelos("6.json");
                }
            }

            return View();
        }
        public IActionResult RegistrarMarca(string id)
        {
            Modelos objModelos = new Modelos(HttpContextAccessor);
            int posicaoFim = id.IndexOf("-");
            
            
            Validacoes.IdMarcaModelo = int.Parse(id.Substring(0, posicaoFim - 1));
            Validacoes.MarcaVeiculo = id.Substring(posicaoFim+2);
          
            
            int nomearquivo =Convert.ToInt32(id.ToString().Substring(0, posicaoFim-1));
            
            ViewBag.ListaModelos = objModelos.Listamodelos($"{nomearquivo}.json");
            return RedirectToAction("RegistrarVeiculo",new { Marca = nomearquivo});

        }


        public IActionResult RegistrarEmpresa(int ? id)
        {
            Cadastro objUf = new Cadastro(HttpContextAccessor);
            if (id != null)
            {
                Cadastro objTransacao = new Cadastro(HttpContextAccessor);
                ViewBag.Registro = objTransacao.CarregaRegistroEmpresa(id);
                ViewBag.Editar = "SIM";
            }

            ViewBag.ListaUf = objUf.ListaUf();
            return View();
        }
        public IActionResult Registrar(Cadastro formulario)
        {
            formulario.HttpContextAccessor = HttpContextAccessor;
            formulario.Insert();
            Validacoes.MarcaModelo = "";
            Validacoes.MarcaVeiculo = "";
            return RedirectToAction("IndexVeiculos");
            
        }
       
        [HttpGet]
       
        public IActionResult ExcluirVeiculo(int Id)
        {
            Cadastro objTransacao = new Cadastro(HttpContextAccessor);
            objTransacao.Excluir(Id);
            return RedirectToAction("IndexVeiculos");
        }
      

        [HttpGet]
        public IActionResult ExcluirRegistroVeiculo(int? Id)
        {
            Cadastro objTransacao = new Cadastro(HttpContextAccessor);
            ViewBag.Registro = objTransacao.CarregaRegistroVeiculo(Id);
            return View();
        }
        
    }
}