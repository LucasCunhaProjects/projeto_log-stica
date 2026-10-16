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

        private void Form3_Load(object sender, EventArgs e)
        {
            this.BackColor = Color.FromArgb(248, 250, 252);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;

            lbl_Titulo.Text = "Cadastro de Usuário";
            lbl_Titulo.Font = new Font("Segoe UI", 18, FontStyle.Bold);
            lbl_Titulo.ForeColor = Color.FromArgb(30, 58, 138);
            lbl_Titulo.Left = (this.ClientSize.Width - lbl_Titulo.Width) / 2;

            lbl_Nome.Font = new Font("Segoe UI", 10);
            lbl_Email.Font = new Font("Segoe UI", 10);
            lbl_Senha.Font = new Font("Segoe UI", 10);

            lbl_Nome.ForeColor = Color.FromArgb(31, 41, 55);
            lbl_Email.ForeColor = Color.FromArgb(31, 41, 55);
            lbl_Senha.ForeColor = Color.FromArgb(31, 41, 55);

            btn_Cadastrar.BackColor = Color.FromArgb(37, 99, 235);
            btn_Cadastrar.ForeColor = Color.White;
            btn_Cadastrar.FlatStyle = FlatStyle.Flat;
            btn_Cadastrar.FlatAppearance.BorderSize = 0;

            btn_Voltar.BackColor = Color.FromArgb(107, 114, 128);
            btn_Voltar.ForeColor = Color.White;
            btn_Voltar.FlatStyle = FlatStyle.Flat;
            btn_Voltar.FlatAppearance.BorderSize = 0;

        }
    }
}
