(function(){
    const app = document.querySelector(".app")
    const btn = document.querySelector("#descriptBtn")

    const socket = io()

    let uname;

    document.querySelector(".container #join-user").addEventListener("click",function(){
        let username = document.querySelector("#username").value;
        var key = document.querySelector("#key").value;
        console.log("1" + key)

        if(username.length == 0){
            return;
        }
        socket.emit("newuser", username);
        uname = username;
        document.querySelector(".join-screen").classList.remove("active")
        document.querySelector(".app").classList.add("active")
        document.querySelector(".chat-screen").classList.add("active")
    })

    document.addEventListener("keydown",(event) => {
        if (event.key === "Enter") {

            let username = document.querySelector(".join-screen #username").value;
            var key = document.querySelector("#key").value;
            console.log("2" + key)
            
            if (username.length == 0) {
                return;
            }
            socket.emit("newuser", username);
            uname = username;
            document.querySelector(".join-screen").classList.remove("active");
            document.querySelector(".app").classList.add("active")
            document.querySelector(".chat-screen").classList.add("active");

        }
    })


    app.querySelector(".chat-screen #send-message").addEventListener("click", function(){
        let message = app.querySelector(".chat-screen #message-input").value;
        let key = document.querySelector("#key");
        if(message.length === key.value.length){

            if(message.length == 0){
                return;
            }
            renderMessage("my",{
                username:uname,
                text:message
            });
            socket.emit("chat",{
                username:uname,
                text:message
            });
            
            app.querySelector(".chat-screen #message-input").value = "";
            // key.value = ""

        }else{
            alert("A chave deve ter o mesmo numero de caracteres que a mensagem")
            app.querySelector(".chat-screen #message-input").value = "";
        }
    })

    // enviar mensagem com enter
  document.addEventListener("keydown", function(event){
    if (event.key === "Enter"){
        let message = app.querySelector(".chat-screen #message-input").value;
        let key = document.querySelector("#key");

        if(message.length === key.value.length){

            if(message.length == 0){
                return;
            }
            renderMessage("my",{
                username:uname,
                text:message
            });
            socket.emit("chat",{
                username:uname,
                text:message
            });
            
            app.querySelector(".chat-screen #message-input").value = "";
            // key.value = ''

            
        }else{
            alert("A chave deve ter o mesmo numero de caracteres que a mensagem")
            app.querySelector(".chat-screen #message-input").value = "";
        }
        
    }
    })
    
    app.querySelector(".chat-screen #exit-chat").addEventListener("click", function(){
        socket.emit("exituser",uname)
        window.location.href = window.location.href;
    })

    socket.on("update",function(update){
        renderMessage("update",update)
    })
    socket.on("chat",function(message){
        renderMessage("other",message)
    })

    function renderMessage(type,message){

        let messageContainer = app.querySelector(".chat-screen .messages")
        let key = document.getElementById("key")

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

                btn.addEventListener("click", function(){
                    el.innerHTML = `
                        <div>
                            <div class="name">Você</div>
                            <div class="text">${message.text}</div>
                        </div>
                    `;
                messageContainer.appendChild(el)
                })


        }else if (type == "other"){

            let el = document.createElement("div");


            el.setAttribute("class","message other-message")

            el.innerHTML = `
                <div>
                    <div class="name">${message.username}</div>
                    <div class="text">${encrypt(message.text, key.value)}</div>
                </div>
            `;

                messageContainer.appendChild(el)

                // descriptar
                btn.addEventListener("click", function(){
                    el.innerHTML = `
                        <div>
                            <div class="name">${message.username}</div>
                            <div class="text">${decrypt(encrypt(message.text, key.value), key.value)}</div>
                        </div>
                    `;
                messageContainer.appendChild(el)
                })
                
        }
        messageContainer.scrollTop = messageContainer.scrollHeight - messageContainer.clientHeight;
    }

const alphabet = 'ABCDEFGHIJKLMNOPQRSTUVWXYZ';


function encrypt(message, key) {
    console.log("Criptografando: " + message);
    console.log("Chave: " + key);
    let ciphertext = '';
    const keyLength = key.length;
    let keyIndex = 0;

    for (const messageChar of message) {
        const messageIndex = alphabet.indexOf(messageChar);
    if (messageIndex < 0) {
        ciphertext += messageChar;
        continue;
    }

    const keyChar = key[keyIndex];
    const keyIndexShift = alphabet.indexOf(keyChar);

    const cipherIndex = (messageIndex + keyIndexShift) % 26;
    const cipherChar = alphabet[cipherIndex];

    ciphertext += cipherChar;

    keyIndex = (keyIndex + 1) % keyLength;
}

console.log("Criptografado: " + message);
console.log("Chave: " + key);
return ciphertext;
}

function decrypt(ciphertext, key) {
    

    console.log("Descriptografando: " + ciphertext);
    console.log("Chave: " + key);

    let message = '';
    const keyLength = key.length;
    let keyIndex = 0;

    for (const cipherChar of ciphertext) {
        const cipherIndex = alphabet.indexOf(cipherChar);
        if (cipherIndex < 0) {
            message += cipherChar;
            continue;
        }

        const keyChar = key[keyIndex];
        const keyIndexShift = alphabet.indexOf(keyChar);

        const messageIndex = (cipherIndex - keyIndexShift + 26) % 26;
        const messageChar = alphabet[messageIndex];

        message += messageChar;

        keyIndex = (keyIndex + 1) % keyLength;
    }

    console.log("Descriptografado: " + message);
    console.log("Chave: " + key);

    return message;
}

})();