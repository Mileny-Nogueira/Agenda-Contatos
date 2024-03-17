// Esta função recebe um input que representa um número de celular e aplica uma máscara no formato (XX) XXXXX-XXXX, essa máscara funciona por meio de expressões regulares
function mascaraCelular(celularInput) {
    celularInput.value = celularInput.value.replace(/(\d{2})(\d{5})(\d{4})/, '($1) $2-$3');
}

// Esta função recebe um input e valida se contém somente números, removendo qualquer caractere não numérico
function validarSomenteNumeros(input) {
    input.value = input.value.replace(/[^0-9]/g, '');
}
