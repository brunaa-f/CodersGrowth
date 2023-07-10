sap.ui.define(
    [
        "sap/ui/core/message/Message",
        "sap/ui/core/MessageType",
        "sap/ui/core/ValueState"
    ],
    function (Message, MessageType, ValueState) {
        "use strict";


        var Validacao = function () {
            this._isValid = true;
            this._aValidacaoFoiRealizada = false;
            this._possiveisAgregacoes = [
                "form",
                "formContainers",
                "formElements",
                "fields",
            ];
            this._valor = "value";
        };


        Validacao.prototype.isValid = function () {
            return this._aValidacaoFoiRealizada && this._isValid;
        };

        Validacao.prototype.validar = function (oControl) {
            this._isValid = true;
            sap.ui
                .getCore()
                .getMessageManager()
                .removeAllMessages();
            this._validar(oControl);
            return this.isValid();
        };


        Validacao.prototype.limparErros = function (oControl) {

            if (!oControl) return;
            if (oControl.setValueState) oControl.setValueState(ValueState.None);
            this._chamadaRecursiva(oControl, this.limparErros);

        };

        Validacao.prototype._validar = function (oControl) {
            var i,
                isvalidardControl = true,
                isValid = true;
            if (
                oControl.getRequired &&
                oControl.getRequired() === true
            ) {
                // Control required
                isValid = this._camposObrigatorios(oControl);
            } else if (
                oControl.getValueState &&
                oControl.getValueState() === ValueState.Error
            ) {
                // Control custom validation
                isValid = false;
                this._setValueState(oControl, ValueState.Error, "Wrong input");
            } else {
                isvalidardControl = false;
            }

            if (!isValid) {
                this._isValid = false;
                this._addMessage(oControl);
            }

            if (!isvalidardControl) {
                this._chamadaRecursiva(oControl, this._validar);
            }
            this._aValidacaoFoiRealizada = true;
        };


        Validacao.prototype._camposObrigatorios = function (oControl) {
            var isValid = true;

            try {
                oControl.getBinding(this._valor);
                var campoValor = oControl.getProperty(
                    this._valor
                );

                if (!campoValor || campoValor === "") {
                    this._setValueState(
                        oControl,
                        ValueState.Error,
                        "Por favor preencha esse campo!"
                    );
                    isValid = false;
                } else {
                    oControl.setValueState(ValueState.None);
                    isValid = true;
                }
            } catch (ex) {

            }
            return isValid;
        };

        Validacao.prototype._addMessage = function (oControl, sMessage) {
            var sLabel,
                eMessageType = MessageType.Error;

            if (sMessage === undefined) sMessage = "Wrong input"; // Default message

            switch (oControl.getMetadata().getName()) {
                case "sap.m.CheckBox":
                case "sap.m.Input":
                case "sap.m.Select":
                    sLabel = oControl
                        .getParent()
                        .getLabel()
                        .getText();
                    break;
            }

            if (oControl.getValueState)
                eMessageType = this._convertValueStateToMessageType(
                    oControl.getValueState()
                );

            sap.ui
                .getCore()
                .getMessageManager()
                .addMessages(
                    new Message({
                        message: oControl.getValueStateText
                            ? oControl.getValueStateText()
                            : sMessage,
                        type: eMessageType,
                        additionalText: sLabel
                    })
                );
        };


        Validacao.prototype._setValueState = function (
            oControl,
            eValueState,
            sText
        ) {
            oControl.setValueState(eValueState);
            if (oControl.getValueStateText && !oControl.getValueStateText())
                oControl.setValueStateText(sText);
        };


        Validacao.prototype._chamadaRecursiva = function (oControl, fFunction) {
            for (var i = 0; i < this._possiveisAgregacoes.length; i += 1) {
                var controleDeAgregacoes = oControl.getAggregation(
                    this._possiveisAgregacoes[i]
                );

                if (!controleDeAgregacoes) continue;

                if (controleDeAgregacoes instanceof Array) {

                    for (var j = 0; j < controleDeAgregacoes.length; j += 1) {
                        fFunction.call(this, controleDeAgregacoes[j]);
                    }
                } else {

                    fFunction.call(this, controleDeAgregacoes);
                }
            }
        };

        Validacao.prototype._convertValueStateToMessageType = function (
            eValueState
        ) {
            var eMessageType;

            switch (eValueState) {
                case ValueState.Error:
                    eMessageType = MessageType.Error;
                    break;
                case ValueState.None:
                    eMessageType = MessageType.None;
                    break;
                default:
                    eMessageType = MessageType.Error;
            }
            return eMessageType;
        };

        return Validacao;
    }
);
