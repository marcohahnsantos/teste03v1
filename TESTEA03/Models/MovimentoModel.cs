using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using TESTEAO3.Util;
using cloudscribe.Web.Pagination;
using Rotativa.AspNetCore;
using System.Data;
namespace TESTEAO3.Models
{
    public class MovimentoModel
    {
        public int ID { get; set; }

        public int ID_MOV { get; set; }

        public string CPF_LOCATORIO { get; set; }
        public int ID_VEICULO { get; set; }
        public String NOME_LOCATORIO { get; set; }
        public String FORNECEDOR { get; set; }
        [DisplayFormat(DataFormatString = "{0:hh.MM}", ApplyFormatInEditMode = true)]
        public DateTime DATA_RESERVA { get; set; }
        public string MARCA { get; set; }
        public string PLACA { get; set; }
        public string MODELO { get; set; }
        public string SATUS_LOCACAO { get; set; }
        public string DATA_ANO_FABRICACAO { get; set; }
        public string DATA_ANO_MODELO { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Data_Ini { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Data_Fim { get; set; }

        public IHttpContextAccessor HttpContextAccessor { get; set; }
        public MovimentoModel()
        {
        }

        public MovimentoModel(IHttpContextAccessor httpContextAccessor)
        {
            HttpContextAccessor = httpContextAccessor;
        }
       

        public List<MovimentoModel> ListaMovimento(string Limite)
        {
            try
            {
                List<MovimentoModel> lista = new List<MovimentoModel>();
                MovimentoModel item;
                //Utilizado pela View Extrato
                string filtro = "";
                if (int.Parse(Limite) > 10 && int.Parse(Limite) < 20)
                {
                    filtro += $" WHERE  NOT A.ID in(SELECT TOP {Limite} " +
                           $" M.ID FROM MOVIMENTACAO_ LOCADORA AS M " +
                           $" ORDER BY M.DATA_CAD,M.ID DESC ) ";
                }

                if (int.Parse(Limite) >= 20)
                {
                    filtro += $" WHERE " +
                              $" NOT A.ID in(SELECT TOP {int.Parse(Limite)} " +
                              $" M.ID FROM MOVIMENTACAO_ LOCADORA AS M " +
                              $" ORDER BY M.DATA_CAD,M.ID DESC  ) ";
                }

                string sql = $"SELECT TOP 10 " +
                             $"M.ID AS ID_MOV, " +
                             $"V.ID, " +
                             $"V.MARCA, " +
                             $"V.MODELO," +
                            // $"M.DATA_RESERVA," +
                            // $"M.DATA_INICIO," +
                            // $"M.DATA_FIM," +
                             $"V.PLACA," +
                             $"V.ANO_FABRICACAO," +
                             $"V.ANO_MODELO," +
                             $"CASE WHEN isnull(M.STATUS_LOCACAO, '0') <> '0' THEN " +
                             $"'LOCADO'"+
                             $"   ELSE " +
                             $"'LIBERADO' " +
                             $" END " +
                             $"AS STATUS_LOCACAO " +
                             $" FROM VEICULOS AS V LEFT JOIN " +
                             $" MOVIMENTACAO_LOCADORA AS M ON " +
                             $" M.ID_VEICULO = V.ID ORDER BY M.ID DESC;";
                           
                DAL objDAL = new DAL();
                DataTable dt = objDAL.RetDataTable(sql);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    item = new MovimentoModel();
                    item.ID = int.Parse(dt.Rows[i]["ID"].ToString());
               //     item.DATA_RESERVA = Convert.ToDateTime(dt.Rows[i]["DATA_RESERVA"].ToString());
                //    item.Data_Ini = Convert.ToDateTime(dt.Rows[i]["DATA_INICIO"].ToString());
                //    item.Data_Fim = Convert.ToDateTime(dt.Rows[i]["DATA_FIM"].ToString());
                    item.MARCA =  dt.Rows[i]["MARCA"].ToString();
                    item.MODELO = dt.Rows[i]["MODELO"].ToString();
                    item.PLACA = dt.Rows[i]["MODELO"].ToString();
                    item.DATA_ANO_FABRICACAO =dt.Rows[i]["ANO_FABRICACAO"].ToString();
                    item.DATA_ANO_MODELO = dt.Rows[i]["ANO_MODELO"].ToString();
                    item.SATUS_LOCACAO= dt.Rows[i]["STATUS_LOCACAO"].ToString();
                    lista.Add(item);
                }
                objDAL.FechaComandoSQL();
                return lista;
            }
            catch (Exception error)
            {
                List<MovimentoModel> lista = new List<MovimentoModel>();
                Validacoes.ErroPagina = "SIM";
                return lista;
            }
        }

        public MovimentoModel ListaMovimentoUnico(int Id)
        {
            try
            {
                MovimentoModel item = new MovimentoModel();
            
                string sql = $"SELECT TOP 10 " +
                             $"M.ID AS ID_MOV, "+
                             $"V.ID, " +
                             $"M.CPF_LOCATARIO, " +
                             $"M.ID_VEICULO, " +
                             $"isnull(M.DATA_RESERVA,GETDATE()) as DATA_RESERVA, " +
                             $"ISNULL(M.DATA_INICIO,GETDATE()) AS DATA_INICIO, " +
                             $"ISNULL(M.DATA_FIM,GETDATE()) AS DATA_FIM, " +
                             $"M.NOME_LOCATARIO, " +
                             $"V.MARCA, " +
                             $"V.MODELO," +
                             $"V.ANO_FABRICACAO," +
                             $"V.ANO_MODELO," +
                             $"CASE WHEN isnull(M.STATUS_LOCACAO, '0') <> '0' THEN " +
                             $"'LOCADO'" +
                             $"   ELSE " +
                             $"'LIBERADO' " +
                             $" END " +
                             $"AS STATUS_LOCACAO " +
                             $" FROM VEICULOS AS V LEFT JOIN " +
                             $" MOVIMENTACAO_LOCADORA AS M ON " +
                             $" V.ID = M.ID_VEICULO "+
                             $" WHERE V.ID={Id}"+
                             $" ORDER BY M.ID DESC;";

                DAL objDAL = new DAL();
                DataTable dt = objDAL.RetDataTable(sql);
                            item = new MovimentoModel();
                            item.ID = int.Parse(dt.Rows[0]["ID"].ToString());
                            item.CPF_LOCATORIO = dt.Rows[0]["CPF_LOCATARIO"].ToString();
                            item.NOME_LOCATORIO = dt.Rows[0]["NOME_LOCATARIO"].ToString();
                            item.DATA_RESERVA =Convert.ToDateTime( dt.Rows[0]["DATA_RESERVA"].ToString());
                            item.Data_Ini = Convert.ToDateTime(dt.Rows[0]["DATA_INICIO"].ToString());
                            item.Data_Fim = Convert.ToDateTime(dt.Rows[0]["DATA_FIM"].ToString())    ;
                            item.MARCA = dt.Rows[0]["MARCA"].ToString();
                            item.MODELO = dt.Rows[0]["MODELO"].ToString();
                            item.DATA_ANO_FABRICACAO = dt.Rows[0]["ANO_FABRICACAO"].ToString();
                            item.DATA_ANO_MODELO = dt.Rows[0]["ANO_MODELO"].ToString();
                            item.SATUS_LOCACAO = dt.Rows[0]["STATUS_LOCACAO"].ToString();
                objDAL.FechaComandoSQL();
                return item;
                
                
            }
            catch (Exception error)
            {
                MovimentoModel item = new MovimentoModel();
                Validacoes.ErroPagina = "SIM";
                return item;
            }
        }
        public MovimentoModel selectStatus(int Id)
        {
            MovimentoModel item = new MovimentoModel();

            string sql = $"SELECT " +
                         $"CASE WHEN isnull(M.STATUS_LOCACAO, '0') <> '0' THEN " +
                         $"'LOCADO'" +
                         $"   ELSE " +
                         $"'LIBERADO' " +
                         $" END " +
                         $"AS STATUS_LOCACAO " +
                         $" FROM VEICULOS AS V LEFT JOIN " +
                         $" MOVIMENTACAO_LOCADORA AS M ON " +
                         $" V.ID = M.ID_VEICULO " +
                         $" WHERE V.ID={Id}";


            DAL objDAL = new DAL();
            DataTable dt = objDAL.RetDataTable(sql);
            item = new MovimentoModel();
            item.SATUS_LOCACAO = dt.Rows[0]["STATUS_LOCACAO"].ToString();
            objDAL.FechaComandoSQL();
            return item;

        }
        public void Insert(int Id , MovimentoModel Dadosrecebidos)
        {
            try
            {
                string id_usuario_logado = @HttpContextAccessor.HttpContext.Session.GetString("IdNomeUsuarioLogado");
                string sql = "";
             
                if (Id != 0)
                {
                 
                    //sql = $"SELECT TOP 10 " +
                    //       $"V.ID, " +
                    //       $"M.CPF_LOCATARIO, " +
                    //       $"M.NOME_LOCATARIO, " +
                    //       $"M.DATA_RESERVA, " +
                    //       $"M.DATA_INICIO, " +
                    //       $"M.DATA_FIM, " +
                    //       $"V.MARCA, " +
                    //       $"V.MODELO," +
                    //       $"V.ANO_FABRICACAO," +
                    //       $"V.ANO_MODELO," +
                    //       $"CASE WHEN isnull(M.STATUS_LOCACAO, '0') <> '0' THEN " +
                    //       $"'LIBERADO'" +
                    //       $"   ELSE " +
                    //       $"'LOCADO' " +
                    //       $" END " +
                    //       $"AS STATUS_LOCACAO " +
                    //       $" FROM VEICULOS AS V LEFT JOIN " +
                    //       $" MOVIMENTACAO_LOCADORA AS M ON " +
                    //       $" V.ID = M.ID_VEICULO " +
                    //       $" WHERE V.ID={Id}" +
                    //       $" ORDER BY M.ID DESC;";

                    //DAL dAL = new DAL();
                    //DAL objDAL1 = dAL;
                    //DataTable dt = objDAL1.RetDataTable(sql);
                 


                //sql = $"INSERT INTO MOVIMENTACAO_LOCADORA " +
                //         $"(CPF_LOCATARIO,ID_VEICULO,NOME_LOCATARIO,DATA_RESERVA,DATA_INICIO,DATA_FIM,STATUS_LOCACAO) " +
                //         $"VALUES ('{dt.Rows[0]["CPF_LOCATARIO"].ToString()}'," +
                //         $"{int.Parse(dt.Rows[0]["ID_VEICULO"].ToString())}," +
                //         $",'{dt.Rows[0]["NOME_LOCATARIO"].ToString()}'," +
                //         $"'{Convert.ToDateTime(dt.Rows[0]["DATA_RESERVA"].ToString())}'," +
                //         $"'{Convert.ToDateTime(dt.Rows[0]["DATA_INICIO"].ToString())}'," +
                //         $"'{Convert.ToDateTime(dt.Rows[0]["DATA_FIM"].ToString())}'," +
                //         $"'LOCADO'";

                    //objDAL1.FechaComandoSQL();
                }
                else
                {
                    //sql = $"UPDATE ABATE SET " +
                    //     $" ID_EMPRESA='{id_Empresa}'," +
                    //     $" ID_FORNECEDOR='{id_Produtor.ToString().Replace(",", ".")}'," +
                    //     $" QUANTIDADE='{Quantidade.ToString().Replace(",", ".")}'," +
                    //     $" DATA_ABATE='{Convert.ToDateTime(Data_Abate).ToString("dd/MM/yyyy hh:mm")}', " +
                    //     $" HORA_ABATE='{Hora_Abate.ToString()}' " +
                    //     $" WHERE ID='{Id}'";
                }
                DAL objDAL = new DAL();
                objDAL.ExecutarComandoSQL(sql);
                objDAL.FechaComandoSQL();
            }
            catch (Exception error)
            {

            }
        }
        //public List<MovimentoModel>ListaMovAbate(string Limite, int? Id)
        //{
        //try
        //{
        //    List<MovimentoModel> lista = new List<MovimentoModel>();
        //    MovimentoModel item;

        //    string filtro = "";


        //    if (int.Parse(Limite) >= 5)
        //    {
        //        Limite = Convert.ToString(int.Parse(Limite) - 5);
        //        if (Limite != "0")
        //        {
        //            filtro += $" AND DELETED='N' AND NOT ID in(SELECT TOP {Limite} " +
        //                   $" ID FROM MOVIMENTACAO_ABATE  " +
        //                   $" ORDER BY ID DESC ) ";
        //        }
        //    }


        //    string sql = $"SELECT " +
        //                    $" TOP 5 " +
        //                    $" ID," +
        //                    $" ID_ORIGEM," +
        //                    $" TAG," +
        //                    $" PESO," +
        //                    $" DATA_ABATE[DATA ABATE] " +
        //                    $" FROM MOVIMENTACAO_ABATE WHERE " +
        //                    $" ID_ABATE ={Id} " + filtro+
        //                    $" ORDER BY ID DESC ";
        //    DAL objDAL = new DAL();
        //    DataTable dt = objDAL.RetDataTable(sql);
        //    for (int i = 0; i < dt.Rows.Count; i++)
        //    {
        //        item = new MovimentoModel();
        //        item.Id = int.Parse(dt.Rows[i]["ID"].ToString());
        //        item.Id_Origem = int.Parse(dt.Rows[i]["ID_ORIGEM"].ToString());
        //        item.TAG = dt.Rows[i]["TAG"].ToString();
        //        item.PESO = int.Parse(dt.Rows[i]["PESO"].ToString());
        //        item.Data_Abate = DateTime.Parse(dt.Rows[i]["DATA ABATE"].ToString()).ToString("dd/MM/yyyy hh:mm:ss");
        //        lista.Add(item);
        //    }
        //    objDAL.FechaComandoSQL();
        //    return lista;
    }

    //catch (Exception error)
    //{
    //    List<MovimentoModel> lista = new List<MovimentoModel>();
    //    Validacoes.ErroPagina = "SIM";
    //    return lista;
    //}
}
        //public MovimentoModel TotalRegistrosMovimento(
        //   int Limite,
        //   string Tabela,
        //   string Campo,
        //   string where,
        //   string CampoOrdem)
        //{

            //try
            //{
            //    MovimentoModel item;
               


            //    string sql = $"SELECT COUNT(T.{Campo}) AS TOTAL " +
            //        $"  FROM {Tabela}  AS T " +
            //        $" {where}";
            //    DAL objDAL = new DAL();
            //    DataTable dt = objDAL.RetDataTable(sql);
            //    item = new MovimentoModel();
            //    item.Total = int.Parse(dt.Rows[0]["TOTAL"].ToString());
            //    return item;
            //}
            //catch (Exception error)
            //{
            //    MovimentoModel item;
            //    item = new MovimentoModel();
            //    Validacoes.ErroPagina = "SIM";
            //    return item;
            //}
        //}
        //public List<MovimentoModel> ListaMovimentacaoAbate()
        //{
        //    try
        //    {
        //        List<MovimentoModel> lista = new List<MovimentoModel>();
        //        MovimentoModel item;

        //        //Utilizado pela View Extrato
        //        string filtro = "";

        //        string sql = $" SELECT ID AS [CODIGO]," +
        //                     $"  DATA_CAD AS[DATA]," +
        //                     $" TAG," +
        //                     $" PESO " +
        //                    $" FROM    MOVIMENTACAO_ABATE " +
        //                    $"  WHERE ID_ABATE={Validacoes.Codigo_Abate} ";
        //        DAL objDAL = new DAL();



        //        DataTable dt = objDAL.RetDataTable(sql);
        //        for (int i = 0; i < dt.Rows.Count; i++)
        //        {
        //            item = new MovimentoModel();
        //            item.Id = int.Parse(dt.Rows[i]["CODIGO"].ToString());
        //            item.DATA = DateTime.Parse(dt.Rows[i]["DATA"].ToString()).ToString("dd/MM/yyyy hh:mm:ss");
        //            item.TAG = dt.Rows[i]["TAG"].ToString();
        //            item.PESO =int.Parse(dt.Rows[i]["PESO"].ToString());
        //            lista.Add(item);
        //        }
        //        objDAL.FechaComandoSQL();
        //        return lista;
        //    }
        //    catch
        //    {
        //        List<MovimentoModel> lista = new List<MovimentoModel>();

        //        return lista;
        //    }
        //}
        //public MovimentoModel CarregaRegistroDadosAbate(int? id)
        //{
        //    try
        //    {
        //        MovimentoModel item = new MovimentoModel();
        //        string id_usuario_logado = @HttpContextAccessor.HttpContext.Session.GetString("IdNomeUsuarioLogado");
        //        string sql = $"SELECT "+
        //                     $"E.DESCRICAO AS [EMPRESA],"+
        //                     $"A.QUANTIDADE AS [QUANTIDADE]," +
        //                     $"A.DATA_ABATE AS [DATA]," +
        //                     $"F.NOME [FORNECEDOR]" +
        //                     $" FROM ABATE A " +
        //                     $"INNER JOIN EMPRESAS E ON A.ID_EMPRESA=E.ID "+
        //                     $"INNER JOIN FORNECEDORES F ON  A.ID_FORNECEDOR=F.ID"+
        //                     $" WHERE A.ID={id}";
        //        DAL objDAL = new DAL();
        //        DataTable dt = objDAL.RetDataTable(sql);
        //        item.EMPRESA = dt.Rows[0]["EMPRESA"].ToString();
        //        item.FORNECEDOR= dt.Rows[0]["FORNECEDOR"].ToString();
        //        item.QUANTIDADE = dt.Rows[0]["QUANTIDADE"].ToString();
        //        item.DATA = dt.Rows[0]["DATA"].ToString();
        //        objDAL.FechaComandoSQL();
        //        return item;
        //    }
        //    catch (Exception erro)
        //    {
        //        MovimentoModel item = new MovimentoModel();
        //        return item;
        //    }
        //}

    //}
