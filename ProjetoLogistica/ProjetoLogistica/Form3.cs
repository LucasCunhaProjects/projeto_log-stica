using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjetoLogistica
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void btn_Cadastrar_Click(object sender, EventArgs e)
        {
            try
            {
                using (MySqlConnection conexao = new MySqlConnection(Conexao.ConexaoString))
                {
                    conexao.Open();

                    string sql = @"INSERT INTO usuario
                          (nome, login, senha)
                          VALUES
                          (@nome, @login, @senha)";

                    MySqlCommand cmd = new MySqlCommand(sql, conexao);

                    cmd.Parameters.AddWithValue("@nome", txt_Nome.Text);
                    cmd.Parameters.AddWithValue("@login", txt_Email.Text);
                    cmd.Parameters.AddWithValue("@senha", txt_Senha.Text);

                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Usuário cadastrado com sucesso!");

                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex.Message);
            }
        }

        private void btn_Voltar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
