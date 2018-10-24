$(document).ready(function () {

    InicializarMascaraNumerica();
});

function InicializarMascaraNumerica() {
    $('input[alt="integer"]').keyup(function (event) {
        if (this.value.match(/[^0-9]/g)) {
            this.value = this.value.replace(/[^0-9]/g, '');
        }
    });

    $('input[alt="decimal"]').keyup(function (event) {
        //^[1-9]\d{0,2}(\,\d{3})*(,\d+)?$
        if (this.value.match(/[^0-9,]/g)) {
            this.value = this.value.replace(/[^0-9,]/g, '');
        }
    });
}
