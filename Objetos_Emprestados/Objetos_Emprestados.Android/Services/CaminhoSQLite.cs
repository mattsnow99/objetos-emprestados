using System;
using System.IO;
using Xamarin.Forms;
using Objetos_Emprestados.Droid.Services;
using Objetos_Emprestados.Services;

[assembly: Dependency(typeof(CaminhoSQLite))]
namespace Objetos_Emprestados.Droid.Services
{

    public class CaminhoSQLite : ICaminhoSQLite
    {
        public string GetCaminhoDB(string nomeDB)
        {
            string caminho = Environment.GetFolderPath(
                Environment.SpecialFolder.Personal);
            return Path.Combine(caminho, nomeDB);
        }
    }
}