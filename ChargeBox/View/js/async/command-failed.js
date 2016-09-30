var area = $("textarea#signal-area");
var value = area.val();

if (value.length > 500)
    value = value.substring(0, 500);

area.val("Failed: {0}\n" + value);