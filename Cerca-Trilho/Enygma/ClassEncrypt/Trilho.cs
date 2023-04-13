using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Enygma;

namespace Enygma.ClassEncrypt
{
    public class Trilho
    {

        public string CriptografarTrilho(string mensagem, int alturaTrilho)
        {
            // Inicializar a variável de saída
            string mensagemCriptografada = "";

            // Definir o tamanho da mensagem
            int tamanhoMensagem = mensagem.Length;

            // Definir o número de colunas do trilho
            int numeroColunasTrilho = (int)Math.Ceiling((double)tamanhoMensagem / (double)alturaTrilho);

            Console.WriteLine();

            // Criar uma matriz para armazenar a mensagem criptografada
            char[,] matrizCriptografada = new char[alturaTrilho, numeroColunasTrilho];

            Console.WriteLine();

            // Inicializar a posição atual na matriz
            int posicaoAtualLinha = 0;
            int posicaoAtualColuna = 0;

            // Percorrer cada caractere da mensagem
            for (int i = 0; i < tamanhoMensagem; i++)
            {
                // Adicionar o caractere à matriz criptografada na posição atual
                matrizCriptografada[posicaoAtualLinha, posicaoAtualColuna] = mensagem[i];

                // Atualizar a posição atual na matriz
                if (posicaoAtualLinha == alturaTrilho - 1)
                {
                    // Se a posição atual estiver na última linha, voltar para a primeira coluna e avançar uma linha
                    posicaoAtualLinha = 0;
                    posicaoAtualColuna++;
                }
                else
                {
                    // Se a posição atual não estiver na última linha, avançar uma linha
                    posicaoAtualLinha++;
                }
            }

            // Percorrer a matriz criptografada para obter a mensagem criptografada
            for (int i = 0; i < alturaTrilho; i++)
            {
                for (int j = 0; j < numeroColunasTrilho; j++)
                {
                    if (matrizCriptografada[i, j] != '\0')
                    {
                        // Se o caractere na posição atual não for um caractere nulo, adicionar à mensagem criptografada
                        mensagemCriptografada += matrizCriptografada[i, j];
                    }
                }
            }

            // Retornar a mensagem criptografada
            return mensagemCriptografada;
        }
        public string DesriptografarTrilho(string encryptedText, int height)
        {
            // Inicializa a variável para armazenar o texto descriptografado
            string decryptedText = "";

            // Inicializa a variável para manter o controle do índice da string criptografada
            int currentIndex = 0;

            // Calcula o tamanho da matriz baseado no número de caracteres e altura da cerca
            int matrixWidth = (int)Math.Ceiling((double)encryptedText.Length / (double)height);

            // Cria uma matriz vazia
            char[,] matrix = new char[height, matrixWidth];

            // Popula a matriz com os caracteres da string criptografada
            for (int col = 0; col < matrixWidth; col++)
            {
                for (int row = 0; row < height; row++)
                {
                    if (currentIndex < encryptedText.Length)
                    {
                        matrix[row, col] = encryptedText[currentIndex];
                        currentIndex++;
                    }
                    else
                    {
                        break;
                    }
                }
            }

            // Percorre a matriz para extrair o texto original
            currentIndex = 0;
            for (int col = 0; col < matrixWidth; col++)
            {
                for (int row = 0; row < height; row++)
                {
                    if (currentIndex < encryptedText.Length && matrix[row, col] != '\0')
                    {
                        decryptedText += matrix[row, col];
                        currentIndex++;
                    }
                    else
                    {
                        break;
                    }
                }
            }

            // Retorna o texto descriptografado
            return decryptedText;
        }
    }
}