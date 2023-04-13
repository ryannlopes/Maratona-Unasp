// Função para cifrar o texto usando a cifra de César
function codificar() {
    var text = document.getElementById("texto").value;
    var key = parseInt(document.getElementById("chave").value);
    var result = "";
    for (var i = 0; i < text.length; i++) {
        var c = text.charCodeAt(i);
        if (c >= 65 && c <= 90) {
            // Maiúsculas
            result += String.fromCharCode((c - 65 + key) % 26 + 65);
        } else if (c >= 97 && c <= 122) {
            // Minúsculas
            result += String.fromCharCode((c - 97 + key) % 26 + 97);
        } else {
            // Outros caracteres
            result += text.charAt(i);
        }
    }
    document.getElementById("resultado-codificado").value = result;
}

// Função para descifrar o texto usando a cifra de César
function descodificar() {
    var text = document.getElementById("resultado-codificado").value;
    var key = parseInt(document.getElementById("chave").value);
    var result = "";
    for (var i = 0; i < text.length; i++) {
        var c = text.charCodeAt(i);
        if (c >= 65 && c <= 90) {
            // Maiúsculas
            result += String.fromCharCode(((c - 65 - key) % 26 + 26) % 26 + 65);
        } else if (c >= 97 && c <= 122) {
            // Minúsculas
            result += String.fromCharCode(((c - 97 - key) % 26 + 26) % 26 + 97);
        } else {
            // Outros caracteres
            result += text.charAt(i);
        }
    }
    document.getElementById("resultado-descodificado").value = result;
}