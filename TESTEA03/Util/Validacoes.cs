using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using cloudscribe.Web.Pagination;
using TESTEAO3.Models; 


namespace TESTEAO3.Util
{
    


    public class Validacoes
    {
        protected static string codigo_Abate;
        public static string Codigo_Abate
        {
            get { return codigo_Abate; }
            set { codigo_Abate = value; }
        }
        protected static int idmarcaVeiculo;
        public static int IdMarcaVeiculo
        {
            get { return idmarcaVeiculo; }
            set { idmarcaVeiculo = value; }
        }

        protected static string marcaVeiculo;
        public static string MarcaVeiculo
        {
            get { return marcaVeiculo; }
            set { marcaVeiculo = value; }
        }
        protected static int idmarcaModelo;
        public static int IdMarcaModelo
        {
            get { return idmarcaModelo; }
            set { idmarcaModelo = value; }
        }

        protected static string marcaModelo;
        public static string MarcaModelo
        {
            get { return marcaModelo; }
            set { marcaModelo = value; }
        }

        protected static string status;
        public static string Status
        {
            get { return status; }
            set { status = value; }
        }

        protected static string excliur_Transacao;
        public static string Excliur_Transacao
        {
            get { return excliur_Transacao; }
            set { excliur_Transacao = value; }
        }

        protected static Cadastro formulario;
        public static Cadastro Formulario
        {
            get { return formulario; }
            set { formulario = value; }
        }
        protected static string tipo_bancoDados;
        public static string Tipo_BancoDados
        {
            get { return tipo_bancoDados; }
            set { tipo_bancoDados = value; }
        }

        protected static string campoPesquisa;
        public static string CampoPesquisa
        {
            get { return campoPesquisa; }
            set { campoPesquisa = value; }
        }

        protected static string tabelaPesquisa;
        public static string TabelaPesquisa
        {
            get { return tabelaPesquisa; }
            set { tabelaPesquisa = value; }
        }
        protected static string campoOrdem;
        public static string CampoOrdem
        {
            get { return campoOrdem; }
            set { campoOrdem = value; }
        }


        protected static string nome_servidor;
        public static string Nome_Servidor
        {
            get { return nome_servidor; }
            set { nome_servidor = value; }
        }

        protected static string nome_bancoDados;
        public static string Nome_BancoDados
        {
            get { return nome_bancoDados; }
            set { nome_bancoDados = value; }
        }


        protected static DateTime data_Ini;
        public static DateTime Data_Ini
        {
            get { return data_Ini; }
            set { data_Ini = value; }
        }
        protected static DateTime data_Fim;
        public static DateTime Data_Fim
        {
            get { return data_Fim; }
            set { data_Fim = value; }
        }
        protected static string tipo_RD;
        public static string Tipo_RD
        {
            get { return tipo_RD; }
            set { tipo_RD = value; }
        }
        protected static int id_Conta;
        public static int Id_Conta
        {
            get { return id_Conta; }
            set { id_Conta = value; }
        }
        protected static int id_Plano_Conta;
        public static int Id_Plano_Conta
        {
            get { return id_Plano_Conta; }
            set { id_Plano_Conta = value; }
        }
        protected static string pesquisar;
        public static string Pesquisar
        {
            get { return pesquisar; }
            set { pesquisar = value; }
        }
        protected static int page;
        public static int Page
        {
            get { return page; }
            set { page = value; }
        }
      
        protected static string erroPagina;
        public static string ErroPagina
        {
            get { return erroPagina; }
            set { erroPagina = value; }
        }
    }


}
