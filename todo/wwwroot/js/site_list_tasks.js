const connection = new signalR.HubConnectionBuilder()
    .withUrl("/TasksHub")
    //.configureLogging(signalR.LogLevel.Information)
    .build();

connection.start().then(function () {
    document.getElementById("messages").innerHTML = "Socket is connected...";
}).catch(function (err) {
    return console.error(err.toString());
});

connection.on('ReceiveMessageToRefreshTableWithTasks', (message) => {
    appendLine(message);
});


function appendLine(massage) {
    var messages = document.getElementById("messages");
    messages.innerHTML += "<br/>Message has comes ...BEGIN...";

    $.ajax({
        contentType: 'application/json',
        type: 'GET',
        url: 'api/Tasks',
        dataType: "json",
        success: function (data, textStatus, jqXHR) {
            messages.innerHTML += "<br/>Reading data Start...";

            var tableTasks = document.getElementById("tableTasks");

            var tableBody = document.getElementById("tTaskBody");
            tableBody.remove();

            var tableBodyNew = document.createElement("tbody");
            tableBodyNew.id = "tTaskBody";


            data.forEach(function (task) {

                //trHTML += '<tr><td>' + task.name + '</td><td>' + data.deadlineDate + '</td><td>' + data.description + '</td><td><a href="/Tasks/Edit/' + task.id +'">Edit</a>< a href = "/Tasks/Details/' + task.id +'" > Details</a><a href="/Tasks/Delete/'+task.id+'">Delete</a></td></tr>';
                var rowTask = document.createElement("tr");

                var cellName = document.createElement("td");
                var cellTextName = document.createTextNode(task.name);
                cellName.appendChild(cellTextName);
                rowTask.appendChild(cellName);

                var cellDeadlineDate = document.createElement("td");
                var cellTextDeadlineDate = document.createTextNode(task.deadlineDate);
                cellDeadlineDate.appendChild(cellTextDeadlineDate);
                rowTask.appendChild(cellDeadlineDate);

                var cellDescription = document.createElement("td");
                var cellTextDescription = document.createTextNode(task.description);
                cellDescription.appendChild(cellTextDescription);
                rowTask.appendChild(cellDescription);

                var cellLinks = document.createElement("td");
                //var cellTextLinks = document.createTextNode('<a href="/Tasks/Edit/' + task.id + '">Edit</a>< a href = "/Tasks/Details/' + task.id + '" > Details</a><a href="/Tasks/Delete/' + task.id +'">Delete</a>');
                cellLinks.innerHTML = '<a href="/Tasks/Edit/' + task.id + '">Edit</a> | <a href = "/Tasks/Details/' + task.id + '">Details</a> | <a href="/Tasks/Delete/' + task.id + '">Delete</a>';
                //cellLinks.appendChild(cellTextLinks);
                rowTask.appendChild(cellLinks);

                tableBodyNew.appendChild(rowTask);

                //messages.innerHTML += "<br/>" + task.name + " | " + task.deadlineDate + " | " + task.description;
            });

            tableTasks.appendChild(tableBodyNew);

            messages.innerHTML += "<br/>Reading data Stop...";
        },
        error: function (jqXHR, textStatus, errorThrown) {
            messages.innerHTML += "<br/>Error";
        }
    });
    messages.innerHTML += "<br/>Message has comes ...END...";
};
