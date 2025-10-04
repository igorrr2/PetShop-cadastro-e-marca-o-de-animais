using PetShop.Models;
using System;
using System.Collections.Generic;
using Microsoft.Data.Sqlite;
using Util.MensagemRetorno;

namespace PetShop.Data
{
    public class BanhoTosaRepository
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
                CREATE TABLE IF NOT EXISTS BanhoTosaAgendamentos (
                    Id TEXT PRIMARY KEY,
                    NomeAnimalAgendado TEXT NOT NULL,
                    NomeTutorAnimal TEXT NOT NULL,
                    ModalidadeAgendamento TEXT NOT NULL,
                    DataAgendamento DATETIME NOT NULL,
                    Observacoes TEXT
                );";

            using var cmd = new SqliteCommand(sql, conexao);
            cmd.ExecuteNonQuery();
        }

        public static Mensagem TryGet(Guid id, out BanhoTosa banhoTosa)
        {
            banhoTosa = null;
            try
            {
                using var conexao = new SqliteConnection(_caminhoBanco);
                conexao.Open();

                string sql = "SELECT * FROM BanhoTosaAgendamentos WHERE Id = @Id";
                using var cmd = new SqliteCommand(sql, conexao);
                cmd.Parameters.AddWithValue("@Id", id.ToString());

                using var reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    banhoTosa = LerBanhoTosa(reader);
                    return new Mensagem();
                }
            }
            catch (Exception ex)
            {
                return new Mensagem(ex.Message, ex);
            }

            return new Mensagem("Agendamento não encontrado no banco de dados");
        }

        public static Mensagem TrySave(BanhoTosa banhoTosa)
        {
            if (banhoTosa == null)
                return new Mensagem("Não há Agendamentos para salvar.");

            try
            {
                using var conexao = new SqliteConnection(_caminhoBanco);
                conexao.Open();

                string sql;
                if (banhoTosa.Id == Guid.Empty) // Novo registro
                {
                    banhoTosa.Id = Guid.NewGuid();
                    sql = @"INSERT INTO BanhoTosaAgendamentos 
                            (Id, DataAgendamento, ModalidadeAgendamento, NomeAnimalAgendado, NomeTutorAnimal, Observacoes) 
                            VALUES (@Id, @DataAgendamento, @ModalidadeAgendamento, @NomeAnimalAgendado, @NomeTutorAnimal, @Observacoes)";
                }
                else // Atualizar registro existente
                {
                    sql = @"UPDATE BanhoTosaAgendamentos SET
                            DataAgendamento = @DataAgendamento,
                            ModalidadeAgendamento = @ModalidadeAgendamento,
                            NomeAnimalAgendado = @NomeAnimalAgendado,
                            NomeTutorAnimal = @NomeTutorAnimal,
                            Observacoes = @Observacoes
                            WHERE Id = @Id";
                }

                using var cmd = new SqliteCommand(sql, conexao);
                cmd.Parameters.AddWithValue("@Id", banhoTosa.Id.ToString());
                cmd.Parameters.AddWithValue("@DataAgendamento", banhoTosa.DataAgendamento.ToString("yyyy-MM-dd HH:mm:ss"));
                cmd.Parameters.AddWithValue("@ModalidadeAgendamento", banhoTosa.ModalidadeAgendamento);
                cmd.Parameters.AddWithValue("@NomeAnimalAgendado", banhoTosa.NomeAnimalAgendado);
                cmd.Parameters.AddWithValue("@NomeTutorAnimal", banhoTosa.NomeTutorAnimal);
                cmd.Parameters.AddWithValue("@Observacoes", banhoTosa.Observacoes);

                cmd.ExecuteNonQuery();
                return new Mensagem();
            }
            catch (Exception ex)
            {
                return new Mensagem(ex.Message, ex);
            }
        }

        public static Mensagem TryDelete(Guid id)
        {
            try
            {
                using var conexao = new SqliteConnection(_caminhoBanco);
                conexao.Open();

                string sql = "DELETE FROM BanhoTosaAgendamentos WHERE Id = @Id";
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

        public static Mensagem ListAll(out List<BanhoTosa> banhoTosaList, bool Historico = false)
        {
            banhoTosaList = new List<BanhoTosa>();
            try
            {
                using var conexao = new SqliteConnection(_caminhoBanco);
                conexao.Open();
                string sql;
                if (Historico)
                {
                    sql = @"
                    SELECT * FROM BanhoTosaAgendamentos
                    WHERE DATE(DataAgendamento) < DATE('now', 'localtime')
                    ORDER BY DataAgendamento ASC";
                }
                else
                {
                    sql = @"
                    SELECT * FROM BanhoTosaAgendamentos
                    WHERE DATE(DataAgendamento) >= DATE('now', 'localtime')
                    ORDER BY DataAgendamento ASC";
                }
                using var cmd = new SqliteCommand(sql, conexao);
                using var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    banhoTosaList.Add(LerBanhoTosa(reader));
                }
                return new Mensagem();
            }
            catch (Exception ex)
            {
                return new Mensagem(ex.Message, ex);
            }
        }

        public static Mensagem TryGetByAgendamentosDoDia(out List<BanhoTosa> banhoTosaList)
        {
            banhoTosaList = new List<BanhoTosa>();
            try
            {
                using var conexao = new SqliteConnection(_caminhoBanco);
                conexao.Open();

                string sql = @"
                    SELECT * FROM BanhoTosaAgendamentos
                    WHERE DATE(DataAgendamento) = DATE('now', 'localtime')
                    ORDER BY DataAgendamento ASC";

                using var cmd = new SqliteCommand(sql, conexao);
                using var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    banhoTosaList.Add(LerBanhoTosa(reader));
                }
                return new Mensagem();
            }
            catch (Exception ex)
            {
                return new Mensagem(ex.Message, ex);
            }
        }

        // Método auxiliar para ler os dados
        private static BanhoTosa LerBanhoTosa(SqliteDataReader reader)
        {
            return new BanhoTosa
            {
                Id = Guid.Parse(reader["Id"].ToString()),
                DataAgendamento = DateTime.Parse(reader["DataAgendamento"].ToString()),
                ModalidadeAgendamento = reader["ModalidadeAgendamento"].ToString(),
                NomeAnimalAgendado = reader["NomeAnimalAgendado"].ToString(),
                NomeTutorAnimal = reader["NomeTutorAnimal"].ToString(),
                Observacoes = reader["Observacoes"].ToString()
            };
        }
    }
}
