
namespace ClubeDoLivro.Domain
{
    public class Autor
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string SobreNome { get; set; }
        public List<Livro> Livros { get; set; }
        public int LivrosEscritos => Livros.Count;

        public Autor()
        {
            Livros = new List<Livro>();
        }

        public void AdicionarLivro(Livro livro)
        {
            if(!Livros.Contains(livro))
            {
                Livros.Add(livro);
                livro.AdicionarAutor(this);
            }
        }
    }
}