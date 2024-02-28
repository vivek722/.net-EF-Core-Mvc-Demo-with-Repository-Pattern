
$(document).ready(function () {

    dataTable();
});

function dataTable() {   
    $.ajax({
        url: '/Employees/getAll',
        type: "GET",
        datatype: "json",
        success: onSuccess
    });
}
function onSuccess(response) {  
    $("#DataTable").DataTable({         
        bLengthChange: false,
        lengthMenu: [[3, 5, 10, -1], [3, 5, 10, "All"]],     
        searching: false,      
        data: response,
        columns: [
            {
                data: 'icon',
                render: function (data, type, row, meta) {
                    return '<Button class="btn"><i class="fa-solid fa-circle-plus fa-flip-vertical" style="color: #000000;"></i></Button>'
                }
            },
            {
                data: 'Image',
                render: function (data, type, row, meta) {
                    return '<img src="/uploads/'+row.image+'" class="rounded-circle" height="50px;" width="50px" />'
                }
            },
            {
                data: 'First_Name',
                render: function (data, type, row, meta) {
                    return row.first_Name + " " + row.last_Name
                }
            },
            {
                data: 'email',
                render: function (data, type, row, meta) {
                    return row.email
                }
            },

            {
                data: 'Gender',
                render: function (data, type, row, meta) {
                    return row.gender
                }
            },
             {
                 data: 'Designation',
                render: function (data, type, row, meta) {
                    return row.designation
                }
            },
            {
                data: 'Action',
                render: function (data, type, row, meta) {
                    return '<a href="/employees/update/' + row.id + '"><i class="fa-solid fa-user-pen mx-3" style="color: #000000;"></i></a >' + " " + ' <a class="btn" onclick="deleteDailog(/employees/delete/' + row.id +')"> <i class="fa-solid fa-trash" style="color: #000000;"></i></a > ' 
                }
            }           
        ]
        
    });
}


