sap.ui.define([
    "sap/ui/core/mvc/Controller",
    "sap/ui/model/json/JSONModel"

], function (Controller, JSONModel) {
    "use strict";
    return Controller.extend("ControleDeAlunos.controller.Detalhes", {


        onInit: function () {
            let oView = this.getView();
            const localhost = "https://localhost:7082/";

            //retorna buscar todos
            fetch(localhost + "api/Aluno")

                .then((response) => response.json())
                .then((data) => {
                    oView.setModel(new JSONModel(data), "alunos");
                })
                .catch((error) => {
                    // console.error(error);
                });
        },
    });
});