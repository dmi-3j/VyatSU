function addList() {
    var listDiv = document.createElement("div");
    listDiv.classList.add("todo-list");

    var listTitleInput = document.getElementById("listName");
    var listTitle = listTitleInput.value;

    if (listTitle.trim() === '') {
        alert("Пожалуйста, введите название списка дел.");
        return;
    }

    var listTitleEl = document.createElement("h2");
    listTitleEl.textContent = listTitle;
    listDiv.appendChild(listTitleEl);

    var taskInput = document.createElement("input");
    taskInput.type = "text";
    taskInput.placeholder = "Введите название дела";
    listDiv.appendChild(taskInput);

    var addButton = document.createElement("button");
    addButton.textContent = "Добавить дело";
    addButton.onclick = function() { addTask(listDiv, taskInput); };
    listDiv.appendChild(addButton);

    var deleteButton = document.createElement("button");
    deleteButton.textContent = "Удалить список";
    deleteButton.className = "delete-button";
    deleteButton.onclick = function() { deleteList(listDiv); };
    listDiv.appendChild(deleteButton);

    var taskList = document.createElement("ul");
    listDiv.appendChild(taskList);

    document.getElementById("lists").appendChild(listDiv);

    listTitleInput.value = "";
}

function addTask(listDiv, taskInput) {
    var taskText = taskInput.value;

    if (taskText.trim() === '') {
        alert("Пожалуйста, введите название дела.");
        return;
    }

    var listItem = document.createElement("li");

    var checkbox = document.createElement("input");
    checkbox.type = "checkbox";
    listItem.appendChild(checkbox);

    var taskLabel = document.createElement("span");
    taskLabel.textContent = taskText;
    listItem.appendChild(taskLabel);

    var deleteButton = document.createElement("button");
    deleteButton.textContent = "Удалить";
    deleteButton.className = "delete-button";
    deleteButton.onclick = function() { deleteTask(listDiv, listItem); };
    listItem.appendChild(deleteButton);

    listDiv.querySelector("ul").appendChild(listItem);
    taskInput.value = "";
}

function deleteTask(listDiv, listItem) {
    listDiv.querySelector("ul").removeChild(listItem);
}
function deleteList(listDiv) {
    document.getElementById("lists").removeChild(listDiv);
}
