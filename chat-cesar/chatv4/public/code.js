(function(){
    const app = document.querySelector(".app")
    const btn = document.querySelector("#descriptBtn")
    const socket = io()
    let uname;
    
  

    // Função para Login clicando no botao entrar
    document.querySelector(".container #join-user").addEventListener("click",function(){
        
            let username = document.querySelector("#username").value
            let key = document.querySelector("#key").value
    
            if(username.length == 0 || key.length == 0){
                return;
            }
    
            document.querySelector(".join-screen").classList.remove("active")
            document.querySelector(".app").classList.add("active")
            document.querySelector(".chat-screen").classList.add("active")
    
            socket.emit("newuser", username);
            socket.emit("key", key)
            
            uname = username;
            

            
        })
        
    

        

    // Função para login com enter
    document.addEventListener("keydown",(event) => {
        if (event.key === "Enter") {

            let username = document.querySelector(".join-screen #username").value;
            let key = document.querySelector("#key").value

            if (username.length == 0 || key.length == 0) {
                return;
            }
            

            
            document.querySelector(".join-screen").classList.remove("active");
            document.querySelector(".app").classList.add("active")
            document.querySelector(".chat-screen").classList.add("active");

            socket.emit("newuser", username);
            socket.emit("key", key)

            uname = username;
            

        }
    })

// função para enviar mensagem com o botao de enviar
app.querySelector(".chat-screen #send-message").addEventListener("click", function(){
    let message = app.querySelector(".chat-screen #message-input").value;
    if(message.length == 0){
        return;
    }
    renderMessage("my",{
        username:uname,
        text:message,
    });
    socket.emit("chat",{
        username:uname,
        text:message,
    });

    app.querySelector(".chat-screen #message-input").value = "";

    

})

    // função para Enviar mensagem com enter
    document.addEventListener("keydown", function(event){
        if (event.key === "Enter"){
            let message = app.querySelector(".chat-screen #message-input").value;
            if(message.length == 0){
                return;
            }
            
            renderMessage("my",{
                username:uname,
                text:message,
               
            });
            socket.emit("chat",{
                username:uname,
                text:message,
                
            });
            
            app.querySelector(".chat-screen #message-input").value = "";
            
        }
        })
    // Sair do chat e ir pra tela de login
    app.querySelector(".chat-screen #exit-chat").addEventListener("click", function(){
        socket.emit("exituser",uname)
        window.location.href = window.location.href;
    })

    // Atualizar mensagens e usuarios
    socket.on("update",function(update){
        renderMessage("update",update)
        
    })
    socket.on("chat",function(message){
        renderMessage("other",message)
    })

    // função mostrar mensagem
    async function renderMessage(type,message){
        let messageContainer = app.querySelector(".chat-screen .messages")
        // Se for "my" mensagem mostrar do lado direito
        if(type == 'my'){
            let el = document.createElement("div");
            el.setAttribute("class","message my-message")
            el.innerHTML = `
                <div>
                    <div class="name">Você</div>
                    <div class="text">${message.text}</div>
                </div>
                `;
                
                messageContainer.appendChild(el)

            // Descriptografar mensagem ao clicar no botâo
               btn.addEventListener("click", function(){
                el.innerHTML = `
            <div>
                <div class="name">Você</div>
                <div class="text">${message.text}</div>
            </div>
            `;
            messageContainer.appendChild(el)
            
            })
         // Se a mensagem nao for sua mostrar do lado esquerdo
        }else if (type == "other"){
            let el = document.createElement("div");
            el.setAttribute("class","message other-message")
            el.innerHTML = `
                <div>
                    <div class="name">${message.username}</div>
                    <div class="text">${CriptografarCesar(message.text, key.value)}</div>
                </div>
                `;
                messageContainer.appendChild(el)

                // Descriptografar mensagem ao clicar no botão
                btn.addEventListener("click", function(){
                        el.innerHTML = `
                        <div>
                            <div class="name">${message.username}</div>
                            <div class="text">${DecryptCaesar(message.text, key.value)}</div>
                        </div>
                        `;
                    
                
                messageContainer.appendChild(el)
                
                })
                
        }
        // else if(type == "update"){
        //     let el = document.createElement("div");
        //     el.setAttribute("class","entrou")
        //     el.innerText = message;
        //         messageContainer.appendChild(el)
        // }
        messageContainer.scrollTop = messageContainer.scrollHeight - messageContainer.clientHeight;
    }


    // função para criptografar
    function CriptografarCesar(mensagem, deslocamento) {
        if (typeof mensagem !== "string") {
            throw new Error("A mensagem deve ser uma string");
        }
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


    // função para descriptograr
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



})();