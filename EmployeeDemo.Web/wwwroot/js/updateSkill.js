skillData = [];
function skillAdd(item) {
    let dataList = item;
    skillData.push(dataList);
    $("#skills").append('<li>' + dataList + '<span><i class="fa-solid fa-xmark" id="deleteIcon" style="color: #000000;"></i></span></li>')
    $("#Skill_Name").val(skillData);
    $("#txtAddDataList").val("");
}