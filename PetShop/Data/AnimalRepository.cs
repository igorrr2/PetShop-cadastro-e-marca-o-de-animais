using System;
using System.Collections.Generic;
using Microsoft.Data.Sqlite;
using PetShop.Models;
using PetShop.MensagemRetorno;

namespace PetShop.Data
{
    public static class AnimalRepository
    {
        private static readonly string _caminhoBanco = "Data Source=petshop.db;";

        public static void Initialize()
        {
            CriarTabelaSeNaoExistir();
        }

        private static void CriarTabelaSeNaoExistir()
        {
            using var conexao = new SqliteConnection(_caminhoBanco);
            conexao.Open();

            string sql = @"
            CREATE TABLE IF NOT EXISTS Animal (
                Id TEXT PRIMARY KEY,
                Nome TEXT NOT NULL,
                Tipo TEXT NOT NULL,
                Raca TEXT NOT NULL,
                Sexo TEXT NOT NULL,
                DataNascimento TEXT NOT NULL,
                Observacoes TEXT
            );";

            using var cmd = new SqliteCommand(sql, conexao);
            cmd.ExecuteNonQuery();
        }

        // Método para obter um animal pelo Id
        public static Mensagem TryGet(Guid id, out Animal animal)
        {
            animal = null;
            try
            {
                using var conexao = new SqliteConnection(_caminhoBanco);
                conexao.Open();

                string sql = "SELECT * FROM Animal WHERE Id = @Id";
                using var cmd = new SqliteCommand(sql, conexao);
                cmd.Parameters.AddWithValue("@Id", id.ToString());

                using var reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    animal = new Animal
                    {
                        Id = Guid.Parse(reader["Id"].ToString()),
                        Nome = reader["Nome"].ToString(),
                        Tipo = reader["Tipo"].ToString(),
                        Raca = reader["Raca"].ToString(),
                        Sexo = reader["Sexo"].ToString(),
                        DataNascimento = DateTime.Parse(reader["DataNascimento"].ToString()),
                        Observacoes = reader["Observacoes"].ToString()
                    };
                    return new Mensagem();
                }
            }
            catch (Exception ex)
            {
                return new Mensagem(ex.Message, ex);
            }
            if (animal == null)
                return new Mensagem("Animal não encontrado no banco de dados");

            return new Mensagem();
        }

        // Método para salvar ou atualizar
        public static Mensagem TrySave(Animal animal)
        {
            if (animal == null) return new Mensagem("Não há animal para salvar.");

            try
            {
                using var conexao = new SqliteConnection(_caminhoBanco);
                conexao.Open();

                string sql;
                if (animal.Id == Guid.Empty) // Novo registro
                {
                    animal.Id = Guid.NewGuid();
                    sql = @"INSERT INTO Animal (Id, Nome, Tipo, Raca, Sexo, DataNascimento, Observacoes) 
                            VALUES (@Id, @Nome, @Tipo, @Raca, @Sexo, @DataNascimento, @Observacoes)";
                }
                else // Atualizar registro existente
                {
                    sql = @"UPDATE Animal SET
                            Nome = @Nome,
                            Tipo = @Tipo,
                            Raca = @Raca,
                            Sexo = @Sexo,
                            DataNascimento = @DataNascimento,
                            Observacoes = @Observacoes
                            WHERE Id = @Id";
                }

                using var cmd = new SqliteCommand(sql, conexao);
                cmd.Parameters.AddWithValue("@Id", animal.Id.ToString());
                cmd.Parameters.AddWithValue("@Nome", animal.Nome);
                cmd.Parameters.AddWithValue("@Tipo", animal.Tipo);
                cmd.Parameters.AddWithValue("@Raca", animal.Raca);
                cmd.Parameters.AddWithValue("@Sexo", animal.Sexo);
                cmd.Parameters.AddWithValue("@DataNascimento", animal.DataNascimento.ToString("yyyy-MM-dd"));
                cmd.Parameters.AddWithValue("@Observacoes", animal.Observacoes);

                cmd.ExecuteNonQuery();
                return new Mensagem();
            }
            catch (Exception ex)
            {
                return new Mensagem(ex.Message, ex);
            }
        }

        // Método para deletar
        public static Mensagem TryDelete(Guid id)
        {
            try
            {
                using var conexao = new SqliteConnection(_caminhoBanco);
                conexao.Open();

                string sql = "DELETE FROM Animal WHERE Id = @Id";
                using var cmd = new SqliteCommand(sql, conexao);
                cmd.Parameters.AddWithValue("@Id", id.ToString());
                cmd.ExecuteNonQuery();

                return new Mensagem();
            }
            catch (Exception ex)
            {
                return new Mensagem(ex.Message, ex);
            }
        }

        // Método para listar todos os animais
        public static List<Animal> ListAll()
        {
            var lista = new List<Animal>();
            try
            {
                using var conexao = new SqliteConnection(_caminhoBanco);
                conexao.Open();

                string sql = "SELECT * FROM Animal";
                using var cmd = new SqliteCommand(sql, conexao);
                using var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    lista.Add(new Animal
                    {
                        Id = Guid.Parse(reader["Id"].ToString()),
                        Nome = reader["Nome"].ToString(),
                        Tipo = reader["Tipo"].ToString(),
                        Raca = reader["Raca"].ToString(),
                        Sexo = reader["Sexo"].ToString(),
                        DataNascimento = DateTime.Parse(reader["DataNascimento"].ToString()),
                        Observacoes = reader["Observacoes"].ToString()
                    });
                }
            }
            catch
            {
                // log de erro opcional
            }

            return lista;
        }
    }
}
