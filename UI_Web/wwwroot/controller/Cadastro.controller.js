sap.ui.define([
    "sap/ui/core/mvc/Controller",
    "sap/ui/model/json/JSONModel",
    "sap/ui/core/routing/History"
], function (
    Controller,
    JSONModel,
    History) {

    "use strict";
    return Controller.extend("ControleDeAlunos.controller.Cadastro", {

        onInit: function () {
            let rota = sap.ui.core.UIComponent.getRouterFor(this);
            rota.attachRoutePatternMatched(this.rotaCorrespondida, this);
        },
        rotaCorrespondida: function () {
            const aluno = "aluno";
            var objetoDeDadosCliente = new JSONModel({});
            this.getView().setModel(objetoDeDadosCliente, aluno);
        },

        aoClicarCancelar: function () {

        },
        aoClicarSalvar: function () {

            const mensagemDeErro = "Erro ao cadastrar aluno";
            const aluno = "aluno";
            var modeloAlunos = this.getView().getModel(aluno).getData();

            let dataNascimento = modeloAlunos.nascimento.split('/');
            let dataFormatada = new Date(dataNascimento[2], dataNascimento[1], dataNascimento[0]);
            var novoAluno = {
                nome: modeloAlunos.nome,
                cpf: modeloAlunos.cpf,
                telefone: modeloAlunos.telefone,
                nascimento: dataFormatada,
            };

            let endpoint = "api/Aluno"

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
        },
        aoClicarVoltar: function () {
            const rotaTelaInicial = "TelaInicial"
            var caminhoAnterior = History.getInstance().getPreviousHash();
            if (caminhoAnterior !== undefined) {
                window.history.go(-1);
            } else {
                var rota = this.getOwnerComponent().getRouter();
                rota.navTo(rotaTelaInicial);
            }
        },
    });
});