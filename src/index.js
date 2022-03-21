"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
require("./css/main.css");
var signalR = require("@microsoft/signalr");
var divMessages = document.querySelector("#divMessages");
var tbMessage = document.querySelector("#tbMessage");
var btnSend = document.querySelector("#btnSend");
var username = new Date().getTime();
var connection = new signalR.HubConnectionBuilder()
    .withUrl("/hub")
    .build();
//signalR이라는 서비스를 사용하는데, /hub라는 URL을 가지고 소켓을 연결한다.
//signalR 서비스로부터 messageReceived 이벤트를 받으면 함수를 수행한다.
connection.on("messageReceived", function (username, message) {
    var messages = document.createElement("div");
    messages.innerHTML =
        "<div class=\"message-author\">".concat(username, "</div><div>").concat(message, "</div>");
    divMessages.appendChild(messages);
    divMessages.scrollTop = divMessages.scrollHeight;
});
connection.start().catch(function (err) { return document.write(err); });
tbMessage.addEventListener("keyup", function (e) {
    if (e.key === "Enter") {
        send();
    }
});
btnSend.addEventListener("click", send);
function send() {
    connection.send("newMessage", username, tbMessage.value)
        .then(function () { return tbMessage.value = ""; });
}
