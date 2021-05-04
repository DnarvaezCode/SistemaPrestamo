$("#ComboboxPrestamo").on("change", () => {

    $("#txtMontoPrestamo").val("");
    $("#txtComision").val("");
    $("#txtEstadoComision").val("");
    var elementoPrestamo = $('[name="ComboboxPrestamo"]');
    var selectedPrestamoValue = elementoPrestamo.val();

    if (selectedPrestamoValue.length === 0) {
        $("#txtComision").val(0);
        return;
    }

    $(elementoPrestamo).addClass("input-validation-error").parent().children("span").html('');

    $.ajax({
        type: "POST",
        url: 'Comisione/ObtenerMontoDePrestamoPorId/' + parseInt(selectedPrestamoValue),
        data: {},
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: (response) => {
            $("#txtMontoPrestamo").val(response.monto)
            const porcentaje = $("#txtPorcentaje").val() ? parseInt($("#txtPorcentaje").val()) : 0;
            const monto = parseInt(response.monto);
            $("#txtComision").val(monto * (porcentaje / 100));
            $("#txtEstadoComision").val(response.estadoComision);
        },
        error: (error) => {
            console.log(error);

        }
    });
});

$("#txtPorcentaje").on("change", () => {
    var monto = $("#txtMontoPrestamo").val() ? parseInt($("#txtMontoPrestamo").val()) : 0;
    const porcentaje = $("#txtPorcentaje").val() ? parseInt($("#txtPorcentaje").val()) : 0;
    $("#txtComision").val(monto * (porcentaje / 100));
});

$("#btnAgregar").on("click", () => {

    var elementoPrestamo = $('[name="ComboboxPrestamo"]');
    var selectedPrestamoValue = elementoPrestamo.val();
    const porcentaje = document.getElementById("txtPorcentaje");

    if (!ValidateInput(porcentaje)) return;

    if (selectedPrestamoValue.length === 0) {
        $(elementoPrestamo).addClass("input-validation-error").parent().children("span").html('Debe seleccionar el número de préstamo.');
        return;
    }

    elementoPrestamo.val($("#ComboboxPrestamo option:first").val()).change();
    $("#txtMontoPrestamo").val("");
    $("#txtPorcentaje").val("");
    $("#txtComision").val(0);
    $("#txtEstadoComision").val("");
});

function ValidateInput(elemento) {

    $(elemento).removeClass("input-validation-error").removeClass("valid").parent().children("span").html('');
    const value = $(elemento).val();

    if (!value.trim()) {
        $(elemento).addClass("input-validation-error").parent().children("span").html('Campo requerido.');
        return false;
    }

    if (parseInt(value.trim()) === 0) {
        $(elemento).addClass("input-validation-error").parent().children("span").html('El porcentaje debe ser mayor a cero.');
        return false;
    }
    $(elemento).removeClass("input-validation-error").removeClass("valid").parent().children("span").html('');
    return true;
}