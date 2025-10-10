using ApiPetShopLibrary.Login;
using PetShopClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Util.MensagemRetorno;

namespace PetShop
{
    public static class AppSession
    {
        public static string Token { get; set; }
        public static string Usuario { get; set; }
        public static string UsuarioId { get; set; }

        public static bool EstaLogado => !string.IsNullOrEmpty(Token);

        public static async Task Logout(Form owner)
        {

            using (var loading = new LoadingForm("Efetuando Logout...", "Aguarde enquanto o logout está sendo efetuado"))
            {
                loading.StartPosition = FormStartPosition.CenterScreen;

                var task = Task.Run(async () =>
                {
                    try
                    {
                        Client cliente = new Client();
                        var resultado = await cliente.DeslogarAsync(Token);

                        Token = null;
                        Usuario = null;
                        UsuarioId = null;
                    }
                    catch (Exception ex)
                    {
                    }
                    finally
                    {
                        if (!loading.IsDisposed)
                            loading.Invoke(new Action(() => loading.Close()));
                    }
                });

                loading.ShowDialog(owner);

                task.Wait();
            }
        }

    }
}

