$(function () {

    $(".btnSend").click(function () {
        var text = $(".inputText").val()
        if (text == null || text == "") {
            alert("You can't put an empty comment")
        } else {
            comment(text);
        }
    })

    $("[class^=btnPlus]").click(function () {
        var commentId = $(this).attr("class").replace("btnPlus_", "")
        var plus = true;

        vote(commentId, plus);
    })

    $("[class^=btnMinus]").click(function () {
        var commentId = $(this).attr("class").replace("btnMinus_", "")
        var plus = false;

        vote(commentId, plus);
    })

    $("[class^=btnReply]").click(function () {
        $(this).closest(".box").next().slideToggle()
        $(this).closest(".box").toggleClass("active")
        $(this).closest(".isReply").next().slideToggle()
        $(this).closest(".isReply").toggleClass("active")
    })

    $("[class^=btnSendReply_]").click(function () {
        var commentId = $(this).attr("class").replace("btnSendReply_", "");
        var text = $(this).closest(".replyBox").children("input").val()
        reply(text, commentId)
    })

    function comment(text) {
        $.ajax({
            type: "post",
            url: "/Comments/New/",
            cache: false,
            data: { text: text },
            success: function (res) {

                if (res) {

                    location.href = "/Comments/"

                }
            },
            error: function (ex) {

                console.log(ex);

            }
        })
    }

    function reply(text, commentId) {
        $.ajax({
            type: "post",
            url: "/Comments/Reply/",
            cache: false,
            data: {
                text: text,
                replyId: commentId
            },
            success: function (res) {

                if (res) {

                    location.href = "/Comments/"

                }
            },
            error: function (ex) {

                console.log(ex);

            }
        })
    }


    function vote(commentId, plus) {
        $.ajax({
            type: "post",
            url: "/Comments/Vote/",
            cache: false,
            data: {
                commentId: commentId,
                plus: plus
            },
            success: function (res) {
                if (res) {
                    location.href = "/Comments/"
                }
            },
            error: function (ex) {
                console.log(ex);
            }
        })
    }
})