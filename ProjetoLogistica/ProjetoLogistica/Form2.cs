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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void btn_Entrar_Click(object sender, EventArgs e)
        {
            try
            {
                using (MySqlConnection conexao = new MySqlConnection(Conexao.ConexaoString))
                {
                    conexao.Open();

                    string sql = @"SELECT * 
                           FROM usuario 
                           WHERE login = @login 
                           AND senha = @senha";

                    MySqlCommand cmd = new MySqlCommand(sql, conexao);

                    cmd.Parameters.AddWithValue("@login", txt_Login.Text);
                    cmd.Parameters.AddWithValue("@senha", txt_Senha.Text);

                    MySqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        MessageBox.Show("Login realizado com sucesso!");

                        Form1 login = new Form1();
                        login.Show();

                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Usuário ou senha inválidos!");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex.Message);
            }
        }

        private void btn_Cadastrar_Click(object sender, EventArgs e)
        {
            Form3 cadastro = new Form3();

            this.Hide();

            cadastro.ShowDialog();

            this.Show();
        }

        private void btn_Encerrar_Click(object sender, EventArgs e)
        {
            DialogResult resposta = MessageBox.Show(
                "Deseja realmente encerrar o sistema?",
                "Confirmar Saída",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (resposta == DialogResult.Yes)
            {   
                Application.Exit();
            }
        }
    }
    
}
