sap.ui.define(
    [
        "sap/ui/core/mvc/Controller",
        "sap/ui/model/json/JSONModel",
    ],
    function (Controller, JSONModel) {
        "use strict";
        return Controller.extend("ControleDeAlunos.Controller.TelaInicial", {
            onInit: function () {
                let oView = this.getView();

                //retorna buscar todos
                fetch("/api/Aluno")

                    .then((response) => response.json())
                    .then((data) => {
                        oView.setModel(new JSONModel(data), "alunos");
                    })
                    .catch((error) => {
                        console.error(error);
                    });
            },

            _aoClicarAbreFormCadastro: function () {
                let rota = this.getOwnerComponent().getRouter();
                rota.navTo("Cadastro");
            },

        })
    })
