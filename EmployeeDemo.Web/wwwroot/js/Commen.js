function deleteDailog(url) {
        Swal.fire({
        title: "Are you sure?",
        text: "You won't be able to revert this!",
        icon: "warning",
        showCancelButton: true,
        confirmButtonColor: "#3085d6",
        cancelButtonColor: "#d33",
        confirmButtonText: "Yes, delete it!"
    }).then((result) => {
        if (result.isConfirmed) {
            $.ajax({
                url: url,
                type: 'DELETE',               
                success: function (data) {                   
                    window.location = "/employees/index";                       
                }                                  
                })
        }
    })
}

function ShowLoding() {
    $(".loader").show();
}
function HideLoding() {
    $(".loader").hide();
}
function ShowData() {
    $("#Data").show();
}
$(window).on('beforeunload', function () {
    ShowLoding();
})
$(document).on('submit', 'form', function () {
    ShowLoding();
})
window.setTimeout(function () {
    $(".loader").hide();
    ShowData();
}, 2000);