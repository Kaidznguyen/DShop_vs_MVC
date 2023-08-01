// jq cho trang detailproduct
// hàm ẩn tab_content
$('.tabs-content-item').hide();
// hàm hiển thị tab_content đầu tiên
$('.tabs-content-item:first-child').fadeIn();
// hàm chuyển class active 
$('.tabs-item').click(function () {
    // active nav tabs
    $('.tabs-item').removeClass('active');
    $(this).addClass('active');
    // show tabs content item
    let id_tab_content = $(this).children('a').attr('href');
    $('.tabs-content-item').hide();
    $(id_tab_content).fadeIn();
    return false;
});

//slide show 1
$('.slider-show').slick({
    infinite: true,
    slidesToShow: 1,
    slidesToScroll: 1,
    autoplay: true,
    autoplaySpeed: 5000,
    dots: true,
    fade: true,
    cssEase: 'linear',
    prevArrow:"<button type='button' class='slick-prev pull-left'><i class='fa-solid fa-angle-left'></i></button>",
    nextArrow:"<button type='button' class='slick-next pull-right'><i class='fa-solid fa-angle-right'></i></button>",
    responsive: [
        {
        breakpoint: 1024,
        settings: {
            arrows:false,
        }
        },
        {
        breakpoint: 720,
        settings: {
            arrows:false,
            infinite: false,
        }
        }
    ]
});
    // Slider show sản phẩm
    $('.slider-product').slick({
        infinite: false,
        slidesToShow: 5,
        slidesToScroll: 3,
        cssEase: 'linear',
        speed: 1000,
        prevArrow:"<button type='button' class='slick-prev pull-left product-arrow'><i class='fa-solid fa-angle-left'></i></button>",
        nextArrow:"<button type='button' class='slick-next pull-right product-arrow'><i class='fa-solid fa-angle-right'></i></button>",
        responsive: [
            {
            breakpoint: 1024,
            settings: {
                slidesToShow: 3,
                slidesToScroll: 3,
                arrows:false,
            }
            },
            {
            breakpoint: 720,
            settings: {
                arrows:false,
                slidesToShow: 2,
                slidesToScroll: 2,
            }
            }
        ]
    });

    // hàm hiển thị thông báo
    $('.help').click(function(){
        alert('Chức năng đang trong quá trình thực hiện, hãy thử lại sau!!!');
        return false;
    });
    // hàm ấn tim đổi màu
    $('.feedback-img-icon_item').click(function(){
        if($(this).hasClass('feedback-img-icon-like')){
            $(this).removeClass('feedback-img-icon-like')
            return false;
        }
        else{
            $(this).addClass('feedback-img-icon-like')
            return false;
        }
    });
    // hàm về đầu trang
    $(window).scroll(function(){
        if($(this).scrollTop()){
            $('.backtop').fadeIn();
        }
        else{
            $('.backtop').fadeOut();
        }
    });
    $('.backtop').click(function(){
        $('html, body').animate({
            scrollTop: 0
        }, 1000);
    });
    //$('.btn-login').click(function(){
    //    $('.modal-login').css('display','none');
    //    $('.login,.register').addClass('hidden__user')
    //    $('.hd__navbar-user').addClass('active__user')
    //});
    // jq cho trang admin
//// add class hovered
//let list =document.querySelectorAll('.navigation li');
//function activeLink(){
//    list.forEach((item) =>
//    item.classList.remove(''));
//    this.classList.add('hovered');
//}
//list.forEach((item) => 
//item.addEventListener('mouseover',activeLink));
//// menu toggle
//let toggle = document.querySelector('.toggle');
//let navigation = document.querySelector('.navigation');
//let main = document.querySelector('.main__admin');

//toggle.onclick = function(){
//    navigation.classList.toggle('active');
//    main.classList.toggle('active')
//}
//// hàm ẩn tab_content
//$('.tab-content_admin').hide();
//// hàm hiển thị tab_content đầu tiên
//$('.tab-content_admin:nth-child(2)').fadeIn();
//// hàm chuyển class active 
//$('.navigation-item').click(function(){
//        // show tabs content item
//        let id_tab_content =  $(this).children('a').attr('href');
//        $('.tab-content_admin').hide();
//        $(id_tab_content).fadeIn();
//        return false;
//    });
//// hiển thị form thêm sản phẩm
//$('.title-tab_admin2').click(function(){
//    $('.overplay').css('display','flex');
//});
//// đóng form thêm sản phẩm
//$('.close').click(function(){
//    $('.overplay').css('display','none');
//});
//// chuyển đổi them
//const themtoggle= document.querySelector(".dark-light__them");
//themtoggle.addEventListener('click', () =>{
//    document.body.classList.toggle('color__dark-them');

//    themtoggle.querySelector('span:nth-child(1)').classList.toggle('active_them');
//    themtoggle.querySelector('span:nth-child(2)').classList.toggle('active_them');
//});
