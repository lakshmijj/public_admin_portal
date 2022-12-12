
//Session timeout in minute.
var sessionTimeout = "20";

//Session timeout warning before 2 minute.
var sessionTimeoutWarning = parseInt(sessionTimeout) - 2;

//Session timeout in millisecond.
var sTimeout = parseInt(sessionTimeout) * 60 * 1000;

//Calculating minutes before timeout in millisecond.
var minutesForExpiry = (parseInt(sessionTimeout) - parseInt(sessionTimeoutWarning));


//setTimeout(' Redirect()', sTimeout);
function SessionWarning() {
    //document.getElementById("lblExpire").innerHTML  = "Your session will expire in another " + minutesForExpiry + " mins! Please refresh the page before the session expires";
    document.getElementById("alert").style.display = "block";
   // alert(message);
    setTimeout('Redirect()', (minutesForExpiry * 1000 * 60));

}

function Redirect() {
    //document.getElementById("lblExpire").innerHTML =  "Session expired. You will be redirected to login page";
     document.getElementById("frmLogout").submit();
    window.location = "/";
}

$(".category_1 .pinned").last().addClass("bordered");
$(".category_2 .pinned").last().addClass("bordered");
$(".category_3 .pinned").last().addClass("bordered");
$(".category_4 .pinned").last().addClass("bordered");