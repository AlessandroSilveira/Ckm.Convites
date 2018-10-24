
$(document).ready(function () {
    var telMask = ['(99) 9999-99999', '(99) 99999-9999'];
    var tel = document.querySelector('input[id=Telefone]');
    VMasker(tel).maskPattern(telMask[0]);
    tel.addEventListener('input', inputHandler.bind(undefined, telMask, 14), false);

    $("#salvar").click(function () {
        var valida = ValidarCampos();

        if (valida) {
            var nome = $("#Nome").val();
            var email = $("#Email").val();
            var telefone = $("#Telefone").val();

            var data = {
                Nome: nome,
                Email: email,
                Telefone: RemoverCaracteres(telefone),
                Cpf: ""
            };

            $.ajax({
                url: '/Pessoa/Post',
                type: 'POST',
                contentType: 'application/json',
                dataType: "json",
                data: JSON.stringify(data),
                success: function (data) { successFunction(data); limpaCampos() },
            })
        }
    });

    $(".downloadConvite").click(function () {
        $.ajax({
            type: "POST",
            url: '@Url.Action("ExportConvite", "Pessoa")',
            contentType: "application/json; charset=utf-8",
            dataType: "json",
        }).done(function (data) {
            if (data.fileName != "") {
                window.location.href = "@Url.RouteUrl(new { Controller = "Pessoa", Action = "Download"})/?file=" + data.fileName;
            }
        });
    });
});

function ValidarCampos() {
    if ($("#Nome").val() == "" && $("#Email").val() == "" && $("#Telefone").val() == "") {
        alert("Existem campos obrigatórios que não foram preenchidos!");
        return false;
    } else {
        return true;
    }
}

function successFunction(data) {
    if (data.Message == true) {
        $(".w-form-done-Sucesso").show();
        $(".w-form-fail-falha").hide();
        $("#buttonConvite").show();
    } else {
        $(".w-form-fail-falha").show();
        $(".w-form-done-Sucesso").hide();
        $("#buttonConvite").hide();
    }
}

function limpaCampos() {
    $("#Nome").val("");
    $("#Email").val("");
    $("#Telefone").val("");
}

function inputHandler(masks, max, event) {
    var c = event.target;
    var v = c.value.replace(/\D/g, '');
    var m = c.value.length > max ? 1 : 0;
    VMasker(c).unMask();
    VMasker(c).maskPattern(masks[m]);
    c.value = VMasker.toPattern(v, masks[m]);
}

function RemoverCaracteres(texto) {
    var novotexto = texto;
    return novotexto.replace(/[^\d]+/g, '');
}
