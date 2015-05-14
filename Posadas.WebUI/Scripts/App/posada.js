﻿var uri = '/api/Lugares/';

$(document).ready(function () {
    $("#OtroLugar").hide();
    if ($("#EstadoId").val()) {
        $('#LugarId').removeAttr("disabled");
        if ($("#OtroLugar").val()) {
            $("#OtroLugar").show();
        }
    }
    $('#EstadoId').on('change', function () {
        $("#OtroLugar").hide();
        updateLugar(this.value);

    });

    $('#LugarId').on('change', function () {
        if (this.value == -1) {
            $("#OtroLugar").show();
        }
        else {
            $("#OtroLugar").hide();
        }
    });
});

function updateLugar(estadoId) {
    $.getJSON(uri + estadoId)
        .done(function (data) {
            // On success, 'data' contains a list of products.
            $('#LugarId').removeAttr("disabled").find('option').remove();
            $('#LugarId').append('<option value="0">Seleccione un lugar</option>');

            $.each(data, function (key, item) {
                // Add a list item for the product.

                $('#LugarId').append('<option value="' + item.Id + '">' + item.Nombre + '</option>');

            });
            $('#LugarId').append('<option value="-1"> otro </option>');
        });
}