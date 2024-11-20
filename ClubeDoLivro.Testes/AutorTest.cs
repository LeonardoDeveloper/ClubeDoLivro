using ClubeDoLivro.Domain;
using FluentAssertions;
using FluentAssertions.Equivalency;

namespace ClubeDoLivro.Testes
{
    public class AutorTest
    {
        private readonly Autor _autor;
        public AutorTest()
        {
            _autor = AutorTesteFactory.ObterAutor();
        }

        [Fact]
        public void QuandoEuCrioUmAutor_OAutorDeveSerCriadoCorretamente()
        {
            //Arrange

            //Act

            //Assert
            _autor.EhValido().Should().BeTrue();
        }

        [Fact]
        public void QuandoEuAdicionoUmLivroNoAutor_AQuantidadeDeLivrosEscritosDeveAumentarEmUmaUnidade()
        {
            //Arrange
            var livro = LivroTesteFactory.ObterLivro();
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
            var livro = LivroTesteFactory.ObterLivro();
            var quantidadeDeLivrosAntes = _autor.LivrosEscritos;
            var quantidadeEsperada = quantidadeDeLivrosAntes + 1;

            //Act
            _autor.AdicionarLivro(livro);


            //Assert
            Assert.True(livro.QuantidadeAutores == 1);
            livro.FoiEscritoPelo(_autor).Should().BeTrue();
        }

        [Fact]
        public void QuandoEuAdicionoDoisLivrosoNoAutor_OAutorPrecisaTerDoisLivros()
        {
            //Arrange
            var livro1 = LivroTesteFactory.ObterLivro(1);
            var livro2 = LivroTesteFactory.ObterLivro(2);
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

        [Fact]
        public void QuandoEuDigoQueUmAutorEscreveUmLivro_EsseLivroDeveConterOAutorEmSuaListaDeAutores()
        {
            //Arrange
            var livro1 = LivroTesteFactory.ObterLivro();

            //Act
            _autor.AdicionarLivro(livro1);

            //Assert
            _autor.Livros.Should().NotBeEmpty();
            _autor.Livros.Should().HaveCount(1);

            _autor.LivrosEscritos.Should().Be(1);

            livro1.QuantidadeAutores.Should().Be(1);
        }
    }

    public class LivroTesteFactory
    {
        public static Livro ObterLivro(int id = 0)
        {
            return new Livro { Id = id, CodigoISBN = "1214322", Edicao = "1", Nome = "C#", Paginas = 125, Volume = "1" };
        }
    }

    public class AutorTesteFactory
    {
        public static Autor ObterAutor(int id = 0)
        {
            return new Autor {Id = id,  Nome = "Leonardo", SobreNome = "Said"  };
        }
    }

}
