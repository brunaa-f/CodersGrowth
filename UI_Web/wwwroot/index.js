sap.ui.define([
    "sap/ui/core/ComponentContainer"

], function (ComponentContainer) {
    "use strict";
    new ComponentContainer({

        name: "ControleDeAlunos",
        settings: {
            id: "ControleDeAlunos"
        },
        async: true

    }).placeAt("conteudo");
});