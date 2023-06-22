sap.ui.define(
    [
        "sap/ui/core/mvc/Controller",
        "sap/ui/model/json/JSONModel",
    ],
    function (Controller, JSONModel) {
        "use strict";
        return Controller.extend("ControleDeAlunos.controller.TelaInicial", {
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

            aoClicarAbreFormCadastro: function () {
                let rota = this.getOwnerComponent().getRouter();
                let rotaCadastro = "Cadastro";
                rota.navTo(rotaCadastro);
            },

            aoClicarAlunoAbreDetalhes: function (oEvent) {
                debugger
                var item = oEvent.getSource();
                var oRouter = this.getOwnerComponent().getRouter();
                oRouter.navTo("Detalhes", {
                    invoicePath: window.encodeURIComponent(item.getBindingContext("id").getPath().substr(1))
                });
            }
        })
    }
)
