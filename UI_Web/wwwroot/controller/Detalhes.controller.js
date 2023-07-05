sap.ui.define([
    "sap/ui/core/mvc/Controller",
    "sap/ui/model/json/JSONModel",
], function (
    Controller,
    JSONModel) {
    "use strict";
    return Controller.extend("ControleDeAlunos.controller.Detalhes", {


        onInit: function () {
            let rota = sap.ui.core.UIComponent.getRouterFor(this);
            rota.attachRoutePatternMatched(this.rotaCorrespondida, this);
        },

        rotaCorrespondida: function (oEvent) {
            let id = oEvent.getParameter("arguments").id;
            this.obterAluno(id);
        },

        obterAluno: function (id) {
            let aluno = this.getView();

            fetch(`/api/Aluno/${id}`)
                .then((response) => response.json())
                .then((data) => {
                    aluno.setModel(new JSONModel(data), "aluno");
                })
                .catch((error) => {
                    console.error(error);
                });
        },

        aoClicarVoltar: function () {
            const rotaTelaInicial = "TelaInicial"

            var rota = this.getOwnerComponent().getRouter();
            rota.navTo(rotaTelaInicial);
        }
    });
});