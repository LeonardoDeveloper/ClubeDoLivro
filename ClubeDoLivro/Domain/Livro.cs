namespace ClubeDoLivro.Domain
{
    public class Livro
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Volume { get; set; }
        public string Edicao { get; set; }
        public string CodigoISBN { get; set; }
        public string Paginas { get; set; }
        public List<Autor> Autores { get; set; }

        public Livro()
        {
            Autores = new List<Autor>();
        }

        public void AdicionarAutor(Autor autor)
        {
            if(!Autores.Contains(autor))
            {  
                Autores.Add(autor);
                autor.AdicionarLivro(this);
            }    
        }
    }
}
