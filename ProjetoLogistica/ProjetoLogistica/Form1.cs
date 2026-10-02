using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace ProjetoLogistica
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button21_Click(object sender, EventArgs e)
        {
            {
                using (var banco = Conexao.ObterConexao())

                    banco.Open();
                MessageBox.Show("Conexão realizada com sucesso!");
            }
    }

        private void btn_salvarVeiculo_Click(object sender, EventArgs e)
        {
            try
            {
                using (MySqlConnection banco = new MySqlConnection(Conexao.ConexaoString))
                {
                    banco.Open();

                    string sql = @"
                        INSERT INTO veiculo
                        (modelo, placa, consumo_medio, carga_maxima)
                        VALUES
                        (@modelo, @placa, @consumo, @carga)";

                    MySqlCommand comando = new MySqlCommand(sql, banco);

                    comando.Parameters.AddWithValue("@modelo", txt_Modelo.Text);
                    comando.Parameters.AddWithValue("@placa", txt_Placa.Text);
                    comando.Parameters.AddWithValue("@consumo", txt_Consumo.Text);
                    comando.Parameters.AddWithValue("@carga", txt_Carga.Text);

                    comando.ExecuteNonQuery();

                    txt_VeiculoID.Clear();
                    txt_Modelo.Clear();
                    txt_Placa.Clear();
                    txt_Consumo.Clear();
                    txt_Carga.Clear();

                    txt_Modelo.Focus();

                    MessageBox.Show(
                        "Veículo cadastrado com sucesso!",
                        "Sucesso",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                }
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message);
            }
        }
    }
}
