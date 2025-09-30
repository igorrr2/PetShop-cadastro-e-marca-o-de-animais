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

        public static void Logout()
        {
            Token = null;
            Usuario = null;
        }

    }
}
