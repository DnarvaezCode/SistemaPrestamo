$("#ComboboxPrestamo").on("change", () => {
    debugger;
    var elementoPrestamo = $('[name="ComboboxPrestamo"]');
    var selectedPrestamoValue = elementoPrestamo.val();

    if (selectedPrestamoValue.length === 0) {
        return;
    }

    //Swal.fire({
    //    icon: 'success',
    //    title: 'Oops...',
    //    text: 'La transacción se realizo sactifactoriamente!'
    //})

});