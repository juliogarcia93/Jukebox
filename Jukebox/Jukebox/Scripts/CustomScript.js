$(document).ready(function () {

        $('#butt-select').click(function () {
            if ($('#room-type').val() == "Public") {
                $('#room-select').toggle(1000);
                $('#genre-select').toggle(1000);
                $('#room-type').show();
            } else if ($('#room-type').val() == "Private") {
                $('#room-select').toggle(1000);
                $('#room-search').toggle(1000);   
            }
        });
        $('#butt-close').click(function () {
            if ($('#room-type').val() == "Public") {
                $('#room-type').show();
                $('#genre-select').toggle();
            } else {
                $('#room-type').show();
                $('#room-select').toggle();
            }
        });
    
});

function SlideExit() {
    $('#room-select').hide(250);
}

