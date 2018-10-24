$(document).ready(function () {
    $("#salvar").click(function () {
        var nome = $("#Nome").val();
        var email = $("#Email").val();
        var telefone = $("#Telefone").val();

        var data = {
            Nome : nome,
            Email: email,
            Telefone: telefone,
            Cpf: ""
        };

        $.ajax({
            url: '/pessoa/post',
            type: 'POST',
            contentType: 'application/json',
            data: JSON.stringify(data)
        })
            .done($(".w-form-done-Sucesso").show())
            .fail($(".w-form-fail-falha").show());       
    });
});