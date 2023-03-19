using System;
using System.Data;
using System.Reflection;
using System.Runtime.ConstrainedExecution;
using System.Text.RegularExpressions;
using MySql.Data.MySqlClient;


namespace WebApplicationStandAuto.Models
{
    public class comprasContext
    {

        //Está no AppSettings.json e é onde se encontra as informações para conectar com a base de dados.
        public string ConnectionString { get; set; }

        //Construtor recebe como parametro a connection String.
        public comprasContext()
        {
            this.ConnectionString = "server=localhost;port=3306;database=standauto;user=root;password=Abc123";
        }

        private MySqlConnection GetConnection()
        {
            return new MySqlConnection(ConnectionString);
        }


        //Obter Compras ou Automóveis para compra
        public List<compras> GetAllcompras()
        {
            List<compras> comprasList = new List<compras>();

            using (MySqlConnection conn = GetConnection())
            {
                //Abrir a ligação
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM compras;", conn);
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        comprasList.Add(new compras()
                        {
                            idCompras = reader.GetInt32("idCompras"),
                            marca = reader.GetString("marca"),
                            modelo = reader.GetString("modelo"),
                            ano = reader.GetInt32("ano"),
                            cor = reader.GetString("cor"),
                            fonte_energia = reader.GetString("fonte_energia"),
                            matricula = reader.GetString("matricula"),
                            quilometros = reader.GetInt32("quilometros"),
                            preco = reader.GetDecimal("preco")
                        });
                    }
                }
            }

            return comprasList;
        }

        //Obter os Automóveis em Stand.
        public List<stand> GetAllstand()
        {
            List<stand> standList = new List<stand>();

            using (MySqlConnection conn = GetConnection())
            {
                //Abrir a ligação
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM stand;", conn);
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        standList.Add(new stand()
                        {
                            idCarros= reader.GetInt32("idCarros"),
                            marca = reader.GetString("marca"),
                            modelo = reader.GetString("modelo"),
                            ano = reader.GetInt32("ano"),
                            cor = reader.GetString("cor"),
                            fonte_energia = reader.GetString("fonte_energia"),
                            matricula = reader.GetString("matricula"),
                            preco_compra = reader.GetDecimal("preco_compra"),
                            data_compra = reader.GetDateTime("data_compra"),
                            quilometros = reader.GetInt32("quilometros"),
                            preco_venda = reader.GetDecimal("preco_venda")
                        });
                    }
                }
            }

            return standList;
        }

        //Obter os Automóveis vendidos para vendas.
        public List<vendas> GetAllvendas()
        {
            List<vendas> vendasList = new List<vendas>();

            using (MySqlConnection conn = GetConnection())
            {
                //Abrir a ligação
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM vendas;", conn);
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        vendasList.Add(new vendas()
                        {
                            idVendas = reader.GetInt32("idVendas"),
                            marca = reader.GetString("marca"),
                            modelo = reader.GetString("modelo"),
                            ano = reader.GetInt32("ano"),
                            cor = reader.GetString("cor"),
                            fonte_energia = reader.GetString("fonte_energia"),
                            matricula = reader.GetString("matricula"),
                            quilometros = reader.GetInt32("quilometros"),
                            preco_compra = reader.GetDecimal("preco_compra"),
                            preco_venda = reader.GetDecimal("preco_venda"),
                            data_compra = reader.GetDateTime("data_compra"),
                            data_venda = reader.GetDateTime("data_venda")
                        });
                    }
                }
            }

            return vendasList;
        }

        //Obter os Automóveis vendidos com contabilidade.
        public List<contabilidade> GetAllcontabilidade()
        {
            List<contabilidade> contabilidadeList = new List<contabilidade>();

            using (MySqlConnection conn = GetConnection())
            {
                //Abrir a ligação
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM contabilidade;", conn);
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        contabilidadeList.Add(new contabilidade()
                        {
                            idc = reader.GetInt32("idc"),
                            marca = reader.GetString("marca"),
                            modelo = reader.GetString("modelo"),
                            ano = reader.GetInt32("ano"),                         
                            matricula = reader.GetString("matricula"),                          
                            preco_compra = reader.GetDecimal("preco_compra"),
                            preco_venda = reader.GetDecimal("preco_venda"),
                            lucro_carro = reader.GetDecimal("lucro_carro"),
                            data_compra = reader.GetDateTime("data_compra"),
                            data_venda = reader.GetDateTime("data_venda"),
                            tempo_stand = reader.GetInt32("tempo_stand")
                        });
                    }
                }
            }

            return contabilidadeList;
        }

        public void UpdateStand(stand stand)
        {

            using (MySqlConnection conn = GetConnection())
            {
                //Abrir a ligação
                conn.Open();

                //Query
                MySqlCommand cmd = new MySqlCommand("UPDATE stand SET marca=@marca, modelo=@modelo, ano=@ano, cor=@cor, fonte_energia=@fonte_energia, matricula=@matricula, preco_compra=@preco_compra,  quilometros=@quilometros, preco_venda=@preco_venda WHERE idCarros = @idCarros;", conn);

                cmd.Parameters.AddWithValue("@idCarros", stand.idCarros);
                cmd.Parameters.AddWithValue("@marca", stand.marca);
                cmd.Parameters.AddWithValue("@modelo", stand.modelo);
                cmd.Parameters.AddWithValue("@ano", stand.ano);
                cmd.Parameters.AddWithValue("@cor", stand.cor);
                cmd.Parameters.AddWithValue("@fonte_energia", stand.fonte_energia);
                cmd.Parameters.AddWithValue("@matricula", stand.matricula);
                cmd.Parameters.AddWithValue("@preco_compra", stand.preco_compra);
                cmd.Parameters.AddWithValue("@quilometros", stand.quilometros);
                cmd.Parameters.AddWithValue("@preco_venda", stand.preco_venda);

                cmd.ExecuteNonQuery();

                conn.Close();

            }
        }

        //Operação CRUD - Delete Stand
        public void deleteStand(int IDC)
        {

            using (MySqlConnection conn = GetConnection())
            {
                //Abrir a ligação
                conn.Open();

                //Query
                MySqlCommand cmd = new MySqlCommand("DELETE FROM stand WHERE idCarros = @IDC;", conn);

                cmd.Parameters.AddWithValue("IDC", IDC);

                if (cmd.ExecuteNonQuery() == 0)
                {
                    throw new Exception("Não foi possível apagar");
                }

                conn.Close();

            }
        }



        //Operações CRUD - Create Stand
        public void createStand(stand Stand)
        {

            using (MySqlConnection conn = GetConnection())
            {
                //Abrir a ligação
                conn.Open();

                //Query
                MySqlCommand cmd = new MySqlCommand("INSERT INTO stand (marca, modelo, ano, cor, fonte_energia, matricula, preco_compra, data_compra, quilometros, preco_venda ) VALUES (@marca, @modelo ,@ano, @cor, @fonte_energia, @matricula, @preco_compra, @data_compra, @quilometros, @preco_venda);", conn);

                cmd.Parameters.AddWithValue("marca", Stand.marca);
                cmd.Parameters.AddWithValue("modelo", Stand.modelo);
                cmd.Parameters.AddWithValue("ano", Stand.ano);
                cmd.Parameters.AddWithValue("cor", Stand.cor);
                cmd.Parameters.AddWithValue("fonte_energia", Stand.fonte_energia);
                cmd.Parameters.AddWithValue("matricula", Stand.matricula);
                cmd.Parameters.AddWithValue("preco_compra", Stand.preco_compra);
                cmd.Parameters.AddWithValue("data_compra", Stand.data_compra);
                cmd.Parameters.AddWithValue("quilometros", Stand.quilometros);
                cmd.Parameters.AddWithValue("preco_venda", Stand.preco_venda);

                cmd.ExecuteNonQuery();

                conn.Close();

            }
        }

        //Operações CRUD - Adicionar as Vendas - (vender em Stand).
        public void create_vendas(vendas vendas)
        {

            using (MySqlConnection conn = GetConnection())
            {
                //Abrir a ligação
                conn.Open();

                //Query
                MySqlCommand cmd = new MySqlCommand("INSERT INTO vendas (marca, modelo, ano, cor, fonte_energia, matricula, quilometros, preco_compra, preco_venda, data_compra , data_venda ) VALUES (@marca, @modelo ,@ano, @cor, @fonte_energia, @matricula, @quilometros, @preco_compra, @preco_venda, @data_compra, @data_venda);", conn);

                //cmd.Parameters.AddWithValue("idVendas", vendas.idVendas);
                cmd.Parameters.AddWithValue("marca", vendas.marca);
                cmd.Parameters.AddWithValue("modelo", vendas.modelo);
                cmd.Parameters.AddWithValue("ano", vendas.ano);
                cmd.Parameters.AddWithValue("cor", vendas.cor);
                cmd.Parameters.AddWithValue("fonte_energia", vendas.fonte_energia);
                cmd.Parameters.AddWithValue("matricula", vendas.matricula);
                cmd.Parameters.AddWithValue("quilometros", vendas.quilometros);
                cmd.Parameters.AddWithValue("preco_compra", vendas.preco_compra);
                cmd.Parameters.AddWithValue("preco_venda", vendas.preco_venda);
                cmd.Parameters.AddWithValue("data_compra", vendas.data_compra);
                cmd.Parameters.AddWithValue("data_venda", vendas.data_venda);

                cmd.ExecuteNonQuery();

                conn.Close();

            }
        }

        //Operações CRUD - Adicionar a Stand- (Comprar).
        public void create_compra(stand stand)
        {

            using (MySqlConnection conn = GetConnection())
            {
                //Abrir a ligação
                conn.Open();

                //Query
                MySqlCommand cmd = new MySqlCommand("INSERT INTO stand (marca, modelo, ano, cor, fonte_energia, matricula, preco_compra, data_compra, quilometros, preco_venda ) VALUES (@marca, @modelo ,@ano, @cor, @fonte_energia, @matricula, @preco_compra, @data_compra, @quilometros, @preco_venda);", conn);

                //cmd.Parameters.AddWithValue("idCarros", stand.idCarros);
                cmd.Parameters.AddWithValue("marca", stand.marca);
                cmd.Parameters.AddWithValue("modelo", stand.modelo);
                cmd.Parameters.AddWithValue("ano", stand.ano);
                cmd.Parameters.AddWithValue("cor", stand.cor);
                cmd.Parameters.AddWithValue("fonte_energia", stand.fonte_energia);
                cmd.Parameters.AddWithValue("matricula", stand.matricula);
                cmd.Parameters.AddWithValue("preco_compra", stand.preco_compra);
                cmd.Parameters.AddWithValue("data_compra", stand.data_compra);
                cmd.Parameters.AddWithValue("quilometros", stand.quilometros);
                cmd.Parameters.AddWithValue("preco_venda", stand.preco_venda);
              
               

                cmd.ExecuteNonQuery();

                conn.Close();

            }
        }


        //Operação CRUD - Delete Compra
        public void deleteCompra(int IDC)
        {

            using (MySqlConnection conn = GetConnection())
            {
                //Abrir a ligação
                conn.Open();

                //Query
                MySqlCommand cmd = new MySqlCommand("DELETE FROM compras WHERE idCompras = @IDC;", conn);

                cmd.Parameters.AddWithValue("IDC", IDC);

                if (cmd.ExecuteNonQuery() == 0)
                {
                    throw new Exception("Não foi possível apagar");
                }

                conn.Close();

            }
        }


        // - Adicionar a contabilidade(Passar de tabela vendas para a tabela Contabilidade).
        public void create_Contabilidade(contabilidade contabilidade)
        {

            using (MySqlConnection conn = GetConnection())
            {
                //Abrir a ligação
                conn.Open();

                //Query
                MySqlCommand cmd = new MySqlCommand("INSERT INTO contabilidade (marca, modelo, ano, cor, fonte_energia, matricula, quilometros, preco_compra, preco_venda, lucro_carro, data_compra, data_venda, tempo_stand ) VALUES (@marca, @modelo ,@ano, @cor, @fonte_energia, @matricula,  @quilometros, @preco_compra,  @preco_venda, @lucro_carro, @data_compra, @data_venda, @tempo_stand);", conn);

                //cmd.Parameters.AddWithValue("idC", stand.idc);
                cmd.Parameters.AddWithValue("marca", contabilidade.marca);
                cmd.Parameters.AddWithValue("modelo", contabilidade.modelo);
                cmd.Parameters.AddWithValue("ano", contabilidade.ano);
                cmd.Parameters.AddWithValue("cor", contabilidade.cor);
                cmd.Parameters.AddWithValue("fonte_energia", contabilidade.fonte_energia);
                cmd.Parameters.AddWithValue("matricula", contabilidade.matricula);
                cmd.Parameters.AddWithValue("quilometros", contabilidade.quilometros);
                cmd.Parameters.AddWithValue("preco_compra", contabilidade.preco_compra);
                cmd.Parameters.AddWithValue("preco_venda", contabilidade.preco_venda);
                cmd.Parameters.AddWithValue("lucro_carro", contabilidade.lucro_carro);
                cmd.Parameters.AddWithValue("data_compra", contabilidade.data_compra);
                cmd.Parameters.AddWithValue("data_venda", contabilidade.data_venda);
                cmd.Parameters.AddWithValue("tempo_stand", contabilidade.tempo_stand);

                cmd.ExecuteNonQuery();

                conn.Close();

            }
        }


       
        //Obter o Lucro Total dos carros vendidos.
        public decimal GetLucro()
        {
             decimal Lucro=0;

            List<contabilidade> contabilidadeList = new List<contabilidade>();

            using (MySqlConnection conn = GetConnection())
            {
                //Abrir a ligação.
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM contabilidade;", conn);
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        contabilidadeList.Add(new contabilidade()
                        {
                            idc = reader.GetInt32("idc"),
                            marca = reader.GetString("marca"),
                            modelo = reader.GetString("modelo"),
                            ano = reader.GetInt32("ano"),
                            matricula = reader.GetString("matricula"),
                            preco_compra = reader.GetDecimal("preco_compra"),
                            preco_venda = reader.GetDecimal("preco_venda"),
                            lucro_carro = reader.GetDecimal("lucro_carro"),
                            data_compra = reader.GetDateTime("data_compra"),
                            data_venda = reader.GetDateTime("data_venda"),
                            tempo_stand = reader.GetInt32("tempo_stand")
                        });
                    }
                    foreach (var item in contabilidadeList){ 
                             Lucro += item.lucro_carro;
                    }
                }
            }
            return Lucro;
        }

        //Obter o Total Investido dos carros comprados.
        public decimal GetInvestido()
        {
            decimal investido = 0;

            List<contabilidade> contabilidadeList = new List<contabilidade>();

            using (MySqlConnection conn = GetConnection())
            {
                //Abrir a ligação
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM contabilidade;", conn);
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        contabilidadeList.Add(new contabilidade()
                        {
                            idc = reader.GetInt32("idc"),
                            marca = reader.GetString("marca"),
                            modelo = reader.GetString("modelo"),
                            ano = reader.GetInt32("ano"),
                            cor = "Nenhuma", 
                            fonte_energia = "Nenhuma",
                            matricula = reader.GetString("matricula"),
                            quilometros = 0, 
                            preco_compra = reader.GetDecimal("preco_compra"),
                            preco_venda = reader.GetDecimal("preco_venda"),
                            lucro_carro = reader.GetDecimal("lucro_carro"),
                            data_compra = reader.GetDateTime("data_compra"),
                            data_venda = reader.GetDateTime("data_venda"),
                            tempo_stand = reader.GetInt32("tempo_stand")
                        });  ;
                    }
                    foreach (var item in contabilidadeList)
                    {
                        investido += item.preco_compra;
                    }
                }
            }
            return investido;
        }

        //Obter o Total Recebido dos carros vendidos.
        public decimal GetRecebido()
        {
            decimal recebido = 0;

            List<contabilidade> contabilidadeList = new List<contabilidade>();

            using (MySqlConnection conn = GetConnection())
            {
                //Abrir a ligação
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT idc, marca, modelo, ano, matricula, preco_compra, preco_venda, lucro_carro, data_compra, data_venda, tempo_stand FROM contabilidade;", conn);
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        contabilidadeList.Add(new contabilidade()
                        {
                            idc = reader.GetInt32("idc"),
                            marca = reader.GetString("marca"),
                            modelo = reader.GetString("modelo"),
                            ano = reader.GetInt32("ano"),   
                            matricula = reader.GetString("matricula"),                        
                            preco_compra = reader.GetDecimal("preco_compra"),
                            preco_venda = reader.GetDecimal("preco_venda"),
                            lucro_carro = reader.GetDecimal("lucro_carro"),
                            data_compra = reader.GetDateTime("data_compra"),
                            data_venda = reader.GetDateTime("data_venda"),
                            tempo_stand = reader.GetInt32("tempo_stand")
                        });
                    }
                    foreach (var item in contabilidadeList)
                    {
                        recebido += item.preco_venda;
                    }
                }
            }
            return recebido;
        }

        //Operação CRUD - Delete Vendas
        public void deleteVendas(int IDC)
        {

            using (MySqlConnection conn = GetConnection())
            {
                //Abrir a ligação
                conn.Open();

                //Query
                MySqlCommand cmd = new MySqlCommand("DELETE FROM vendas WHERE idVendas = @IDC;", conn);

                cmd.Parameters.AddWithValue("IDC", IDC);

                if (cmd.ExecuteNonQuery() == 0)
                {
                    throw new Exception("Não foi possível apagar");
                }

                conn.Close();

            }
        }

        //Operação CRUD - Delete Vendas
        public void deleteContabilidade(int IDC)
        {

            using (MySqlConnection conn = GetConnection())
            {
                //Abrir a ligação
                conn.Open();

                //Query
                MySqlCommand cmd = new MySqlCommand("DELETE FROM contabilidade WHERE idc = @IDC;", conn);

                cmd.Parameters.AddWithValue("IDC", IDC);

                if (cmd.ExecuteNonQuery() == 0)
                {
                    throw new Exception("Não foi possível apagar");
                }

                conn.Close();

            }
        }

        // Pesquisa por Marca em Compras.
        public List<compras> searchByMarca(string Brand)
        {

            List<compras> comprasList = new List<compras>();

            using (MySqlConnection conn = GetConnection())
            {
                //Abrir a ligação
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM compras WHERE marca LIKE CONCAT('%',@Brand,'%');", conn);

                cmd.Parameters.AddWithValue("Brand", Brand);

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        comprasList.Add(new compras()
                        {
                            idCompras = reader.GetInt32("idCompras"),
                            marca = reader.GetString("marca"),
                            modelo = reader.GetString("modelo"),
                            ano = reader.GetInt32("ano"),
                            cor = reader.GetString("cor"),
                            fonte_energia = reader.GetString("fonte_energia"),
                            matricula = reader.GetString("matricula"),
                            quilometros = reader.GetInt32("quilometros"),
                            preco = reader.GetDecimal("preco"),
                        });
                        
                    }
                }
            }

            return comprasList;
        }

        // Pesquisa por Modelo em Compras.
        public List<compras> searchByModelo(string Model)
        {

            List<compras> comprasList = new List<compras>();

            using (MySqlConnection conn = GetConnection())
            {
                //Abrir a ligação
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM compras WHERE modelo LIKE CONCAT('%',@Model,'%');", conn);

                cmd.Parameters.AddWithValue("Model", Model);

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        comprasList.Add(new compras()
                        {
                            idCompras = reader.GetInt32("idCompras"),
                            marca = reader.GetString("marca"),
                            modelo = reader.GetString("modelo"),
                            ano = reader.GetInt32("ano"),
                            cor = reader.GetString("cor"),
                            fonte_energia = reader.GetString("fonte_energia"),
                            matricula = reader.GetString("matricula"),
                            quilometros = reader.GetInt32("quilometros"),
                            preco = reader.GetDecimal("preco"),
                        });

                    }
                }
            }

            return comprasList;
        }


        // Pesquisa por ano em Compras.
        public List<compras> searchByAno2(int Yearano)
        {

            List<compras> comprasList = new List<compras>();

            using (MySqlConnection conn = GetConnection())
            {
                //Abrir a ligação
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM compras WHERE ano <= @Yearano;", conn);
                cmd.Parameters.AddWithValue("Yearano", Yearano);

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        comprasList.Add(new compras()
                        {
                            idCompras = reader.GetInt32("idCompras"),
                            marca = reader.GetString("marca"),
                            modelo = reader.GetString("modelo"),
                            ano = reader.GetInt32("ano"),
                            cor = reader.GetString("Cor"),
                            fonte_energia = reader.GetString("fonte_energia"),
                            matricula = reader.GetString("matricula"),
                            quilometros = reader.GetInt32("quilometros"),
                            preco = reader.GetDecimal("preco"),
                        });
                       
                    }
                }
            }

            return comprasList;
        }


        // Pesquisa por Cor em Compras.
        public List<compras> searchByCor(string Color)
        {

            List<compras> comprasList = new List<compras>();

            using (MySqlConnection conn = GetConnection())
            {
                //Abrir a ligação
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM compras WHERE cor LIKE CONCAT('%',@Color,'%');", conn);

                cmd.Parameters.AddWithValue("Color", Color);

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        comprasList.Add(new compras()
                        {
                            idCompras = reader.GetInt32("idCompras"),
                            marca = reader.GetString("marca"),
                            modelo = reader.GetString("modelo"),
                            ano = reader.GetInt32("ano"),
                            cor = reader.GetString("cor"),
                            fonte_energia = reader.GetString("fonte_energia"),
                            matricula = reader.GetString("matricula"),
                            quilometros = reader.GetInt32("quilometros"),
                            preco = reader.GetDecimal("preco"),
                        });

                    }
                }
            }

            return comprasList;
        }

        // Pesquisa por Fonte de energia em Compras.
        public List<compras> searchByFonte(string Energy)
        {

            List<compras> comprasList = new List<compras>();

            using (MySqlConnection conn = GetConnection())
            {
                //Abrir a ligação
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM compras WHERE fonte_energia LIKE CONCAT('%',@Energy,'%');", conn);

                cmd.Parameters.AddWithValue("Energy", Energy);

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        comprasList.Add(new compras()
                        {
                            idCompras = reader.GetInt32("idCompras"),
                            marca = reader.GetString("marca"),
                            modelo = reader.GetString("modelo"),
                            ano = reader.GetInt32("ano"),
                            cor = reader.GetString("cor"),
                            fonte_energia = reader.GetString("fonte_energia"),
                            matricula = reader.GetString("matricula"),
                            quilometros = reader.GetInt32("quilometros"),
                            preco = reader.GetDecimal("preco"),
                        });

                    }
                }
            }

            return comprasList;
        }

        // Pesquisa por Matricula em Compras.
        public List<compras> searchByMatricula(string Registration)
        {

            List<compras> comprasList = new List<compras>();

            using (MySqlConnection conn = GetConnection())
            {
                //Abrir a ligação
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM compras WHERE matricula LIKE @Registration;", conn);

                cmd.Parameters.AddWithValue("Registration", Registration);

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        comprasList.Add(new compras()
                        {
                            idCompras = reader.GetInt32("idCompras"),
                            marca = reader.GetString("marca"),
                            modelo = reader.GetString("modelo"),
                            ano = reader.GetInt32("ano"),
                            cor = reader.GetString("cor"),
                            fonte_energia = reader.GetString("fonte_energia"),
                            matricula = reader.GetString("matricula"),
                            quilometros = reader.GetInt32("quilometros"),
                            preco = reader.GetDecimal("preco"),
                        });

                    }
                }
            }

            return comprasList;
        }


        // Pesquisa por Quilómetros em Compras.
        public List<compras> searchByKM(int KM)
        {

            List<compras> comprasList = new List<compras>();

            using (MySqlConnection conn = GetConnection())
            {
                //Abrir a ligação
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM compras WHERE quilometros <= @KM;", conn);

                cmd.Parameters.AddWithValue("KM", KM);

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        comprasList.Add(new compras()
                        {
                            idCompras = reader.GetInt32("idCompras"),
                            marca = reader.GetString("marca"),
                            modelo = reader.GetString("modelo"),
                            ano = reader.GetInt32("ano"),
                            cor = reader.GetString("cor"),
                            fonte_energia = reader.GetString("fonte_energia"),
                            matricula = reader.GetString("matricula"),
                            quilometros = reader.GetInt32("quilometros"),
                            preco = reader.GetDecimal("preco"),
                        });

                    }
                }
            }

            return comprasList;
        }

        // Pesquisa por Preço em Compras.
        public List<compras> searchByPreco(decimal Price)
        {

            List<compras> comprasList = new List<compras>();

            using (MySqlConnection conn = GetConnection())
            {
                //Abrir a ligação
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM compras WHERE preco <= @Price;", conn);

                cmd.Parameters.AddWithValue("Price", Price);

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        comprasList.Add(new compras()
                        {
                            idCompras = reader.GetInt32("idCompras"),
                            marca = reader.GetString("marca"),
                            modelo = reader.GetString("modelo"),
                            ano = reader.GetInt32("ano"),
                            cor = reader.GetString("cor"),
                            fonte_energia = reader.GetString("fonte_energia"),
                            matricula = reader.GetString("matricula"),
                            quilometros = reader.GetInt32("quilometros"),
                            preco = reader.GetDecimal("preco"),
                        });

                    }
                }
            }

            return comprasList;
        }

    }
}
