jQuery(document).ready(function ($) {
    $('#tabs').tab();
});




function validarCedula(textbox) {

    if (textbox.validity.patternMismatch) {
        textbox.setCustomValidity('Por favor ingrese una cédula válida, debe ingresar los ceros, sin giones, ejemplo: 101110111');
        return false;
    }
    textbox.setCustomValidity('');
    return true;
    
}




function validarNumeroDoctor(textbox) {

    if (textbox.validity.patternMismatch) {
        console.log("error de tipo");
        textbox.setCustomValidity('Por favor ingrese una identificador válido de doctor');
        return false;
    }
    console.log("sin error");
    textbox.setCustomValidity('');
    return true;

}

function validarHora(textbox) {
    
    if (textbox.validity.patternMismatch) {
        console.log("error de tipo");
        textbox.setCustomValidity('Por favor ingrese una hora válida, ejemplo 10:30 pm');
        return false;
    }
    console.log("sin error");
    textbox.setCustomValidity('');
    return true;

}

function validarFecha(textbox) {

    if (textbox.validity.patternMismatch) {
        console.log("error de tipo");
        textbox.setCustomValidity('Por favor ingrese una fecha válida, ejemplo 03/12/2001 o 03-12-2001');
        return false;
    }
    console.log("sin error");
    textbox.setCustomValidity('');
    return true;

}