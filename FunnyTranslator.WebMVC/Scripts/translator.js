function presentTranslatedText(translationInfo) {

    var template = $('#success-translation-result-template')
        .html()
        .replace(/###TRANSLATION_METHOD###/g, translationInfo.TranslationMethod)
        .replace(/###TRANSLATED_TEXT###/g, translationInfo.TranslatedText);


    $('#translation-result').empty().append(template);
}

function displayError(errorMsg) {
    toastr.options.positionClass = 'toast-bottom-right';
    toastr.error(errorMsg);
}

$(function () {
    $('#btn-translate').click(function (event) {
        //Button load status
        const $target = $('#btn-translate');
        $target.attr("disabled", true);
        $target.append('<i class="fa fa-spinner fa-pulse"></i>');

        $.ajax({
            type: "POST",
            url: POST_TRANSLATE_URL,
            data: JSON.stringify({
                'text': $('#textToTranslateTextArea').val(),
                'translateType': $('#translateTypeSelect').val()
            }),
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (data) {
                if (data.IsSuccess) {
                    presentTranslatedText(data.Result);
                }
                else {
                    data.Errors.forEach(function (error) {
                        displayError(error);
                    });
                }
            },
            error: function (data) {
                displayError(data.responseJSON.ErrorMessage);
            },
            failure: function (errMsg) {
                displayError(errMsg);
            },
            complete: function (data) {
                $target.find("i.fa-spinner").remove();
                $target.attr("disabled", false);
            }
        });
    });
});