jQuery.extend({

    prompt: function (text, type, times) {
        var prompt = $(['<div class="prompt ', type, '"><i></i><em>', text, '</em></div>'].join('')).appendTo('body');

        prompt.css('margin-left', -prompt.width()).fadeIn();

        setTimeout(function () {
            prompt.fadeOut(function () {
                prompt.remove();
            });
        }, times);
    }
});