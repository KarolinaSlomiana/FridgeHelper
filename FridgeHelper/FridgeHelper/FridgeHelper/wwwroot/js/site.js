// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

function showProductDetails(currentRow, showHistoric) {
    var productName = currentRow.find('#item_Name').val();
    $.ajax({
        url: "Products/GetProductNameDetails",
        data: {
            name: productName,
            showHistoric: showHistoric
        }
    }).done(function (response) {
        $('.detailsRow').remove();
        var newRow = "<tr hidden='hidden' class='detailsRow' data-productname=" + productName + "><td colspan='10'>" + response + "</td></tr>";
        currentRow.after(newRow);
        $(".showUsedProductsCheckBox").change(toggleHistoricProducts);
        $('.detailsRow').toggle("slow", function () {});
    });
}

function toggleHistoricProducts() {
    var currentRow = $(this).closest('tr.detailsRow');
    var productName = currentRow.data('productname');
    var showHistoric = $(this)[0].checked;

    $.ajax({
        url: "Products/GetProductNameDetails",
        data: {
            name: productName,
            showHistoric: showHistoric
        }
    }).done(function (response) {
        currentRow.find('tbody').html($(response).find('tbody').html());
    });
}

$(".productShowDetailsButton").click(function () {
    var currentRow = $(this).closest('tr');
    showProductDetails(currentRow, false);
});

$(".productImage").each(function () {
    var productName = 'argus morela';
    $.ajax({
        //url: "https://www.google.com/search?biw=1376&bih=684&tbm=shop&q=" + productName,
        url: "https://www.google.com/search",
        data: {
            q: productName,
            oq: productName,
            tbm: 'shop',
            biw: 1376,
            bih: 684
        }
    }).done(function (response) {
        var selector =
            'html body#gsr.srp.tbo.vasq div#main div#cnt.mdm div.mw div#rcnt div.col div#center_col div#res.med div#search div div#ires div#rso div.sh-sr__shop-result-group div.sh-pr__product-results div.sh-dlr__list-result div.sh-dlr__content div.sh-dlr__thumbnail a div img';
        $(this).html($(response).find(selector));
    });
})