﻿var area = $("textarea#signal-area");
var value = area.val();

if (value.length > 500)
    value = value.substring(0, 500);

area.val("Sent: {0}\n" + value);

var showOnConsole = false;

if (showOnConsole) {{
        var console = $("div#communication-area");
        value = console.html();

        if (value.length > 1000)
            value = value.substring(0, 1000);

        console.html("[Command]: Sent, {0} <br />" + value);
}}