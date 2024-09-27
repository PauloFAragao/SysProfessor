using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Diagnostics;

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
                    using (SqlCommand sqlCmd = new SqlCommand("sp_show_discipline", sqlCon))
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
                    using (SqlCommand sqlCmd = new SqlCommand("sp_search_discipline_name", SqlCon))
                    {
                        sqlCmd.CommandType = CommandType.StoredProcedure;

                        // Adicionando o parâmetro ao comando SQL
                        sqlCmd.Parameters.Add(CreateSqlParameter(name, "@name", 100 ));

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
                    Debug.WriteLine($"Erro: {ex.Message}");
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
                        sqlCmd.Parameters.Add(CreateSqlParameter(name, "@name", 100));

                        // Parâmetro para a média minima para aprovação
                        sqlCmd.Parameters.Add(CreateSqlParameter(average, "@average"));

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
                    using (SqlCommand sqlCmd = new SqlCommand("sp_edit_discipline", sqlCon))
                    {
                        sqlCmd.CommandType = CommandType.StoredProcedure;

                        // Parâmetro de saída para o ID da diciplina
                        sqlCmd.Parameters.Add(CreateSqlParameter(idDiscipline , "@iddiscipline"));
                        
                        // Parâmetro para o nome do aluno
                        sqlCmd.Parameters.Add(CreateSqlParameter(name, "@name", 100));

                        // Parâmetro para a média minima para aprovação
                        sqlCmd.Parameters.Add(CreateSqlParameter(average, "@average"));

                        // Executa o comando e verifica se a edição foi bem-sucedida
                        int linhasAfetadas = sqlCmd.ExecuteNonQuery();
                        if (linhasAfetadas == 1)
                        {
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
                    using (SqlCommand sqlCmd = new SqlCommand("sp_delete_discipline", sqlCon))
                    {
                        sqlCmd.CommandType = CommandType.StoredProcedure;

                        // Parâmetro de saída para o ID da diciplina
                        sqlCmd.Parameters.Add(CreateSqlParameter(idDiscipline, "@iddiscipline"));

                        // Executa o comando e verifica se foi deletado com sucesso
                        int linhasAfetadas = sqlCmd.ExecuteNonQuery();
                        if (linhasAfetadas == 1)
                        {
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
                        sqlCmd.Parameters.Add(CreateSqlParameter(name, "@name", 100));

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
                    Debug.WriteLine($"Erro: {ex.Message}");
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
                        sqlCmd.Parameters.Add(CreateSqlParameter(name, "@name", 100));

                        // Parâmetro para o número do aluno
                        sqlCmd.Parameters.Add(CreateSqlParameter(number, "@num"));

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
                    using (SqlCommand sqlCmd = new SqlCommand("sp_edit_student", sqlCon))
                    {
                        sqlCmd.CommandType = CommandType.StoredProcedure;

                        // Parâmetro para o ID do aluno
                        sqlCmd.Parameters.Add(CreateSqlParameter(idStudant, "@idstudent"));

                        // Parâmetro para o nome do aluno
                        sqlCmd.Parameters.Add(CreateSqlParameter(name, "@name", 100));

                        // Parâmetro para o número do aluno
                        sqlCmd.Parameters.Add(CreateSqlParameter(number, "@num"));

                        // Executa o comando e verifica se a edição foi bem-sucedida
                        int linhasAfetadas = sqlCmd.ExecuteNonQuery();
                        if (linhasAfetadas == 1)
                        {
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
                    using (SqlCommand sqlCmd = new SqlCommand("sp_del_studant", sqlCon))
                    {
                        sqlCmd.CommandType = CommandType.StoredProcedure;

                        // Parâmetro de saída para o ID da nome
                        sqlCmd.Parameters.Add(CreateSqlParameter(idStudant, "@idstudent"));

                        // Executa o comando e verifica se foi deletado com sucesso
                        int linhasAfetadas = sqlCmd.ExecuteNonQuery();
                        if (linhasAfetadas == 1)
                        {
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

                    //consultando a quantidade de alunos inseridos no banco de dados
                    using (SqlCommand sqlCmd = new SqlCommand("sp_get_studants_amount", SqlCon))
                    {
                        //Define o tipo de comando como StoredProcedure, 
                        //o que indica que estamos chamando um procedimento armazenado no banco de dados.
                        sqlCmd.CommandType = CommandType.StoredProcedure;

                        //parametro da quantidade de alunos
                        SqlParameter parStudantsAmount = CreateSqlParameter("@amount", ParameterDirection.Output, SqlDbType.Int);
                        sqlCmd.Parameters.Add(parStudantsAmount);

                        // Executar a stored procedure
                        sqlCmd.ExecuteNonQuery();

                        // Ler os valores dos parâmetros de saída
                        resp[0] = (int)parStudantsAmount.Value;
                    }

                    //consultando a quantidade de máterias inseridas no banco de dados
                    using (SqlCommand sqlCmd = new SqlCommand("sp_get_discipline_amount", SqlCon))
                    {
                        //Define o tipo de comando como StoredProcedure, 
                        //o que indica que estamos chamando um procedimento armazenado no banco de dados.
                        sqlCmd.CommandType = CommandType.StoredProcedure;

                        //parametro da quantidade de alunos
                        SqlParameter parDisciplineAmount = CreateSqlParameter("@amount", ParameterDirection.Output, SqlDbType.Int);
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

                        //parâmetro de saída para verificar se há algum registro
                        SqlParameter registered = CreateSqlParameter("@Registered", ParameterDirection.Output, SqlDbType.Bit);
                        sqlCmd.Parameters.Add(registered);

                        //parâmetro de saída do id do registro
                        SqlParameter idParam = CreateSqlParameter("@Id", ParameterDirection.Output, SqlDbType.Int);
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
                using (SqlCommand sqlCmd = new SqlCommand("sp_edit_configurations", sqlCon))
                {
                    sqlCmd.CommandType = CommandType.StoredProcedure;

                    // Parâmetro para o ID
                    sqlCmd.Parameters.Add( CreateSqlParameter(id, "@id_conf") );

                    // Parâmetro para o nome do professor
                    sqlCmd.Parameters.Add(CreateSqlParameter(professorName, "@professor_name", 100));

                    // Parâmetro para o nome da escola
                    sqlCmd.Parameters.Add(CreateSqlParameter(schollName, "@scholl_name", 100));

                    // Executa o comando e verifica se a edição foi bem-sucedida
                    int linhasAfetadas = sqlCmd.ExecuteNonQuery();
                    if (linhasAfetadas == 1)
                    {
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
                using (SqlCommand sqlCmd = new SqlCommand("sp_insert_configurations", sqlCon))
                {
                    sqlCmd.CommandType = CommandType.StoredProcedure;

                    // Parâmetro para o nome do professor
                    sqlCmd.Parameters.Add(CreateSqlParameter(professorName, "@professor_name", 100));

                    // Parâmetro para o nome da escola
                    sqlCmd.Parameters.Add(CreateSqlParameter(schollName, "@scholl_name", 100));

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

                        // parâmetro para receber o nome do professor
                        SqlParameter parProfessorName = CreateSqlParameter("@professor_name", ParameterDirection.Output, SqlDbType.VarChar, 100);
                        sqlCmd.Parameters.Add(parProfessorName);

                        // parâmetro para receber o nome da escola
                        SqlParameter parSchollName = CreateSqlParameter("@scholl_name", ParameterDirection.Output, SqlDbType.VarChar, 100);
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

        //método que vai retornar as materias com base em um aluno
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

                    // pegando dados da tabela das máterias
                    using (SqlCommand sqlCmd = new SqlCommand("sp_show_discipline", sqlCon))
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

                                //criando uma tupla
                                Tuple<int, string, decimal> disciplione = Tuple.Create(id, name, media);

                                //adicinando a tupla a lista de tuplas
                                disciplines.Add(disciplione);
                            }
                        }
                    }

                    // pegando as notas do aluno idStudant
                    using (SqlCommand sqlCmd = new SqlCommand("sp_search_scores_from_studant", sqlCon))
                    {
                        //Define o tipo de comando como StoredProcedure, 
                        //o que indica que estamos chamando um procedimento armazenado no banco de dados.
                        sqlCmd.CommandType = CommandType.StoredProcedure;

                        // Parâmetro para o ID do aluno
                        sqlCmd.Parameters.Add(CreateSqlParameter(idStudant, "@idstudent"));

                        // Objeto que vai guardar informações da tabela
                        using (SqlDataAdapter sqlDat = new SqlDataAdapter(sqlCmd))
                        {
                            // Preenchendo o DataTable
                            sqlDat.Fill(dtResult);
                        }
                    }
                }
                catch (Exception ex)
                {
                    dtResult = null;
                    Debug.WriteLine("Exception: " + ex);
                }
            }

            //chamando o método que vai fazer as edições na datatable
            return EditStudentDisciplinesDataTable(dtResult, disciplines);
        }

        //método que vai retornar os alunos com base em uma materia
        public static DataTable GetDiscliplineStudents(int idDiscipline, decimal average)
        {
            DataTable dtResult = new DataTable("students");

            //lista de tuplas para guardar as alunos
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

                        // Parâmetro para o ID da máteria
                        sqlCmd.Parameters.Add(CreateSqlParameter(idDiscipline, "@iddiscipline"));

                        // Objeto que vai guardar informações da tabela
                        using (SqlDataAdapter sqlDat = new SqlDataAdapter(sqlCmd))
                        {
                            // Preenchendo o DataTable
                            sqlDat.Fill(dtResult);
                        }
                    }
                }
                catch (Exception ex)
                {
                    dtResult = null;
                    Debug.WriteLine("Exception: " + ex);
                }
            }

            //chamando o método que vai fazer as edições na datatable
            return EditDiscliplineStudentsDataTable(dtResult, students, average);
        }

        //método para pesquisar as máterias com base em um aluno
        public static DataTable GetStudentDiscliplinesFilterDiscipline(int idStudant, string name)
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
                    using (SqlCommand sqlCmd = new SqlCommand("sp_search_discipline_name", sqlCon))
                    {
                        //Define o tipo de comando como StoredProcedure, 
                        //o que indica que estamos chamando um procedimento armazenado no banco de dados.
                        sqlCmd.CommandType = CommandType.StoredProcedure;

                        // Adicionando o parâmetro ao comando SQL
                        sqlCmd.Parameters.Add(CreateSqlParameter(name, "@name", 100));

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
                        sqlCmd.Parameters.Add(CreateSqlParameter(idStudant, "@idstudent"));

                        // Adicionando o parâmetro ao comando SQL
                        sqlCmd.Parameters.Add(CreateSqlParameter(name, "@name", 100));

                        // Criando o DataAdapter
                        using (SqlDataAdapter sqlDat = new SqlDataAdapter(sqlCmd))
                        {
                            // Preenchendo o DataTable
                            sqlDat.Fill(dtResult);
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Log ou tratamento da exceção pode ser adicionado aqui
                    // Exemplo: Console.WriteLine(ex.Message);
                    dtResult = null;
                    Debug.WriteLine($"Erro: {ex.Message}");
                }
            }

            //chamando o método que vai fazer as edições na datatable
            return EditStudentDisciplinesDataTable(dtResult, disciplines);
        }

        //método para pesquisar os alunos com base em uma materia
        public static DataTable GetDisciplineStudentsFilderStudent(int idDiscipline, decimal average, string name)
        {
            DataTable dtResult = new DataTable("students");

            //lista de tuplas para guardar as alunos
            List<Tuple<int, string, int>> students = new List<Tuple<int, string, int>>();

            // Objeto da conexão com o banco de dados
            using (SqlConnection sqlCon = new SqlConnection(Connection.Cn))
            {
                try
                {
                    // Abrindo a conexão ao banco de dados
                    sqlCon.Open();

                    // Comando SQL - que está no banco de dados
                    using (SqlCommand sqlCmd = new SqlCommand("sp_search_student_name", sqlCon))
                    {
                        //Define o tipo de comando como StoredProcedure, 
                        //o que indica que estamos chamando um procedimento armazenado no banco de dados.
                        sqlCmd.CommandType = CommandType.StoredProcedure;

                        // Adicionando o parâmetro ao comando SQL
                        sqlCmd.Parameters.Add(CreateSqlParameter(name, "@name", 100));

                        using (SqlDataReader reader = sqlCmd.ExecuteReader())
                        {
                            // Ler e manipular os dados
                            while (reader.Read())
                            {
                                int id = reader.GetInt32(0);
                                string studentName = reader.GetString(1);
                                int number = reader.GetInt32(2);

                                //Debug.WriteLine($"id: {id} nome: {studentName}, numero: {number}");

                                //criando uma tupla
                                Tuple<int, string, int> student = Tuple.Create(id, studentName, number);

                                //adicinando a tupla a lista de tuplas
                                students.Add(student);
                            }
                        }
                    }

                    // Configurando o comando SQL
                    using (SqlCommand sqlCmd = new SqlCommand("sp_search_disciplineid_student", sqlCon))
                    {
                        sqlCmd.CommandType = CommandType.StoredProcedure;

                        // Parâmetro de saída para o ID da nome
                        sqlCmd.Parameters.Add(CreateSqlParameter(idDiscipline, "@iddiscipline"));

                        // Adicionando o parâmetro ao comando SQL
                        sqlCmd.Parameters.Add(CreateSqlParameter(name, "@name", 100));

                        // Criando o DataAdapter
                        using (SqlDataAdapter sqlDat = new SqlDataAdapter(sqlCmd))
                        {
                            // Preenchendo o DataTable
                            sqlDat.Fill(dtResult);
                        }
                    }

                }
                catch (Exception ex)
                {
                    dtResult = null;
                    Debug.WriteLine("Exception: " + ex);
                }
            }

            //chamando o método que vai fazer as edições na datatable
            return EditDiscliplineStudentsDataTable(dtResult, students, average);
        }

        //método para editar notas
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
                    using (SqlCommand sqlCmd = new SqlCommand("sp_edit_scores", sqlCon))
                    {
                        sqlCmd.CommandType = CommandType.StoredProcedure;

                        // Parâmetro para o ID
                        sqlCmd.Parameters.Add(CreateSqlParameter(id, "@idscores"));

                        // Parâmetro para a nota do primeiro trimestre
                        sqlCmd.Parameters.Add(CreateSqlParameter(sfiq, "@scorefit"));

                        // Parâmetro para a nota do segundo trimestre
                        sqlCmd.Parameters.Add(CreateSqlParameter(ssq, "@scorest"));

                        // Parâmetro para a nota do terceiro trimestre
                        sqlCmd.Parameters.Add(CreateSqlParameter(stq, "@scorett"));

                        // Parâmetro para a nota do quarto trimestre
                        sqlCmd.Parameters.Add(CreateSqlParameter(sfoq, "@scorefot"));

                        // Parâmetro para a média minima para aprovação
                        sqlCmd.Parameters.Add(CreateSqlParameter(average, "@average"));

                        // Executa o comando e verifica se a edição foi bem-sucedida
                        int linhasAfetadas = sqlCmd.ExecuteNonQuery();
                        if (linhasAfetadas == 1)
                        {
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

        //------------------------------------- editar Datatable ------------------------------------
        //métodos que editam o Datatable para adicinoar novas colunas e colodar dados nessas colunas

        private static DataTable EditStudentDisciplinesDataTable(DataTable dtResult, List<Tuple<int, string, decimal>> disciplines)
        {
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
            }

            return dtResult;
        }

        private static DataTable EditDiscliplineStudentsDataTable(DataTable dtResult, List<Tuple<int, string, int>> students, decimal average)
        {
            Debug.WriteLine("Chamado aqui");
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

            return dtResult;
        }

        //------------------------------------- SqlParameter -------------------------------------

        //sobrecarga para criar um parametro do tipo int não output
        private static SqlParameter CreateSqlParameter(int value, string varName)
        {
            //Debug.WriteLine($"value: {value}, varname: {varName}");
            SqlParameter parameter = new SqlParameter
            {
                ParameterName = varName,
                SqlDbType = SqlDbType.Int,
                Value = value
            };
            return parameter;
        }

        //sobrecarga para criar um parametro do tipo decimal não output
        private static SqlParameter CreateSqlParameter(decimal value, string varName)
        {
            //Debug.WriteLine($"value: {value}, varname: {varName}");
            SqlParameter parameter = new SqlParameter
            {
                ParameterName = varName,
                SqlDbType = SqlDbType.Decimal,
                Value = value
            };
            return parameter;
        }

        //sobrecarga para criar um paramentro do tipo string não output
        private static SqlParameter CreateSqlParameter(string value, string varName, int size)
        {
            //Debug.WriteLine($"value: {value}, varname: {varName}, size: {size}");
            SqlParameter parameter = new SqlParameter
            {
                ParameterName = varName,
                SqlDbType = SqlDbType.VarChar,
                Size = size,
                Value = value
            };
            return parameter;
        }

        //sobrecarga para criar um paramentro ParameterDirection.Output
        private static SqlParameter CreateSqlParameter(string varName, ParameterDirection direction, SqlDbType type)
        {
            //Debug.WriteLine($"varname: {varName}");
            SqlParameter parameter = new SqlParameter
            {
                Direction = direction,
                SqlDbType = type,
                ParameterName = varName
            };
            return parameter;
        }

        //sobrecarga para criar um paramentro ParameterDirection.Output para string
        private static SqlParameter CreateSqlParameter(string varName, ParameterDirection direction, SqlDbType type, int size)
        {
            //Debug.WriteLine($"varname: {varName}");
            SqlParameter parameter = new SqlParameter
            {
                Direction = direction,
                SqlDbType = type,
                Size = size,
                ParameterName = varName
            };
            return parameter;
        }

    }
}
