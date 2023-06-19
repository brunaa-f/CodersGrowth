sap.ui.define(
    [
        "sap/ui/core/mvc/Controller",
        "sap/ui/model/json/JSONModel",
        "sap/ui/model/Filter",
        "sap/ui/model/FilterOperator",
        "sap/ui/core/routing/Router",
    ],
    function (Controller, JSONModel, Filter, FilterOperator) {
        "use strict";
        return Controller.extend("ControleDeAlunos.Controller.TelaInicial", {
            onInit: function () {
                let oView = this.getView();

                fetch("/api/Aluno")
                    .then((response) => response.json())
                    .then((data) => {
                        oView.setModel(new JSONModel(data), "alunos");
                    })
                    .catch((error) => {
                        console.error(error);
                    });
            },
        })
    })
