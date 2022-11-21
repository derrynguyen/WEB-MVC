﻿var product = {
    init: function () {
        product.registerEvents();
    },
    registerEvents: function () {
        $('#btnCommentNew').off('click').on('click', function (e) {
            e.preventDefault();
            var btn = $(this);
            var userid = btn.data('userid');
            var commentmsg = document.getElementById('txtCommentNew');
            if (commentmsg.value == "") {

                bootbox.alert("Chưa nhập nội dung bình luận");
                return;
            }
            $.ajax({
                url: "/Blog/createPots",
                data: {
                    IDPosts = IDPosts,
                    titlePosts = titlePosts,
                    contentPots = contentPots,
                    userID = UserID,
                    timePosts = timePosts,
                },
                dataType: "json",
                type: "POST",
                success: function (response) {
                    if (response.status == true) {
                        commentmsg.value = "";
                        bootbox.alert({
                            message: "Bạn đã thêm bình luận thành công",
                            size: 'medium',
                            closeButton: false
                        });
                        $("#div_allcomment").load("/Product/GetComment?productid=" + productid);
                    }
                    else {
                        bootbox.alert("Thêm bình luận lỗi");
                    }
                }
            });
        });

        $('.abcdefghkj').off('click').on('click', function (e) {
            e.preventDefault();
            var btn = $(this);
            var productid = btn.data('productid');
            var userid = btn.data('userid');
            var parenid = btn.data('parentid');

            var commentmsg = btn.data('commentmsg');

            var commentmsgvalue = document.getElementById(commentmsg);


            if (commentmsgvalue.value == "") {

                bootbox.alert("Chưa nhập nội dung bình luận");
                return;
            }
            $.ajax({
                url: "/Blog/createPots",
                data: {
                    productid: productid,
                    userid: userid,
                    parentid: parenid,
                    commentmsg: commentmsgvalue.value,
                    rate: 5
                },
                dataType: "json",
                type: "POST",
                success: function (response) {
                    if (response.status == true) {
                        commentmsg.value = "";
                        bootbox.alert({
                            message: "Bạn đã thêm bình luận thành công",
                            size: 'medium',
                            closeButton: false
                        });
                        $("#div_allcomment").load("/Product/GetComment?productid=" + productid);
                    }
                    else {
                        bootbox.alert("Thêm bình luận lỗi");
                    }
                }
            });
        });


    }
}
product.init();