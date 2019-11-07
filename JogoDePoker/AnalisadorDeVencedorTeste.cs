using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace JogoDePoker
{
    public class AnalisadorDeVencedorTeste
    {

        //Dois jogadores cada um com 5 cartas e saber quem é o vencedor
        //metodo para fazer com o que o segundo jogador vença
        [Theory]
        [InlineData("2O, 4C, 3P, 6C, 7C", "3O, 5C, 2E, 9C, 7P", "Segundo Jogador")]
        [InlineData("3O, 5C, 2E, 9C, 7P", "2O, 4C, 3P, 6C, 7C", "Primeiro Jogador")]
        public void DeveAnalisarvencedorQuandoTiverMaiorCarta(string cartasDoPrimeiroJogadorString, string cartasDoSegundoJogadorString, string vencedorEsperado)
        {

            var cartasDoPrimeiroJogador = cartasDoPrimeiroJogadorString.Split(',').ToList();
            var cartasDoSegundoJogador = cartasDoSegundoJogadorString.Split(',').ToList();
            var analisador = new AnalisadorDeVencedor();


            var vencedor = analisador.Analisar(cartasDoPrimeiroJogador, cartasDoSegundoJogador);
            Assert.Equal(vencedorEsperado, vencedor);
        }
    }

    public class AnalisadorDeVencedor
    {
        public AnalisadorDeVencedor()
        {
        }

        public string Analisar(List<string> cartasDoPrimeiroJogador, List<string> cartasDoSegundoJogador)
        {
            var maiorCartaDoPrimeiroJogador = cartasDoPrimeiroJogador
                .Select(carta => int.Parse(carta.Substring(0, 1)))
                .OrderBy(valorDaCarta => valorDaCarta)
                .Max();

            var maiorCartaDoSegundoJogador = cartasDoSegundoJogador
                .Select(carta => int.Parse(carta.Substring(0, 1)))
                .OrderBy(valorDaCarta => valorDaCarta)
                .Max();

            return maiorCartaDoPrimeiroJogador > maiorCartaDoSegundoJogador ? "Primeiro Jogador" : "Segundo Jogador";
            
        }
    }
}
