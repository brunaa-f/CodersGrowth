sap.ui.define(
    [
        "sap/ui/core/ValueState"
    ],
    function (ValueState) {
        "use strict";

        var Validacao = function () {
            this._isValid = true;
            this._aValidacaoFoiRealizada = false;
            this._valor = "value";
            this._possiveisAgregacoes = [
                "form",
                "formContainers",
                "formElements",
                "fields",
            ];
        };

        Validacao.prototype.isValid = function () {
            return this._aValidacaoFoiRealizada && this._isValid;
        };

        Validacao.prototype.validar = function (oControl) {
            this._isValid = true;
            sap.ui.getCore().getMessageManager().removeAllMessages();
            this._validar(oControl);
            return this.isValid();
        };

        Validacao.prototype.limparErros = function (oControl) {

            if (!oControl) return;
            if (oControl.setValueState) oControl.setValueState(ValueState.None);
            this._chamadaRecursiva(oControl, this.limparErros);

        };

        Validacao.prototype._validar = function (oControl) {

            var isvalidardControl = true,
                isValid = true;

            if (oControl.getRequired && oControl.getRequired() === true) {

                isValid = this._camposObrigatorios(oControl);
            } else if (
                oControl.getValueState && oControl.getValueState() === ValueState.Error
            ) {

                isValid = false;
                this._setValueState(oControl, ValueState.Error, "Wrong input");
            } else {
                isvalidardControl = false;
            }

            if (!isvalidardControl) {
                this._chamadaRecursiva(oControl, this._validar);
            }
            this._aValidacaoFoiRealizada = true;
        };


        Validacao.prototype._camposObrigatorios = function (oControl) {
            var isValid = true;

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

            return isValid;
        };

        Validacao.prototype._setValueState = function (oControl, eValueState, sText) {
            oControl.setValueState(eValueState);
            if (oControl.getValueStateText && !oControl.getValueStateText()) {
                oControl.setValueStateText(sText);
            }
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

        return Validacao;
    }
);
