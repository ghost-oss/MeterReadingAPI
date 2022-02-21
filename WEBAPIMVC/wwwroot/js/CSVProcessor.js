$(function ()
{
    $('#btnUpload').on('click', function () {
    var fileExtension = ['csv'];
    var filename = $('#fUpload').val();
    if (filename.length === 0) {
        alert("Please select a file.");
        return false;
    }
    else {
        var extension = filename.replace(/^.*\./, '');
        if ($.inArray(extension, fileExtension) === -1) {
            alert("Please select only CSV files.");
            return false;
        }
    }
    var fdata = new FormData();
    var fileUpload = $("#fUpload").get(0);
    var files = fileUpload.files;
    fdata.append("file", files[0]);

        $.ajax({
            type: "POST",
            url: "api/MeterReadingAPI/meter-reading-uploads",
            beforeSend: function (xhr) {
                xhr.setRequestHeader("RequestVerificationToken",
                    $('input:hidden[name="__RequestVerificationToken"]').val());
            },
            data: fdata,
            contentType: false,
            processData: false,
            success: function (response) {
                if (response.length === 0)
                    alert('Some error occured while uploading');
                else {
                    var data = JSON.parse(response);
                    var successfulReadings = data.MeterReadingValidationJsonResponse.successfulReadings;
                    var failedReadings = data.MeterReadingValidationJsonResponse.failedReadings;
                    $("#successfulInputs").text(successfulReadings);
                    $("#unsuccessfulInputs").text(failedReadings);
                }
            }
        });

    });
});