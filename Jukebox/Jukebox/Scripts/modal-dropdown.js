$(document).ready(function () {

    $('#Room-dropdown').click(function () {
        $('#pw-of-room').val("");
        $('#name-of-room2').val("");
        $('#privacy-selector').val(0);
        $('#room-pw').val("");
        $('#room-name').val("");
        $('#privacy-selector2').val(0);
        $('#genre-selector').val(0);
        $('#genre-selector2').val(0);
        $('#name-of-room').val("");
        $('#modal-footer').slideUp("slow");
        $('#modal-footer2').slideUp("slow");
    });

    $('#privacy-selector').change(function () {
        var option = $('#privacy-selector').val();
        if (option.toLowerCase() == "private") {
            $('#modal-private-information').slideDown("slow");
            $('#modal-genre').slideUp("slow");
            $('#modal-public-information').slideUp("slow");
        }
        else {
            if (option.toLowerCase() == "public") {
                $('#modal-genre').slideDown("slow");
                $('#modal-private-information').slideUp("slow");
                $('#modal-footer').slideUp("slow");
            } else if (option == 0) {
                $("#modal-private-information").slideUp("slow");
                $('#modal-genre').slideUp("slow");
                $('#modal-public-information').slideUp("slow");
                $('#modal-footer').slideUp("slow");
            }
        }
    });

    $('#privacy-selector2').change(function () {
        var option = $('#privacy-selector2').val();
        if (option.toLowerCase() == "private") {
            $('#modal-private-information2').slideDown("slow");
            $('#modal-genre2').slideUp("slow");
            $('#modal-public-information2').slideUp("slow");
        }
        else {
            if (option.toLowerCase() == "public") {
                $('#modal-genre2').slideDown("slow");
                $('#modal-private-information2').slideUp("slow");
                $('#modal-footer2').slideUp("slow");
            } else if (option == 0) {
                $("#modal-private-information2").slideUp("slow");
                $('#modal-genre2').slideUp("slow");
                $('#modal-footer2').slideUp("slow");
            }
        }
    });

    $('#genre-selector').change(function () {
        $('#modal-public-information').slideDown("slow");
    });

    $('#room-naming').keyup(function () {
            $('#modal-footer').slideDown("slow");
    
    });

    $('#pw-of-room').keyup(function () {
        $('#modal-footer').slideDown("slow");
    });


    $('#CreateAroomModal').on('hidden.bs.modal', function () {
        $("#modal-private-information").hide();
        $('#modal-genre').hide();
        $('#modal-public-information').hide();
        $('#modal-footer').hide();
    });

    $('#JoinAroomModal').on('hidden.bs.modal', function () {
        $("#modal-private-information2").hide();
        $('#modal-genre2').hide();
        $('#modal-footer2').hide();
    });


    $('#genre-selector2').change(function () {
        var genre = $('#genre-selector2').val();
        if (genre == 0) {
            $('#modal-footer2').slideUp("slow");
        } else {
            $('#modal-footer2').slideDown("slow");
        }
    });


    $('#genre-choice').change(function () {
        var option = $('#genre-choice').val();
        if (option.toLowerCase() == "select a genre") {
            $('#modal-footer2').slideUp("slow");
        }
        else {
            $('#modal-footer2').slideDown("slow");
        }
    });

    $('#room-pw').keyup(function () {
        $('#modal-footer2').slideDown("slow");
    });

});



