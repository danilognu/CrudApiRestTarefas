
function enviarDados() {

    $.ajax(
        {
            type: "POST",
            dataType: 'json',
            url: "http://localhost:31157/api/Tarefa",
            data: JSON.stringify({
                Titulo: document.getElementById("titulo").value,
                Data: document.getElementById("dataTarefa").value + "T00:00:00Z",
                Descricao: document.getElementById("descricao").value,
            }),
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json'
            }, success: function (retorno) {

                if (retorno)
                    alert("Tarefa Cadastrada")
            }
        });  

}