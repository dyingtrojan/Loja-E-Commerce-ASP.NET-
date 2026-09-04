const API_URL_ESTOQUE = 'https://localhost:7281/api/Estoque';

var qtd_estoque = 0;
async function carregarEstoque() {
    try {
        const response = await fetch(API_URL_ESTOQUE);
        const estoques = await response.json();

        const EstoqueTable = document.querySelector('#tabelaEstoque tbody');

        EstoqueTable.innerHTML = '';

        estoques.forEach(estoque => {
            qtd_estoque = qtd_estoque + 1;
            EstoqueTable.innerHTML += `
                <tr>
                    <td>${estoque.Cod_Estoque}</td>
                    <td>${estoque.Cod_Funcionario}</td>
                    <td>${estoque.Cod_Produto}</td>
                </tr>
            `;
        });
    } catch (erro) {
        console.error('Erro ao buscar estoque: ', erro);
    }
}

async function cadastrarEstoque() {
    const cod_funcionario = parseInt(document.getElementById("estCodFuncionario").value);
    const cod_produto = parseInt(document.getElementById("estCodProduto").value);

    const novo_estoque = {
        Cod_Funcionario: cod_funcionario,
        Cod_Produto: cod_produto
    };

    try {
        const response = await fetch(API_URL_ESTOQUE, {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(novo_estoque)
        });

        const result = await response.json();
        console.log("Sucesso: ", result);
    } catch (error) {
        console.log("Erro: " + error);
    }
    await carregarEstoque();
}