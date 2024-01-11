$(document).ready(function () {
    BuscarClientes();
});

function BuscarClientes() {
    $.ajax({
        url: '/Clients/BuscarTodosOsClientes',
        type: 'GET',
        dataType: 'json',
        success: function (clients) {
            console.log(clients);

            var select = $('#selectClients');
            select.empty();
            select.append($('<option></option>').val('').text('Selecione um cliente'));

            $.each(clients, function (index, client) {
                select.append($('<option></option>').val(client.id).text(client.name));
            });
        },
        error: function (textStatus) {
            console.error('Erro ao obter os clientes:', textStatus);
        }
    });
}