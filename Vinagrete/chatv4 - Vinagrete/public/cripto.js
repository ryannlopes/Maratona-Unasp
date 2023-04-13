const key = document.querySelector('#key')

function CriptografarCesar(mensagem, deslocamento) {
    // Converter a mensagem em maiúsculas
    mensagem = mensagem.toUpperCase();

    // Verificar se o deslocamento é válido
    if (deslocamento < 0 || deslocamento > 25) {
        throw new Error("O deslocamento deve estar entre 0 e 25");
    }

    // Criptografar cada caractere da mensagem
    let mensagemCriptografada = "";
    for (let i = 0; i < mensagem.length; i++) {
        let caractereCriptografado = CriptografarCaractere(mensagem[i], deslocamento);
        mensagemCriptografada += caractereCriptografado;
    }

    // Retornar a mensagem criptografada
    console.log(mensagemCriptografada)
    return mensagemCriptografada;
}

function CriptografarCaractere(caractere, deslocamento) {
    // Obter o código ASCII do caractere
    let codigoCaractere = caractere.charCodeAt(0);

    // Criptografar o código ASCII do caractere
    let codigoCaractereCriptografado = (codigoCaractere - 65 + deslocamento) % 26 + 65;

    // Converter o código ASCII criptografado em um caractere e retornar
    return String.fromCharCode(codigoCaractereCriptografado);
}



function DecryptCaesar(encryptedText, shift) {
  // Inicializa a variável para armazenar o texto descriptografado
  let decryptedText = "";

  // Percorre a string criptografada e decifra cada caractere
  for (let i = 0; i < encryptedText.length; i++) {
    let c = encryptedText[i];

    // Verifica se o caractere é uma letra maiúscula
    if (c.match(/[A-Z]/)) {
      // Calcula o deslocamento com base no número de posições para trás na tabela ASCII
      let offset = ((c.charCodeAt(0) - 65 - shift + 26) % 26) + 65;

      // Adiciona o caractere descriptografado ao texto descriptografado
      decryptedText += String.fromCharCode(offset);
    } else {
      // Adiciona caracteres especiais ou espaços em branco ao texto descriptografado sem alterá-los
      decryptedText += c;
    }
  }

  // Retorna o texto descriptografado
  console.log(decryptedText)
  return decryptedText;
}
let name = CriptografarCesar('teste',3)
CriptografarCesar("teste",2)
DecryptCaesar(name,3)
  