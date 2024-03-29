using Alura.Estacionamento.Alura.Estacionamento.Modelos;
using Alura.Estacionamento.Modelos;
using System;
using Xunit;
using Xunit.Abstractions;

namespace Alura.Estacionamento.Testes
{
    public class VeiculoTeste : IDisposable
    {
        private Veiculo veiculo;
        public ITestOutputHelper SaidaConsoleTeste;

        public VeiculoTeste(ITestOutputHelper _saidaConsoleTeste)
        {
            SaidaConsoleTeste = _saidaConsoleTeste;
            SaidaConsoleTeste.WriteLine("Construtor invocado.");
            veiculo = new Veiculo();
        }
        
        [Fact]
        public void TestaVeiculoAcelerarComParametro10()
        {
            //Arrange
            //var veiculo = new Veiculo();
            //Act
            veiculo.Acelerar(10);
            //Assert
            Assert.Equal(100, veiculo.VelocidadeAtual);
        }

        [Fact]
        public void TestaVeiculoFrearComParametro10()
        {
            //Arrange
            //var veiculo = new Veiculo();
            //Act
            veiculo.Frear(10);
            //Assert
            Assert.Equal(-150, veiculo.VelocidadeAtual);
        }

        [Fact(Skip = "Teste ainda n�o implementado. Ignorar")]
        public void ValidaNomeProprietarioDoVeiculo()
        {
            //Arrange


            //Act


            //Assert
        }

        [Fact]

        public void FichaDeInformacaoDoVeiculo()
        {
            //Arrange
            //var carro = new Veiculo();
            veiculo.Proprietario = "Carlos Silva";
            veiculo.Tipo = TipoVeiculo.Automovel;
            veiculo.Placa = "ZAP-7419";
            veiculo.Cor = "Verde";
            veiculo.Modelo = "Variante";

            //Act
            string dados = veiculo.ToString();

            //Assert
            Assert.Contains("Ficha do Ve�culo:", dados);
        }

        [Fact]
        public void TestaNomeProprietarioVeiculoComMenosDeTresCaracteres()
        {
            //Arrange
            string nomeProprietario = "Ab";
            
            //Assert
            Assert.Throws<System.FormatException>(
                //Act
                () => new Veiculo(nomeProprietario)
            );
        }

        [Fact]
        public void TestaMensagemExcecaoDoQuartoCaractereDaPlaca()
        {
            //Arrange
            string placa = "ASDF8888";

            //Act
            var mensagem = Assert.Throws<System.FormatException>(
                
                () => new Veiculo().Placa = placa
            );

            //Assert
            Assert.Equal("O 4� caractere deve ser um h�fen", mensagem.Message);
        }

        [Fact]
        public void TestaMensagemExcecaoUltimosDigitosDaPlacaSaoNumeros()
        {
            //Arrange
            string placa = "ASD-7F47";

            //Act
            var mensagem = Assert.Throws<System.FormatException>(
                    () => new Veiculo().Placa = placa
                );

            //Assert
            Assert.Equal("Do 5� ao 8� caractere deve-se ter um n�mero!", mensagem.Message);

        }

        public void Dispose()
        {
            SaidaConsoleTeste.WriteLine("Dispose invocado.");
        }
    }
}
