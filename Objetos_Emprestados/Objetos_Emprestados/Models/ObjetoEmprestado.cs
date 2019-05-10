using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace Objetos_Emprestados.Models
{
    public class ObjetoEmprestado
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Descricao { get; set; }
        public string Nome { get; set; }
        public DateTime Data { get; set; }
    }
}
