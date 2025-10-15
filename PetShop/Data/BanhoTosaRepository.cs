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
                    IdAgendamentoBancoServidor TEXT,
                    UsuarioId TEXT,
                    AnimalId TEXT,
                    ModalidadeAgendamento TEXT NOT NULL,
                    DataAgendamento DATETIME NOT NULL,
                    Observacoes TEXT
                );";

            using var cmd = new SqliteCommand(sql, conexao);
            cmd.ExecuteNonQuery();
        }

        public static Mensagem TryGetByIdAgendamentoBancoServidor(string IdAgendamentoBancoServidor, out BanhoTosa banhoTosa)
        {
            banhoTosa = null;
            try
            {
                using var conexao = new SqliteConnection(_caminhoBanco);
                conexao.Open();

                string sql = "SELECT * FROM BanhoTosaAgendamentos WHERE IdAgendamentoBancoServidor = @IdAgendamentoBancoServidor";
                using var cmd = new SqliteCommand(sql, conexao);
                cmd.Parameters.AddWithValue("@IdAgendamentoBancoServidor", IdAgendamentoBancoServidor);

                using var reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    banhoTosa = LerBanhoTosa(reader); 
                }
            }
            catch (Exception ex)
            {
                return new Mensagem(ex.Message, ex);
            }
            return new Mensagem();

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
                if (banhoTosa.Id == Guid.Empty) 
                {
                    banhoTosa.Id = Guid.NewGuid();
                    sql = @"INSERT INTO BanhoTosaAgendamentos 
                            (Id, IdAgendamentoBancoServidor, UsuarioId, AnimalId, DataAgendamento, ModalidadeAgendamento, Observacoes) 
                            VALUES (@Id, @IdAgendamentoBancoServidor, @UsuarioId, @AnimalId, @DataAgendamento, @ModalidadeAgendamento, @Observacoes)";
                }
                else 
                {
                    sql = @"UPDATE BanhoTosaAgendamentos SET
                            IdAgendamentoBancoServidor = @IdAgendamentoBancoServidor,
                            UsuarioId = @UsuarioId,
                            DataAgendamento = @DataAgendamento,
                            ModalidadeAgendamento = @ModalidadeAgendamento,
                            Observacoes = @Observacoes
                            WHERE Id = @Id";
                }

                using var cmd = new SqliteCommand(sql, conexao);
                cmd.Parameters.AddWithValue("@Id", banhoTosa.Id.ToString());
                cmd.Parameters.AddWithValue("@AnimalId", banhoTosa.AnimalId.ToString());
                cmd.Parameters.AddWithValue("@IdAgendamentoBancoServidor", banhoTosa.IdAgendamentoBancoServidor);
                cmd.Parameters.AddWithValue("@UsuarioId", banhoTosa.UsuarioId);
                cmd.Parameters.AddWithValue("@DataAgendamento", banhoTosa.DataAgendamento.ToString("yyyy-MM-dd HH:mm:ss"));
                cmd.Parameters.AddWithValue("@ModalidadeAgendamento", banhoTosa.ModalidadeAgendamento);
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
                    sql = $@"
                    SELECT * FROM BanhoTosaAgendamentos
                    WHERE DataAgendamento < datetime('now', 'localtime') AND UsuarioId = '{AppSession.UsuarioId}' 
                    ORDER BY DataAgendamento ASC";
                }
                else
                {
                    sql = $@"
                    SELECT * FROM BanhoTosaAgendamentos
                    WHERE DataAgendamento >= datetime('now', 'localtime') AND UsuarioId = '{AppSession.UsuarioId}'
                    ORDER BY DataAgendamento ASC";
                }
                using var cmd = new SqliteCommand(sql, conexao);
                using var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    var banho = LerBanhoTosa(reader);

                    if (banho.AnimalId != Guid.Empty)
                    {
                        AnimalRepository.TryGet(banho.AnimalId, out Animal animal);
                        if (animal != null)
                        {
                            banho.NomeAnimalAgendado = animal.NomeAnimal;
                            banho.NomeTutorAnimal = animal.NomeTutor;
                        }
                    }

                    banhoTosaList.Add(banho);
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

                string sql = $@"
                    SELECT * FROM BanhoTosaAgendamentos
                    WHERE DATE(DataAgendamento) = DATE('now', 'localtime') AND UsuarioId = '{AppSession.UsuarioId}'
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

        private static BanhoTosa LerBanhoTosa(SqliteDataReader reader)
        {
            return new BanhoTosa
            {
                Id = Guid.Parse(reader["Id"].ToString()),
                AnimalId = Guid.Parse(reader["AnimalId"].ToString()),
                IdAgendamentoBancoServidor = reader["IdAgendamentoBancoServidor"].ToString(),
                UsuarioId = reader["UsuarioId"].ToString(),
                DataAgendamento = DateTime.Parse(reader["DataAgendamento"].ToString()),
                ModalidadeAgendamento = reader["ModalidadeAgendamento"].ToString(),
                Observacoes = reader["Observacoes"].ToString()
            };
        }
    }
}
