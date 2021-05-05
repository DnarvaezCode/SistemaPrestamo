$(document).ready(() => {
    $("#btnEditar").hide();
});

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
    const indice = arrayComisiones.findIndex(item => {
        return item.numeroPrestamo == numeroPrestamo.toString();
    });
    $("#btnAgregar").hide();
    $("#btnEditar").show();
    $('[name="ComboboxPrestamo"]').prop('disabled', 'disabled');
    $("#txtMontoPrestamo").val(arrayComisiones[indice].montoPrestamo);
    $("#txtPorcentaje").val(arrayComisiones[indice].porcentaje);
    $("#txtComision").val(arrayComisiones[indice].monto);

    $.ajax({
        type: "POST",
        url: 'Comisione/ObtenerMontoDePrestamoPorId/' + parseInt(arrayComisiones[indice].prestamoId),
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
            $("#ComboboxPrestamo").val(response.id);
        },
        error: (error) => {
            console.log(error);

        }
    });

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
                $("#comisiones").append(obtenerFilas(arrayComisiones, i))
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
        clienteId: parseInt($("#txtClienteId").val()),
        prestamoId: selectedPrestamoValue,
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
        $("#comisiones").append(obtenerFilas(arrayComisiones, i))
    }

    elementoPrestamo.val($("#ComboboxPrestamo option:first").val()).change();
    limpiarElementos();
});

$("#btnEditar").on("click", () => {

    var elementoPrestamo = $('[name="ComboboxPrestamo"]');
    const porcentaje = document.getElementById("txtPorcentaje");

    if (!ValidateInput(porcentaje)) return;

    var numeroPrestamo = elementoPrestamo.children('option:selected').text();
    $("#btnAgregar").show();
    $("#btnEditar").hide();

    const indice = arrayComisiones.findIndex(item => {
        return item.numeroPrestamo == numeroPrestamo.toString();
    });

    arrayComisiones[indice].numeroPrestamo = numeroPrestamo;
    arrayComisiones[indice].montoPrestamo = $("#txtMontoPrestamo").val();
    arrayComisiones[indice].porcentaje = $("#txtPorcentaje").val();
    arrayComisiones[indice].monto = $("#txtComision").val();
    $("#comisiones").html('');

    for (var i = 0; i < arrayComisiones.length; i++) {
        $("#comisiones").append(obtenerFilas(arrayComisiones, i))
    }

    elementoPrestamo.val($("#ComboboxPrestamo option:first").val()).change();
    limpiarElementos();
    $('[name="ComboboxPrestamo"]').removeAttr('disabled', 'disabled');

    Swal.fire(
        'Actualizado!',
        'Registro actualizado sactifactoriamente.',
        'success'
    );
});

function obtenerFilas(arrayComisiones, i) {
    return `<tr>
                <td style="display:none">${arrayComisiones[i].prestamoId}</td>
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
            </tr>`
}

$("#btnGuardar").on("click", () => {

    if (arrayComisiones.length === 0) {
        Swal.fire(
            'Adventencia!',
            'Debe de agregar por lo menos una comisión.',
            'warning'
        );
        return;
    }

    var comisiones = [];
    for (var i = 0; i < arrayComisiones.length; i++) {
        comisiones.push({
            ClienteId: parseInt($("#txtClienteId").val()),
            PrestamoId: parseInt(arrayComisiones[i].prestamoId.replace(/[C$]/g, '')),
            Porcentaje: parseInt(arrayComisiones[i].porcentaje),
            monto: parseInt(arrayComisiones[i].monto.replace(/[C$]/g, ''))
        });
    }

    $.ajax({
        async: true,
        url: "/Comisione/GuardarComision",
        type: "POST",
        data: {
            comisionDTO: comisiones
        },
        success: ({ data }) => {
            Swal.fire({
                title: '¿Esta seguro que desea aplicar las comisiones?',
                text: "",
                icon: 'warning',
                showCancelButton: true,
                confirmButtonColor: '#3085d6',
                cancelButtonColor: '#d33',
                confirmButtonText: 'Si',
                cancelButtonText: 'No'
            }).then((result) => {
                if (result.isConfirmed) {
                    $("#comisiones").html('');
                    Swal.fire(
                        'Guardado!',
                        'Las comisiones se guardaron sactifactoriamente.',
                        'success'
                    );
                    setInterval(() => { window.location.reload();}, 3000)
                   
                }
            });
        },
        error: ({ responseJSON: message }) => {
            Swal.fire(
                'Error!',
                'No se pudierón guardar las comisiones.',
                'error'
            );
        }
    });
});