$(document).ready(function () {

    //dataTable();
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

//function dataTable() {
//    debugger
//    $("#datatabledata").DataTable({
//        "ajax":
//        {
//            url : '/Employees/getAll',
//            type: "GET",
//            datatype: "json",
//            success: onSuccess
//        }
//    });
//    }
//function onSuccess(response) {
//    debugger
//        $("#datatabledata").DataTable({
//            bprocessing: true,
//            bLengthChange: false,
//            lengthMenu: [[3, 5, 10, -1], [3, 5, 10, "All"]],
//            bfilter: false,
//            bSort: false,
//            searching: false,
//            bPaginate: true,
//            data: response,
//            columns: [
//                //{
//                //    data: 'Id',
//                //    render: function (data, type, row, meta) {
//                //        return row.Id
//                //    }
//                //},
//                {
//                    data: 'First_Name',
//                    render: function (data, type, row, meta) {
//                        return row.first_Name
//                    }
//                   },
//                //{
//                //    data: 'Last_Name',
//                //    render: function (data, type, row, meta) {
//                //        return row.Last_Name
//                //    }
//                //},
//                {
//                    data: 'Email',
//                    render: function (data, type, row, meta) {
//                        return row.email
//                    }
//                },
//                {
//                    data: 'Gender',
//                    render: function (data, type, row, meta) {
//                        return row.gender
//                    }
//                },
//                //{
//                //    data: 'Designation',
//                //    render: function (data, type, row, meta) {
//                //        return row.Designation
//                //    }
//                //},
//                //{
//                //    data: 'Image',
//                //    render: function (data, type, row, meta) {
//                //        return row.Image
//                //    }
//                //},
//                //{
//                //    data: 'Description',
//                //    render: function (data, type, row, meta) {
//                //        return row.Description
//                //    }
//                //},
//                //{
//                //    data: 'Skill_Name',
//                //    render: function (data, type, row, meta) {
//                //        return row.Skill_Name
//                //    }
//                //}
//            ]
//        });
//    }


