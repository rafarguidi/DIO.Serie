using System;
using System.Collections.Generic;
using System.Text;

namespace DIO.Series
{
    public class Serie : EntidadeBase
    {
        private Genero Genero { get; set; }
        private string Titulo { get; set; }
        private string Descricao { get; set; }
        private int Ano { get; set; }

        public Serie(int id, Genero genero, string titulo, string descricao, int ano)
        {
            this.Id = id;
            this.Genero = genero;
            this.Titulo = titulo;
            this.Descricao = descricao;
            this.Ano = ano;
        }

        public override string ToString()
        {
            string texto = $@"
            ID: {this.Id}
            Genero: {this.Genero}
            Titulo: {this.Titulo}
            Descricao: {this.Descricao}
            Ano: {this.Ano}";
            return texto;
        }

        public int GetId => this.Id;

        public string GetTitulo() => this.Titulo;

    }
}
