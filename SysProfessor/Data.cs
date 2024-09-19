using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Drawing;
using System.Xml.Linq;
using System.Data.SqlTypes;

namespace SysProfessor
{
    internal class Data
    {
        //------------------------------------- máterias -------------------------------------

        //método mostrar materias
        public static DataTable ShowDisciplines()
        {
            // Objeto do tipo DataTable
            DataTable DtResultado = new DataTable("discliplines");

            // Objeto da conexão com o banco de dados
            using (SqlConnection sqlCon = new SqlConnection(Connection.Cn))
            {
                try
                {
                    // Abrindo a conexão ao banco de dados
                    sqlCon.Open();

                    // Comando SQL - que está no banco de dados
                    using (SqlCommand sqlCmd = new SqlCommand("spshow_discipline", sqlCon))
                    {
                        //Define o tipo de comando como StoredProcedure, 
                        //o que indica que estamos chamando um procedimento armazenado no banco de dados.
                        sqlCmd.CommandType = CommandType.StoredProcedure;

                        // Objeto que vai guardar informações da tabela
                        using (SqlDataAdapter sqlDat = new SqlDataAdapter(sqlCmd))
                        {
                            // Preenchendo o DataTable
                            sqlDat.Fill(DtResultado);
                        }
                    }
                }
                catch (Exception ex)
                {
                    DtResultado = null;
                    Debug.WriteLine("Exception: " + ex);
                }
            }

            return DtResultado;
        }

        //método pesquisar uma materia
        public static DataTable SearchDiscipline(string name)
        {
            // Objeto do tipo DataTable
            DataTable DtResultado = new DataTable("discipline");

            // Objeto da conexão com o banco de dados
            using (SqlConnection SqlCon = new SqlConnection(Connection.Cn))
            {
                try
                {
                    // Abrindo a conexão ao banco de dados
                    SqlCon.Open();

                    // Configurando o comando SQL
                    using (SqlCommand sqlCmd = new SqlCommand("spsearch_discipline_name", SqlCon))
                    {
                        sqlCmd.CommandType = CommandType.StoredProcedure;

                        // Adicionando o parâmetro ao comando SQL
                        SqlParameter ParTextSearch = new SqlParameter
                        {
                            ParameterName = "@name", //Nome do parâmetro no procedimento armazenado. nome da variavel no sql
                            SqlDbType = SqlDbType.VarChar, //Define o tipo de dados como VARCHAR no banco de dados.
                            Size = 100, //Define o tamanho do VARCHAR (50 caracteres).
                            Value = (object)name ?? DBNull.Value // Usando DBNull.Value para valores nulos
                                                                 //O valor do parâmetro, que pode ser o texto a ser buscado. Usa DBNull.Value para valores nulos
                        };
                        sqlCmd.Parameters.Add(ParTextSearch);

                        // Criando o DataAdapter
                        using (SqlDataAdapter sqlDat = new SqlDataAdapter(sqlCmd))
                        {
                            // Preenchendo o DataTable
                            sqlDat.Fill(DtResultado);
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Log ou tratamento da exceção pode ser adicionado aqui
                    // Exemplo: Console.WriteLine(ex.Message);
                    DtResultado = null;
                }
            }
            return DtResultado;
        }

        //método inserir materia
        public static string InsertDiscipline(string name, decimal average)
        {
            string resp = "";

            // Cria uma conexão com o banco de dados e garante que ela será fechada e liberada corretamente após o uso.
            using (SqlConnection sqlCon = new SqlConnection(Connection.Cn))
            {
                try
                {
                    // Abrindo conexão
                    sqlCon.Open();

                    // Cria um comando SQL que vai chamar uma stored procedure
                    using (SqlCommand sqlCmd = new SqlCommand("sp_insert_discipline_and_scores", sqlCon))
                    {
                        sqlCmd.CommandType = CommandType.StoredProcedure;

                        // Parâmetro para o nome do aluno
                        SqlParameter parName = new SqlParameter
                        {
                            ParameterName = "@name",
                            SqlDbType = SqlDbType.VarChar,
                            Size = 100,
                            Value = string.IsNullOrEmpty(name) ? (object)DBNull.Value : name
                        };
                        sqlCmd.Parameters.Add(parName);

                        // Parâmetro para a média minima para aprovação
                        SqlParameter parAverage = new SqlParameter
                        {
                            ParameterName = "@average",
                            SqlDbType = SqlDbType.Decimal,
                            Value = average
                        };
                        sqlCmd.Parameters.Add(parAverage);

                        // Executa o comando e verifica se a inserção foi bem-sucedida
                        int linhasAfetadas = sqlCmd.ExecuteNonQuery();
                        if (linhasAfetadas > 0)
                        {
                            resp = "Registro inserido com sucesso.";
                        }
                        else
                        {
                            resp = "Registro não inserido.";
                        }
                    }
                }
                catch (Exception ex)
                {
                    resp = $"Erro: {ex.Message}";
                }
            }

            return resp;
        }

        //método editar materia
        public static string EditDiscipline(int idDiscipline, string name, decimal average)
        {
            string resp = "";

            //Cria uma conexão com o banco de dados e garante que ela será fechada e liberada corretamente após o uso.
            using (SqlConnection sqlCon = new SqlConnection(Connection.Cn))
            {
                try
                {
                    //abrindo conexão
                    sqlCon.Open();

                    //cria um comando sql que vai chamar uma função que foi escrita no sql (stored procedure)
                    using (SqlCommand sqlCmd = new SqlCommand("spedit_discipline", sqlCon))
                    {
                        sqlCmd.CommandType = CommandType.StoredProcedure;

                        // Parâmetro de saída para o ID da nome
                        SqlParameter parIdDiscipline = new SqlParameter
                        {
                            ParameterName = "@iddiscipline",
                            SqlDbType = SqlDbType.Int,
                            Value = idDiscipline
                        };
                        sqlCmd.Parameters.Add(parIdDiscipline);

                        // Parâmetro para o nome do aluno
                        SqlParameter parName = new SqlParameter
                        {
                            ParameterName = "@name",
                            SqlDbType = SqlDbType.VarChar,
                            Size = 100,
                            Value = string.IsNullOrEmpty(name) ? (object)DBNull.Value : name
                        };
                        sqlCmd.Parameters.Add(parName);

                        // Parâmetro para a média minima para aprovação
                        SqlParameter parAverage = new SqlParameter
                        {
                            ParameterName = "@average",
                            SqlDbType = SqlDbType.Decimal,
                            Value = average
                        };
                        sqlCmd.Parameters.Add(parAverage);

                        // Executa o comando e verifica se a edição foi bem-sucedida
                        int linhasAfetadas = sqlCmd.ExecuteNonQuery();
                        if (linhasAfetadas == 1)
                        {
                            int id_Aluno = Convert.ToInt32(parIdDiscipline.Value);
                            resp = $"Registro editado com sucesso.";
                        }
                        else
                        {
                            resp = "Registro não editado";
                        }
                    }
                }
                catch (Exception ex)
                {
                    resp = $"Erro: {ex.Message}";
                    Debug.WriteLine("ERRO: " + resp);
                }
            }

            return resp;
        }

        //método deletar materia
        public static string DeleteDiscipline(int idDiscipline)
        {
            string resp = "";

            //Cria uma conexão com o banco de dados e garante que ela será fechada e liberada corretamente após o uso.
            using (SqlConnection sqlCon = new SqlConnection(Connection.Cn))
            {
                try
                {
                    //abrindo conexão
                    sqlCon.Open();

                    //cria um comando sql que vai chamar uma função que foi escrita no sql (stored procedure)
                    using (SqlCommand sqlCmd = new SqlCommand("spdelete_discipline", sqlCon))
                    {
                        sqlCmd.CommandType = CommandType.StoredProcedure;

                        // Parâmetro de saída para o ID da nome
                        SqlParameter parIdDiscipline = new SqlParameter
                        {
                            ParameterName = "@iddiscipline",
                            SqlDbType = SqlDbType.Int,
                            Value = idDiscipline
                        };
                        sqlCmd.Parameters.Add(parIdDiscipline);

                        // Executa o comando e verifica se foi deletado com sucesso
                        int linhasAfetadas = sqlCmd.ExecuteNonQuery();
                        if (linhasAfetadas == 1)
                        {
                            int id_Aluno = Convert.ToInt32(parIdDiscipline.Value);
                            resp = $"Registro deletado com sucesso.";
                        }
                        else
                        {
                            resp = "Registro não deletado";
                        }
                    }
                }
                catch (Exception ex)
                {
                    resp = $"Erro: {ex.Message}";
                    Debug.WriteLine("ERRO: " + resp);
                }
            }

            return resp;
        }

        //------------------------------------- alunos -------------------------------------
        
        //método mostrar alunos
        public static DataTable ShowStudants()
        {
            // Objeto do tipo DataTable
            DataTable DtResultado = new DataTable("studants");

            // Objeto da conexão com o banco de dados
            using (SqlConnection SqlCon = new SqlConnection(Connection.Cn))
            {
                try
                {
                    // Abrindo a conexão ao banco de dados
                    SqlCon.Open();

                    // Comando SQL - que está no banco de dados
                    using (SqlCommand sqlCmd = new SqlCommand("sp_show_students", SqlCon))
                    {
                        //Define o tipo de comando como StoredProcedure, 
                        //o que indica que estamos chamando um procedimento armazenado no banco de dados.
                        sqlCmd.CommandType = CommandType.StoredProcedure;

                        // Objeto que vai guardar informações da tabela
                        using (SqlDataAdapter sqlDat = new SqlDataAdapter(sqlCmd))
                        {
                            // Preenchendo o DataTable
                            sqlDat.Fill(DtResultado);
                        }
                    }
                }
                catch (Exception ex)
                {
                    DtResultado = null;
                    Debug.WriteLine("Exception: " + ex);
                }
            }

            return DtResultado;
        }

        //método pesquisar um aluno
        public static DataTable SearchStudent(string name)
        {
            // Objeto do tipo DataTable
            DataTable DtResultado = new DataTable("student");

            // Objeto da conexão com o banco de dados
            using (SqlConnection SqlCon = new SqlConnection(Connection.Cn))
            {
                try
                {
                    // Abrindo a conexão ao banco de dados
                    SqlCon.Open();

                    // Configurando o comando SQL
                    using (SqlCommand sqlCmd = new SqlCommand("sp_search_student_name", SqlCon))
                    {
                        sqlCmd.CommandType = CommandType.StoredProcedure;

                        // Adicionando o parâmetro ao comando SQL
                        SqlParameter ParTextSearch = new SqlParameter
                        {
                            ParameterName = "@name", //Nome do parâmetro no procedimento armazenado. nome da variavel no sql
                            SqlDbType = SqlDbType.VarChar, //Define o tipo de dados como VARCHAR no banco de dados.
                            Size = 100, //Define o tamanho do VARCHAR (50 caracteres).
                            Value = (object)name ?? DBNull.Value // Usando DBNull.Value para valores nulos
                                                                 //O valor do parâmetro, que pode ser o texto a ser buscado. Usa DBNull.Value para valores nulos
                        };
                        sqlCmd.Parameters.Add(ParTextSearch);

                        // Criando o DataAdapter
                        using (SqlDataAdapter sqlDat = new SqlDataAdapter(sqlCmd))
                        {
                            // Preenchendo o DataTable
                            sqlDat.Fill(DtResultado);
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Log ou tratamento da exceção pode ser adicionado aqui
                    // Exemplo: Console.WriteLine(ex.Message);
                    DtResultado = null;
                }
            }
            return DtResultado;
        }

        //método inserir aluno
        public static string InsertStudant(string name, int number)
        {
            string resp = "";

            // Cria uma conexão com o banco de dados e garante que ela será fechada e liberada corretamente após o uso.
            using (SqlConnection sqlCon = new SqlConnection(Connection.Cn))
            {
                try
                {
                    // Abrindo conexão
                    sqlCon.Open();

                    // Cria um comando SQL que vai chamar uma stored procedure
                    using (SqlCommand sqlCmd = new SqlCommand("sp_insert_student_and_scores", sqlCon))
                    {
                        sqlCmd.CommandType = CommandType.StoredProcedure;

                        // Parâmetro para o nome do aluno
                        SqlParameter parName = new SqlParameter
                        {
                            ParameterName = "@name",
                            SqlDbType = SqlDbType.VarChar,
                            Size = 100,
                            Value = string.IsNullOrEmpty(name) ? (object)DBNull.Value : name
                        };
                        sqlCmd.Parameters.Add(parName);

                        // Parâmetro para o número do aluno
                        SqlParameter parNumber = new SqlParameter
                        {
                            ParameterName = "@num",
                            SqlDbType = SqlDbType.Int,
                            Value = number
                        };
                        sqlCmd.Parameters.Add(parNumber);

                        // Executa o comando e verifica se a inserção foi bem-sucedida
                        int linhasAfetadas = sqlCmd.ExecuteNonQuery();
                        if (linhasAfetadas > 0)
                            resp = "Registro inserido com sucesso.";
                        
                        else resp = "Registro não inserido.";
                    }
                }
                catch (Exception ex)
                {
                    resp = $"Erro: {ex.Message}";
                }
            }

            return resp;
        }

        //método editar aluno
        public static string EditStudant(int idStudant, string name, int number)
        {
            string resp = "";

            //Cria uma conexão com o banco de dados e garante que ela será fechada e liberada corretamente após o uso.
            using (SqlConnection sqlCon = new SqlConnection(Connection.Cn))
            {
                try
                {
                    //abrindo conexão
                    sqlCon.Open();

                    //cria um comando sql que vai chamar uma função que foi escrita no sql (stored procedure)
                    using (SqlCommand sqlCmd = new SqlCommand("spedit_student", sqlCon))
                    {
                        sqlCmd.CommandType = CommandType.StoredProcedure;

                        // Parâmetro de saída para o ID da nome
                        SqlParameter parIdStudant = new SqlParameter
                        {
                            ParameterName = "@idstudent",
                            SqlDbType = SqlDbType.Int,
                            Value = idStudant
                        };
                        sqlCmd.Parameters.Add(parIdStudant);

                        // Parâmetro para o nome do aluno
                        SqlParameter parName = new SqlParameter
                        {
                            ParameterName = "@name",
                            SqlDbType = SqlDbType.VarChar,
                            Size = 100,
                            Value = string.IsNullOrEmpty(name) ? (object)DBNull.Value : name
                        };
                        sqlCmd.Parameters.Add(parName);

                        // Parâmetro para o número do aluno
                        SqlParameter parNumber = new SqlParameter
                        {
                            ParameterName = "@num",
                            SqlDbType = SqlDbType.Int,
                            Value = number
                        };
                        sqlCmd.Parameters.Add(parNumber);

                        // Executa o comando e verifica se a edição foi bem-sucedida
                        int linhasAfetadas = sqlCmd.ExecuteNonQuery();
                        if (linhasAfetadas == 1)
                        {
                            int id_Aluno = Convert.ToInt32(parIdStudant.Value);
                            resp = $"Registro editado com sucesso.";
                        }
                        else
                        {
                            resp = "Registro não editado";
                        }
                    }
                }
                catch (Exception ex)
                {
                    resp = $"Erro: {ex.Message}";
                    Debug.WriteLine("ERRO: " + resp);
                }
            }

            return resp;
        }

        //método deletar aluno
        public static string DeleteStudant(int idStudant)
        {
            string resp = "";

            //Cria uma conexão com o banco de dados e garante que ela será fechada e liberada corretamente após o uso.
            using (SqlConnection sqlCon = new SqlConnection(Connection.Cn))
            {
                try
                {
                    //abrindo conexão
                    sqlCon.Open();

                    //cria um comando sql que vai chamar uma função que foi escrita no sql (stored procedure)
                    using (SqlCommand sqlCmd = new SqlCommand("spdel_studant", sqlCon))
                    {
                        sqlCmd.CommandType = CommandType.StoredProcedure;

                        // Parâmetro de saída para o ID da nome
                        SqlParameter parIdStudant = new SqlParameter
                        {
                            ParameterName = "@idstudent",
                            SqlDbType = SqlDbType.Int,
                            Value = idStudant
                        };
                        sqlCmd.Parameters.Add(parIdStudant);

                        // Executa o comando e verifica se foi deletado com sucesso
                        int linhasAfetadas = sqlCmd.ExecuteNonQuery();
                        if (linhasAfetadas == 1)
                        {
                            int id_Aluno = Convert.ToInt32(parIdStudant.Value);
                            resp = $"Registro deletado com sucesso.";
                        }
                        else
                        {
                            resp = "Registro não deletado";
                        }
                    }
                }
                catch (Exception ex)
                {
                    resp = $"Erro: {ex.Message}";
                    Debug.WriteLine("ERRO: " + resp);
                }
            }

            return resp;
        }

        //------------------------------------- Pegando as Quantidades -------------------------------------

        public static int[] GetAmount()
        {
            int[] resp = new int[2];

            // Objeto da conexão com o banco de dados
            using (SqlConnection SqlCon = new SqlConnection(Connection.Cn))
            {
                try
                {
                    // Abrindo a conexão ao banco de dados
                    SqlCon.Open();

                    // Comando SQL - que está no banco de dados
                    using (SqlCommand sqlCmd = new SqlCommand("sp_get_studants_amount", SqlCon))
                    {
                        //Define o tipo de comando como StoredProcedure, 
                        //o que indica que estamos chamando um procedimento armazenado no banco de dados.
                        sqlCmd.CommandType = CommandType.StoredProcedure;

                        //parametro da quantidade de alunos
                        SqlParameter parStudantsAmount = new SqlParameter("@amount", SqlDbType.Int)
                        {
                            Direction = ParameterDirection.Output
                        };
                        sqlCmd.Parameters.Add(parStudantsAmount);

                        // Executar a stored procedure
                        sqlCmd.ExecuteNonQuery();

                        // Ler os valores dos parâmetros de saída
                        resp[0] = (int)parStudantsAmount.Value;
                    }

                    using (SqlCommand sqlCmd = new SqlCommand("sp_get_discipline_amount", SqlCon))
                    {
                        //Define o tipo de comando como StoredProcedure, 
                        //o que indica que estamos chamando um procedimento armazenado no banco de dados.
                        sqlCmd.CommandType = CommandType.StoredProcedure;

                        //parametro da quantidade de alunos
                        SqlParameter parDisciplineAmount = new SqlParameter("@amount", SqlDbType.Int)
                        {
                            Direction = ParameterDirection.Output
                        };
                        sqlCmd.Parameters.Add(parDisciplineAmount);

                        // Executar a stored procedure
                        sqlCmd.ExecuteNonQuery();

                        // Ler os valores dos parâmetros de saída
                        resp[1] = (int)parDisciplineAmount.Value;
                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine("Exception: " + ex);
                }
            }

            return resp;
        }
        
        //------------------------------------- Configurações -------------------------------------

        public static string SetConfigurations(string professorName, string schollName)
        {
            string resp = "";

            using (SqlConnection SqlCon = new SqlConnection(Connection.Cn))
            {
                try
                {
                    SqlCon.Open();

                    using (SqlCommand sqlCmd = new SqlCommand("sp_verify_configurations_data", SqlCon))
                    {
                        sqlCmd.CommandType = CommandType.StoredProcedure;

                        // Definir parâmetros de saída
                        SqlParameter registered = new SqlParameter("@Registered", SqlDbType.Bit)
                        {
                            Direction = ParameterDirection.Output
                        };
                        sqlCmd.Parameters.Add(registered);

                        SqlParameter idParam = new SqlParameter("@Id", SqlDbType.Int)
                        {
                            Direction = ParameterDirection.Output
                        };
                        sqlCmd.Parameters.Add(idParam);

                        // Executar a stored procedure
                        sqlCmd.ExecuteNonQuery();

                        // Ler os valores dos parâmetros de saída
                        bool result = (bool)registered.Value;
                        int id = (int)idParam.Value;

                        //se já tiver algo no banco de dados
                        if (result) resp = EditConfigurations(SqlCon, id, professorName, schollName);
                        
                        //se não cria um novo registro
                        else resp = CreateConfigurations(SqlCon, professorName, schollName);
                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine("Exception: " + ex);
                }
            }

            return resp;
        }

        private static string EditConfigurations(SqlConnection sqlCon, int id, string professorName, string schollName)
        {
            string resp = "";

            try
            {
                //cria um comando sql que vai chamar uma função que foi escrita no sql (stored procedure)
                using (SqlCommand sqlCmd = new SqlCommand("spedit_configurations", sqlCon))
                {
                    sqlCmd.CommandType = CommandType.StoredProcedure;

                    // Parâmetro para o ID
                    SqlParameter parId = new SqlParameter
                    {
                        ParameterName = "@id_conf",
                        SqlDbType = SqlDbType.Int,
                        Value = id
                    };
                    sqlCmd.Parameters.Add(parId);

                    // Parâmetro para o nome do professor
                    SqlParameter parProfessorName = new SqlParameter
                    {
                        ParameterName = "@professor_name",
                        SqlDbType = SqlDbType.VarChar,
                        Size = 100,
                        Value = string.IsNullOrEmpty(professorName) ? (object)DBNull.Value : professorName
                    };
                    sqlCmd.Parameters.Add(parProfessorName);

                    // Parâmetro para o nome da escola
                    SqlParameter parSchollName = new SqlParameter
                    {
                        ParameterName = "@scholl_name",
                        SqlDbType = SqlDbType.VarChar,
                        Size = 100,
                        Value = string.IsNullOrEmpty(schollName) ? (object)DBNull.Value : schollName
                    };
                    sqlCmd.Parameters.Add(parSchollName);

                    // Executa o comando e verifica se a edição foi bem-sucedida
                    int linhasAfetadas = sqlCmd.ExecuteNonQuery();
                    if (linhasAfetadas == 1)
                    {
                        int id_Aluno = Convert.ToInt32(parId.Value);
                        resp = $"Registro editado com sucesso.";
                    }
                    else
                    {
                        resp = "Registro não editado";
                    }
                }
            }
            catch (Exception ex)
            {
                resp = $"Erro: {ex.Message}";
                Debug.WriteLine("ERRO: " + resp);
            }

            return resp;
        }

        private static string CreateConfigurations(SqlConnection sqlCon, string professorName, string schollName)
        {
            string resp = "";

            try
            {

                // Cria um comando SQL que vai chamar uma stored procedure
                using (SqlCommand sqlCmd = new SqlCommand("spinsert_configurations", sqlCon))
                {
                    sqlCmd.CommandType = CommandType.StoredProcedure;

                    // Parâmetro para o nome do professor
                    SqlParameter parProfessorName = new SqlParameter
                    {
                        ParameterName = "@professor_name",
                        SqlDbType = SqlDbType.VarChar,
                        Size = 100,
                        Value = string.IsNullOrEmpty(professorName) ? (object)DBNull.Value : professorName
                    };
                    sqlCmd.Parameters.Add(parProfessorName);

                    // Parâmetro para o nome da escola
                    SqlParameter parSchollName = new SqlParameter
                    {
                        ParameterName = "@scholl_name",
                        SqlDbType = SqlDbType.VarChar,
                        Size = 100,
                        Value = string.IsNullOrEmpty(schollName) ? (object)DBNull.Value : schollName
                    };
                    sqlCmd.Parameters.Add(parSchollName);

                    // Executa o comando e verifica se a inserção foi bem-sucedida
                    int linhasAfetadas = sqlCmd.ExecuteNonQuery();
                    if (linhasAfetadas == 1)
                    {
                        resp = "Registro inserido com sucesso.";
                    }
                    else
                    {
                        resp = "Registro não inserido.";
                    }
                }
            }
            catch (Exception ex)
            {
                resp = $"Erro: {ex.Message}";
            }

            return resp;
        }

        public static string[] GetConfigurations()
        {
            string[] result = new string[2];

            // Objeto da conexão com o banco de dados
            using (SqlConnection SqlCon = new SqlConnection(Connection.Cn))
            {
                try
                {
                    // Abrindo a conexão ao banco de dados
                    SqlCon.Open();

                    // Configurando o comando SQL
                    using (SqlCommand sqlCmd = new SqlCommand("sp_read_configurations", SqlCon))
                    {
                        sqlCmd.CommandType = CommandType.StoredProcedure;

                        // Definir parâmetros de saída
                        SqlParameter parProfessorName = new SqlParameter
                        {
                            ParameterName = "@professor_name",
                            SqlDbType = SqlDbType.VarChar,
                            Size = 100,
                            Direction = ParameterDirection.Output
                        };
                        sqlCmd.Parameters.Add(parProfessorName);

                        SqlParameter parSchollName = new SqlParameter
                        {
                            ParameterName = "@scholl_name",
                            SqlDbType = SqlDbType.VarChar,
                            Size = 100,
                            Direction = ParameterDirection.Output
                        };
                        sqlCmd.Parameters.Add(parSchollName);

                        // Executar a stored procedure
                        sqlCmd.ExecuteNonQuery();

                        result[0] = Convert.ToString(parProfessorName.Value);
                        result[1] = Convert.ToString(parSchollName.Value);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            return result;
        }

        //------------------------------------- Notas -------------------------------------

        public static DataTable GetStudentDisciplines(int idStudant)
        {
            DataTable dtResult = new DataTable("disciplines");

            //lista de tuplas para guardar as materias
            List<Tuple<int, string, decimal>> disciplines = new List<Tuple<int, string, decimal>>();

            // Objeto da conexão com o banco de dados
            using (SqlConnection sqlCon = new SqlConnection(Connection.Cn))
            {
                try
                {
                    // Abrindo a conexão ao banco de dados
                    sqlCon.Open();

                    // Comando SQL - que está no banco de dados
                    using (SqlCommand sqlCmd = new SqlCommand("spshow_discipline", sqlCon))
                    {
                        //Define o tipo de comando como StoredProcedure, 
                        //o que indica que estamos chamando um procedimento armazenado no banco de dados.
                        sqlCmd.CommandType = CommandType.StoredProcedure;

                        using (SqlDataReader reader = sqlCmd.ExecuteReader())
                        {
                            // Ler e manipular os dados
                            while (reader.Read())
                            {
                                int id = reader.GetInt32(0);
                                string name = reader.GetString(1);
                                decimal media = reader.GetDecimal(2);

                                //Debug.WriteLine($"id: {id} nome: {name} media: {media}");

                                //criando uma tupla
                                Tuple<int, string, decimal> disciplione = Tuple.Create(id, name, media);

                                //adicinando a tupla a lista de tuplas
                                disciplines.Add(disciplione);
                            }
                        }
                    }

                    // Comando SQL - que está no banco de dados
                    using (SqlCommand sqlCmd = new SqlCommand("sp_search_scores_from_studant", sqlCon))
                    {
                        //Define o tipo de comando como StoredProcedure, 
                        //o que indica que estamos chamando um procedimento armazenado no banco de dados.
                        sqlCmd.CommandType = CommandType.StoredProcedure;

                        SqlParameter parIdStudant = new SqlParameter
                        {
                            ParameterName = "@idstudent",
                            SqlDbType = SqlDbType.Int,
                            Value = idStudant
                        };
                        sqlCmd.Parameters.Add(parIdStudant);

                        // Objeto que vai guardar informações da tabela
                        using (SqlDataAdapter sqlDat = new SqlDataAdapter(sqlCmd))
                        {
                            // Preenchendo o DataTable
                            sqlDat.Fill(dtResult);
                        }

                        // Adicionando a nova coluna para o nome da disciplina
                        dtResult.Columns.Add("disciplineName", typeof(string));

                        // Reorganizando as colunas para que 'disciplineName' fique depois de 'idmateria'
                        dtResult.Columns["disciplineName"].SetOrdinal(dtResult.Columns["idmateria"].Ordinal + 1);

                        // Adicionando a nova coluna para o status
                        dtResult.Columns.Add("status", typeof(string));

                        //mudando o valor da coluna onte estão os ids das materias
                        foreach (DataRow row in dtResult.Rows)
                        {
                            foreach (Tuple<int, string, decimal> discipline in disciplines)
                            {
                                if ( (int)row["idmateria"] == discipline.Item1 )
                                    row["disciplineName"] = discipline.Item2;
                                

                                if( (decimal)row["media"] >= discipline.Item3 )
                                    row["status"] = "Aprovado";

                                else
                                    row["status"] = "Reprovado";
                            }
                            //Debug.WriteLine("valor: "+ row["disciplineName"]);
                        }
                        
                    }
                }
                catch (Exception ex)
                {
                    dtResult = null;
                    Debug.WriteLine("Exception: " + ex);
                }
            }


            return dtResult;
        }

        public static DataTable GetDiscliplineStudents(int idDiscipline, decimal average)
        {
            DataTable dtResult = new DataTable("students");

            //lista de tuplas para guardar as materias
            List<Tuple<int, string, int>> students = new List<Tuple<int, string, int>>();

            // Objeto da conexão com o banco de dados
            using (SqlConnection SqlCon = new SqlConnection(Connection.Cn))
            {
                try
                {
                    // Abrindo a conexão ao banco de dados
                    SqlCon.Open();

                    // Comando SQL - que está no banco de dados
                    using (SqlCommand sqlCmd = new SqlCommand("sp_show_students", SqlCon))
                    {
                        //Define o tipo de comando como StoredProcedure, 
                        //o que indica que estamos chamando um procedimento armazenado no banco de dados.
                        sqlCmd.CommandType = CommandType.StoredProcedure;

                        using (SqlDataReader reader = sqlCmd.ExecuteReader())
                        {
                            // Ler e manipular os dados
                            while (reader.Read())
                            {
                                int id = reader.GetInt32(0);
                                string name = reader.GetString(1);
                                int number = reader.GetInt32(2);

                                //Debug.WriteLine($"id: {id} nome: {name}, numero: {number}");

                                //criando uma tupla
                                Tuple<int, string, int> student = Tuple.Create(id, name, number);

                                //adicinando a tupla a lista de tuplas
                                students.Add(student);
                            }
                        }
                    }

                    // Comando SQL - que está no banco de dados
                    using (SqlCommand sqlCmd = new SqlCommand("sp_search_scores_from_discipline", SqlCon))
                    {
                        //Define o tipo de comando como StoredProcedure, 
                        //o que indica que estamos chamando um procedimento armazenado no banco de dados.
                        sqlCmd.CommandType = CommandType.StoredProcedure;

                        SqlParameter parIdDiscipline = new SqlParameter
                        {
                            ParameterName = "@iddiscipline",
                            SqlDbType = SqlDbType.Int,
                            Value = idDiscipline
                        };
                        sqlCmd.Parameters.Add(parIdDiscipline);

                        // Objeto que vai guardar informações da tabela
                        using (SqlDataAdapter sqlDat = new SqlDataAdapter(sqlCmd))
                        {
                            // Preenchendo o DataTable
                            sqlDat.Fill(dtResult);
                        }

                        // Adicionando uma nova coluna para o nome da disciplina
                        dtResult.Columns.Add("studentName", typeof(string));

                        //Reorganizando as colunas para que 'studentName' fique depois de 'idmateria'
                        dtResult.Columns["studentName"].SetOrdinal(dtResult.Columns["idmateria"].Ordinal + 1);

                        //adicionado uma nova coluna para o numero da chamada
                        dtResult.Columns.Add("numero", typeof(int));

                        //Reorganizando as colunas para que 'numero' fique depois de 'studentName'
                        dtResult.Columns["numero"].SetOrdinal(dtResult.Columns["studentName"].Ordinal + 1);

                        // Adicionando uma nova coluna para o status
                        dtResult.Columns.Add("status", typeof(string));

                        //mudando o valor da coluna onte estão os ids das materias
                        foreach (DataRow row in dtResult.Rows)
                        {
                            foreach (Tuple<int, string, int> student in students)
                            {
                                if ((int)row["idaluno"] == student.Item1)
                                {
                                    row["studentName"] = student.Item2;
                                    row["numero"] = student.Item3;
                                }

                                if ((decimal)row["media"] >= average)
                                    row["status"] = "Aprovado";

                                else
                                    row["status"] = "Reprovado";
                            }
                            //Debug.WriteLine("valor: "+ row["studentName"]);
                        }
                    }
                }
                catch (Exception ex)
                {
                    dtResult = null;
                    Debug.WriteLine("Exception: " + ex);
                }
            }
            return dtResult;
        }

        public static DataTable GetStudentDiscliplinesFilterdiscipline(int idStudant, string name)
        {
            DataTable dtResult = new DataTable("disciplines");

            //lista de tuplas para guardar as materias
            List<Tuple<int, string, decimal>> disciplines = new List<Tuple<int, string, decimal>>();

            // Objeto da conexão com o banco de dados
            using (SqlConnection sqlCon = new SqlConnection(Connection.Cn))
            {
                try
                {
                    // Abrindo a conexão ao banco de dados
                    sqlCon.Open();

                    // Comando SQL - que está no banco de dados
                    using (SqlCommand sqlCmd = new SqlCommand("spsearch_discipline_name", sqlCon))
                    {
                        //Define o tipo de comando como StoredProcedure, 
                        //o que indica que estamos chamando um procedimento armazenado no banco de dados.
                        sqlCmd.CommandType = CommandType.StoredProcedure;

                        // Adicionando o parâmetro ao comando SQL
                        SqlParameter ParTextSearch = new SqlParameter
                        {
                            ParameterName = "@name", //Nome do parâmetro no procedimento armazenado. nome da variavel no sql
                            SqlDbType = SqlDbType.VarChar, //Define o tipo de dados como VARCHAR no banco de dados.
                            Size = 100, //Define o tamanho do VARCHAR (50 caracteres).
                            Value = (object)name ?? DBNull.Value // Usando DBNull.Value para valores nulos
                                                                   //O valor do parâmetro, que pode ser o texto a ser buscado. Usa DBNull.Value para valores nulos
                        };
                        sqlCmd.Parameters.Add(ParTextSearch);

                        using (SqlDataReader reader = sqlCmd.ExecuteReader())
                        {
                            // Ler e manipular os dados
                            while (reader.Read())
                            {
                                int id = reader.GetInt32(0);
                                string disciplineName = reader.GetString(1);
                                decimal media = reader.GetDecimal(2);

                                //Debug.WriteLine($"id: {id} nome: {disciplineName} media: {media}");

                                //criando uma tupla
                                Tuple<int, string, decimal> disciplione = Tuple.Create(id, disciplineName, media);

                                //adicinando a tupla a lista de tuplas
                                disciplines.Add(disciplione);
                            }
                        }
                    }

                    // Configurando o comando SQL
                    using (SqlCommand sqlCmd = new SqlCommand("sp_search_studentid_discipline", sqlCon))
                    {
                        sqlCmd.CommandType = CommandType.StoredProcedure;

                        // Parâmetro de saída para o ID da nome
                        SqlParameter parIdStudant = new SqlParameter
                        {
                            ParameterName = "@idstudent",
                            SqlDbType = SqlDbType.Int,
                            Value = idStudant
                        };
                        sqlCmd.Parameters.Add(parIdStudant);

                        // Adicionando o parâmetro ao comando SQL
                        SqlParameter ParTextSearch = new SqlParameter
                        {
                            ParameterName = "@name", //Nome do parâmetro no procedimento armazenado. nome da variavel no sql
                            SqlDbType = SqlDbType.VarChar, //Define o tipo de dados como VARCHAR no banco de dados.
                            Size = 100, //Define o tamanho do VARCHAR (50 caracteres).
                            Value = (object)name ?? DBNull.Value // Usando DBNull.Value para valores nulos
                                                                 //O valor do parâmetro, que pode ser o texto a ser buscado. Usa DBNull.Value para valores nulos
                        };
                        sqlCmd.Parameters.Add(ParTextSearch);

                        // Criando o DataAdapter
                        using (SqlDataAdapter sqlDat = new SqlDataAdapter(sqlCmd))
                        {
                            // Preenchendo o DataTable
                            sqlDat.Fill(dtResult);
                        }

                        // Adicionando a nova coluna para o nome da disciplina
                        dtResult.Columns.Add("disciplineName", typeof(string));

                        // Reorganizando as colunas para que 'disciplineName' fique depois de 'idmateria'
                        dtResult.Columns["disciplineName"].SetOrdinal(dtResult.Columns["idmateria"].Ordinal + 1);

                        // Adicionando a nova coluna para o status
                        dtResult.Columns.Add("status", typeof(string));

                        //mudando o valor da coluna onte estão os ids das materias
                        foreach (DataRow row in dtResult.Rows)
                        {
                            foreach (Tuple<int, string, decimal> discipline in disciplines)
                            {
                                if ((int)row["idmateria"] == discipline.Item1)
                                    row["disciplineName"] = discipline.Item2;

                                if ((decimal)row["media"] >= discipline.Item3)
                                    row["status"] = "Aprovado";

                                else
                                    row["status"] = "Reprovado";
                            }
                            //Debug.WriteLine("valor: "+ row["disciplineName"]);
                        }

                    }
                }
                catch (Exception ex)
                {
                    // Log ou tratamento da exceção pode ser adicionado aqui
                    // Exemplo: Console.WriteLine(ex.Message);
                    dtResult = null;
                }
            }

            return dtResult;
        }



        public static string EditScores(int id, decimal sfiq, decimal ssq, decimal stq, decimal sfoq, decimal average)
        {
            string resp = "";

            //Cria uma conexão com o banco de dados e garante que ela será fechada e liberada corretamente após o uso.
            using (SqlConnection sqlCon = new SqlConnection(Connection.Cn))
            {
                try
                {
                    //abrindo conexão
                    sqlCon.Open();

                    //cria um comando sql que vai chamar uma função que foi escrita no sql (stored procedure)
                    using (SqlCommand sqlCmd = new SqlCommand("spedit_scores", sqlCon))
                    {
                        sqlCmd.CommandType = CommandType.StoredProcedure;

                        // Parâmetro para o ID
                        SqlParameter parId = new SqlParameter
                        {
                            ParameterName = "@idscores",
                            SqlDbType = SqlDbType.Int,
                            Value = id
                        };
                        sqlCmd.Parameters.Add(parId);

                        // Parâmetro para a nota do primeiro trimestre
                        SqlParameter parSfiq = new SqlParameter
                        {
                            ParameterName = "@scorefit",
                            SqlDbType = SqlDbType.Decimal,
                            Value = sfiq
                        };
                        sqlCmd.Parameters.Add(parSfiq);

                        // Parâmetro para a nota do segundo trimestre
                        SqlParameter parSsq = new SqlParameter
                        {
                            ParameterName = "@scorest",
                            SqlDbType = SqlDbType.Decimal,
                            Value = ssq
                        };
                        sqlCmd.Parameters.Add(parSsq);

                        // Parâmetro para a nota do terceiro trimestre
                        SqlParameter parStq = new SqlParameter
                        {
                            ParameterName = "@scorett",
                            SqlDbType = SqlDbType.Decimal,
                            Value = stq
                        };
                        sqlCmd.Parameters.Add(parStq);

                        // Parâmetro para a nota do quarto trimestre
                        SqlParameter parSfoq = new SqlParameter
                        {
                            ParameterName = "@scorefot",
                            SqlDbType = SqlDbType.Decimal,
                            Value = sfoq
                        };
                        sqlCmd.Parameters.Add(parSfoq);

                        // Parâmetro para a média minima para aprovação
                        SqlParameter parAverage = new SqlParameter
                        {
                            ParameterName = "@average",
                            SqlDbType = SqlDbType.Decimal,
                            Value = average
                        };
                        sqlCmd.Parameters.Add(parAverage);

                        // Executa o comando e verifica se a edição foi bem-sucedida
                        int linhasAfetadas = sqlCmd.ExecuteNonQuery();
                        if (linhasAfetadas == 1)
                        {
                            int id_Aluno = Convert.ToInt32(parId.Value);
                            resp = $"Registro editado com sucesso.";
                        }
                        else
                        {
                            resp = "Registro não editado";
                        }
                    }
                }
                catch (Exception ex)
                {
                    resp = $"Erro: {ex.Message}";
                    Debug.WriteLine("ERRO: " + resp);
                }
            }

            return resp;
        }
    
    }
}
