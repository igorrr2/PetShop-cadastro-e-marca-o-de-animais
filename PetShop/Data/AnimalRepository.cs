using System;
using System.Collections.Generic;
using Microsoft.Data.Sqlite;
using PetShop.Models;
using Util.MensagemRetorno;

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
                IdAnimalBancoServidor TEXT,
                NomeAnimal TEXT NOT NULL,
                NomeTutor TEXT NOT NULL,
                Raca TEXT NOT NULL,
                Sexo TEXT NOT NULL,
                DataNascimento TEXT NOT NULL,
                Observacoes TEXT,
                NumeroTelefoneTutor TEXT
            );";

            using var cmd = new SqliteCommand(sql, conexao);
            cmd.ExecuteNonQuery();
        }

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
                        IdAnimalBancoServidor = reader["Id"].ToString(),
                        NomeAnimal = reader["NomeAnimal"].ToString(),
                        NomeTutor = reader["NomeTutor"].ToString(),
                        Raca = reader["Raca"].ToString(),
                        Sexo = reader["Sexo"].ToString(),
                        DataNascimento = DateTime.Parse(reader["DataNascimento"].ToString()),
                        Observacoes = reader["Observacoes"].ToString(),
                        NumeroTelefoneTutor = reader["NumeroTelefoneTutor"].ToString()
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
                    sql = @"INSERT INTO Animal (Id, IdAnimalBancoServidor, NomeAnimal, NomeTutor, Raca, Sexo, DataNascimento, Observacoes, NumeroTelefoneTutor) 
                            VALUES (@Id, @IdAnimalBancoServidor, @NomeAnimal, @NomeTutor, @Raca, @Sexo, @DataNascimento, @Observacoes, @NumeroTelefoneTutor)";
                }
                else // Atualizar registro existente
                {
                    sql = @"UPDATE Animal SET
                            IdAnimalBancoServidor = @IdAnimalBancoServidor,
                            NomeAnimal = @NomeAnimal,
                            NomeTutor = @NomeTutor,
                            Raca = @Raca,
                            Sexo = @Sexo,
                            DataNascimento = @DataNascimento,
                            Observacoes = @Observacoes,
                            NumeroTelefoneTutor = @NumeroTelefoneTutor
                            WHERE Id = @Id";
                }

                using var cmd = new SqliteCommand(sql, conexao);
                cmd.Parameters.AddWithValue("@Id", animal.Id.ToString());
                cmd.Parameters.AddWithValue("@IdAnimalBancoServidor", animal.IdAnimalBancoServidor);
                cmd.Parameters.AddWithValue("@NomeAnimal", animal.NomeAnimal);
                cmd.Parameters.AddWithValue("@NomeTutor", animal.NomeTutor);
                cmd.Parameters.AddWithValue("@Raca", animal.Raca);
                cmd.Parameters.AddWithValue("@Sexo", animal.Sexo);
                cmd.Parameters.AddWithValue("@DataNascimento", animal.DataNascimento.ToString("yyyy-MM-dd"));
                cmd.Parameters.AddWithValue("@Observacoes", animal.Observacoes);
                cmd.Parameters.AddWithValue("@NumeroTelefoneTutor", animal.NumeroTelefoneTutor);

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

        public static Mensagem ListAll(out List<Animal> animais)
        {
            animais = new List<Animal>();
            try
            {
                using var conexao = new SqliteConnection(_caminhoBanco);
                conexao.Open();

                string sql = "SELECT * FROM Animal";
                using var cmd = new SqliteCommand(sql, conexao);
                using var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    animais.Add(new Animal
                    {
                        Id = Guid.Parse(reader["Id"].ToString()),
                        IdAnimalBancoServidor = reader["IdAnimalBancoServidor"].ToString(),
                        NomeAnimal = reader["NomeAnimal"].ToString(),
                        NomeTutor = reader["NomeTutor"].ToString(),
                        Raca = reader["Raca"].ToString(),
                        Sexo = reader["Sexo"].ToString(),
                        DataNascimento = DateTime.Parse(reader["DataNascimento"].ToString()),
                        Observacoes = reader["Observacoes"].ToString(),
                        NumeroTelefoneTutor = reader["NumeroTelefoneTutor"].ToString()
                    });
                }
                return new Mensagem();
            }
            catch (Exception ex)
            {
                return new Mensagem(ex.Message, ex);
            }
        }
    }
}
