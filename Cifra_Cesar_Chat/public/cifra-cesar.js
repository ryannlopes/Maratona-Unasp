function criptografarCesar(message, key) {
    //separa as strings
    const letras = "abcdefghijklmnopqrstuvwxyz".split("");
    //sera criada uma nova string com as letras criptografadas conforme a key
    const letrasCriptografadas = letras.slice(key).concat(letras.slice(0, key));
    let result = "";
    for (let i = 0; i < message.length; i++) {
        let char = message[i].toLowerCase();
        let index = letras.indexOf(char);
        if (index !== -1) {
        let charCriptografado = letrasCriptografadas[index];
        if (message[i] === char.toUpperCase()) {
            charCriptografado = charCriptografado.toUpperCase();
        }
        result += charCriptografado;
        } else {
        result += message[i];
        }
    }
    return result;
}
  
function descriptografarCesar(message, key) {
    return criptografarCesar(message, -key);
}
  
export { criptografarCesar, descriptografarCesar };