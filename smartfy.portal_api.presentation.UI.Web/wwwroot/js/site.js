/**
 * Variavel para conter o evento de click do botão "YES" do Modal
 */
var ModalYes = function () { };

/**
 * Variavel para conter o evento de click do botão "NO" do Modal
 */
var ModalNo = function () { };

/**
 * Variavel para conter o evento de click do botão "Ok" do Modal
 */
var ModalOk = function () { };

/**
 * Tipos de modal
 * Message: modal com titulo, corpo e botão "OK".
 * YesNo: modal com titulo, corpo e botões "Sim" e "Não"
 */
const ModalTypes = {
    Message: `<button type='button' class='btn btn-default' data-dismiss='modal' onclick='ModalOk();'>Ok</button>`,
    YesNo: `<button type='button' class='btn btn-primary' onclick='ModalYes();'>Sim</button>
            <button type='button' class='btn btn-default' data-dismiss='modal' onclick='ModalNo();'>Não</button>`
}

/**
 * Mostra modal com gif animado de loading
 */
function showLoading() {
    $('#modalLoading').show();
}

/**
 * Esconde modal com git animado de loading
 */
function hideLoading() {
    $('#modalLoading').hide();
}

/**
 * Configura e mostra modal na tela
 * @param {any} title
 * @param {any} body
 * @param {any} type
 * @param {any} cssClass
 */
function showModal(title, body, type, cssClass) {
    $("#ModalTitulo").text(title);
    $("#ModalBody").text(body);
    $("#ModalFooter").html(type);
    $("#ModalHeader").addClass(cssClass);
    $("#ModalMensagem").modal('show');
}

/**
 * Fecha o modal
 */
function closeModal() {
    $("#ModalMensagem").modal('hide');
}

function parseServerDate(data) {
    return data.substring(0, 10);
}

$(document)
    .ajaxStart(function () {
        showLoading();
    })
    .ajaxStop(function () {
        hideLoading();
    });

var inputNumberAcceptCharacteres = "1234567890,";
var documentAcceptCharacteres = "1234567890";

var calculateDecimalPlaces = function (value, places) {
    var numberOfZeros = 0;
    var arr = [];
    var decimalValue = "";

    if (value.indexOf(",") < 0) {
        numberOfZeros = places;
        arr[0] = value;
    } else {
        arr = value.split(",");
        decimalValue = arr[arr.length - 1];
        numberOfZeros = places - decimalValue.length;
    }

    for (x = 0; x < numberOfZeros; x++) {
        decimalValue += "0";
    }

    if (numberOfZeros < 0) {
        decimalValue = decimalValue.substr(0, places);
    }

    return arr[0] + "," + decimalValue;
};

// Função que retira os pontos do CPF para enviar na API
var limpaCpf = function (cpf) {
    return cpf.replace(".", "").replace(".", "").replace("-", "");
};

$(document).ready(function () {
    // Datatables
    $(".dt").each(function (i, v) {
        var columns = $(v).data('cols').split(',').map(function (o) {
            var r = { mDataProp: o, name: o };
            return r;
        });
        $(v).find('[data-format]').each(function (i, v) {
            var fmt = $(this).data('format');
            columns[$(this).index()].render = function (data) {
                switch (fmt) {
                    case "money":
                        return formatMoney(data);
                    case "date":
                        return data;
                    case "cpf":
                        return data;
                    default:
                        return data;
                }
            };
        });

        var what = $(v).data('what');
        var deleteUrl = $(v).data('delete-url');
        var editUrl = $(v).data('edit-url');
        var createUrl = $(v).data('create-url');

        columns.push({
            "data": null,
            render: function (data) {
                return `<a href='${editUrl}/${data.dT_RowId}' class='btn btn-outline-info btn-sm btn-edit'>Editar</a>
                    <a href='${deleteUrl}/${data.dT_RowId}' class='btn btn-outline-danger btn-sm btn-remove'>Excluir</a>`;
            }
        });



        var t = $(v).dataTable({
            lengthMenu: [25, 50, 75, 100],
            dom: 'Bfrtip',
            bProcessing: true,
            bServerSide: true,
            bSearch: false,
            "ajax": {
                "url": $(v).data('url'),
                "type": "POST"
            },
            "rowCallback": function (row, data) {
                if (typeof (rowCallBack) != "undefined") {
                    rowCallBack(row, data);// isso daqui serve para criarmos um rowcallback diferente para cada view
                    // se adicionarmos uma funccao chamada rollcalback na pagina index ela sera executada aqui. agora que vi, rollcakback esta errado
                }
                $(row).find('.btn-remove').unbind('click').click(function () {
                    window.location.href = deleteUrl + "/" + data.dT_RowId;
                });
                $(row).find('.btn-edit').unbind('click').click(function () {
                    window.location.href = editUrl + "/" + data.dT_RowId;
                });
            },
            colReorder: true,
            autoFill: true,
            keys: true,
            select: false,
            rowReorder: false,
            buttons: [
                {
                    text: '<u>N</u>ovo registro',
                    className: 'btn btn-info btn-sm w-150',
                    action: function (e, dt, node, config) {
                        window.location.href = createUrl;
                    },
                    key: {
                        key: 'n',
                        altKey: true
                    }
                },
                {
                    extend: 'print',
                    text: 'Imprimir',
                    className: 'btn btn-primary btn-sm'
                },
                {
                    extend: 'copy',
                    text: '<u>C</u>opiar',
                    className: 'btn btn-success btn-sm',
                    key: {
                        key: 'c',
                        altKey: true
                    }
                },
                {
                    extend: 'excel',
                    className: 'btn btn-warning btn-sm'
                },
                {
                    extend: 'pdf',
                    className: 'btn btn-danger btn-sm'
                }
            ],

            "language": {
                "sEmptyTable": "Nenhum registro encontrado",
                "sInfo": "Mostrando de _START_ até _END_ de _TOTAL_ registros",
                "sInfoEmpty": "Mostrando 0 até 0 de 0 registros",
                "sInfoFiltered": "(Filtrados de _MAX_ registros)",
                "sInfoPostFix": "",
                "sInfoThousands": ".",
                "sLengthMenu": "_MENU_ resultados por página",
                "sLoadingRecords": "Carregando...",
                "sProcessing": "Processando...",
                "sZeroRecords": "Nenhum registro encontrado",
                "sSearch": "Pesquisar",
                "oPaginate": {
                    "sNext": "Próximo",
                    "sPrevious": "Anterior",
                    "sFirst": "Primeiro",
                    "sLast": "Último"
                },
                "oAria": {
                    "sSortAscending": ": Ordenar colunas de forma ascendente",
                    "sSortDescending": ": Ordenar colunas de forma descendente"
                },
                "select": {
                    "rows": {
                        "_": "Selecionado %d linhas",
                        "0": "Nenhuma linha selecionada",
                        "1": "Selecionado 1 linha"
                    }
                }
            },
            //sAjaxSource: "/ContaBancarias/List", // this links to your controller method from Step 3
            //fnServerParams: function (aoData) {aoData.push({ name: "datatableId", value: "personDatatable" }); // add the name of the datatable to the ajax request. This should be equal to the unique name you gave it in Step 1},
            //"fnServerData": function (sSource, aoData, fnCallback) {
            //    $.ajax($(v).data('url'), {
            //        type:"OPTIONS", success: function () {
            //            $.ajax($(v).data('url'), {
            //                type: "POST", success: function () {
            //                    fnCallback(d);
            //                }
            //            });
            //        }
            //    });
            //},

            columns: columns,
            fnDrawCallback: function () {
                //bindButton($(".btn-edit"));

            },
            preInit: function () {
                $("body").css("cursor", "wait");
            },
            initComplete: function () {
                $("body").css("cursor", "default");
            },

        });

        //Hide Search Button
        //$('#dt_filter').hide();
    });

    $('.decimal-input').on("blur", function (ev) {
        $(ev.target).val(calculateDecimalPlaces($(ev.target).val(), 2));
    });

    $('.decimal-input').on("keypress", function (ev) {
        if (inputNumberAcceptCharacteres.indexOf(ev.key) < 0) ev.preventDefault();
    });

    $('.documento').on("focus", function (ev) {
        var currval = $(ev.target).val();
        var newVal = currval.replace(".", "").replace(".", "").replace("-", "");
        $(ev.target).val(newVal);
    });

    $('.documento').on("blur", function (ev) {
        var value = limpaCpf($(ev.target).val());

        if (value.length !== 11 && value.length !== 15) {
            $(ev.target).val('');
            $('#modalDocumentoInvalido').modal();
        }

        if (value.length === 11) {
            var currval = $(ev.target).val();
            var maskedVal = currval.substr(0, 3) + "." + currval.substr(3, 3) + "." + currval.substr(6, 3) + "-" + currval.substr(9, 2);
            $(ev.target).val(maskedVal);

            var cpf = currval.replace(".", "").replace(".", "").replace("-", "");
            onCpfBlur(cpf);
        }

        if (value.length === 15) {
            var cns = $(ev.target).val();

            onCnsBlur(cns);
        }
    });

    $('.documento').on("keypress", function (ev) {
        if (documentAcceptCharacteres.indexOf(ev.key) < 0) ev.preventDefault();
        if ($(ev.target).val().length >= 15) ev.preventDefault();
    });

    //Campo filtro
    $('.documento-filtro').on("focus", function (ev) {
        var currval = $(ev.target).val();
        var newVal = currval.replace(".", "").replace(".", "").replace("-", "");
        $(ev.target).val(newVal);
    });

    $('.documento-filtro').on("blur", function (ev) {
        var value = limpaCpf($(ev.target).val());

        if (value.length !== 11 && value.length !== 15) {
            $(ev.target).val('');
            $('#modalDocumentoInvalido').modal();
        }

        if (value.length === 11) {
            var currval = $(ev.target).val();
            var maskedVal = currval.substr(0, 3) + "." + currval.substr(3, 3) + "." + currval.substr(6, 3) + "-" + currval.substr(9, 2);
            $(ev.target).val(maskedVal);

            var cpf = currval.replace(".", "").replace(".", "").replace("-", "");
        }

        if (value.length === 15) {
            var cns = $(ev.target).val();
        }
    });

    $('.documento-filtro').on("keypress", function (ev) {
        if (documentAcceptCharacteres.indexOf(ev.key) < 0) ev.preventDefault();
        if ($(ev.target).val().length >= 15) ev.preventDefault();
    });

    // Here we start to playing
    $.ajax({
        dataType: "json",
        method: "GET",
        url: "api/all",// TODO: verificar isso apiall
        success: function (data) {
            var dataset = {
                partners: [{        // total partners = length
                    id: '',
                    name: '',
                    teams: [{       // total teams = length
                        id: '',
                        time: 100,  // sum of files
                        cameras: [{ // total cameras = length
                            inoperation: false,
                            id: ''
                        }]
                    }]
                }]
            };

            $('#partners-table tbody tr').empty();
            $('#tmlp-partner-row').tmpl(data).appendTo($('#partners-table tbody'));
            // template no dados tabulares e series nos charts            
        }
    });
});

