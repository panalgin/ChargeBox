﻿var console = $("div#communication-area");
var value = console.html();

if (value.length > 1000)
    value = value.substring(0, 1000);

var data = $.parseJSON("{0}");
console.html("<span style=\"color: lime\">[Info]: " + data["PortID"] + " numaralı sokette sarj işlemi başlatıldı. Toplam sarj süresi: " + (data["Period"] / 60) +" dakika.</span> <br />" + value);