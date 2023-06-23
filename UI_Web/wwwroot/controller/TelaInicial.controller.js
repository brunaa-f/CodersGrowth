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

                fetch(localhost + "api/Aluno")

                    .then((response) => response.json())
                    .then((data) => {
                        oView.setModel(new JSONModel(data), "alunos");
                    })
                    .catch((error) => {
                        // console.error(error);
                    });
            },

            aoClicarAbreCadastro: function () {
                const rotaCadastro = "Cadastro";

                let rota = this.getOwnerComponent().getRouter();
                rota.navTo(rotaCadastro);
            },

            aoClicarAbreDetalhes: function (oEvent) {
                const rotaDetalhes = "Detalhes"

                let item = oEvent.getSource();
                let lista = item.getBindingContext("alunos");
                let rota = this.getOwnerComponent().getRouter();
                let idObjSelecionado = lista.getProperty("id");
                rota.navTo("Detalhes", {
                    id: idObjSelecionado
                });
            }
        })
    }
)
