using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using cloudscribe.Web.Pagination;



namespace TESTEAO3.Models
{
    public class Paginacao
    {
        public Paginacao()
        {
            Paging = new PaginationSettings();
        }
        public string Query { get; set; } = string.Empty; //só use se for implementar um grid com pesquisa, se não não precisa estar no modelo

        //public List<Product> Products { get; set; } = null; //não precisa neste exemplo
        //public List<Consultores> ListaConsultores { get; set; } = null; //não precisa neste exemplo

        public PaginationSettings Paging { get; set; }


    }
}