Number.prototype.toHHMMSS = function () {{
    var seconds = Math.floor(this),
        hours = Math.floor(seconds / 3600);
    seconds -= hours * 3600;
    var minutes = Math.floor(seconds / 60);
    seconds -= minutes * 60;

    if (hours < 10) {{ hours = "0" + hours; }}
    if (minutes < 10) {{ minutes = "0" + minutes; }}
    if (seconds < 10) {{ seconds = "0" + seconds; }}

    return hours + ':' + minutes + ':' + seconds;
}}

var data = $.parseJSON("{0}");

for (var i = 0; i < 16; i++) {{
    var item = data[i];
    
    var chObject = $("div#usb-" + (parseInt(item["PortID"]) + 1));

    var time_left = (item["RemainingChargingTime"]).toHHMMSS();
    chObject.children("span.period").text("Kalan: " + time_left);
}}