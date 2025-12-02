function addToPlan(id, el) {
    $.post('@Url.Action("SavePlan")', { ids: [id] }, function (r) {
        if (r.ok) { $(el).addClass("on"); toastr.success("Added to plan"); }
    });
}
function removeFromPlan(id) {
    $.post('@Url.Action("RemoveFromPlan")', { id: id }, function (r) {
        if (r.ok) { $("#planList").load('@Url.Action("MyPlan")'); toastr.info("Removed"); }
    });
}
$(function () {
    $("#genForm").on("submit", function (e) {
        e.preventDefault();
        $.post('@Url.Action("Generate")', $(this).serialize(), function (html) {
            $("#result").html(html);
        });
    });
});