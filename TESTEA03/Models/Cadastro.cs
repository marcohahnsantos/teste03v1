using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using TESTEAO3.Util;
using cloudscribe.Web.Pagination;
using System.Data;

namespace TESTEAO3.Models
{
    public class Cadastro
    {
        public int Id { get; set; }
        public String Modelo { get; set; }
        public String Marca { get; set; }
        public String Placa { get; set; }
        public String AnoModelo { get; set; }
        public String AnoFabricacao { get; set; }

        public int Total { get; set; }
        public String CpfCnpj { get; set; }
        public String Cpf { get; set; }
        public String Ie { get; set; }
        public String Descricao { get; set; }
        public String Endereco { get; set; }
        public String Bairro { get; set; }
        public String Cidade { get; set; }
        public String Uf { get; set; }
        public String Cep { get; set; }
        public String Contato { get; set; }
        [EmailAddress(ErrorMessage = "o e-mail informado é Inválido!")]
        public String EmailContato { get; set; }
        public String FoneContato { get; set; }
        public String CelularContato { get; set; }
        public String Data { get; set; }
        public String Usuario_Logado { get; set; }
        public int Id_Uf { get; set; }
        public int ID_MRCA { get; set; }
        public String SiglaUF { get; set; }
        public String UnidadeUF { get; set; }
        public String CampoPesquisa { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}", ApplyFormatInEditMode = true)]
        public string Data_Ini { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}", ApplyFormatInEditMode = true)]
        public string Data_Fim { get; set; }
        public IHttpContextAccessor HttpContextAccessor { get; set; }



        public Cadastro()
        {

        }
        public Cadastro TotalRegistros(
           int Limite,
           DateTime DataIni,
           DateTime DataFim,
           string Tabela,
           string Campo,
           string CampoOrdem)
        {

            try
            {
                Cadastro item;
                // string id_usuario_logado = @HttpContextAccessor.HttpContext.Session.GetString("IdNomeUsuarioLogado");
                
                string filtro = "";
                //if (Limite >= 20)
                //{
                //    filtro += $" WHERE NOT T.{Campo} in(SELECT TOP {Limite - 10} T.{Campo} FROM " +
                //              $" {Tabela} AS T " +
                //              $" ORDER BY T.{CampoOrdem} DESC ) ";
                //}
                //else
                //{
                //    filtro += $" WHERE NOT T.{Campo} in(SELECT TOP {Limite} T.ID FROM {Tabela} AS T " +
                //              $" ORDER BY T.{CampoOrdem} DESC ) ";
                //}


                //if (DataIni!=null && DataFim!=null)
                //{
                //    filtro += $" AND T.DATA_CAD >= ''{DataFim.ToString("yyyy/MM/dd")}'" +
                //              $" AND T.DATA_CAD <='{DataFim.ToString("yyyy/MM/dd")}' ";
                //}
                if ((DataIni != null && DataFim != null))
                {
                    //  filtro += $" AND T.DATA BETWEEN '{DataIni.ToString("yyyy/MM/dd")}' AND '{DataFim.ToString("yyyy/MM/dd")}' ";

                    filtro += $"  WHERE DATA_ABATE BETWEEN '{DataIni.ToString("dd/MM/yyyy")}' AND '{DataFim.ToString("dd/MM/yyyy")}' ";

                }


                string sql = $"SELECT COUNT(T.{Campo}) AS TOTAL " +
                    $"  FROM {Tabela}  AS T " +
                    $" {filtro}";
                DAL objDAL = new DAL();
                DataTable dt = objDAL.RetDataTable(sql);
                item = new Cadastro();
                item.Total = int.Parse(dt.Rows[0]["TOTAL"].ToString());
                return item;
            }
            catch (Exception error)
            {
                Cadastro item;
                item = new Cadastro();
                Validacoes.ErroPagina = "SIM";
                return item;
            }
        }

        public List<Cadastro> ListVeiculos()
        {
            try
            {
                List<Cadastro> lista = new List<Cadastro>();
                Cadastro item;

                string id_usuario_logado = @HttpContextAccessor.HttpContext.Session.GetString("IdNomeUsuarioLogado");
                string sql = $"SELECT ID,MODELO,MARCA,PLACA,ANO_MODELO,ANO_FABRICACAO " +
                             $"FROM VEICULOS ";
                DAL objDAL = new DAL();
                DataTable dt = objDAL.RetDataTable(sql);

                item = new Cadastro();



                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    item = new Cadastro();
                    item.Id = int.Parse(dt.Rows[i]["ID"].ToString());
                    item.Modelo = dt.Rows[i]["MODELO"].ToString();
                    item.Marca = dt.Rows[i]["MARCA"].ToString();
                    item.Placa = dt.Rows[i]["PLACA"].ToString();
                    item.AnoModelo = dt.Rows[i]["ANO_MODELO"].ToString();
                    item.AnoFabricacao = dt.Rows[i]["ANO_FABRICACAO"].ToString();
                    lista.Add(item);
                }
                objDAL.FechaComandoSQL();
                return lista;
            }
            catch
            {
                List<Cadastro> lista = new List<Cadastro>();
                return lista;
            }
        }
        public List<Cadastro> ListaFornecedores(string Limite)
        {
            try
            {

                List<Cadastro> lista = new List<Cadastro>();
                Cadastro item;

                //Utilizado pela View Extrato
                string filtro = "";
                if (int.Parse(Limite) >= 20)
                {
                    filtro += $" WHERE DELETED='N' AND " +
                              $" NOT T.ID in(SELECT TOP {int.Parse(Limite)} " +
                              $" T.ID FROM FORNECEDORES AS T " +
                              $" ORDER BY T.ID DESC ) ";
                }
                else
                {
                    filtro += $" WHERE DELETED='N' AND NOT T.ID in(SELECT TOP {Limite} " +
                              $" T.ID FROM FORNECEDORES AS T " +
                              $" ORDER BY T.ID DESC ) ";
                }

                
                string sql = $"SELECT TOP 10 T.ID,T.DATA_CAD,T.CNPJ_CPF,T.INSTEST,T.NOME, " +
                             $"T.ENDERECO,T.CIDADE,T.BAIRRO,T.ESTADO,T.CONTATO," +
                             $"T.EMAIL,T.FONE,T.CPF,T.CEP " +
                             $" FROM FORNECEDORES  AS T  " +
                             $" {filtro}" +
                             $" ORDER BY T.ID DESC ";
                DAL objDAL = new DAL();
                DataTable dt = objDAL.RetDataTable(sql);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    item = new Cadastro();
                    item.Id = int.Parse(dt.Rows[i]["ID"].ToString());
                    item.CpfCnpj = dt.Rows[i]["CNPJ_CPF"].ToString();
                    item.Ie = dt.Rows[i]["INSTEST"].ToString();
                    item.Descricao = dt.Rows[i]["NOME"].ToString();
                    item.Endereco = dt.Rows[i]["ENDERECO"].ToString();
                    item.Bairro = dt.Rows[i]["BAIRRO"].ToString();
                    item.Cidade = dt.Rows[i]["CIDADE"].ToString();
                    item.Uf = dt.Rows[i]["ESTADO"].ToString();
                    item.Cep = dt.Rows[i]["CEP"].ToString();
                    item.Contato = dt.Rows[i]["CONTATO"].ToString();
                    item.EmailContato = dt.Rows[i]["EMAIL"].ToString();
                    item.FoneContato = dt.Rows[i]["FONE"].ToString();
                    lista.Add(item);
                }
                objDAL.FechaComandoSQL();
                return lista;
            }
            catch (Exception error)
            {
                List<Cadastro> lista = new List<Cadastro>();
                Validacoes.ErroPagina = "SIM";
                return lista;
            }
        }
        //Recebe Contexto para as variaveis de sessão
        public Cadastro(IHttpContextAccessor httpContextAccessor)
        {
            HttpContextAccessor = httpContextAccessor;
        }
        public List<Cadastro> ListaUf()
        {
            try
            {
                List<Cadastro> lista = new List<Cadastro>();
                Cadastro item;
                string id_usuario_logado = @HttpContextAccessor.HttpContext.Session.GetString("IdNomeUsuarioLogado");
                string sql = $"SELECT ID_UF,SIGLA,UNIDADE" +
                    $" FROM UNIDADE_FEDERACAO WHERE DELETED='N' ";
                DAL objDAL = new DAL();
                DataTable dt = objDAL.RetDataTable(sql);
                item = new Cadastro();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    item = new Cadastro();
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
                List<Cadastro> lista = new List<Cadastro>();
                return lista;
            }
        }
        public List<Cadastro> ListaEmpresas()
        {
            try
            {
                List<Cadastro> lista = new List<Cadastro>();
                Cadastro item;

                string id_usuario_logado = @HttpContextAccessor.HttpContext.Session.GetString("IdNomeUsuarioLogado");
                string sql = $"SELECT ID,MODELO,MARCA,PLACA,ANO_MODELO,ANO_FABRRICACAO "+  
                             $"FROM EMPRESAS WHERE DELETED='N' ";
                DAL objDAL = new DAL();
                DataTable dt = objDAL.RetDataTable(sql);

                item = new Cadastro();
               


                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    item = new Cadastro();
                    item.Id = int.Parse(dt.Rows[i]["ID"].ToString());
                    item.CpfCnpj = dt.Rows[i]["CNPJ"].ToString();
                    item.Ie = dt.Rows[i]["IE"].ToString();
                    item.Descricao = dt.Rows[i]["DESCRICAO"].ToString();
                    item.Endereco = dt.Rows[i]["ENDERECO"].ToString();
                    item.Cidade = dt.Rows[i]["CIDADE"].ToString();
                    item.Uf = dt.Rows[i]["UF"].ToString();
                    item.Contato = dt.Rows[i]["CONTATO"].ToString();
                    item.EmailContato = dt.Rows[i]["EMAIL_CONTATO"].ToString();
                    item.FoneContato = dt.Rows[i]["FONE_CONTATO"].ToString();
                    item.CelularContato = dt.Rows[i]["CELULAR_CONTATO"].ToString();
                    lista.Add(item);
                }
                objDAL.FechaComandoSQL();
                return lista;
            }
            catch
            {
                List<Cadastro> lista = new List<Cadastro>();
                return lista;
            }
        }
        public List<Cadastro> ListaProdutor()
        {
            try
            {
                List<Cadastro> lista = new List<Cadastro>();
                Cadastro item;
                string id_usuario_logado = @HttpContextAccessor.HttpContext.Session.GetString("IdNomeUsuarioLogado");
                string sql = $"SELECT ID,CNPJ_CPF,INSTEST,NOME,ENDERECO," +
                    $"BAIRRO,CIDADE,ESTADO,CONTATO,EMAIL,FONE,CEP " +
                    $"FROM FORNECEDORES WHERE DELETED='N' ";
                DAL objDAL = new DAL();
                DataTable dt = objDAL.RetDataTable(sql);
                item = new Cadastro();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    item = new Cadastro();
                    item.Id = int.Parse(dt.Rows[i]["ID"].ToString());
                    item.CpfCnpj = dt.Rows[i]["CNPJ_CPF"].ToString();
                    item.Ie = dt.Rows[i]["INSTEST"].ToString();
                    item.Descricao = dt.Rows[i]["NOME"].ToString();
                    item.Endereco = dt.Rows[i]["ENDERECO"].ToString();
                    item.Bairro= dt.Rows[i]["BAIRRO"].ToString();
                    item.Cidade = dt.Rows[i]["CIDADE"].ToString();
                    item.Uf = dt.Rows[i]["ESTADO"].ToString();
                    item.Cep= dt.Rows[i]["CEP"].ToString();
                    item.Contato = dt.Rows[i]["CONTATO"].ToString();
                    item.EmailContato = dt.Rows[i]["EMAIL"].ToString();
                    item.FoneContato = dt.Rows[i]["FONE"].ToString();
                    lista.Add(item);
                }
                objDAL.FechaComandoSQL();
                return lista;
            }
            catch
            {
                List<Cadastro> lista = new List<Cadastro>();
                return lista;
            }
        }

        public Cadastro CarregaRegistroVeiculo(int? id)
        {
            try
            {
                Cadastro item = new Cadastro();
                string id_usuario_logado = @HttpContextAccessor.HttpContext.Session.GetString("IdNomeUsuarioLogado");
                string sql = $"SELECT ID,MODELO,MARCA,PLACA,ANO_MODELO,ANO_FABRICACAO,ID_MARCA " +
                             $"FROM VEICULOS WHERE ID={id}";
                DAL objDAL = new DAL();
                DataTable dt = objDAL.RetDataTable(sql);

                item.Id = int.Parse(dt.Rows[0]["ID"].ToString());
                item.Modelo = dt.Rows[0]["MODELO"].ToString();
                item.Marca = dt.Rows[0]["MARCA"].ToString();
                item.Placa = dt.Rows[0]["PLACA"].ToString();
                item.AnoModelo = dt.Rows[0]["ANO_MODELO"].ToString();
                item.AnoFabricacao = dt.Rows[0]["ANO_FABRICACAO"].ToString();
                item.ID_MRCA= int.Parse(dt.Rows[0]["ID_MARCA"].ToString());
                Validacoes.IdMarcaVeiculo = item.ID_MRCA;
                Validacoes.MarcaVeiculo = item.Marca;
                Validacoes.Id_Conta = item.Id;
                objDAL.FechaComandoSQL();
                return item;
            }
            catch
            {
                Cadastro item = new Cadastro();
                return item;
            }
        }

        public Cadastro CarregaRegistroEmpresa(int? id)
        {
            try
            {
                Cadastro item = new Cadastro();
                string id_usuario_logado = @HttpContextAccessor.HttpContext.Session.GetString("IdNomeUsuarioLogado");
                string sql = $"SELECT ID,CNPJ,IE,DESCRICAO,ENDERECO,CIDADE," +
                             $" UF,CONTATO,EMAIL_CONTATO,FONE_CONTATO,CELULAR_CONTATO,DATA_CAD " +
                             $"FROM EMPRESAS WHERE ID={id}";
                DAL objDAL = new DAL();
                DataTable dt = objDAL.RetDataTable(sql);

                item.Id = int.Parse(dt.Rows[0]["ID"].ToString());
                item.CpfCnpj = dt.Rows[0]["CNPJ"].ToString();
                item.Ie = dt.Rows[0]["IE"].ToString();
                item.Descricao = dt.Rows[0]["DESCRICAO"].ToString();
                item.Endereco = dt.Rows[0]["ENDERECO"].ToString();
                item.Cidade = dt.Rows[0]["CIDADE"].ToString();
                item.Uf = dt.Rows[0]["UF"].ToString();
                item.Contato = dt.Rows[0]["CONTATO"].ToString();
                item.EmailContato = dt.Rows[0]["EMAIL_CONTATO"].ToString();
                item.FoneContato = dt.Rows[0]["FONE_CONTATO"].ToString();
                item.CelularContato = dt.Rows[0]["CELULAR_CONTATO"].ToString();
                item.Data= dt.Rows[0]["DATA_CAD"].ToString();
                objDAL.FechaComandoSQL();
                return item;
            }
            catch
            {
                Cadastro item = new Cadastro();
                return item;
            }
        }

        public Cadastro CarregaRegistroProdutor(int? id)
        {
            try
            {
                Cadastro item = new Cadastro();
                string id_usuario_logado = @HttpContextAccessor.HttpContext.Session.GetString("IdNomeUsuarioLogado");
                string sql = $"SELECT ID,CNPJ_CPF,INSTEST,NOME,ENDERECO," +
                   $"BAIRRO,CIDADE,ESTADO,CONTATO,EMAIL,FONE,CEP,CPF,DATA_CAD " +
                   $"FROM FORNECEDORES WHERE ID={id}";
                DAL objDAL = new DAL();
                DataTable dt = objDAL.RetDataTable(sql);

                item.Id = int.Parse(dt.Rows[0]["ID"].ToString());
                item.Data =dt.Rows[0]["DATA_CAD"].ToString();
                item.CpfCnpj = dt.Rows[0]["CNPJ_CPF"].ToString();
                item.Cpf = dt.Rows[0]["CPF"].ToString();
                item.Ie = dt.Rows[0]["INSTEST"].ToString();
                item.Descricao = dt.Rows[0]["NOME"].ToString();
                item.Endereco = dt.Rows[0]["ENDERECO"].ToString();
                item.Bairro = dt.Rows[0]["BAIRRO"].ToString();
                item.Cidade = dt.Rows[0]["CIDADE"].ToString();
                item.Uf = dt.Rows[0]["ESTADO"].ToString();
                item.Cep = dt.Rows[0]["CEP"].ToString();
                item.Contato = dt.Rows[0]["CONTATO"].ToString();
                item.EmailContato = dt.Rows[0]["EMAIL"].ToString();
                item.FoneContato = dt.Rows[0]["FONE"].ToString();
                objDAL.FechaComandoSQL();
                return item;
            }
            catch
            {
                Cadastro item = new Cadastro();
                return item;
            }
        }

        public void Insert()
        {
            try
            {
                string id_usuario_logado = @HttpContextAccessor.HttpContext.Session.GetString("IdNomeUsuarioLogado");
                string sql = "";
                if (Validacoes.Id_Conta == 0)
                {
                    int posicaoFim =  Marca.IndexOf("-");
                    Validacoes.IdMarcaVeiculo = int.Parse(Marca.Substring(0,posicaoFim - 1));
                    Validacoes.MarcaModelo = Modelo.Substring(posicaoFim + 3).Replace("'","");
                    sql = $"INSERT INTO VEICULOS " +
                         $"(ID_MARCA,MARCA,ID_MODELO,MODELO,PLACA,ANO_MODELO,ANO_FABRICACAO) " +
                         $"VALUES ({Validacoes.IdMarcaVeiculo}, '{Validacoes.MarcaVeiculo}',{Validacoes.IdMarcaModelo},'{Validacoes.MarcaModelo}'" +
                         $",'{Placa.ToString()}','{AnoModelo.ToString()}','{AnoFabricacao.ToString()}')";
                }
                else
                {
                    int posicaoFim = Marca.IndexOf("-");
                    Validacoes.IdMarcaVeiculo = int.Parse(Marca.Substring(0, posicaoFim - 1));
                    Validacoes.MarcaModelo = Modelo.Substring(posicaoFim + 3).Replace("'", "");
                    sql = $"UPDATE VEICULOS SET ID_MARCA={Validacoes.IdMarcaVeiculo}," +
                            $"MARCA='{Validacoes.MarcaVeiculo}'," +
                            $"ID_MODELO={Validacoes.IdMarcaModelo}," +
                            $"MODELO='{Validacoes.MarcaModelo}'," +
                            $"PLACA='{Placa.ToString()}'," +
                            $"ANO_MODELO='{AnoModelo.ToString()}'," +
                            $"ANO_FABRICACAO='{AnoFabricacao.ToString()}'"+
                            $" WHERE ID='{Validacoes.Id_Conta}'";
                    Validacoes.Id_Conta = 0;
                }
                DAL objDAL = new DAL();
                objDAL.ExecutarComandoSQL(sql);
                objDAL.FechaComandoSQL();
            }
            catch (Exception error)
            {

            }
        }
        public void InsertProdutor(string ValorUF)
        {
            try
            {
                string id_usuario_logado = @HttpContextAccessor.HttpContext.Session.GetString("IdNomeUsuarioLogado");
                string sql = "";
                if (CpfCnpj == null)
                    CpfCnpj = "";
                if (Cpf == null)
                    Cpf = "";
                if (Ie == null)
                    Ie = "";
                if (Endereco == null)
                    Endereco = "";
                if (Cidade == null)
                    Cidade = "";
                if (Bairro == null)
                    Bairro = "";
                if (Cep == null)
                    Cep = "";
                if (Contato == null)
                    Contato = "";
                if (EmailContato == null)
                    EmailContato = "";
                if (FoneContato == null)
                    FoneContato = "";

                if (Id == 0)
                {
                    sql = $"INSERT INTO FORNECEDORES " +
                         $"(NOME,CNPJ_CPF,CPF,INSTEST,ENDERECO,CIDADE,BAIRRO,ESTADO," +
                         $"CEP,CONTATO,EMAIL,FONE) " +
                         $"VALUES ('{Descricao.ToString().ToUpper()}'," +
                         $"'{CpfCnpj.ToString().Replace(",", ".")}','{Cpf.ToString().Replace(",", ".")}'," +
                         $"'{Ie.ToString().ToUpper()}','{Endereco.ToString().ToUpper()}'," +
                         $"'{Cidade.ToString().ToUpper()}','{Bairro.ToString().ToUpper()}'," +
                         $"'{ValorUF.ToString().ToUpper()}','{Cep.ToString().ToUpper()}'," +
                         $"'{Contato.ToString().ToUpper()}','{EmailContato.ToString().ToUpper()}'," +
                         $"'{FoneContato.ToString().ToUpper()}')";
                }
                else
                {
                    sql = $"UPDATE FORNECEDORES " +
                            $"SET NOME='{Descricao}'," +
                            $"CNPJ_CPF='{CpfCnpj.ToString().Replace(",", ".")}'," +
                            $"CPF='{Cpf.ToString().Replace(",", ".")}'," +
                            $"INSTEST='{Ie.ToString().Replace(",", ".")}'," +
                            $"ENDERECO='{Endereco.ToString().Replace(",", ".")}'," +
                            $"CIDADE='{Cidade.ToString().Replace(",", ".")}'," +
                            $"BAIRRO='{Bairro.ToString().Replace(",", ".")}'," +                            
                            $"ESTADO='{ValorUF.ToString().Replace(",", ".")}'," +
                            $"CEP='{Cep.ToString().Replace(",", ".")}'," +
                            $"CONTATO='{Contato.ToString().Replace(",", ".")}'," +
                            $"EMAIL='{EmailContato.ToString().Replace(",", ".")}'," +
                            $"FONE='{FoneContato.ToString().Replace(",", ".")}'" +
                            $" WHERE ID='{Id}'";
                }
                DAL objDAL = new DAL();
                objDAL.ExecutarComandoSQL(sql);
                objDAL.FechaComandoSQL();
            }
            catch (Exception error)
            {

            }
        }


        public Cadastro Pesquisa(int Id , 
            string CampoWhere,
            string Campo,            
            string Tabela)
        {
            try
            {
                Cadastro item;
                //Utilizado pela View Extrato
                string filtro = "";

                filtro += $" WHERE {CampoWhere}={Id} ";

                string sql = $"SELECT {Campo} " +
                    $"  FROM {Tabela} " +
                    $" {filtro}";
                DAL objDAL = new DAL();
                DataTable dt = objDAL.RetDataTable(sql);
                item = new Cadastro();
                item.CampoPesquisa = dt.Rows[0][$"{Campo}"].ToString();
                objDAL.FechaComandoSQL();
                return item;
            }
            catch (Exception ERRO)
            {
                Cadastro item;
                item = new Cadastro();
                Validacoes.ErroPagina = "SIM";
                return item;
            }
        }

        public void Excluir(int Id)
        {
            try
            {
                new DAL().ExecutarComandoSQL("DELETE VEICULOS WHERE ID=" + Id);
                new DAL().FechaComandoSQL();
            }
            catch
            {

            }
        }
        public void ExcluirProdutor(int Id)
        {
            try
            {
                new DAL().ExecutarComandoSQL("UPDATE FORNECEDORES SET DELETED='S' WHERE ID=" + Id);
                new DAL().FechaComandoSQL();
            }
            catch
            {

            }
        }


    }
}
