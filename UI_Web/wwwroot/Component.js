sap.ui.define([

    "sap/ui/core/UIComponent",
    "sap/ui/model/json/JSONModel",

], function (UIComponent, JSONModel) {

    "use strict";
    return UIComponent.extend("ControleDeAlunos.Component", {
        metadata: {

            interfaces: ["sap.ui.core.IAsyncContentCreation"],
            manifest: "json"
        },
        init: function () {

            UIComponent.prototype.init.apply(this, arguments);
            var oData = {
                recipient: {
                    name: ""
                }
            };
            let oModel = new JSONModel(oData);
            this.setModel(oModel);
            this.getRouter().initialize();
        }
    });
});