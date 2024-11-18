using ClubeDoLivro.Domain;

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
        public void QuandoEuCrioUmLivro_APropriedadeAutoresDeveEstarInstanciada()
        {
            //Arrange

            //Act

            //Assert
            Assert.NotNull(_livro.Autores);
        }

        [Fact]
        public void QuandoEuCrioUmLivro_APropriedadePaginasDeveSerNula()
        {
            //Arrange

            //Act

            //Assert
            Assert.Null(_livro.Paginas);
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
    }
}