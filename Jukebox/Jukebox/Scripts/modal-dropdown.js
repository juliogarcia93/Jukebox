$(document).ready(function () {
    $('#privacy-selector').change(function () {
        var option = $('#privacy-selector').val();
        if (option.toLowerCase() == "private") {
            $('#modal-private-information').slideDown("slow");
            $('#modal-footer').slideDown("slow");
            $('#modal-genre').slideUp("slow");
            $('#modal-public-information').slideUp("slow");
        }
        else {
            if (option.toLowerCase() == "public") {
                $('#modal-genre').slideDown("slow");
                $('#modal-private-information').slideUp("slow");
                $('#modal-footer').slideUp("slow");
            } else if (option.toLowerCase() == "select your privacy:") {
                $("#modal-private-information").slideUp("slow");
                $('#modal-genre').slideUp("slow");
                $('#modal-public-information').slideUp("slow");
                $('#modal-footer').slideUp("slow");
            }
        }
    });

    $('#genre-selector').change(function () {
        $('#modal-public-information').slideDown("slow");
        $('#modal-footer').slideDown("slow");
    });

    $('#CreateAroomModal').on('hidden.bs.modal', function () {
        $("#modal-private-information").hide();
        $('#modal-genre').hide();
        $('#modal-public-information').hide();
        $('#modal-footer').hide();
    });


});

$(document).ready(function () {
    $('#privacy-selector2').change(function () {
        var option = $('#privacy-selector2').val();
        if (option.toLowerCase() == "private") {
            $('#modal-private-creation').slideDown("slow");
            $('#modal-footer2').slideUp("slow");
            $('#genre-select').slideUp("slow");
           
        }
        else {
            if (option.toLowerCase() == "public") {
                $('#genre-select').slideDown("slow");
                $('#modal-private-creation').slideUp("slow");
                $('#modal-footer2').slideUp("slow");
            } else if (option.toLowerCase() == "select your privacy:") {
                $("#modal-private-creation").slideUp("slow");
                $('#genre-select').slideUp("slow");
                $('#modal-footer2').slideUp("slow");
            }
        }
    });


    $('#JoinAroomModal').on('hidden.bs.modal', function () {
        $("#modal-private-creation").hide();
        $('#genre-select').hide();
        $('#modal-footer2').hide();
    });


});

$(document).ready(function () {
    $('#genre-choice').change(function () {
        var option = $('#genre-choice').val();
        if (option.toLowerCase() == "select a genre") {
            $('#modal-footer2').slideUp("slow");
        }
        else {
            $('#modal-footer2').slideDown("slow");
        }
    });
});

$(document).ready(function () {
    $('#room-name').keypress(function () {
        $('#room-pw').keypress(function () {
            $('#modal-footer2').slideUp("slow");
        });
    });
    $('#room-pw').keypress(function () {
        $('#room-name').keypress(function () {
            $('#modal-footer2').slideUp("slow");
        });
    });
});