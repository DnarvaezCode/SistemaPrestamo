var arrayComisiones = [];
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
            $("#txtMontoPrestamo").val(response.monto.toLocaleString("es-ni", {
                style: "currency",
                currency: "NIO"
            }))
            const porcentaje = $("#txtPorcentaje").val() ? parseInt($("#txtPorcentaje").val()) : 0;
            const monto = parseInt(response.monto);
            $("#txtComision").val((monto * (porcentaje / 100)).toLocaleString("es-ni", {
                style: "currency",
                currency: "NIO"
            }));
            $("#txtEstadoComision").val(response.estadoComision);
        },
        error: (error) => {
            console.log(error);

        }
    });
});

$("#txtPorcentaje").on("change", () => {
    var monto = $("#txtMontoPrestamo").val() ? parseInt($("#txtMontoPrestamo").val().replace(/[C$]/g, '')) : 0;
    const porcentaje = $("#txtPorcentaje").val() ? parseInt($("#txtPorcentaje").val()) : 0;
    $("#txtComision").val((monto * (porcentaje / 100)).toLocaleString("es-ni", {
        style: "currency",
        currency: "NIO"
    }));
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

function limpiarElementos() {
    $("#txtMontoPrestamo").val("");
    $("#txtPorcentaje").val("");
    $("#txtComision").val(0);
    $("#txtEstadoComision").val("");
}

function exists(numeroPrestamo) {
    return arrayComisiones
        .map(function (item) {
            return item.numeroPrestamo;
        })
        .includes(numeroPrestamo);
}

function editarComision(numeroPrestamo) {

}


function eliminarComision(numeroPrestamo) {

    const indice = arrayComisiones.findIndex(item => {
        return item.numeroPrestamo == numeroPrestamo.toString();
    });

    Swal.fire({
        title: '¿Esta seguro que desea eliminar este registro?',
        text: "",
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Si',
        cancelButtonText: 'No'
    }).then((result) => {
        if (result.isConfirmed) {

            arrayComisiones.splice(indice, 1);
            $("#comisiones").html('');
            for (var i = 0; i < arrayComisiones.length; i++) {
                $("#comisiones").append(`
                   <tr>
                        <td>${arrayComisiones[i].numeroPrestamo}</td>
                        <td>${arrayComisiones[i].montoPrestamo}</td>
                        <td>${arrayComisiones[i].porcentaje} %</td>
                        <td>${arrayComisiones[i].monto}</td>
                        <td>
                            <div class="btn-group">
                                <button type="button" title="Editar" onclick="editarComision(${arrayComisiones[i].numeroPrestamo})"
                                   class="btn btn-info btn-sm text-white"><i class="fa fa-pencil"></i></button>
                                <button type="button" onclick="eliminarComision(${arrayComisiones[i].numeroPrestamo})" title="Eliminar"
                                   class="btn btn-danger btn-sm text-white"><i class="fa fa-trash"></i></button>
                            </div>
                        </td>
                    </tr>
                `)
            };

            Swal.fire(
                'Eliminado!',
                'Registro eliminado sactifactoriamente.',
                'success'
            )
        }
    });
}



$("#btnAgregar").on("click", () => {

    var elementoPrestamo = $('[name="ComboboxPrestamo"]');
    var selectedPrestamoValue = elementoPrestamo.val();
    const porcentaje = document.getElementById("txtPorcentaje");

    if (!ValidateInput(porcentaje)) return;

    if (selectedPrestamoValue.length === 0) {
        $(elementoPrestamo).addClass("input-validation-error").parent().children("span").html('Debe seleccionar el número de préstamo.');
        return;
    }

    var numeroPrestamo = elementoPrestamo.children('option:selected').text();

    const comisiones = {
        clienteId: 1,
        prestamoId: 2,
        porcentaje: $("#txtPorcentaje").val(),
        monto: $("#txtComision").val(),
        numeroPrestamo: numeroPrestamo,
        montoPrestamo: $("#txtMontoPrestamo").val()

    };

    if (exists(comisiones.numeroPrestamo))
        Swal.fire('Alerta', `Ya existe un registro con el mismo número de préstamo.`, "warning");
    else
        arrayComisiones.push(comisiones);

    $("#comisiones").html('');
    for (var i = 0; i < arrayComisiones.length; i++) {
        $("#comisiones").append(`
                   <tr>
                        <td>${arrayComisiones[i].numeroPrestamo}</td>
                        <td>${arrayComisiones[i].montoPrestamo}</td>
                        <td>${arrayComisiones[i].porcentaje} %</td>
                        <td>${arrayComisiones[i].monto}</td>
                        <td>
                            <div class="btn-group">
                                <button type="button" title="Editar" onclick="editarComision(${arrayComisiones[i].numeroPrestamo})"
                                   class="btn btn-info btn-sm text-white"><i class="fa fa-pencil"></i></button>
                                <button type="button" onclick="eliminarComision(${arrayComisiones[i].numeroPrestamo})" title="Eliminar"
                                   class="btn btn-danger btn-sm text-white"><i class="fa fa-trash"></i></button>
                            </div>
                        </td>
                    </tr>
        `)
    }

    elementoPrestamo.val($("#ComboboxPrestamo option:first").val()).change();
    limpiarElementos(elementoPrestamo);
});