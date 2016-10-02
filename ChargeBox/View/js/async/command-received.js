var area = $("textarea#signal-area");
var value = area.val();

if (value.length > 500)
    value = value.substring(0, 500);

area.val("Received: {0}\n" + value);

var console = $("div#communication-area");
value = console.html();

if (value.length > 1000)
    value = value.substring(0, 1000);

console.html("[Command]: Received, {0} <br />" + value);