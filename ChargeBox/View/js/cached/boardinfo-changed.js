$("div#control-ajax").show();

var data = "{0}"; //this comes from CLR

var object = $.parseJSON(data);

$("span#serial-cb").text(object["Serial"]);
$("span#tokenmax1-cb").text(object["TokenMax1"]);
$("span#tokenmax2-cb").text(object["TokenMax2"]);
$("span#tokentotal1-cb").text(object["TokenTotal1"]);
$("span#tokentotal2-cb").text(object["TokenTotal2"]);
$("span#awaitinterval-cb").text(object["AwaitInterval"]);
$("span#chargeperiod-cb").text(object["ChargePeriod"]);
$("span#factory-cb").text(object["Factory"]);

$("input#TokenMax1-Box").val(object["TokenMax1"]);
$("input#TokenMax2-Box").val(object["TokenMax2"]);
$("input#ChargePeriod-Box").val(object["ChargePeriod"]);
$("input#AwaitInterval-Box").val(object["AwaitInterval"]);
$("input#Toggle-Mode").prop("checked", true);

$("div#control-ajax").fadeOut(1000);