using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Enygma;

namespace Enygma.ClassEncrypt
{
    public class Trilho
    {

        public string CriptografarEmTrilho(string mensagem, int alturaTrilho)
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

        public string DesriptografarEmTrilho(string mensagem, int numLinhas)
        {
            int tamanho = mensagem.Length;

            // Determina quantos caracteres cabem em cada linha

            int numCaracteresLinhaCheia = tamanho / numLinhas;

            int numLinhasCom1CaracterExtra = tamanho % numLinhas;

            // Determina quantos caracteres cada linha terá

            int[] numCaracteresLinha = new int[numLinhas];

            for (int i = 0; i < numLinhas; i++)
            {
                numCaracteresLinha[i] = (i < numLinhasCom1CaracterExtra) ? numCaracteresLinhaCheia + 1 : numCaracteresLinhaCheia;
            }

            // Descriptografa a mensagem

            int posicao = 0;

            char[,] matriz = new char[numLinhas, numCaracteresLinhaCheia + 1];

            for (int linha = 0; linha < numLinhas; linha++)
            {
                for (int coluna = 0; coluna < numCaracteresLinha[linha]; coluna++)
                {
                    matriz[linha, coluna] = mensagem[posicao];

                    posicao++;
                }
            }

            string mensagemDescriptografada = "";

            for (int coluna = 0; coluna < numCaracteresLinhaCheia + 1; coluna++)
            {
                for (int linha = 0; linha < numLinhas; linha++)
                {
                    if (coluna < numCaracteresLinha[linha])
                    {
                        mensagemDescriptografada += matriz[linha, coluna];
                    }
                }
            }

            return mensagemDescriptografada;
        }
    }
}