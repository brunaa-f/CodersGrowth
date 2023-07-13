sap.ui.define(
    [
    ],
    function () {
        "use strict";

        return {

            validarNome: function (campo) {

                const nome = campo.getValue().trim();
                const valorMinimodeCaracteres = 2;
                const padrao = /[^a-zà-ú]/gi;

                if (nome === '') {
                    return "Campo Nome é obrigatório.";
                }
                if (nome.length <= valorMinimodeCaracteres || padrao.test(nome)) {
                    return "valor inválido";
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

                function validaPrimeiroDigito(cpf) {
                    let soma = 0;
                    let multiplicador = 10;

                    for (let tamanho = 0; tamanho < 9; tamanho++) {
                        soma += cpf[tamanho] * multiplicador;
                        multiplicador--
                    }

                    soma = (soma * 10) % 11;

                    if (soma == 10 || soma == 11) {
                        soma = 0;
                    }

                    return soma != cpf[9];
                }

                function validaSegundoDigito(cpf) {
                    let soma = 0;
                    let multiplicador = 11;

                    for (let tamanho = 0; tamanho < 10; tamanho++) {
                        soma += cpf[tamanho] * multiplicador;
                        multiplicador--
                    }

                    soma = (soma * 10) % 11;

                    if (soma == 10 || soma == 11) {
                        soma = 0;
                    }

                    return soma != cpf[10];
                }

                if (cpf === '') {
                    return "Campo CPF é obrigatório.";
                }

                if (numerosRepetidos.includes(cpf) || validaPrimeiroDigito(cpf) || validaSegundoDigito(cpf)) {
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