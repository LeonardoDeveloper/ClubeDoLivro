﻿using System.Linq;

namespace ClubeDoLivro.Domain
{
    public class Livro
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Volume { get; set; }
        public string Edicao { get; set; }
        public string CodigoISBN { get; set; }
        public int Paginas { get; set; }
        private List<Autor> Autores { get; set; }
        public int QuantidadeAutores => Autores.Count;

        public Livro()
        {
            Autores = new List<Autor>();
        }

        public bool FoiEscritoPelo(Autor autor)
        {
            return Autores.Any(x => x.Id == autor.Id);
        }

        public void AdicionarAutor(Autor autor)
        {
            if(!Autores.Any(x => x.Id == autor.Id))
            {
                if (autor.EhValido())
                {
                    Autores.Add(autor);
                    autor.AdicionarLivro(this);
                }
            }    
        }

        public bool EhValido()
        {
            return
                    !string.IsNullOrWhiteSpace(Nome)
                    && !string.IsNullOrWhiteSpace(Volume)
                    && !string.IsNullOrWhiteSpace(Edicao)
                    && !string.IsNullOrWhiteSpace(CodigoISBN)
                    && Paginas > 0;
        }
    }
}
