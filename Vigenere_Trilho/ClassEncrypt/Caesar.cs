using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Enygma;

namespace Enygma.ClassEncrypt
{
    public class Caesar
    {
        public string CriptografarEmCaesar(string mensagem, int deslocamento)
        {
            // Converter a mensagem em maiúsculas

            mensagem = mensagem.ToUpper();

            // Inicializar a variável de saída

            string mensagemCriptografada = "";

            // Definir o tamanho da mensagem

            int tamanhoMensagem = mensagem.Length;

            // Percorrer cada caractere da mensagem

            for (int i = 0; i < tamanhoMensagem; i++)
            {
                // Obter o código ASCII do caractere da mensagem

                int codigoCaractereMensagem = (int)mensagem[i];

                // Criptografar o caractere da mensagem utilizando a cifra de César

                int codigoCaractereCriptografado = (codigoCaractereMensagem + deslocamento - 65) % 26 + 65;

                // Converter o código ASCII criptografado em um caractere e adicionar à mensagem criptografada

                char caractereCriptografado = (char)codigoCaractereCriptografado;

                mensagemCriptografada += caractereCriptografado;
            }

            // Retornar a mensagem criptografada

            return mensagemCriptografada;
        }

        public string DescriptografarEmCaesar(string encryptedText, int shift)
        {
            // Inicializa a variável para armazenar o texto descriptografado

            string decryptedText = "";

            // Percorre a string criptografada e decifra cada caractere

            foreach (char c in encryptedText)
            {
                // Verifica se o caractere é uma letra maiúscula

                if (Char.IsUpper(c))
                {
                    // Calcula o deslocamento com base no número de posições para trás na tabela ASCII

                    int offset = ((c - 'A') - shift + 26) % 26;

                    // Adiciona o caractere descriptografado ao texto descriptografado

                    decryptedText += (char)(offset + 'A');
                }
                else
                {
                    // Adiciona caracteres especiais ou espaços em branco ao texto descriptografado sem alterá-los

                    decryptedText += c;
                }
            }

            // Retorna o texto descriptografado

            return decryptedText;
        }
    }
}