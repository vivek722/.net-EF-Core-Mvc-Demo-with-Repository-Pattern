// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
Skillarray = [];
$("#btnAddDataList").click(function () {
    let dataList = $("#txtAddDataList").val();
    Skillarray.push(dataList);
    $('ul').append('<li>' + dataList + '<span><i class="fa-solid fa-xmark" id="deleteIcon" style="color: #000000;"></i></span></li>')
    $("#Skill_Name").val(Skillarray);
    $("#txtAddDataList").val("");
});
$('ul').on("click", "span", function () {    
    let removeSkill = $(this).parent('li').text();
    Skillarray.splice(Skillarray.indexOf(removeSkill), 1)
    $(this).parent('li').remove();
    $("#Skill_Name").val(Skillarray);
});

function skillAdd(item) {
    let dataList = item;
    $("#skills").append('<li>' + dataList + '<span><i class="fa-solid fa-xmark" id="deleteIcon" style="color: #000000;"></i></span></li>')
    Skillarray.push(dataList);
    $("#txtAddDataList").val("");
}