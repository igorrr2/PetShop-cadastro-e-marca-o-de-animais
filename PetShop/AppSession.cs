using ApiPetShopLibrary.Login;
using PetShopClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShop
{
    public static class AppSession
    {
        public static string Token { get; set; }
        public static string Usuario { get; set; }

        public static bool EstaLogado => !string.IsNullOrEmpty(Token);

        public static async Task Logout()
        {
            Client cliente = new Client();
            DeslogarResposta resultado = await cliente.DeslogarAsync(Token);
            Token = null;
            Usuario = null;
        }

    }
}
