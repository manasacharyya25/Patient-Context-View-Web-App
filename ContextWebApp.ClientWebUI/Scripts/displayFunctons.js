function MyPatients() {
    $('#screenTitle').html("My Patients");
    $('#screenDetails').html('<table class="table table-hover"><thead id = "thead" ></thead ><tbody id="tbody"></tbody></table >');
    $('#thead').html('<tr><th>MRN</th><th>Name</th><th>ICU</th><th>Bed</th></tr>');
    $('#tbody').html("");
    for (var i = 0; i < myPatients.length; i++) {
        $('#tbody').append('<tr><td>' + myPatients[i][0] + '</td><td>' + myPatients[i][1] + '</td><td>' + myPatients[i][2] + '</td><td>' + myPatients[i][3] + '</td></tr>');
    }
}

function Demographics() {
    if (contextSet == false) {
        $('#screenTitle').html("Patient Context Not Set");
        $('#screenDetails').html("");
    } else {
        $('#screenTitle').html("Demographic Details");
        $('#screenDetails').html('<table class="table table-hover"><thead id = "thead" ></thead ><tbody id="tbody"></tbody></table >');
        $('#thead').html('<tr><th>MRN</th><th>Name</th><th>Age</th><th>Address</th></tr>');
        $('#tbody').html('<tr><td>' + patients.mrn + '</td><td>' + patients.name + '</td><td>' + patients.age + '</td><td>' + patients.address + '</td></tr>');
    }
}

function Vitals() {
    if (contextSet == false) {
        $('#screenTitle').html("Patient Context Not Set");
        $('#screenDetails').html("");
    } else {
        $('#screenTitle').html("Patient Vitals");
        $('#screenDetails').html('<ul class="list-group"><li class= "list-group-item" >MRN: ' + patients.mrn + '</li ><li class="list-group-item">Name: ' + patients.name + '</li><li class="list-group-item">Gender: ' + patients.sex + '</li><li class="list-group-item">Temperature: ' + patients.temperature + '</li><li class="list-group-item">Blood Pressure: ' + patients.bp + '</li><li class="list-group-item">BMI: ' + patients.bmi + '</li><li class="list-group-item">Glucose: ' + patients.glucoseLevel + '</li><li class="list-group-item">Pulse Rate: ' + patients.pulseRate + '</li><li class="list-group-item">Heart Rate: ' + patients.heartRate + '</li></ul >');
    }
}

function MedicationOrders() {
    $('#screenTitle').html("Medication Orders");
}