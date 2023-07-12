sap.ui.define(
    [
        "sap/ui/core/ValueState"
    ],
    function (ValueState) {
        "use strict";

        return {

            validarNome: function (valor) {
                const nome = valor.getValue();
                const mensagemTamanhoMinimoNome = "ValidarTamanhoMinimo";

                if (!this._muitoCurto(nome)) {
                    this.mostrarErros(valor, mensagemTamanhoMinimoNome);
                    return false;
                }
                this._limparErros(valor);
                return true;
            },

            validarCPF: function (valor) {
                const cpf = valor.getValue();
            },
            _muitoCurto: function (tamanhoNome) {
                const tamanhoMinimoNome = 2;
                return tamanhoNome.length >= tamanhoMinimoNome;
            },


            mostrarErros: function (campo, mensagem) {
                campo.setValueStateText(mensagem);
                campo.setValueState(sap.ui.core.ValueState.Error);
            },
            _limparErros: function (campo) {
                campo.setValueState(sap.ui.core.ValueState.None);
            },

            validarCamposFormulario: function (view) {
                const campoNome = "campoNome";
                const campoCPF = "campoCPF";
                const campoTelefone = "campoTelefone"
                const campoNascimento = "campoNascimento"

                if (!this.validarNome(view.byId(campoNome))) {
                    return false;
                }

            }
        }
    }
);