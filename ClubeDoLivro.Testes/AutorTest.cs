using ClubeDoLivro.Domain;
using FluentAssertions;

namespace ClubeDoLivro.Testes
{
    public class AutorTest
    {
        private readonly Autor _autor;
        public AutorTest()
        {
            _autor = new Autor();
        }

        [Fact]
        public void QuandoEuCrioUmAutor_OAutorDeveSerCriadoCorretamente()
        {
            //Arrange

            //Act

            //Assert
            Assert.NotNull(_autor);
            Assert.NotNull(_autor.Livros);
            Assert.Equal(0, _autor.Id);
            Assert.Null(_autor.Nome);
            Assert.Null(_autor.SobreNome);
        }

        [Fact]
        public void QuandoEuAdicionoUmLivroNoAutor_AQuantidadeDeLivrosEscritosDeveAumentarEmUmaUnidade()
        {
            //Arrange
            var livro = new Livro();
            var quantidadeDeLivrosAntes = _autor.LivrosEscritos;
            var quantidadeEsperada = quantidadeDeLivrosAntes + 1;

            //Act
            _autor.AdicionarLivro(livro);
            

            //Assert
            Assert.Equal(quantidadeEsperada, _autor.LivrosEscritos);
          
        }

        [Fact]
        public void QuandoEuAdicionoUmLivroNoAutor_OLivroPrecisaConterOAutorNaListaDeAutores()
        {
            //Arrange
            var livro = new Livro();
            var quantidadeDeLivrosAntes = _autor.LivrosEscritos;
            var quantidadeEsperada = quantidadeDeLivrosAntes + 1;

            //Act
            _autor.AdicionarLivro(livro);


            //Assert
            Assert.True(livro.Autores.Count == 1);
            Assert.Contains(_autor, livro.Autores);
        }

        [Fact]
        public void QuandoEuAdicionoDoisLivrosoNoAutor_OAutorPrecisaTerDoisLivros()
        {
            //Arrange
            var livro1 = new Livro();
            var livro2 = new Livro();
            var quantidadeDeLivrosAntes = _autor.LivrosEscritos;
            var quantidadeEsperada = quantidadeDeLivrosAntes + 2;

            //Act
            _autor.AdicionarLivro(livro1);
            _autor.AdicionarLivro(livro2);


            //Assert
            Assert.Contains(livro1, _autor.Livros);
            Assert.Contains(livro2, _autor.Livros);

            _autor.LivrosEscritos.Should().Be(quantidadeEsperada);
        }
    }
}
