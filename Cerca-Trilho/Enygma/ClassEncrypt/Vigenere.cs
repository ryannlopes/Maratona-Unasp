using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Enygma;

namespace Enygma.ClassEncrypt
{
    public class Vigenere
    {

        public string CriptografarVigenere(string mensagem, string chave)
        {
            // Converter a mensagem e a chave em maiúsculas
            mensagem = mensagem.ToUpper();
            chave = chave.ToUpper();

            // Inicializar a variável de saída
            string mensagemCriptografada = "";

            // Definir o tamanho da mensagem e da chave
            int tamanhoMensagem = mensagem.Length;
            int tamanhoChave = chave.Length;

            // Definir um índice para percorrer a chave
            int indiceChave = 0;

            // Percorrer cada caractere da mensagem
            for (int i = 0; i < tamanhoMensagem; i++)
            {
                // Obter o caractere correspondente na chave
                char caractereChave = chave[indiceChave % tamanhoChave];

                // Obter o código ASCII do caractere da mensagem e da chave
                int codigoCaractereMensagem = (int)mensagem[i];
                int codigoCaractereChave = (int)caractereChave;

                // Criptografar o caractere da mensagem utilizando a cifra de Vigenère
                int codigoCaractereCriptografado = (codigoCaractereMensagem + codigoCaractereChave) % 26;

                // Converter o código ASCII criptografado em um caractere e adicionar à mensagem criptografada
                char caractereCriptografado = (char)(codigoCaractereCriptografado + 65);
                mensagemCriptografada += caractereCriptografado;

                // Incrementar o índice da chave
                indiceChave++;
            }

            // Retornar a mensagem criptografada
            return mensagemCriptografada;
        }

        public string DecryptVigenere(string encryptedText, string keyword)
        {
            // Inicializa a variável para armazenar o texto descriptografado
            string decryptedText = "";

            // Converte a chave em maiúsculas para fins de consistência
            keyword = keyword.ToUpper();

            // Percorre a string criptografada e decifra cada caractere
            int keywordIndex = 0;
            for (int i = 0; i < encryptedText.Length; i++)
            {
                // Obtém o caractere atual da string criptografada
                char encryptedChar = encryptedText[i];

                // Calcula o deslocamento com base no caractere correspondente na chave
                int keywordChar = keyword[keywordIndex] - 'A';
                int offset = (encryptedChar - 'A' - keywordChar + 26) % 26;

                // Adiciona o caractere descriptografado ao texto descriptografado
                decryptedText += (char)(offset + 'A');

                // Atualiza o índice da chave (se a chave for menor que a string criptografada, ela se repetirá)
                keywordIndex = (keywordIndex + 1) % keyword.Length;
            }

            // Retorna o texto descriptografado
            return decryptedText;
        }
    }
}