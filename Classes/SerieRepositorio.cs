using DIO.Series.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DIO.Series
{
    public class SerieRepositorio : IRepositorio<Serie>
    {
        private List<Serie> listaSerie = new List<Serie>();

        public void Atualizar(int id, Serie entidade)
        {
            var index = listaSerie.FindIndex(s => s.Id == id);
            listaSerie[index] = entidade;
        }

        public void Excluir(int id)
        {
            var serie = RetornarPorId(id);
            serie.Desativar();
        }

        public void Insere(Serie entidade)
        {
            listaSerie.Add(entidade);
        }

        public List<Serie> Lista()
        {
            return listaSerie.FindAll(s => s.GetAtivo());
        }

        public int ProximoId()
        {
            return listaSerie.Count();
        }

        public Serie RetornarPorId(int id)
        {
            return listaSerie.Find(s => s.Id == id);
        }
    }
}
