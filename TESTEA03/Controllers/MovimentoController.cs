using System;
using System.IO;
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
using Rotativa.AspNetCore;

namespace TESTEAO3.Controllers
{
    public class MovimentoController : Controller
    {
        private IHttpContextAccessor httpContextAccessor;
        IHttpContextAccessor HttpContextAccessor;
        private const int DefaultPageSize = 5;

        public object MessageBox1 { get; private set; }

        public MovimentoController(IHttpContextAccessor httpContextAccessor)
        {
            HttpContextAccessor = httpContextAccessor;
        }
      
        [HttpPost]
        public IActionResult VerMovimento(int? page, Cadastro formulario)
        {
            Validacoes.Pesquisar = "Sim";
            Validacoes.Page = Convert.ToInt16(page);
            Validacoes.Formulario = formulario;
            Validacoes.Data_Ini = DateTime.Parse(formulario.Data_Ini.ToString());
            Validacoes.Data_Fim = DateTime.Parse(formulario.Data_Fim.ToString());
            Validacoes.Excliur_Transacao = "S";
            return RedirectToAction("IndexMovimento");
        }
        public IActionResult RegistrarMovimento(int? id)
        {
            MovimentoModel objMovimento = new MovimentoModel(HttpContextAccessor);
            ViewBag.Registro = objMovimento.ListaMovimentoUnico((int)id);
            return View(); 
        }
        public IActionResult Liberar(int id, MovimentoModel formulario)
        {

            var status=formulario.selectStatus((int)id);
            if (status.SATUS_LOCACAO=="LOCADO")
            {
               
            }

            return RedirectToAction("IndexMovimento");

        }
            public IActionResult Registrar(int? id,
                                       string Cpf,
                                       string Nome,
                                       string DataLocacao,
                                       string DataIni,
                                       string DataFim,
                                       string Status,
                                       MovimentoModel formulario)
        {

            if (Status == "LOCADO")
            {
                return RedirectToAction("Alerta");
            }

            formulario.HttpContextAccessor = HttpContextAccessor;
            formulario.Insert((int)id, formulario);
            Validacoes.MarcaModelo = "";
            Validacoes.MarcaVeiculo = "";

            return View();
        }
        public IActionResult Alerta()
        {

            return View();
        }

      
        public IActionResult IndexMovimento(int? page, Cadastro formulario,
         String Pesquisar)
        {
            MovimentoModel objMovimento = new MovimentoModel(HttpContextAccessor);

            
            
            int LimitPage = 0;
            if (page == null && Validacoes.Excliur_Transacao != "S")
            {
                Validacoes.Data_Ini = DateTime.Parse("01/" +
                            "01/" +
                            System.DateTime.Now.Year.ToString());
                Validacoes.Data_Fim = DateTime.Parse(System.DateTime.Now.ToString().Substring(0, 10));
            }


            if (Validacoes.Pesquisar == "Sim")
            {
                if (page!=null)
                 Validacoes.Page = int.Parse(page.ToString());

                formulario = Validacoes.Formulario;
            }



            if (page == null || Validacoes.Pesquisar == "Sim")
            {
                page = 1;
                LimitPage = 0;
                if (Validacoes.Excliur_Transacao == "S")
                {
                    Validacoes.Excliur_Transacao = "N";
                }
                else
                {
                    if (formulario.Data_Ini != null)
                    {
                        Validacoes.Data_Ini = DateTime.Parse(formulario.Data_Ini.ToString());
                    }
                    if (formulario.Data_Fim != null)
                    {
                        Validacoes.Data_Fim = DateTime.Parse(formulario.Data_Fim.ToString());
                    }
                }
                if (formulario == null)
                {
                    formulario = Validacoes.Formulario;
                }
                LimitPage = Convert.ToInt32(Validacoes.Page) * 5;



            }
            else
            {
                LimitPage = Convert.ToInt32(page) * 5;
                if (Validacoes.Excliur_Transacao == "S")
                {
                    Validacoes.Excliur_Transacao = "N";
                }
                else
                {
                    if (formulario.Data_Ini != null)
                    {
                        Validacoes.Data_Ini = DateTime.Parse(formulario.Data_Ini.ToString());
                    }
                    if (formulario.Data_Fim != null)
                    {
                        Validacoes.Data_Fim = DateTime.Parse(formulario.Data_Fim.ToString());
                    }
                }
                //if (formulario.Conta_Id == 0)
                //{
                //    Validacoes.Id_Conta = formulario.Conta_Id;
                //}
                //if (formulario.Plano_Conta_Id == 0)
                //{
                //    Validacoes.Id_Plano_Conta = formulario.Plano_Conta_Id;
                //}

            }
            LimitPage = Convert.ToInt32(Validacoes.Page) * 5;
           
            ViewBag.ListaAMovimento = objMovimento.ListaMovimento(LimitPage.ToString());

            Validacoes.TabelaPesquisa = "MOVIMENTACAO_LOCADORA";
            Validacoes.CampoPesquisa = "ID";
            Validacoes.CampoOrdem = "ID";
            var model = new Paginacao();
            var TotalDeRegistros = formulario.TotalRegistros
                (
                LimitPage,
                Validacoes.Data_Ini,
                Validacoes.Data_Fim,
                Validacoes.TabelaPesquisa,
                Validacoes.CampoPesquisa,
                Validacoes.CampoOrdem);

            model.Paging.CurrentPage = long.Parse(page.ToString());
            model.Paging.ItemsPerPage = DefaultPageSize;
            model.Paging.TotalItems = long.Parse(TotalDeRegistros.Total.ToString());

            ViewBag.Data1 = Validacoes.Data_Ini;
            ViewBag.Data2 = Validacoes.Data_Fim;

            ViewBag.CurrentPage = Validacoes.Page;
            ViewBag.ItemsPerPage = DefaultPageSize;
            ViewBag.TotalItems = long.Parse(TotalDeRegistros.Total.ToString());
            ViewBag.PageSize = DefaultPageSize;
            ViewBag.PageNumber = page;
            ViewBag.PageSize = DefaultPageSize;
            ViewBag.PageNumber = page;
            return View();
        }
        [HttpPost]
        public IActionResult GerarPdf(MovimentoModel formulario)
        {
            formulario.HttpContextAccessor = HttpContextAccessor;
            //ViewBag.ListaMapaFinanceiro = formulario.ListaMovimentacaoAbate();

            //ViewBag.ListaContas = new ContaModel(HttpContextAccpublic IActionResult VisualizarComoPDF()
            return new ViewAsPdf("VisualizarComoPDF");

        }
        
    }
}