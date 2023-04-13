using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Enygma;

namespace Enygma.ClassEncrypt
{
    public class Trilho_2
    {
        public int[] GerarSenha()
        {
            Random numeroAleatorio = new Random();

            int[] senha = new int[7];

            int count = 0, status = 1;

            while (count < 7)
            {
                int valor = numeroAleatorio.Next(1, 8);

                for (int i = 0; i < 7; i++)
                {
                    if (senha[i] == valor) status = 0;
                }

                if ((status == 1) && (valor != 0))
                {
                    senha[count] = valor;
                    count++;
                }
                status = 1;
            }

            int[] senha_2 = { 4, 3, 1, 2, 5, 6, 7 };

            // return senha_2;

            return senha;
        }

        public string CriptografarEmTrilho(string InMessage, int[] key)
        {
            int[] senha = key;

            int NumLinha = (int)Math.Ceiling((double)InMessage.Length / 7);

            // Converte o texto em vetor

            char[] TextoVetor = InMessage.ToCharArray();

            // Inicializa a matriz

            char[,] TextoMatriz = new char[NumLinha, 7];

            // Inicializa a saida da função

            char[] TextoCriptografado = new char[InMessage.Length];

            // Variaveis da função

            int count = 0, coluna = 0, posicao = 0;

            // Converte o texto em matriz

            for (int i = 0; i < NumLinha; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    if (count < InMessage.Length)
                    {
                        TextoMatriz[i, j] = TextoVetor[count];

                        count++;
                    }
                    else TextoMatriz[i, j] = ' ';
                }
            }

            // Indica a numeração correspondente da primeira coluna a ser analisada

            count = 1;

            // Inicio do processo de criptografia

            while (count <= 7)
            {

                // Identifica o indice da primeira coluna a ser analisada

                for (int i = 0; i < 7; i++)
                {
                    if (senha[i] == count) coluna = i;
                }

                //Processo de leitura vertical dos valores da coluna

                for (int i = 0; i < NumLinha; i++)
                {
                    if (TextoMatriz[i, coluna] != ' ')
                    {
                        TextoCriptografado[posicao] = TextoMatriz[i, coluna];
                        posicao++;
                    }

                }

                count++;
            }

            return new string(TextoCriptografado);

        }

        public string DescriptografarEmTrilho(string InMessage, int[] key)
        {

            int[] senha = key;

            int NumLinha = (int)Math.Ceiling((double)InMessage.Length / 7);

            // Converte o texto em vetor

            char[] TextoVetor = InMessage.ToCharArray();

            // Inicializa a matriz

            char[,] TextoMatriz = new char[NumLinha, 7];

            // Inicializa a saida da função

            char[] TextoCriptografado = new char[TextoVetor.Length];

            // Variaveis da função

            int count = 0, coluna = 0, posicao = 0;

            // Indica a numeração correspondente da primeira coluna a ser analisada

            count = 1;

            // Inicio do processo de criptografia

            while (count <= 7)
            {
                // Identifica o indice da primeira coluna a ser analisada

                for (int i = 0; i < 7; i++)
                {
                    if (senha[i] == count) coluna = i;
                }

                //Processo de escrita vertical dos valores da coluna

                for (int linha = 0; linha < NumLinha; linha++)
                {
                    if (posicao < TextoVetor.Length)
                    {
                        TextoMatriz[linha, coluna] = TextoVetor[posicao];

                        posicao++;
                    }
                    else TextoMatriz[linha, coluna] = ' ';
                }

                count++;
            }

            // Converte o a matriz em texto

            count = 0;

            for (int i = 0; i < NumLinha; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    TextoCriptografado[count] = TextoMatriz[i, j];

                    count++;
                }
            }

            return new string(TextoCriptografado);
        }
    }
}