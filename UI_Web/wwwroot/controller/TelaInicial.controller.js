sap.ui.define(
    [
        "sap/ui/core/mvc/Controller",
        "sap/ui/model/json/JSONModel",
        "sap/ui/model/Filter",
        "sap/ui/model/FilterOperator"
    ],
    function (
        Controller,
        JSONModel,
        Filter,
        FilterOperator) {

        "use strict";
        return Controller.extend("ControleDeAlunos.controller.TelaInicial", {
            onInit: function () {
                let view = this.getView();
                const endpoint = "api/Aluno";
                const modeloAlunos = "alunos";

                fetch(endpoint)

                    .then((response) => response.json())
                    .then((data) => {
                        view.setModel(new JSONModel(data), modeloAlunos);
                    })
                    .catch((error) => {
                        console.error(error);
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
                rota.navTo(rotaDetalhes, {
                    id: idObjSelecionado
                });
            },
            aoClicarBucar: function () {

                var aFilter = [];
                var sQuery = oEvent.getParameter("query");
                if (sQuery) {
                    aFilter.push(new Filter("alunos/nome", FilterOperator.Contains, sQuery));
                }

                // filter binding
                var oList = this.byId("listaAlunos");
                var oBinding = oList.getBinding("items");
                oBinding.filter(aFilter);
            }
        })
    }
)
