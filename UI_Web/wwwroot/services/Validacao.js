sap.ui.define(
    [
        "sap/ui/core/message/Message",
        "sap/ui/core/MessageType",
        "sap/ui/core/ValueState"
    ],
    function (Message, MessageType, ValueState) {
        "use strict";
        var Validacao = function () {
            this._eValido = true;
            this._validacaoRealizada = false;
            this._possiveisAgragacoes = [
                "items",
                "content",
                "form",
                "formContainers",
                "formElements",
                "fields",
                "sections",
                "subSections",
                "_grid",
                "cells",
                "_page"
            ];
            this._validarPropriedades = ["value", "selectedKey", "text"];
        };
        Validacao.prototype.isValid = function () {
            return this._validacaoRealizada && this._eValido;
        };
    }
);