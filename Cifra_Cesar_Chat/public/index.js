import { criptografarCesar, descriptografarCesar } from "./cifra-cesar.js";

(function(){
    const app = document.querySelector(".app")
    const btn = document.querySelector("#descriptBtn")
    const socket = io()
    let uname;
    let key;

    // Função para Login clicando no botao entrar
    document.querySelector(".container #join-user").addEventListener("click",function(){

        let username = document.querySelector("#username").value
        key = document.querySelector("#key").value

        console.log("chave ao entrar com click:"+ key);

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
            key = document.querySelector("#key").value

            console.log("Chave ao logar com enter:"+ key);


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

        console.log("Mensagem ao enviar com click:"+ message);


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

            console.log("Mensagem ao enviar com enter:"+ message);

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
    function renderMessage(type, message){

        console.log("Mensagem ao entrar no renderMessage:" + message.text);

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

            console.log("Mensagem criptografar:"+ message.text);
            console.log("Chave criptografar:"+ key);

            el.setAttribute("class","message other-message")
            el.innerHTML = `
                <div>
                    <div class="name">${message.username}</div>
                    <div class="text">${criptografarCesar(message.text, key)}</div>
                </div>
            `;

            messageContainer.appendChild(el)

            // Descriptografar mensagem ao clicar no botão
            btn.addEventListener("click", function(){
                el.innerHTML = `
                    <div>
                        <div class="name">${message.username}</div>
                        <div class="text">${descriptografarCesar(criptografarCesar(message.text, key), key)}</div>
                    </div>
                `;

                console.log("Mensagem descriptografar:"+ criptografarCesar(message.text, key));
                console.log("Mensagem descriptografada:"+ descriptografarCesar(criptografarCesar(message.text, key), key));
                console.log("Chave descriptografar:"+ key);
                    
                messageContainer.appendChild(el)
            }) 
        }
        messageContainer.scrollTop = messageContainer.scrollHeight - messageContainer.clientHeight;
    }

})();