using System;
using System.Collections.Generic;
using System.IO;

namespace InterpretadorDeNumeros.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string texto = " __   __  \n" +
                           " __| |  | \n" +
                           "|__  |__| ";


            StringReader leitorTexto = new StringReader(texto);

            var primeiraLinha = leitorTexto.ReadLine();
            char[] arrayPrimeiraLinha = primeiraLinha.ToCharArray();

            string segundaLinha = leitorTexto.ReadLine();
            char[] arraySegundaLinha = segundaLinha.ToCharArray();

            string terceiraLinha = leitorTexto.ReadLine();
            char[] arrayTerceiraLinha = terceiraLinha.ToCharArray();

            var indicePrimeiraColuna = 0;
            var indiceUltimaColuna = 3;

            for (int i = indicePrimeiraColuna; i < indiceUltimaColuna; i++)
            {
                if (indicePrimeiraColuna >= arrayPrimeiraLinha.Length)
                {
                    break;
                }

                var estruturaDoNumero = new bool[7] { false, // Superior 0
                                                        false, // Sup Dir 1
                                                        false, // Inf Dir 2
                                                        false, // Inferior 3
                                                        false, // Inf Esq 4
                                                        false, // Sup Esq 5
                                                        false  // Central 6
                                                               };

                var caracter = arrayPrimeiraLinha[indicePrimeiraColuna + 1];
                if (caracter == '_')
                {
                    estruturaDoNumero[0] = true; // Superior
                }

                caracter = arraySegundaLinha[indicePrimeiraColuna];
                if (caracter == '|')
                {
                    estruturaDoNumero[5] = true; // Superior Esquerdo
                }

                caracter = arraySegundaLinha[indicePrimeiraColuna + 1];
                if (caracter == '_')
                {
                    estruturaDoNumero[6] = true; // Central
                }

                caracter = arraySegundaLinha[indicePrimeiraColuna + 3];
                if (caracter == '|')
                {
                    estruturaDoNumero[1] = true; // Superior Direito
                }

                caracter = arrayTerceiraLinha[indicePrimeiraColuna];
                if (caracter == '|')
                {
                    estruturaDoNumero[4] = true; // Inferior Esquerdo
                }

                caracter = arrayTerceiraLinha[indicePrimeiraColuna + 1];
                if (caracter == '_')
                {
                    estruturaDoNumero[3] = true; // Inferior
                }

                caracter = arrayTerceiraLinha[indicePrimeiraColuna + 3];
                if (caracter == '|')
                {
                    estruturaDoNumero[2] = true; // Inferior Direito
                }

                indicePrimeiraColuna += 5;
                indiceUltimaColuna += 5;

                if (estruturaDoNumero[0] && estruturaDoNumero[1] && estruturaDoNumero[6] &&
                estruturaDoNumero[4] && estruturaDoNumero[3] && estruturaDoNumero[5] == false && 
                estruturaDoNumero[2] == false)
                {
                    Console.Write("2");
                }
                else if (estruturaDoNumero[0] && estruturaDoNumero[1] && estruturaDoNumero[2] &&
                estruturaDoNumero[3] && estruturaDoNumero[4] && estruturaDoNumero[5] && 
                estruturaDoNumero[6] == false)
                {
                    Console.Write("0");
                }
                else
                {
                    Console.WriteLine("Não identifiquei, senhora.");
                }
            }

            Console.ReadLine();

            // Superior 0
            // Sup Dir 1
            // Inf Dir 2
            // Inferior 3
            // Inf Esq 4
            // Sup Esq 5
            // Central 6
        }
    }
}
