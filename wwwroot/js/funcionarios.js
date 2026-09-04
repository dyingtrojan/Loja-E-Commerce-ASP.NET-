const API_URL_FUNCIONARIOS = 'https://localhost:7281/api/Funcionarios';

var qtd_funcionarios = 0;
async function carregarFuncionarios() {
    try {
        const response = await fetch(API_URL_FUNCIONARIOS);
        const funcionarios = await response.json();

        const FuncionarioTable = document.querySelector('#tabelaFuncionarios tbody');

        FuncionarioTable.innerHTML = '';

        funcionarios.forEach(funcionario => {
            qtd_funcionarios = qtd_funcionarios + 1;
            FuncionarioTable.innerHTML += `
                <tr>
                    <td>${funcionario.Cod_func}</td>
                    <td>${funcionario.nome}</td>
                    <td>${funcionario.cargo}</td>
                    <td>${funcionario.salario}</td>
                    <td>${funcionario.data_nascimento}</td>
                </tr>
            `;
        });
    } catch (erro) {
        console.error('Erro ao buscar funcionários: ', erro);
    }
}

async function cadastrarFuncionario() {
    const nome = document.getElementById("funcNome").value;
    const cargo = document.getElementById("funcCargo").value;
    const salario = parseFloat(document.getElementById("funcSalario").value);
    const data_nascimento = document.getElementById("funcDataNasc").value;

    const novo_funcionario = {
        nome: nome,
        cargo: cargo,
        salario: salario,
        data_nascimento: data_nascimento
    };

    try {
        const response = await fetch(API_URL_FUNCIONARIOS, {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(novo_funcionario)
        });

        const result = await response.json();
        console.log("Sucesso: ", result);
    } catch (error) {
        console.log("Erro: " + error);
    }
    await carregarFuncionarios();
}