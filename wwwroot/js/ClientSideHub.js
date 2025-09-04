import { signalR } from "./signalr";

const Connection = new signalR.HubConnectionBuilder().
    WithUrl("/chatBot")
    .Build();

Connection.on("ReciveMessage" , (message, userId) => {

});

Connection.Start().catch(err => console.error("signalR not connected"));

document.getElementById("ChatForm").addEventListener("submit", function (event) {
    event.preventDefault();
    const message = document.getElementById("messageInput").value;
    const userId = document.getElementById("UserIdInput").value;

    Connection.invoke("sendMessage", message, userId)
        .catch(err => console.error("ssssssssss", err))

});