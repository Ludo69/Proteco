$(function () {

    var url = "http://proteco.mx/";
    //var url = "http://localhost/proteco/";

    $("#typed").typed({
        strings: ["android, iOS ^500", "bases, java, linux ^700", "ensamblado ^500", "cómputo forense ^500", "c++, matlab, c# ^400", "python, ruby, fortran ^500", "rm -rf / ^300"],
        typeSpeed: 70,
        backDelay: 600,
        loop: true,
        contentType: 'html',
        loopCount: false
    });

    $(".reset").click(function () {
        $("#typed").typed('reset');
    });


    // Captcha Casero
    function randomNumber(min, max) {
        return Math.floor(Math.random() * (max - min + 1) + min);
    }

    $('#captchaOperation').html([randomNumber(1, 100), '+', randomNumber(1, 200), '='].join(' '));

    // Registro 
    $("#unamDos").hide();
    $("#tipoDIV").hide();
    $("#botonUNAM").hide();
    $("#botonExterno").hide();

    $("#tipoUsuario").change(function () {
        var tipo = $("#tipoUsuario").val();
        if (tipo === '0') {
            $("#tipoDIV").hide();
            $("#UNAM").hide();
            $("#externo").hide();
            $("#general").hide();
        } else if (tipo === '1') {
            $("#externo").hide();
            $("#general").hide();
            $("#tipoDIV").show();
            $("#UNAM").show();
        } else if (tipo === '2') {
            $("#UNAM").hide();
            $("#general").hide();
            $("#tipoDIV").show();
            $("#externo").show();
        } else if (tipo === '3') {
            $("#externo").hide();
            $("#UNAM").hide();
            $("#tipoDIV").show();
            $("#general").show();
        } else {
            $("#tipoDIV").hide();
            $("#UNAM").hide();
            $("#externo").hide();
            $("#general").hide();
        }
    });

    $("#plantel").change(function () {
        if ($("#plantel").val() === '0') {
            $("#unamDos").hide();
        } else {
            $.ajax({
                url: url + "registro/carreras",
                type: "post",
                data: {'id': $("#plantel").val()},
                success: function (data) {
                    $("#carrera").html(data);
                }
            });
            $("#unamDos").show();
        }
    });

    $("#carrera").change(function () {
        if ($("#carrera").val() === '0') {
            $("#botonUNAM").hide();
        } else {
            $("#botonUNAM").show();
        }
    });

    $("#foranea").change(function () {
        if ($("#foranea").val() === '0') {
            $("#botonExterno").hide();
        } else {
            $("#botonExterno").show();
        }
    });

    // Form Validation 
    $('#formu').bootstrapValidator({
        feedbackIcons: {
            valid: 'glyphicon glyphicon-ok',
            invalid: 'glyphicon glyphicon-remove',
            validating: 'glyphicon glyphicon-refresh'
        },
        fields: {
            nombre: {
                validators: {
                    notEmpty: {
                        message: 'El nombre es un campo requerido'
                    },
                    stringLength: {
                        min: 3,
                        max: 40,
                        message: 'El nombre debe ser mayor de 3 y menor de 40 caracteres de largo'
                    },
                    regexp: {
                        regexp: /^[a-zñáéíóú\s]+$/i,
                        message: 'Solamente caracteres alfabéticos y espacios'
                    }
                }
            },
            apaterno: {
                validators: {
                    notEmpty: {
                        message: 'El apellido paterno es un campo requerido'
                    },
                    stringLength: {
                        min: 3,
                        max: 40,
                        message: 'El apellido paterno debe ser mayor de 3 y menor de 40 caracteres de largo'
                    },
                    regexp: {
                        regexp: /^[a-zñáéíóú\s]+$/i,
                        message: 'Solamente caracteres alfabéticos y espacios'
                    }
                }
            },
            amaterno: {
                validators: {
                    notEmpty: {
                        message: 'El apellido materno es un campo requerido'
                    },
                    stringLength: {
                        min: 3,
                        max: 40,
                        message: 'El apellido materno debe ser mayor de 3 y menor de 40 caracteres de largo'
                    },
                    regexp: {
                        regexp: /^[a-zñáéíóú\s]+$/i,
                        message: 'Solamente caracteres alfabéticos y espacios'
                    }
                }
            },
            email: {
                validators: {
                    notEmpty: {
                        message: 'El email es un campo requerido'
                    },
                    emailAddress: {
                        message: 'No cumple con el formato de un email'
                    },
                    callback: {
                        message: 'No disponible',
                        callback: function (value) {
                            var valido = true;
                            $.ajax({
                                url: url + "registro/correo",
                                type: "post",
                                async: false,
                                data: {'email': value},
                                success: function (response) {
                                    if (response) {
                                        valido = false;
                                    }
                                }
                            });
                            return valido;
                        }
                    }
                }
            },
            password: {
                validators: {
                    notEmpty: {
                        message: 'El password es un campo requerido'
                    },
                    identical: {
                        field: 'password2',
                        message: 'El password no coincide'
                    }
                }
            },
            password2: {
                validators: {
                    notEmpty: {
                        message: 'El password es un campo requerido'
                    },
                    identical: {
                        field: 'password',
                        message: 'El password no coincide'
                    }
                }
            },
            captcha: {
                validators: {
                    notEmpty: {
                        message: 'El captcha es un campo requerido'
                    },
                    callback: {
                        message: 'Respuesta incorrecta',
                        callback: function (value) {
                            var items = $('#captchaOperation').html().split(' '), sum = parseInt(items[0]) + parseInt(items[2]);
                            return value == sum;
                        }
                    }
                }
            },
            cuenta: {
                validators: {
                    notEmpty: {
                        message: 'El número de cuenta es un campo requerido'
                    },
                    callback: {
                        message: 'El número de cuenta no es válido',
                        callback: function (cta) {
                            if (cta.charAt(0) === '0' && cta.charAt(1) === '0' && cta.charAt(2) === '0' && cta.length === 9) {
                                return true;
                            } else {
                                var suma_par = 0;
                                var suma_non = 0;
                                var valido = false;
                                var pattern = new RegExp('[0-9]{9}');
                                if (pattern.test(cta)) {
                                    for (var idx = 0; idx < cta.length - 1; idx += 2) {
                                        suma_par += parseInt(cta.charAt(idx + 1));
                                        suma_non += parseInt(cta.charAt(idx));
                                    }
                                    suma_non *= 3;
                                    suma_par *= 7;
                                    var total = suma_non + suma_par;
                                    total = total.toString();
                                    if (total.substring(total.length - 1) === cta.charAt(cta.length - 1)) {
                                        valido = true;
                                    }
                                }
                                return valido;
                            }
                        }
                    }
                }
            },
            rfc1: {
                validators: {
                    regexp: {
                        regexp: /^([A-Z|a-z|&amp;]{3})(([0-9]{2})([0][13456789]|[1][012])([0][1-9]|[12][\d]|[3][0])|([0-9]{2})([0][13578]|[1][02])([0][1-9]|[12][\d]|[3][01])|([02468][048]|[13579][26])([0][2])([0][1-9]|[12][\d])|([1-9]{2})([0][2])([0][1-9]|[12][0-8]))(\w{2}[A|a|0-9]{1})$|^([A-Z|a-z]{4})(([0-9]{2})([0][13456789]|[1][012])([0][1-9]|[12][\d]|[3][0])|([0-9]{2})([0][13578]|[1][02])([0][1-9]|[12][\d]|[3][01])|([02468][048]|[13579][26])([0][2])([0][1-9]|[12][\d])|([1-9]{2})([0][2])([0][1-9]|[12][0-8]))((\w{2})([A|a|0-9]{1})){0,3}$/i,
                        message: 'RFC no válido'
                    },
                    notEmpty: {
                        message: 'El rfc es un campo requerido'
                    },
                    stringLength: {
                        min: 10,
                        max: 13,
                        message: 'El rfc debe ser mayor de 9 y menor de 14 caracteres de largo'
                    }
                }
            },
            rfc2: {
                validators: {
                    regexp: {
                        regexp: /^([A-Z|a-z|&amp;]{3})(([0-9]{2})([0][13456789]|[1][012])([0][1-9]|[12][\d]|[3][0])|([0-9]{2})([0][13578]|[1][02])([0][1-9]|[12][\d]|[3][01])|([02468][048]|[13579][26])([0][2])([0][1-9]|[12][\d])|([1-9]{2})([0][2])([0][1-9]|[12][0-8]))(\w{2}[A|a|0-9]{1})$|^([A-Z|a-z]{4})(([0-9]{2})([0][13456789]|[1][012])([0][1-9]|[12][\d]|[3][0])|([0-9]{2})([0][13578]|[1][02])([0][1-9]|[12][\d]|[3][01])|([02468][048]|[13579][26])([0][2])([0][1-9]|[12][\d])|([1-9]{2})([0][2])([0][1-9]|[12][0-8]))((\w{2})([A|a|0-9]{1})){0,3}$/i,
                        message: 'RFC no válido'
                    },
                    notEmpty: {
                        message: 'El rfc es un campo requerido'
                    },
                    stringLength: {
                        min: 10,
                        max: 13,
                        message: 'El rfc debe ser mayor de 9 y menor de 14 caracteres de largo'
                    }
                }
            }
        }
    });

    $('#formuEdit').bootstrapValidator({
        feedbackIcons: {
            valid: 'glyphicon glyphicon-ok',
            invalid: 'glyphicon glyphicon-remove',
            validating: 'glyphicon glyphicon-refresh'
        },
        fields: {
            nombre: {
                validators: {
                    notEmpty: {
                        message: 'El nombre es un campo requerido'
                    },
                    stringLength: {
                        min: 3,
                        max: 40,
                        message: 'El nombre debe ser mayor de 3 y menor de 40 caracteres de largo'
                    },
                    regexp: {
                        regexp: /^[a-zñáéíóú\s]+$/i,
                        message: 'Solamente caracteres alfabéticos y espacios'
                    }
                }
            },
            apaterno: {
                validators: {
                    notEmpty: {
                        message: 'El apellido paterno es un campo requerido'
                    },
                    stringLength: {
                        min: 3,
                        max: 40,
                        message: 'El apellido paterno debe ser mayor de 3 y menor de 40 caracteres de largo'
                    },
                    regexp: {
                        regexp: /^[a-zñáéíóú\s]+$/i,
                        message: 'Solamente caracteres alfabéticos y espacios'
                    }
                }
            },
            amaterno: {
                validators: {
                    notEmpty: {
                        message: 'El apellido materno es un campo requerido'
                    },
                    stringLength: {
                        min: 3,
                        max: 40,
                        message: 'El apellido materno debe ser mayor de 3 y menor de 40 caracteres de largo'
                    },
                    regexp: {
                        regexp: /^[a-zñáéíóú\s]+$/i,
                        message: 'Solamente caracteres alfabéticos y espacios'
                    }
                }
            }
        }
    });

    $('#formuEditPassword').bootstrapValidator({
        feedbackIcons: {
            valid: 'glyphicon glyphicon-ok',
            invalid: 'glyphicon glyphicon-remove',
            validating: 'glyphicon glyphicon-refresh'
        },
        fields: {
            password: {
                validators: {
                    notEmpty: {
                        message: 'El password es un campo requerido'
                    },
                    identical: {
                        field: 'password2',
                        message: 'El password no coincide'
                    }
                }
            },
            password2: {
                validators: {
                    notEmpty: {
                        message: 'El password es un campo requerido'
                    },
                    identical: {
                        field: 'password',
                        message: 'El password no coincide'
                    }
                }
            }
        }
    });

});
