using TESTEAO3.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace TESTEAO3.Models
{
    public class UsuarioModel
    {
        public int Id { get; set; }
        [Required (ErrorMessage ="Informe seu Nome!")]
        public String  Nome  { get; set; }
        [Required(ErrorMessage = "Informe seu Emai!")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessage ="o e-mail informado é Inválido!")]
        public String  Email { get; set; }
        [Required(ErrorMessage = "Informe sua Senha!")]
        public String  Senha { get; set; }
        [Required(ErrorMessage = "Preencha sua Data Nascimento!")]
        public String Data_Nascimento { get; set; }

        public bool ValidarLogin()
        {
            try
            {
                string sql = $"SELECT ID,NOME,DATA_NASCIMENTO FROM USUARIO WHERE " +
                    $"EMAIL='{Email}' AND SENHA='{Senha}'";
                DAL objDAL = new DAL();
                DataTable dt = objDAL.RetDataTable(sql);
                if (dt != null)
                {
                    if (dt.Rows.Count == 1)
                    {
                        Id = int.Parse(dt.Rows[0]["ID"].ToString());
                        Nome = dt.Rows[0]["NOME"].ToString();
                        Data_Nascimento = dt.Rows[0]["DATA_NASCIMENTO"].ToString();
                        objDAL.FechaComandoSQL();
                        return true;
                    }
                }
                objDAL.FechaComandoSQL();
                return false;
            }
            catch (Exception error)
            {
                return false;
            }
        }
        public void RegistrarUsuario()
        {
            //CAPTURANDO ULTIMO ID 
            try
            {
                string sql = $"SELECT ID FROM USUARIO ";

                DAL objDAL = new DAL();
                DataTable dt = objDAL.RetDataTable(sql);
                if (dt != null)
                {
                    if (dt.Rows.Count == 1)
                    {
                        Id = int.Parse(dt.Rows[0]["ID"].ToString());
                    }
                }

                objDAL.ExecutarComandoSQL(sql);
                string datanascimento = DateTime.Parse(Data_Nascimento).ToString("yyyy/MM/dd");
                sql = $"INSERT INTO USUARIO (NOME,EMAIL,SENHA,DATA_NASCIMENTO)" +
                      $"VALUES ('{Nome}','{Email}','{Senha}','{datanascimento}')";
                objDAL.ExecutarComandoSQL(sql);
                objDAL.FechaComandoSQL();
            }
            catch
            {


            }
        }
    }
}
