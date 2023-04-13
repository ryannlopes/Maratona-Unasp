using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Enygma;

namespace Enygma.ClassEncrypt
{
    public class Vigenere
    {

        public string CriptografarEmVigenere(string mensagem, string chave)
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

        public string DescriptografarEmVigenere(string mensagem, string chave)
        {

            // Inicializa a variável para armazenar o texto descriptografado

            string mensagemDescriptografada = "";

            // Converte a chave em maiúsculas para fins de consistência

            chave = chave.ToUpper();

            // Percorre a string criptografada e decifra cada caractere

            int Indice = 0;

            for (int i = 0; i < mensagem.Length; i++)
            {
                // Obtém o caractere atual da string criptografada

                char CharCriptografado = mensagem[i];

                // Calcula o deslocamento com base no caractere correspondente na chave

                int keywordChar = chave[Indice] - 'A';

                int offset = (CharCriptografado - 'A' - keywordChar + 26) % 26;

                // Adiciona o caractere descriptografado ao texto descriptografado

                mensagemDescriptografada += (char)(offset + 'A');

                // Atualiza o índice da chave (se a chave for menor que a string criptografada, ela se repetirá)

                Indice = (Indice + 1) % chave.Length;
            }

            // Retorna o texto descriptografado

            return mensagemDescriptografada;
        }
    }
}