
$(function(){
   
    $("#ddlCurso").change(function () {
        var Id = $(this).val(); console.log(Id);
        $.getJSON("../Reserva/SelectTurmas?id=" + Id,
               function (classesData) {
                    
                   var select = $("#ddlTurma");
                   select.empty();
                   select.append($('<option/>', {
                       value: 0,
                       text: "Selecione a Turma"
                   }));
                   $.each(classesData, function (index, itemData) {
                       select.append($('<option/>', {
                           value: itemData.Value,
                           text: itemData.Text
                       }));
                   });
               });
    });

    $("#ddlTurma").change(function () {
        var Id = $(this).val(); console.log(Id);
        $.getJSON("../Reserva/SelectDisciplinas?id=" + Id,
               function (classesData) {

                   var select = $("#ddlDisciplina");
                   select.empty();
                   select.append($('<option/>', {
                       value: 0,
                       text: "Selecione a Disciplina"
                   }));
                   $.each(classesData, function (index, itemData) {
                       select.append($('<option/>', {
                           value: itemData.Value,
                           text: itemData.Text
                       }));
                   });
               });
    });

    $("#ddlData").change(function () {
        var Id = $(this).val(); console.log(Id); 
        $.getJSON("../Reserva/SelectTurno?id=" + Id,
               function (classesData) {

                   var select = $("#ddlTurno");
                   select.empty();
                   select.append($('<option/>', {
                       value: 0,
                       text: "Selecione um Turno"
                   }));
                   $.each(classesData, function (index, itemData) {
                       select.append($('<option/>', {
                           value: itemData.Value,
                           text: itemData.Text
                       }));
                   });
               });
    });
    $("#ddlTurno").change(function () {
        var Id = $(this).val();
        var Data = $("#ddlData").val(); console.log(Id);console.log(Data);
        $.getJSON("../Reserva/SelectHorario", { id: $(this).val(), data: $("#ddlData").val() },
               function (classesData) {

                   var select = $("#ddlHorario");
                   select.empty();
                   select.append($('<option/>', {
                       value: 0,
                       text: "Selecione um Turno"
                   }));
                   $.each(classesData, function (index, itemData) {
                       select.append($('<option/>', {
                           value: itemData.Value,
                           text: itemData.Text
                       }));
                   });
               });
    });



});