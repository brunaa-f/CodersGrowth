sap.ui.define([
    "sap/ui/core/mvc/Controller",
    "sap/ui/model/json/JSONModel"
], function (
    Controller,
    JSONModel) {

    "use strict";
    return Controller.extend("ControleDeAlunos.controller.Cadastro", {

        onInit: function () {
            let rota = sap.ui.core.UIComponent.getRouterFor(this);
            rota.attachRoutePatternMatched(this.rotaCorrespondida, this);
        },
        rotaCorrespondida: function () {
            const aluno = "aluno";
            var dadosAluno = new JSONModel({});

            this.getView().setModel(dadosAluno, aluno);
        },

        aoClicarCancelar: function () {
            const rotaTelaInicial = "TelaInicial"
            var rota = this.getOwnerComponent().getRouter();
            rota.navTo(rotaTelaInicial);
        },
        aoClicarSalvar: function () {
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
                });
        },
        aoClicarVoltar: function () {
            const rotaTelaInicial = "TelaInicial"
            var rota = this.getOwnerComponent().getRouter();
            rota.navTo(rotaTelaInicial);
        },

        navegarPaginaDetalhes: function (id) {
            const rotaDetalhes = "Detalhes"

            let rota = this.getOwnerComponent().getRouter();
            let idObjSelecionado = id;
            rota.navTo(rotaDetalhes, {
                id: idObjSelecionado
            });
        }
    });
});