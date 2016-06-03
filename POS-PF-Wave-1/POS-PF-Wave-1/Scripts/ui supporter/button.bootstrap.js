$(".btn-group > .btn").click(function () {
    console.log("Hola");
    $(this).addClass("active").siblings().removeClass("active");
});