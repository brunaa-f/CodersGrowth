sap.ui.define([
    "sap/ui/core/mvc/Controller",
    "sap/ui/model/json/JSONModel",
    "sap/ui/core/routing/History"
], function (Controller, JSONModel, History) {
    "use strict";
    return Controller.extend("ControleDeAlunos.controller.Cadastro", {


        onInit: function () {
        },
        aoClicarSalvar: function () {
        },

        adicionarAluno: function () {


        },
        aoClicarVoltar: function () {
            const rotaTelaInicial = "TelaInicial"
            var caminhoAnterior = History.getInstance().getPreviousHash();
            if (caminhoAnterior !== undefined) {
                window.history.go(-1);
            } else {
                var rota = this.getOwnerComponent().getRouter();
                rota.navTo(rotaTelaInicial);
            }
        }
    });
});