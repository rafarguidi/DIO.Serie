using System;
using System.Collections.Generic;
using System.Text;

namespace DIO.Series
{
    public class Serie : EntidadeBase
    {
        private Genero Genero;
        private string Titulo;
        private string Descricao;
        private int Ano;
        private bool Ativo;

        public Serie(int id, Genero genero, string titulo, string descricao, int ano)
        {
            this.Id = id;
            this.Genero = genero;
            this.Titulo = titulo;
            this.Descricao = descricao;
            this.Ano = ano;
            this.Ativo = true;
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

        public void Desativar()
        {
            this.Ativo = false;
        }

        public void Ativar()
        {
            this.Ativo = true;
        }

        public bool GetAtivo() => this.Ativo;

    }
}
