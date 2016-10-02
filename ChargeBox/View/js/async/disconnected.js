var btn = $("input#connect-button");

//we are disconnected so display connect

btn.removeClass("disconnect");
btn.addClass("connect");
btn.val("Bağlan");

$("div.top div.connection").hide();

$("span#serial-cb").text("?");
$("span#tokenmax1-cb").text("?");
$("span#tokenmax2-cb").text("?");
$("span#tokentotal1-cb").text("?");
$("span#tokentotal2-cb").text("?");
$("span#awaitinterval-cb").text("?");
$("span#chargeperiod-cb").text("?");
$("span#factory-cb").text("?");

$("input#TokenMax1-Box").val(1);
$("input#TokenMax2-Box").val(1);
$("input#ChargePeriod-Box").val(1);
$("input#AwaitInterval-Box").val(1);
$("input#Toggle-Mode").prop("checked", false);