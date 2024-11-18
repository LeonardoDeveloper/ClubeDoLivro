namespace ClubeDoLivro.Domain
{
    public class Autor
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string SobreNome { get; set; }

        public List<Livro> Livros { get; set; }
    }
}