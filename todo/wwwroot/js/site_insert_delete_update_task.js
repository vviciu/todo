const connection = new signalR.HubConnectionBuilder()
    .withUrl("/SignalRTasks")
    //.configureLogging(signalR.LogLevel.Information)
    .build();

connection.start().then(function () {
    document.getElementById("messages").innerHTML = "Socket is connected...";
}).catch(function (err) {
    return console.error(err.toString());
});

var button = document.getElementById('submit');

button.onclick = function () {
    document.getElementById("messages").innerHTML += "<br/>Start Sending...";
    var message = "Coœko do Listy..."
    connection.invoke('SendMessageToRefreshTableWithTasks', message);
    document.getElementById("messages").innerHTML += "<br/>End Sending...";
};
