using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjetoLogistica
{

    public partial class Form1 : Form
    {
        private bool modoEdicao = false;
        private int idVeiculoSelecionado = 0;

        public Form1()
        {
            InitializeComponent();
        }


        private void BloquearCampos()
        {
            txt_Modelo.Enabled = false;
            txt_Placa.Enabled = false;
            txt_Consumo.Enabled = false;
            txt_Carga.Enabled = false;
            txt_VeiculoID.Enabled = false;
        }

        private void LiberarCampos()
        {
            txt_Modelo.Enabled = true;
            txt_Placa.Enabled = true;
            txt_Consumo.Enabled = true;
            txt_Carga.Enabled = true;
        }

        private void LimparCampos()
        {
            txt_VeiculoID.Clear();
            txt_Modelo.Clear();
            txt_Placa.Clear();
            txt_Consumo.Clear();
            txt_Carga.Clear();

            idVeiculoSelecionado = 0;
        }

        private void CarregarVeiculos()
        {
            try
            {
                using (MySqlConnection banco = new MySqlConnection(Conexao.ConexaoString))
                {
                    banco.Open();

                    string sql = @"SELECT
                                    VeiculoID,
                                    Modelo,
                                    Placa,
                                    Consumo_medio,
                                    Carga_maxima     
                                  FROM veiculo";

                    MySqlDataAdapter da = new MySqlDataAdapter(sql, banco);
                    DataTable dt = new DataTable();

                    da.Fill(dt);

                    dataGrid_Veiculo.DataSource = dt;
                }

            }
            catch (Exception erro)
            {
                MessageBox.Show(
                    "Erro ao buscar veículos: " + erro.Message,
                    "Erro",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void EntrarModoEdicao()
        {
            modoEdicao = true;

            LiberarCampos();

            btn_salvarVeiculo.Enabled = true;

            btn_excluirVeiculo.Text = "Cancelar";
            btn_excluirVeiculo.Enabled = true;

            btn_editarVeiculo.Enabled = false;
            btn_buscarVeiculo.Enabled = false;
        }
        private void SairModoEdicao()
        {
            modoEdicao = false;

            BloquearCampos();

            btn_excluirVeiculo.Text = "Excluir";

            btn_salvarVeiculo.Enabled = true;
            btn_excluirVeiculo.Enabled = true;
            btn_editarVeiculo.Enabled = true;
            btn_buscarVeiculo.Enabled = true;

            txt_Modelo.Enabled = false;
            txt_Placa.Enabled = false;
            txt_Consumo.Enabled = false;
            txt_Carga.Enabled = false;
        }


        private void btn_salvarVeiculo_Click(object sender, EventArgs e)
        {
            try
            {
                using (MySqlConnection banco = new MySqlConnection(Conexao.ConexaoString))
                {
                    banco.Open();

                    if (modoEdicao)
                    {
                        string sql = @"
                            UPDATE Veiculo
                            SET
                                Modelo = @modelo,
                                Placa = @placa,
                                Consumo_medio = @consumo,
                                Carga_maxima = @carga
                            WHERE VeiculoID = @ID";

                        MySqlCommand comando = new MySqlCommand(sql, banco);

                        comando.Parameters.AddWithValue("@ID", idVeiculoSelecionado);
                        comando.Parameters.AddWithValue("@modelo", txt_Modelo.Text);
                        comando.Parameters.AddWithValue("@placa", txt_Placa.Text);
                        comando.Parameters.AddWithValue("@consumo", Convert.ToDecimal(txt_Consumo.Text));
                        comando.Parameters.AddWithValue("@carga", Convert.ToDecimal(txt_Carga.Text));

                        comando.ExecuteNonQuery();

                        MessageBox.Show("Veículo atualizado com sucesso.");

                        CarregarVeiculos();

                        SairModoEdicao();

                    }
                    else
                    {
                        string sql = @"
                            INSERT INTO veiculo
                            (modelo, placa, consumo_medio, carga_maxima)
                            VALUES
                            (@modelo, @placa, @consumo, @carga)";

                        MySqlCommand comando = new MySqlCommand(sql, banco);

                        comando.Parameters.AddWithValue("@modelo", txt_Modelo.Text);
                        comando.Parameters.AddWithValue("@placa", txt_Placa.Text);
                        comando.Parameters.AddWithValue("@consumo", Convert.ToDecimal(txt_Consumo.Text));
                        comando.Parameters.AddWithValue("@carga", Convert.ToDecimal(txt_Carga.Text));

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

                        CarregarVeiculos();

                    }

                }

                modoEdicao = false;

                BloquearCampos();

            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message);
            }
        }

        private void btn_buscarVeiculo_Click(object sender, EventArgs e)
        {
            CarregarVeiculos();
            SairModoEdicao();
        }

        private void dataGrid_Veiculo_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow linha = dataGrid_Veiculo.Rows[e.RowIndex];

                txt_VeiculoID.Text = linha.Cells["VeiculoID"].Value.ToString();
                txt_Modelo.Text = linha.Cells["Modelo"].Value.ToString();
                txt_Placa.Text = linha.Cells["Placa"].Value.ToString();
                txt_Consumo.Text = linha.Cells["Consumo_medio"].Value.ToString();
                txt_Carga.Text = linha.Cells["Carga_maxima"].Value.ToString();

                idVeiculoSelecionado = Convert.ToInt32(
                    linha.Cells["VeiculoID"].Value);

            }
        }

        private void btn_editarVeiculo_Click(object sender, EventArgs e)
        {
            CarregarVeiculos();

            if (idVeiculoSelecionado == 0)
            {
                MessageBox.Show("Selecione um veículo.");
                return;
            }

            EntrarModoEdicao();

        }

        private void btn_excluirVeiculo_Click(object sender, EventArgs e)
        {
            if (modoEdicao)
            {
                SairModoEdicao();

                LimparCampos();

                return;
            }

            if (idVeiculoSelecionado == 0)
            {
                MessageBox.Show("Selecione um veículo para excluir.");
                return;
            }

            DialogResult resultado = MessageBox.Show(
                "Deseja realmente excluir este veículo?",
                "Confirmação",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (resultado == DialogResult.Yes)
            {
                try
                {
                    using (MySqlConnection banco = new MySqlConnection(Conexao.ConexaoString))
                    {
                        banco.Open();

                        string sql =
                            "DELETE FROM veiculo WHERE VeiculoID = @ID";

                        MySqlCommand comando = new MySqlCommand(sql, banco);

                        comando.Parameters.AddWithValue("@ID", idVeiculoSelecionado);

                        comando.ExecuteNonQuery();
                    }

                    MessageBox.Show("Veículo excluído com sucesso!");

                    LimparCampos();

                    CarregarVeiculos();

                    idVeiculoSelecionado = 0;
                }
                catch (Exception erro)
                {
                    MessageBox.Show("Erro ao excluir: " + erro.Message);
                }
            }
        }

        private void btn_LimparTelaVeiculo_Click(object sender, EventArgs e)
        {
            LimparCampos();

            dataGrid_Veiculo.DataSource = null;

            modoEdicao = false;

            btn_excluirVeiculo.Text = "Excluir";

            LiberarCampos();

            txt_Modelo.Focus();
        }
    }
}

