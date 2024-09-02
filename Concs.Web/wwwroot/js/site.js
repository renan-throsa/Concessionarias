// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$(document).ready(function () {
    $('#Telefone').mask('(00) 00000-0000');
    $('#CPF').mask('000.000.000-00', { reverse: true });
    $('#Cliente_CPF').mask('000.000.000-00', { reverse: true });
    $('#CEP').mask('00000-000');
    $('#PrecoVenda').mask("#.##0,00", { reverse: true });
    $('#Preco').mask("#.##0,00", { reverse: true });
    $('#VeiculoSelect').select2();
    $('#FabricanteSelect').select2();
    $('#ConcessionariaSelect').select2();
    $('#PaisOrigem').select2();
});