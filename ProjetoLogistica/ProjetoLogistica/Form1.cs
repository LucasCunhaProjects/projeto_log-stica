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

    public partial class Form1 : Form
    {
        private bool modoEdicao = false;
        private int idVeiculoSelecionado = 0;
        private int idMotoristaSelecionado = 0;
        private int idRotaSelecionada = 0;
        private int idPrecoSelecionado = 0;
        private int idViagemSelecionada = 0;

        public Form1()
        {
            InitializeComponent();
        }


        private void BloquearCamposVeiculo()
        {
            txt_Modelo.Enabled = false;
            txt_Placa.Enabled = false;
            txt_Consumo.Enabled = false;
            txt_Carga.Enabled = false;
            txt_VeiculoID.Enabled = false;
        }

        private void BloquearCamposMotorista()
        {
            txt_NomeMotorista.Enabled = false;
            txt_cnh.Enabled = false;
            txt_Telefone.Enabled = false;
            txt_MotoristaID.Enabled = false;
        }

        private void BloquearCamposRota()
        {
            txt_origemRota.Enabled = false;
            txt_destinoRota.Enabled = false;
            txt_distanciaRota.Enabled = false;
            txt_rotaID.Enabled = false;
        }

        private void BloquearCamposCombustivel()
        {
            cmb_combustivel.Enabled = false;
            txt_precoCombustivel.Enabled = false;
            dateTimeCombustivel.Enabled = false;
            txt_combustivelID.Enabled = false;
        }

        private void LiberarCamposVeiculo()
        {
            txt_Modelo.Enabled = true;
            txt_Placa.Enabled = true;
            txt_Consumo.Enabled = true;
            txt_Carga.Enabled = true;
        }

        private void LiberarCamposMotorista()
        {
            txt_NomeMotorista.Enabled = true;
            txt_cnh.Enabled = true;
            txt_Telefone.Enabled = true;
        }

        private void LiberarCamposRota()
        {
            txt_origemRota.Enabled = true;
            txt_destinoRota.Enabled = true;
            txt_distanciaRota.Enabled = true;
        }

        private void LiberarCamposCombustivel()
        {
            cmb_combustivel.Enabled = true;
            txt_precoCombustivel.Enabled = true;
            dateTimeCombustivel.Enabled = true;
            txt_combustivelID.Enabled = true;
        }

        private void LimparCamposVeiculo()
        {
            txt_VeiculoID.Clear();
            txt_Modelo.Clear();
            txt_Placa.Clear();
            txt_Consumo.Clear();
            txt_Carga.Clear();

            
        }

        private void LimparCamposMotorista()
        {
            txt_MotoristaID.Clear();
            txt_NomeMotorista.Clear();
            txt_cnh.Clear();
            txt_Telefone.Clear();

            
        }

        private void LimparCamposRota()
        {
            txt_rotaID.Clear();
            txt_origemRota.Clear();
            txt_destinoRota.Clear();
            txt_distanciaRota.Clear();

            
        }

        private void LimparCamposCombustivel()
        {
            txt_combustivelID.Clear();
            txt_precoCombustivel.Clear();
            cmb_combustivel.Text = "";

            
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

        private void CarregarMotoristas()
        {
            try
            {
                using (MySqlConnection banco = new MySqlConnection(Conexao.ConexaoString))
                {
                    banco.Open();

                    string sql = @"SELECT
                                    MotoristaID,
                                    Nome,
                                    Cnh,
                                    Telefone
                                  FROM motorista";

                    MySqlDataAdapter da = new MySqlDataAdapter(sql, banco);
                    DataTable dt = new DataTable();

                    da.Fill(dt);

                    dataGrid_Motorista.DataSource = dt;
                }

            }
            catch (Exception erro)
            {
                MessageBox.Show(
                    "Erro ao buscar motorista: " + erro.Message,
                    "Erro",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void CarregarRota()
        {
            try
            {
                using (MySqlConnection banco = new MySqlConnection(Conexao.ConexaoString))
                {
                    banco.Open();

                    string sql = @"SELECT
                                    RotaID,
                                    Origem,
                                    Destino,
                                    Distancia
                                  FROM rota";

                    MySqlDataAdapter da = new MySqlDataAdapter(sql, banco);
                    DataTable dt = new DataTable();

                    da.Fill(dt);

                    dataGrid_Rota.DataSource = dt;
                }

            }
            catch (Exception erro)
            {
                MessageBox.Show(
                    "Erro ao buscar rota: " + erro.Message,
                    "Erro",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void CarregarCombustivel()
        {
            try
            {
                using (MySqlConnection banco = new MySqlConnection(Conexao.ConexaoString))
                {
                    banco.Open();

                    string sql = @"SELECT
                                    PrecoID,
                                    Combustivel,
                                    Preco,
                                    Data_consulta
                                  FROM preco_combustivel";

                    MySqlDataAdapter da = new MySqlDataAdapter(sql, banco);
                    DataTable dt = new DataTable();

                    da.Fill(dt);

                    dataGrid_Combustivel.DataSource = dt;
                }

            }
            catch (Exception erro)
            {
                MessageBox.Show(
                    "Erro ao buscar preços: " + erro.Message,
                    "Erro",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void EntrarModoEdicaoVeiculo()
        {
            modoEdicao = true;

            LiberarCamposVeiculo();

            btn_salvarVeiculo.Enabled = true;

            btn_excluirVeiculo.Text = "Cancelar";
            btn_excluirVeiculo.Enabled = true;

            btn_editarVeiculo.Enabled = false;
            btn_buscarVeiculo.Enabled = false;
            btn_LimparVeiculo.Enabled = false;
        }

        private void EntrarModoEdicaoMotorista()
        {
            modoEdicao = true;

            LiberarCamposMotorista();

            btn_salvarMotorista.Enabled = true;

            btn_excluirMotorista.Text = "Cancelar";
            btn_excluirMotorista.Enabled = true;

            btn_editarMotorista.Enabled = false;
            btn_buscarMotorista.Enabled = false;
            btn_LimparMotorista.Enabled = false;
        }

        private void EntrarModoEdicaoRota()
        {
            modoEdicao = true;

            LiberarCamposRota();

            btn_salvarRota.Enabled = true;

            btn_excluirRota.Text = "Cancelar";
            btn_excluirRota.Enabled = true;

            btn_editarRota.Enabled = false;
            btn_buscarRota.Enabled = false;
            btn_LimparRota.Enabled = false;
        }

        private void EntrarModoEdicaoCombustivel()
        {
            modoEdicao = true;

            LiberarCamposCombustivel();

            btn_salvarPreco.Enabled = true;

            btn_excluirPreco.Text = "Cancelar";
            btn_excluirPreco.Enabled = true;

            btn_editarPreco.Enabled = false;
            btn_buscarPreco.Enabled = false;
            btn_LimparPreco.Enabled = false;
        }

        private void SairModoEdicaoVeiculo()
        {
            modoEdicao = false;

            BloquearCamposVeiculo();

            btn_excluirVeiculo.Text = "Excluir";

            btn_salvarVeiculo.Enabled = true;
            btn_excluirVeiculo.Enabled = true;
            btn_editarVeiculo.Enabled = true;
            btn_buscarVeiculo.Enabled = true;
            btn_LimparVeiculo.Enabled = true;

            txt_Modelo.Enabled = false;
            txt_Placa.Enabled = false;
            txt_Consumo.Enabled = false;
            txt_Carga.Enabled = false;
        }

        private void SairModoEdicaoMotorista()
        {
            modoEdicao = false;

            BloquearCamposMotorista();

            btn_excluirMotorista.Text = "Excluir";

            btn_salvarMotorista.Enabled = true;
            btn_excluirMotorista.Enabled = true;
            btn_editarMotorista.Enabled = true;
            btn_buscarMotorista.Enabled = true;
            btn_LimparMotorista.Enabled = true;

            txt_NomeMotorista.Enabled = false;
            txt_cnh.Enabled = false;
            txt_Telefone.Enabled = false;
        }

        private void SairModoEdicaoRota()
        {
            modoEdicao = false;

            BloquearCamposRota();

            btn_excluirRota.Text = "Excluir";

            btn_salvarRota.Enabled = true;
            btn_excluirRota.Enabled = true;
            btn_editarRota.Enabled = true;
            btn_buscarRota.Enabled = true;
            btn_LimparRota.Enabled = true;

            txt_origemRota.Enabled = false;
            txt_destinoRota.Enabled = false;
            txt_distanciaRota.Enabled = false;
        }

        private void SairModoEdicaoCombustivel()
        {
            modoEdicao = false;

            BloquearCamposCombustivel();

            btn_excluirPreco.Text = "Excluir";

            btn_salvarPreco.Enabled = true;
            btn_excluirPreco.Enabled = true;
            btn_editarPreco.Enabled = true;
            btn_buscarPreco.Enabled = true;
            btn_LimparPreco.Enabled = true;

            cmb_combustivel.Enabled = false;
            txt_precoCombustivel.Enabled = false;
            dateTimeCombustivel.Enabled = false;
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

                        SairModoEdicaoVeiculo();

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

                        LimparCamposVeiculo();

                        idVeiculoSelecionado = 0;

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

                BloquearCamposVeiculo();

            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message);
            }
        }

        private void btn_buscarVeiculo_Click(object sender, EventArgs e)
        {
            CarregarVeiculos();
            SairModoEdicaoVeiculo();
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

            EntrarModoEdicaoVeiculo();

        }

        private void btn_excluirVeiculo_Click(object sender, EventArgs e)
        {
            if (modoEdicao)
            {
                SairModoEdicaoVeiculo();

                LimparCamposVeiculo();

                idVeiculoSelecionado = 0;

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

                    LimparCamposVeiculo();

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
            LimparCamposVeiculo();

            idVeiculoSelecionado = 0;

            dataGrid_Veiculo.DataSource = null;

            modoEdicao = false;

            btn_excluirVeiculo.Text = "Excluir";

            LiberarCamposVeiculo();

            txt_Modelo.Focus();
        }

        private void btn_salvarMotorista_Click(object sender, EventArgs e)
        {
            try
            {
                using (MySqlConnection banco = new MySqlConnection(Conexao.ConexaoString))
                {
                    banco.Open();

                    if (modoEdicao)
                    {
                        string sql = @"
                            UPDATE Motorista
                            SET
                                Nome = @nome,
                                Cnh = @cnh,
                                Telefone = @telefone
                            WHERE MotoristaID = @ID";

                        MySqlCommand comando = new MySqlCommand(sql, banco);

                        comando.Parameters.AddWithValue("@ID", idMotoristaSelecionado);
                        comando.Parameters.AddWithValue("@nome", txt_NomeMotorista.Text);
                        comando.Parameters.AddWithValue("@cnh", txt_cnh.Text);
                        comando.Parameters.AddWithValue("@telefone", txt_Telefone.Text);

                        comando.ExecuteNonQuery();

                        MessageBox.Show("Motorista atualizado com sucesso.");

                        CarregarMotoristas();

                        SairModoEdicaoMotorista();

                    }
                    else
                    {
                        string sql = @"
                            INSERT INTO motorista
                            (nome, cnh, telefone)
                            VALUES
                            (@nome, @cnh, @telefone)";

                        MySqlCommand comando = new MySqlCommand(sql, banco);

                        comando.Parameters.AddWithValue("@ID", idMotoristaSelecionado);
                        comando.Parameters.AddWithValue("@nome", txt_NomeMotorista.Text);
                        comando.Parameters.AddWithValue("@cnh", txt_cnh.Text);
                        comando.Parameters.AddWithValue("@telefone", txt_Telefone.Text);

                        comando.ExecuteNonQuery();

                        LimparCamposMotorista();

                        idMotoristaSelecionado = 0;

                        txt_NomeMotorista.Focus();

                        MessageBox.Show(
                            "Motorista cadastrado com sucesso!",
                            "Sucesso",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);

                        CarregarMotoristas();

                    }

                }

                modoEdicao = false;

                BloquearCamposMotorista();

            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message);
            }
        }

        private void btn_editarMotorista_Click(object sender, EventArgs e)
        {
            CarregarMotoristas();

            if (idMotoristaSelecionado == 0)
            {
                MessageBox.Show("Selecione um motorista.");
                return;
            }

            EntrarModoEdicaoMotorista();
        }

        private void btn_buscar_Click(object sender, EventArgs e)
        {
            CarregarMotoristas();
            SairModoEdicaoMotorista();
        }

        private void btn_excluirMotorista_Click(object sender, EventArgs e)
        {
            if (modoEdicao)
            {
                SairModoEdicaoMotorista();

                LimparCamposMotorista();

                idMotoristaSelecionado = 0;

                return;
            }

            if (idMotoristaSelecionado == 0)
            {
                MessageBox.Show("Selecione um motorista para excluir.");
                return;
            }

            DialogResult resultado = MessageBox.Show(
                "Deseja realmente excluir este motorista?",
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
                            "DELETE FROM motorista WHERE MotoristaID = @ID";

                        MySqlCommand comando = new MySqlCommand(sql, banco);

                        comando.Parameters.AddWithValue("@ID", idMotoristaSelecionado);

                        comando.ExecuteNonQuery();
                    }

                    MessageBox.Show("Motorista excluído com sucesso!");

                    LimparCamposMotorista();

                    CarregarMotoristas();

                    idMotoristaSelecionado = 0;
                }
                catch (Exception erro)
                {
                    MessageBox.Show("Erro ao excluir: " + erro.Message);
                }
            }
        }

        private void btn_LimparMotorista_Click(object sender, EventArgs e)
        {
            LimparCamposMotorista();

            idMotoristaSelecionado = 0;

            dataGrid_Motorista.DataSource = null;

            modoEdicao = false;

            btn_excluirMotorista.Text = "Excluir";

            LiberarCamposMotorista();

            txt_NomeMotorista.Focus();
        }

        private void dataGrid_Motorista_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow linha = dataGrid_Motorista.Rows[e.RowIndex];

                txt_MotoristaID.Text = linha.Cells["MotoristaID"].Value.ToString();
                txt_NomeMotorista.Text = linha.Cells["Nome"].Value.ToString();
                txt_cnh.Text = linha.Cells["cnh"].Value.ToString();
                txt_Telefone.Text = linha.Cells["Telefone"].Value.ToString();


                idMotoristaSelecionado = Convert.ToInt32(
                    linha.Cells["MotoristaID"].Value);
            }
        }

        private void btn_salvarRota_Click(object sender, EventArgs e)
        {
            try
            {
                using (MySqlConnection banco = new MySqlConnection(Conexao.ConexaoString))
                {
                    banco.Open();

                    if (modoEdicao)
                    {
                        string sql = @"
                            UPDATE Rota
                            SET
                                Origem = @origem,
                                Destino = @destino,
                                Distancia = @distancia
                            WHERE RotaID = @ID";

                        MySqlCommand comando = new MySqlCommand(sql, banco);

                        comando.Parameters.AddWithValue("@ID", idRotaSelecionada);
                        comando.Parameters.AddWithValue("@origem", txt_origemRota.Text);
                        comando.Parameters.AddWithValue("@destino", txt_destinoRota.Text);
                        comando.Parameters.AddWithValue("@distancia", Convert.ToDecimal(txt_distanciaRota.Text));

                        comando.ExecuteNonQuery();

                        MessageBox.Show("Rota atualizada com sucesso.");

                        CarregarRota();

                        SairModoEdicaoRota();

                    }
                    else
                    {
                        string sql = @"
                            INSERT INTO rota
                            (origem, destino, distancia)
                            VALUES
                            (@origem, @destino, @distancia)";

                        MySqlCommand comando = new MySqlCommand(sql, banco);

                        comando.Parameters.AddWithValue("@ID", idRotaSelecionada);
                        comando.Parameters.AddWithValue("@origem", txt_origemRota.Text);
                        comando.Parameters.AddWithValue("@destino", txt_destinoRota.Text);
                        comando.Parameters.AddWithValue("@distancia", txt_distanciaRota.Text);

                        comando.ExecuteNonQuery();

                        LimparCamposRota();

                        idRotaSelecionada = 0;

                        txt_origemRota.Focus();

                        MessageBox.Show(
                            "Rota cadastrada com sucesso!",
                            "Sucesso",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);

                        CarregarRota();

                    }

                }

                modoEdicao = false;

                BloquearCamposRota();

            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message);
            }
        }

        private void btn_editarRota_Click(object sender, EventArgs e)
        {
            CarregarRota();

            if (idRotaSelecionada == 0)
            {
                MessageBox.Show("Selecione uma rota.");
                return;
            }

            EntrarModoEdicaoRota();
        }

        private void btn_buscarRota_Click(object sender, EventArgs e)
        {
            CarregarRota();
            SairModoEdicaoRota();
        }

        private void btn_excluirRota_Click(object sender, EventArgs e)
        {
            if (modoEdicao)
            {
                SairModoEdicaoRota();

                LimparCamposRota();

                idRotaSelecionada = 0;

                return;
            }

            if (idRotaSelecionada == 0)
            {
                MessageBox.Show("Selecione uma rota para excluir.");
                return;
            }

            DialogResult resultado = MessageBox.Show(
                "Deseja realmente excluir esta rota?",
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
                            "DELETE FROM rota WHERE RotaID = @ID";

                        MySqlCommand comando = new MySqlCommand(sql, banco);

                        comando.Parameters.AddWithValue("@ID", idRotaSelecionada);

                        comando.ExecuteNonQuery();
                    }

                    MessageBox.Show("Rota excluída com sucesso!");

                    LimparCamposRota();

                    CarregarRota();

                    idRotaSelecionada = 0;
                }
                catch (Exception erro)
                {
                    MessageBox.Show("Erro ao excluir: " + erro.Message);
                }
            }
        }
        

        private void btn_LimparRota_Click(object sender, EventArgs e)
        {
            LimparCamposRota();

            idRotaSelecionada = 0;

            dataGrid_Rota.DataSource = null;

            modoEdicao = false;

            btn_excluirRota.Text = "Excluir";

            LiberarCamposRota();

            txt_origemRota.Focus();
        }

        private void dataGrid_Rota_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow linha = dataGrid_Rota.Rows[e.RowIndex];

                txt_rotaID.Text = linha.Cells["RotaID"].Value.ToString();
                txt_origemRota.Text = linha.Cells["Origem"].Value.ToString();
                txt_destinoRota.Text = linha.Cells["Destino"].Value.ToString();
                txt_distanciaRota.Text = linha.Cells["Distancia"].Value.ToString();


                idRotaSelecionada = Convert.ToInt32(
                    linha.Cells["RotaID"].Value);
            }
        }

        private void btn_salvarPreco_Click(object sender, EventArgs e)
        {
            try
            {
                using (MySqlConnection banco = new MySqlConnection(Conexao.ConexaoString))
                {
                    banco.Open();

                    if (modoEdicao)
                    {
                        string sql = @"
                            UPDATE Preco_combustivel
                            SET
                                Combustivel = @combustivel,
                                Preco = @preco,
                                Data_consulta = @data
                            WHERE PrecoID = @ID";

                        MySqlCommand comando = new MySqlCommand(sql, banco);

                        comando.Parameters.AddWithValue("@ID", idPrecoSelecionado);
                        comando.Parameters.AddWithValue("@combustivel", cmb_combustivel.Text);
                        comando.Parameters.AddWithValue("@preco", Convert.ToDecimal(txt_precoCombustivel.Text));
                        comando.Parameters.AddWithValue("@data", dateTimeCombustivel.Value);

                        comando.ExecuteNonQuery();

                        MessageBox.Show("Preço do combustivel atualizado com sucesso.");

                        CarregarCombustivel();

                        SairModoEdicaoCombustivel();

                    }
                    else
                    {
                        string sql = @"
                            INSERT INTO preco_combustivel
                            (combustivel, preco, data_consulta)
                            VALUES
                            (@combustivel, @preco, @data)";

                        MySqlCommand comando = new MySqlCommand(sql, banco);

                        comando.Parameters.AddWithValue("@ID", idPrecoSelecionado);
                        comando.Parameters.AddWithValue("@combustivel", cmb_combustivel.Text);
                        comando.Parameters.AddWithValue("@preco", txt_precoCombustivel.Text);
                        comando.Parameters.AddWithValue("@data", dateTimeCombustivel.Value);

                        comando.ExecuteNonQuery();

                        LimparCamposCombustivel();

                        idPrecoSelecionado = 0;

                        cmb_combustivel.Focus();

                        MessageBox.Show(
                            "Preço do combustivel cadastrado com sucesso!",
                            "Sucesso",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);

                        CarregarCombustivel();

                    }

                }

                modoEdicao = false;

                BloquearCamposCombustivel();

            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message);
            }
        }

        private void btn_editarPreco_Click(object sender, EventArgs e)
        {
            CarregarCombustivel();

            if (idPrecoSelecionado == 0)
            {
                MessageBox.Show("Selecione um Combustivel.");
                return;
            }

            EntrarModoEdicaoCombustivel();
        }

        private void btn_buscarPreco_Click(object sender, EventArgs e)
        {
            CarregarCombustivel();
            SairModoEdicaoCombustivel();
        }

        private void btn_excluirPreco_Click(object sender, EventArgs e)
        {
            if (modoEdicao)
            {
                SairModoEdicaoCombustivel();

                LimparCamposCombustivel();

                idPrecoSelecionado = 0;

                return;
            }

            if (idPrecoSelecionado == 0)
            {
                MessageBox.Show("Selecione um combustivel para excluir.");
                return;
            }

            DialogResult resultado = MessageBox.Show(
                "Deseja realmente excluir este combustivel?",
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
                            "DELETE FROM preco_combustivel WHERE precoID = @ID";

                        MySqlCommand comando = new MySqlCommand(sql, banco);

                        comando.Parameters.AddWithValue("@ID", idPrecoSelecionado);

                        comando.ExecuteNonQuery();
                    }

                    MessageBox.Show("Combustivel excluída com sucesso!");

                    LimparCamposCombustivel();

                    CarregarCombustivel();

                    idPrecoSelecionado = 0;
                }
                catch (Exception erro)
                {
                    MessageBox.Show("Erro ao excluir: " + erro.Message);
                }
            }
        }

        private void btn_LimparPreco_Click(object sender, EventArgs e)
        {
            LimparCamposCombustivel();

            idPrecoSelecionado = 0;

            dataGrid_Combustivel.DataSource = null;

            modoEdicao = false;

            btn_excluirPreco.Text = "Excluir";

            LiberarCamposCombustivel();

            cmb_combustivel.Focus();
        }

        private void dataGrid_Combustivel_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow linha = dataGrid_Combustivel.Rows[e.RowIndex];

                txt_combustivelID.Text = linha.Cells["PrecoID"].Value.ToString();
                cmb_combustivel.Text = linha.Cells["Combustivel"].Value.ToString();
                txt_precoCombustivel.Text = linha.Cells["Preco"].Value.ToString();
                dateTimeCombustivel.Value = Convert.ToDateTime(linha.Cells["Data_consulta"].Value);


                idPrecoSelecionado = Convert.ToInt32(
                    linha.Cells["PrecoID"].Value);
            }
        }
    }
}


