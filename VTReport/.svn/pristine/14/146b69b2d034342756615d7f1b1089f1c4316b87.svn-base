
var pgsTimeVal
function onDashboardBeginUpdate(sender, args) {
    pgsBar.SetPosition(0);
    pgsBar.SetClientVisible(true);

    pgsTimeVal = setInterval(SetPgsPosition, 1000);
}

function onDashboardEndUpdate(sender, args) {
    pgsBar.SetPosition(299);
    pgsBar.SetPosition(300);
    setTimeout(ClearPgsPosition, 1000);
}

function ClearPgsPosition() {
    pgsBar.SetClientVisible(false);
    clearInterval(pgsTimeVal);
}

function SetPgsPosition() {
    var pos = pgsBar.GetPosition();

    if (pos >= 300) {
        pgsBar.SetClientVisible(false);
        clearInterval(pgsTimeVal);
    }
    else {
        pgsBar.SetPosition(++pos);
    }

}