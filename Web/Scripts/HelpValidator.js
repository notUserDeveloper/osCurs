


validateText = function () {
    KnapItemCountCheck();
    KnapItemValCheck();
    CalculateErrorCheck();
    btnParamsCheck();
    btnCalculateCheck();
};

var KIValCheck = false;

KnapItemValCheck = function() {
    $("input[title='Capacity']:text,input[title='Weight']:text").blur(function () {
        var tbVal = $(this);
        if (tbVal.val() <= 0) {
            tbVal.val('0');
            alert('Значение должно быть >0');
            return false;
        }
        return true;
    });
};

KnapItemCountCheck = function() {
    $("[id$='ItemsCount'],[id$='KnapsacksCount']").blur(function () {
        var tbVal = $(this);
        if (tbVal.val() < 1) {
            tbVal.val('');
            KIValCheck = false;
            alert("Значение должно быть > 0");
            return;
        }
        KIValCheck = true;
    });
};

CalculateErrorCheck = function() {
    $("[id$='CalculateError']").blur(function () {
        var erVal = $(this);
        if (erVal.val() > 1 || erVal.val() < 0 || erVal.val() == '') {
            erVal.val('0');
            KIValCheck = false;
            alert("Значение должно быть от 0 до 1");
            return;
        }
        KIValCheck = true;
    });
};

btnParamsCheck = function () {
    $("input[id$='btnGridParameters']").click(function () {
        if (!KIValCheck) {
            alert("Введите все значения");
            return false;
        }
        return true;
    });
};


btnCalculateCheck = function() {
    $("input[id$='btnCalculate']").click(function () {
        var tds = $("td:last-child");
        if (tds.length == 0) {
            return false;
        }
        var check = true;
        tds.each(function () {
            if ($(this).text() <= 0) {
                check = false;
                return;
            }
        });
        if (!check) {
            alert("Не должно быть 0-ых значений");
        }
        return check;
    });
};


$(document).ready(validateText);