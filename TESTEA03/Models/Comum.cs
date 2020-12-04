using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using TESTEAO3.Util;
using System.Data;
namespace TESTEAO3.Models
{
    public class Comum
    {
        public int Id_Uf { get; set; }
        public String SiglaUF { get; set; }
        public String UnidadeUF { get; set; }
        public IHttpContextAccessor HttpContextAccessor { get; set; }
        public Comum()
        {

        }
        //Recebe Contexto para as variaveis de sessão
        public Comum(IHttpContextAccessor httpContextAccessor)
        {
            HttpContextAccessor = httpContextAccessor;
        }

        public List<Comum> ListaUf()
        {
            try
            {
                List<Comum> lista = new List<Comum>();
                Comum item;
                string id_usuario_logado = @HttpContextAccessor.HttpContext.Session.GetString("IdNomeUsuarioLogado");
                string sql = $"SELECT ID_UF,SIGLA,UNIDADE" +
                    $"FROM UNIDADE_FEDERACAO WHERE DELETED='N' ";
                DAL objDAL = new DAL();
                DataTable dt = objDAL.RetDataTable(sql);
                item = new Comum();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    item = new Comum();
                    item.Id_Uf = int.Parse(dt.Rows[i]["ID_UF"].ToString());
                    item.SiglaUF = dt.Rows[i]["SIGLA"].ToString();
                    item.UnidadeUF = dt.Rows[i]["UNIDADE"].ToString();
                    lista.Add(item);
                }
                objDAL.FechaComandoSQL();
                return lista;
            }
            catch
            {
                List<Comum> lista = new List<Comum>();
                return lista;
            }
        }
    }
}
