$(document).ready(function () {

    $("#datatabledata").DataTable({
        bprocessing: true,
        bLengthChange: false,
        lengthMenu: [[3, 5, 10, -1], [3, 5, 10, "All"]],
        bfilter: false,
        bSort: false,
        searching: false,
        bPaginate: true

    });
});