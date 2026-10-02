using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoLogistica
{
    public static class Conexao
    {
        public const string ConexaoString =
            "Server=localhost;Database=projeto_logistica;Uid=root;Pwd=password;";

        public static MySqlConnection ObterConexao()
        {
            return new MySqlConnection(ConexaoString);
        }
    }
}
