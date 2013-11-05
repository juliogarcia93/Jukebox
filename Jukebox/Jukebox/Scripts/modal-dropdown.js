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