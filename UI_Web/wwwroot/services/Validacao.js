sap.ui.define(
    [
    ],
    function () {
        "use strict";

        return {

            validarNome: function (campo) {
                const valorMinimodeCaracteres = 2;
                const nome = campo.getValue().trim();
                if (nome === '') {
                    return "Campo Nome é obrigatório.";
                }

                return "";
            },
            validarCPF: function (campo) {
                const cpf = campo.getValue().replace(/\.|-/g, "").trim();
                const numerosRepetidos = [
                    '00000000000',
                    '11111111111',
                    '22222222222',
                    '33333333333',
                    '44444444444',
                    '55555555555',
                    '66666666666',
                    '77777777777',
                    '88888888888',
                    '99999999999'
                ];

                if (cpf === '') {
                    return "Campo CPF é obrigatório.";
                }

                if (numerosRepetidos.includes(cpf)) {
                    return "CPF inválido.";
                }

                return "";
            },

            validarTelefone: function (campo) {
                const telefone = campo.getValue().replace(/[^0-9]/g, "").trim();
                const formato = /^\d{10,11}$/;

                if (telefone === '') {
                    return "Campo telefone é obrigatório.";
                }

                if (!formato.test(telefone)) {
                    return "Formato de telefone inválido. Deve conter apenas números e ter 10 ou 11 dígitos.";
                }
                return "";
            },

            validarNascimento: function (campo) {
                const nascimento = campo.getValue();

                if (nascimento === '') {
                    return "Campo data de nascimento é obrigatório.";
                }
                return "";
            },

            _limparErros: function (campo) {
                campo.setValueState(sap.ui.core.ValueState.None);
                campo.setValueStateText("");
            },

            _adicionarMensagemDeErros: function (campo, mensagem) {
                campo.setValueStateText(mensagem);
                campo.setValueState(sap.ui.core.ValueState.Error);
            },

            validarCamposFormulario: function (view) {
                const idNome = "campoNome";
                const idCPF = "campoCPF";
                const idTelefone = "campoTelefone";
                const idNascimento = "campoNascimento";

                let eValido = true;

                const nomeCampo = view.byId(idNome);
                const cpfCampo = view.byId(idCPF);
                const telefoneCampo = view.byId(idTelefone);
                const nascimentoCampo = view.byId(idNascimento);

                const nomeErro = this.validarNome(nomeCampo);
                const cpfErro = this.validarCPF(cpfCampo);
                const telefoneErro = this.validarTelefone(telefoneCampo);
                const nascimentoErro = this.validarNascimento(nascimentoCampo);

                if (nomeErro !== "") {
                    this._adicionarMensagemDeErros(nomeCampo, nomeErro);
                    eValido = false;
                } else {
                    this._limparErros(nomeCampo);
                }

                if (cpfErro !== "") {
                    this._adicionarMensagemDeErros(cpfCampo, cpfErro);
                    eValido = false;
                } else {
                    this._limparErros(cpfCampo);
                }

                if (telefoneErro !== "") {
                    this._adicionarMensagemDeErros(telefoneCampo, telefoneErro);
                    eValido = false;
                } else {
                    this._limparErros(telefoneCampo);
                }

                if (nascimentoErro !== "") {
                    this._adicionarMensagemDeErros(nascimentoCampo, nascimentoErro);
                    eValido = false;
                } else {
                    this._limparErros(nascimentoCampo);
                }
                return eValido;
            }
        };
    }
);