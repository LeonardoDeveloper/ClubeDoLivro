using ClubeDoLivro.Domain;
using FluentAssertions;

namespace ClubeDoLivro.Testes
{
    public class LivroTeste
    {
        private readonly Livro _livro;
        public LivroTeste()
        {
            _livro = new Livro();
        }

        [Fact]
        public void QuandoEuCrioUmLivro_OLivroDeveSerCriadoCorretamente()
        {

            //Arrange

            //Act

            //Assert
            Assert.NotNull(_livro);
        }

        [Fact]
        public void QuandoEuCrioUmLivro_AQuantidadeDeAutoresDeveSerZero()
        {
            //Arrange

            //Act

            //Assert
            _livro.QuantidadeAutores.Should().Be(0);
        }

        [Fact]
        public void QuandoEuCrioUmLivro_APropriedadePaginasDeveSerZero()
        {
            //Arrange

            //Act

            //Assert
            _livro.Paginas.Should().Be(0);
        }

        [Fact]
        public void QuandoEuCrioUmLivro_APropriedadeEdicaoDeveSerNula()
        {
            //Arrange

            //Act

            //Assert
            Assert.Null(_livro.Edicao);
        }

        [Fact]
        public void QuandoEuCrioUmLivro_APropriedadeNomeDeveSerNula()
        {
            //Arrange

            //Act

            //Assert
            Assert.Null(_livro.Nome);
        }

        [Fact]
        public void QuandoEuCrioUmLivro_APropriedadeCodigoISBNDeveSerNula()
        {
            //Arrange

            //Act

            //Assert
            Assert.Null(_livro.CodigoISBN);
        }

        [Fact]
        public void QuandoEuCrioUmLivro_APropriedadeVolumeDeveSerNula()
        {
            //Arrange

            //Act

            //Assert
            Assert.Null(_livro.Volume);
        }

        [Fact]
        public void QuandoEuCrioUmLivro_APropriedadeIDDeveSerZero()
        {
            //Arrange

            //Act

            //Assert
            Assert.Equal(0, _livro.Id);
        }

        [Fact]
        public void QuandoEuAdicionoUmAutorParaOLivro_EsseAutorPrecisaAtualizarAListaDeLivrosEscritos()
        {
            //Arrange
            var autor = AutorTesteFactory.ObterAutor();

            var livro = LivroTesteFactory.ObterLivro();
            //Act
            livro.AdicionarAutor(autor);

            //Assert
            autor.LivrosEscritos.Should().Be(1);
            autor.Livros.Should().NotBeEmpty();
            autor.Livros.Should().HaveCount(1);
        }
    }
}