$.connection.hub.url = "http://localhost:5127/signalr";
var chat = $.connection.notificationHub;

chat.client.notifyClient = function (message) {
    $('#myModal2').modal('hide');
    $('#myModal1').modal('hide');
    $('#myModal').modal('show');
    $('#modalMessage').html('Request to change to Patient Context ' + message);
}

chat.client.receiveContext = function (message) {
    contextSet = true;
    patients = message;
    $('#myModal1').modal('show');
    $('#modalContent1').css('background-color', '#92f9ab');
    $('#modalMessage1').html('Patient Context Changed To ' + patients.mrn);
    
    $('#demographicsBtn').click();
}

chat.client.receiveMessage = function (message) {
    $('#myModal1').modal('show');
    $('#modalContent1').css('background-color', '#ffa6a6');
    $('#modalMessage1').html('Request to change Patient Context to ' + message + ' Declined');
}

chat.client.getContext = function (message) {
    if (message == "-1") {
        contextSet = false;
    }
    else {
        contextSet = true;
        patients = message;
        $('#demographicsBtn').click();
    }
}

chat.client.setMyPatients = function(message){
    myPatients = message;
}


/*******   CONNECTION WITH HUB STARTED AND CONTEXT IS SET (IF SET ALREADY)  **********/
$.connection.hub.start().done(function () {
    chat.server.setContext();
    chat.server.getMyPatients();
});


function getContextFromMessage(message) {
    if (message == 'MRN001') {
        patientContext = 0;
    } else if (message == 'MRN002') {
        patientContext = 1;
    } else if (message == 'MRN003') {
        patientContext = 2;
    } else if (message == '-1') {
        patientContext = -1;
    }
}

function Send() {
    var text = document.getElementById('desiredContextChangeText').value;
    chat.server.notifyServer(text);
    $('#desiredContextChangeText').val('');
}

function getDetails() {
    chat.server.details();
}

function Accept() {
    chat.server.accept();
}

function Reject() {
    chat.server.reject();
}