const API_URL_PRODUTOS = 'https://localhost:7281/api/Produtos';

var qtd_produtos = 0
async function carregarProdutos() {
    try {
        const response = await fetch(API_URL_PRODUTOS)
        const produtos = await response.json();

        const produtosTable = document.querySelector('#tabelaProdutos tbody')

        produtosTable.innerHTML = '';

        produtos.forEach(produto => {
            qtd_produtos = qtd_produtos + 1
            produtosTable.innerHTML += `
                <tr>
                    <td>${produto.Cod_produto}</td>
                    <td>${produto.name}</td>
                    <td>${produto.descricao}</td>
                    <td>${produto.preco}</td>
                    <td>${produto.qtd_estoque}</td>
                </tr>
            `
        });
    } catch (erro) {
        console.error('Erro ao buscar produtos: ', erro)
    }
}

async function cadastrarProdutos() {
    const nome = document.getElementById("produtoNome").value;
    const descricao = document.getElementById("produtoDescricao").value;
    const preco = parseFloat(document.getElementById("produtoPreco").value);
    const qtd_estoque = parseInt(document.getElementById("produtoEstoque").value);

    const novo_produto = {
        name: nome,
        descricao: descricao,
        preco: preco,
        qtd_estoque: qtd_estoque
    }
    try {
        const response = await fetch(API_URL_PRODUTOS, {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(novo_produto)
        })

        const result = await response.json();
        console.log("Sucesso: ", result)
    } catch (error) {
        console.log("Erro: " + error)
    }
    await carregarProdutos()
}