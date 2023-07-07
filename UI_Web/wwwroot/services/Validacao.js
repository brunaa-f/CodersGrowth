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
        Validacao.prototype.eValido = function () {
            return this._validacaoRealizada && this._eValido;
        };
        Validacao.prototype.validar = function (oControl) {
            this._eValido = true;
            sap.ui
                .getCore()
                .getMessageManager()
                .removeAllMessages();
            this._validar(oControl);
            return this.eValido();
        };
        Validacao.prototype.clearValueState = function (oControl) {
            if (!oControl) return;

            if (oControl.setValueState) oControl.setValueState(ValueState.None);

            this._recursiveCall(oControl, this.clearValueState);
        };

        Validacao.prototype._validar = function (oControl) {
            var i,
                isValidatedControl = true,
                eValido = true;

            if (
                !(
                    (oControl instanceof sap.ui.core.Control ||
                        oControl instanceof sap.ui.layout.form.FormContainer ||
                        oControl instanceof sap.ui.layout.form.FormElement ||
                        oControl instanceof sap.m.IconTabFilter) &&
                    oControl.getVisible()
                )
            ) {
                return;
            }

            if (
                oControl.getRequired &&
                oControl.getRequired() === true &&
                oControl.getEnabled &&
                oControl.getEnabled() === true
            ) {
                // Control required
                eValido = this._validateRequired(oControl);
            } else if (
                (i = this._hasType(oControl)) !== -1 &&
                oControl.getEnabled &&
                oControl.getEnabled() === true
            ) {
                // Control constraints
                eValido = this._validateConstraint(oControl, i);
            } else if (
                oControl.getValueState &&
                oControl.getValueState() === ValueState.Error
            ) {
                // Control custom validation
                eValido = false;
                this._setValueState(oControl, ValueState.Error, "Wrong input");
            } else {
                isValidatedControl = false;
            }

            if (!eValido) {
                this._eValido = false;
                this._addMessage(oControl);
            }

            if (!isValidatedControl) {
                this._recursiveCall(oControl, this._validar);
            }
            this._validacaoRealizada = true;
        };

        Validacao.prototype._validateRequired = function (oControl) {

            var eValido = true;

            for (var i = 0; i < this._validarPropriedades.length; i += 1) {
                try {
                    oControl.getBinding(this._validarPropriedades[i]);
                    var oExternalValue = oControl.getProperty(
                        this._validarPropriedades[i]
                    );

                    if (!oExternalValue || oExternalValue === "") {
                        this._setValueState(
                            oControl,
                            ValueState.Error,
                            "Please fill this mandatory field!"
                        );
                        eValido = false;
                    } else if (
                        oControl.getAggregation("picker") &&
                        oControl.getProperty("selectedKey").length === 0
                    ) {
                        this._setValueState(
                            oControl,
                            ValueState.Error,
                            "Please choose an entry!"
                        );
                        eValido = false;
                    } else {
                        oControl.setValueState(ValueState.None);
                        eValido = true;
                        break;
                    }
                } catch (ex) {

                }
            }
            return eValido;
        };

        Validacao.prototype._validateConstraint = function (oControl, i) {
            var eValido = true;

            try {
                var editable = oControl.getProperty("editable");
            } catch (ex) {
                editable = true;
            }

            if (editable) {
                try {
                    var oControlBinding = oControl.getBinding(
                        this._validarPropriedades[i]
                    );
                    var oExternalValue = oControl.getProperty(
                        this._validarPropriedades[i]
                    );
                    var oInternalValue = oControlBinding
                        .getType()
                        .parseValue(oExternalValue, oControlBinding.sInternalType);
                    oControlBinding.getType().validateValue(oInternalValue);
                    oControl.setValueState(ValueState.None);
                } catch (ex) {
                    eValido = false;
                    this._setValueState(oControl, ValueState.Error, ex.message);
                }
            }
            return eValido;
        };

        Validacao.prototype._addMessage = function (oControl, sMessage) {
            var sLabel,
                eMessageType = MessageType.Error;

            if (sMessage === undefined) sMessage = "Wrong input";

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

        Validacao.prototype._hasType = function (oControl) {
            for (var i = 0; i < this._validarPropriedades.length; i += 1) {
                if (
                    oControl.getBinding(this._validarPropriedades[i]) &&
                    oControl.getBinding(this._validarPropriedades[i]).getType()
                )
                    return i;
            }
            return -1;
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

        Validacao.prototype._recursiveCall = function (oControl, fFunction) {
            for (var i = 0; i < this._possiveisAgragacoes.length; i += 1) {
                var aControlAggregation = oControl.getAggregation(
                    this._possiveisAgragacoes[i]
                );

                if (!aControlAggregation) continue;

                if (aControlAggregation instanceof Array) {
                    // generally, aggregations are of type Array
                    for (var j = 0; j < aControlAggregation.length; j += 1) {
                        fFunction.call(this, aControlAggregation[j]);
                    }
                } else {
                    // ...however, with sap.ui.layout.form.Form, it is a single object *sigh*
                    fFunction.call(this, aControlAggregation);
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