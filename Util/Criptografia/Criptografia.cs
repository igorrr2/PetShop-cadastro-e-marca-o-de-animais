using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using Util.MensagemRetorno;

namespace Util.Criptografia
{
    public static class Criptografia
    {
        private static void GerarChaveIV(Guid guid, out byte[] key, out byte[] iv)
        {
            // Converte Guid em ShortGuid (Base64)
            ShortGuid shortGuid = guid;
            byte[] keyBytes = Encoding.UTF8.GetBytes(shortGuid.ToString());

            // AES exige chave de 16, 24 ou 32 bytes → ajusta para 32 bytes
            key = new byte[32];
            for (int i = 0; i < key.Length; i++)
                key[i] = keyBytes[i % keyBytes.Length];

            // Vetor de inicialização de 16 bytes
            iv = new byte[16];
            for (int i = 0; i < iv.Length; i++)
                iv[i] = keyBytes[i % keyBytes.Length];
        }

        public static Mensagem Criptografar(string senha, Guid chave, out string senhaCriptografada)
        {
            senhaCriptografada = string.Empty;

            if (string.IsNullOrEmpty(senha))
                return new Mensagem("Senha não informada");

            try
            {
                GerarChaveIV(chave, out byte[] key, out byte[] iv);

                using (Aes aes = Aes.Create())
                {
                    aes.Key = key;
                    aes.IV = iv;

                    ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);

                    using (MemoryStream ms = new MemoryStream())
                    using (CryptoStream cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write))
                    using (StreamWriter sw = new StreamWriter(cs))
                    {
                        sw.Write(senha);
                        sw.Flush();       // Esvazia buffer do StreamWriter
                        cs.FlushFinalBlock(); // Finaliza criptografia no CryptoStream
                        senhaCriptografada = Convert.ToBase64String(ms.ToArray());
                    }
                }

                return new Mensagem();
            }
            catch (Exception ex)
            {
                return new Mensagem(ex.Message, ex);
            }
        }

        public static Mensagem Descriptografar(string senhaCriptografada, Guid chave, out string senhaOriginal)
        {
            senhaOriginal = string.Empty;

            if (string.IsNullOrEmpty(senhaCriptografada))
                return new Mensagem("Senha não informada");

            try
            {
                GerarChaveIV(chave, out byte[] key, out byte[] iv);

                using (Aes aes = Aes.Create())
                {
                    aes.Key = key;
                    aes.IV = iv;

                    ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV);

                    using (MemoryStream ms = new MemoryStream(Convert.FromBase64String(senhaCriptografada)))
                    using (CryptoStream cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Read))
                    using (StreamReader sr = new StreamReader(cs))
                    {
                        senhaOriginal = sr.ReadToEnd();
                    }
                }

                return new Mensagem(); // sucesso
            }
            catch (Exception ex)
            {
                return new Mensagem(ex.Message, ex);
            }
        }
    }
}
