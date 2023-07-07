sap.ui.define([
    "sap/ui/core/mvc/Controller",
    "sap/ui/model/json/JSONModel",
    "sap/m/Dialog",
    "sap/m/Button",
    "sap/m/library",
    "sap/m/MessageToast",
    "sap/m/Text",
    "sap/ui/core/ValueState",
    "../services/Validacao"

], function (
    Controller,
    JSONModel,
    Dialog,
    Button,
    library,
    MessageToast,
    Text,
    ValueState,
    Validacao,
) {

    "use strict";
    var ButtonType = library.ButtonType;
    var DialogType = library.DialogType;

    var PageController = Controller.extend("ControleDeAlunos.controller.Cadastro", {

        onInit: function () {
            let rota = sap.ui.core.UIComponent.getRouterFor(this);
            rota.attachRoutePatternMatched(this.rotaCorrespondida, this);

            sap.ui.getCore().attachValidationError(function (oEvent) {
                debugger;
                oEvent.getParameter("element").setValueState(ValueState.Error);
            });
            sap.ui.getCore().attachValidationSuccess(function (oEvent) {
                debugger;
                oEvent.getParameter("element").setValueState(ValueState.None);
            });
        },

        rotaCorrespondida: function () {
            const aluno = "aluno";
            var dadosAluno = new JSONModel({});

            this.getView().setModel(dadosAluno, aluno);
        },
        validarCampos: function () {
            var oControl = this.getView().byId("VBox");
            var bValidation = this._validar(oControl);
            if (!bValidation) {
                alert("preencha os campos obrigatórios");
            }
        },

        _validar: function (oControl) {
            debugger;
            var validacao = new Validacao();
            if (validacao.validar(oControl)) {
                return true;
            } else {
                return false;
            }
        },

        aoClicarSalvar: function () {
            this.validarCampos();
            const aluno = "aluno";
            let modeloAlunos = this.getView().getModel(aluno).getData();
            let id = modeloAlunos.id;
            this.cadastrarAluno();
        },
        aoClicarCancelar: function () {

            if (!this.oApproveDialog) {
                this.oApproveDialog = new Dialog({
                    type: DialogType.Message,
                    title: "Deseja cancelar?",
                    content: new Text({ text: "Você pode perder os seus dados" }),
                    beginButton: new Button({
                        type: ButtonType.Emphasized,
                        text: "OK",
                        press: function () {
                            this.oApproveDialog.close();
                            this.navegarParaPaginaInicial()
                        }.bind(this)
                    }),
                    endButton: new Button({
                        text: "Cancel",
                        press: function () {
                            this.oApproveDialog.close();
                        }.bind(this)
                    })
                });
            }
            this.oApproveDialog.open();
        },
        aoClicarVoltar: function () {
            const rotaTelaInicial = "TelaInicial"
            var rota = this.getOwnerComponent().getRouter();
            rota.navTo(rotaTelaInicial);
        },

        navegarPaginaDetalhes: function (id) {
            const rotaDetalhes = "Detalhes"

            let rota = this.getOwnerComponent().getRouter();
            rota.navTo(rotaDetalhes, {
                id: id
            });
        },

        navegarParaPaginaInicial: function () {
            const rotaTelaInicial = "TelaInicial"

            let rota = this.getOwnerComponent().getRouter();
            rota.navTo(rotaTelaInicial);
        },

        cadastrarAluno: function () {
            const aluno = "aluno";
            let modeloAlunos = this.getView().getModel(aluno).getData();
            let dataNascimento = modeloAlunos.nascimento.split('/');
            let dataFormatada = new Date(dataNascimento[2], dataNascimento[1], dataNascimento[0]);
            let endpoint = "api/Aluno"

            var novoAluno = {
                nome: modeloAlunos.nome,
                cpf: modeloAlunos.cpf,
                telefone: modeloAlunos.telefone,
                nascimento: dataFormatada,
            };

            const mensagemDeErro = "Erro ao cadastrar aluno";
            fetch(endpoint, {
                method: "POST",
                headers: {
                    'Content-Type': 'application/json',
                },
                body: JSON.stringify(novoAluno),
            })
                .then((resposta) => {

                    if (!resposta.ok) {
                        throw new Error(mensagemDeErro);
                    }
                    return resposta.json();
                })
                .then(data => {
                    var idAluno = data.id;
                    this.navegarPaginaDetalhes(idAluno);
                    var msg = 'Aluno Cadastrado com sucesso';
                    MessageToast.show(msg);
                });
        },

        editarAluno: function () {

        }
    });
    return PageController;
});









