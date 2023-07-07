sap.ui.define(
    [
        "sap/ui/core/message/Message",
        "sap/ui/core/MessageType",
        "sap/ui/core/ValueState"
    ],
    function (Message, MessageType, ValueState) {
        "use strict";

        var Validacao = function () {
            this._validado = true;
            this._validacoesRealizadas = false;
            this._valor = "value";
            this._possiveisAgragacoes = [
                "form",
                "formContainers",
                "formElements",
                "fields",
            ];
        };

        Validacao.prototype.validar = function (controle) {
            this._validado = true;
            sap.ui.getCore().getMessageManager().removeAllMessages();
            this._validar(controle);
            return this.validado();
        };

        Validacao.prototype.validado = function () {
            return this._validacoesRealizadas && this._validado;
        };


        Validacao.prototype.limparStatus = function (controle) {
            if (!controle) return;
            if (controle.setValueState) controle.setValueState(ValueState.None);
            this._chamadaRecursiva(controle, this.limparStatus);
        };

        Validacao.prototype._validar = function (controle) {

            var validacaoControle = true,
                validado = true;

            if (controle.getRequired &&
                controle.getRequired() === true &&
                controle.getEnabled &&
                controle.getEnabled() === true) {

                validado = this._validarCamposObrigatorios(controle);

            } else if (

                controle.getValueState &&
                controle.getValueState() === ValueState.Error

            ) {
                validado = false;
                this._definirEstado(controle, ValueState.Error, "Wrong input");
            } else {
                validacaoControle = false;
            }

            if (!validado) {
                this._validado = false;
                this._addMessage(controle);
            }

            if (!validacaoControle) {
                this._chamadaRecursiva(controle, this._validar);
            }
            this._validacoesRealizadas = true;
        };

        Validacao.prototype._validarCamposObrigatorios = function (controle) {

            var validado = true;

            try {
                controle.getBinding(this._valor);
                var oExternalValue = controle.getProperty(
                    this._valor);

                if (!oExternalValue || oExternalValue === "") {
                    this._definirEstado(
                        controle,
                        ValueState.Error,
                        "Este campo é obrigatório"
                    );
                    validado = false;
                } else {
                    controle.setValueState(ValueState.None);
                    validado = true;
                }
            } catch (ex) {

            }
            return validado;
        };

        Validacao.prototype._addMessage = function (controle, sMessage) {
            var sLabel,
                eMessageType = MessageType.Error;


            switch (controle.getMetadata().getName()) {
                case "sap.m.Input":

                    sLabel = controle.getText();
                    break;
            }

            if (controle.getValueState)
                eMessageType = this._converterEstadoParaMensagem(
                    controle.getValueState()
                );

            sap.ui.getCore().getMessageManager().addMessages(
                new Message({
                    message: controle.getValueStateText
                        ? controle.getValueStateText()
                        : sMessage,
                    type: eMessageType,
                    additionalText: sLabel
                })
            );
        };

        Validacao.prototype._definirEstado = function (
            controle,
            eValueState,
            sText
        ) {
            controle.setValueState(eValueState);
            if (controle.getValueStateText && !controle.getValueStateText())
                controle.setValueStateText(sText);
        };

        Validacao.prototype._chamadaRecursiva = function (controle, fFunction) {
            for (var i = 0; i < this._possiveisAgragacoes.length; i++) {
                var aControlAggregation = controle.getAggregation(
                    this._possiveisAgragacoes[i]
                );
                if (!aControlAggregation) continue;
                if (aControlAggregation instanceof Array) {
                    for (var j = 0; j < aControlAggregation.length; j += 1) {
                        fFunction.call(this, aControlAggregation[j]);
                    }
                } else {
                    fFunction.call(this, aControlAggregation);
                }
            }
        };

        Validacao.prototype._converterEstadoParaMensagem = function (eValueState) {
            var eMessageType;

            switch (eValueState) {
                case ValueState.Error:
                    eMessageType = MessageType.Error;
                    break;
                case ValueState.Information:
                    eMessageType = MessageType.Information;
                    break;
                case ValueState.None:
                    eMessageType = MessageType.None;
                    break;
                case ValueState.Success:
                    eMessageType = MessageType.Success;
                    break;
                case ValueState.Warning:
                    eMessageType = MessageType.Warning;
                    break;
                default:
                    eMessageType = MessageType.Error;
            }
            return eMessageType;
        };
        return Validacao;
    }
);