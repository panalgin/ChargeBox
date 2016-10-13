var console = $("div#communication-area");
var value = console.html();

if (value.length > 1000)
    value = value.substring(0, 1000);

var data = $.parseJSON("{0}");
console.html("<span style=\"color: red\">[Info]: " + data["PortID"] + " numaralı soketten bir cihaz çıkarıldı.</span> <br />" + value);