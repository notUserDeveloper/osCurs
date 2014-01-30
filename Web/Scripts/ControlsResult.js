


Init = function () {
        $("#Time,#OptSolv,#AcceptSolv").removeClass("hide");
};

$(document).ready(function () {

    window.Sys.WebForms.PageRequestManager.getInstance().add_endRequest(Init);

});
