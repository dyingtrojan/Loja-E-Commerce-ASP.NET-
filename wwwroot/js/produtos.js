const API_URL_PRODUTOS = 'https://localhost:7281/api/Produtos';


function mostrarAba(idAba) {
    document.querySelectorAll('.aba').forEach(sec => sec.style.display = 'none');
    document.getElementById(idAba).style.display = 'block';
}


async function carregarProdutos() {
    try {
        const response = await fetch(`${API_URL_PRODUTOS}`);
        const produtos = await response.json();
        
        const tbody = document.querySelector('#tabelaProdutos tbody');
        tbody.innerHTML = '';
        
        produtos.forEach(p => {
            tbody.innerHTML += `
                <tr>
                    <td>${p.id}</td>
                    <td>${p.nome}</td>
                    <td>R$ ${p.preco.toFixed(2)}</td>
                    <td>${p.quantidadeEstoque}</td>
                </tr>
            `;
        });
    } catch (erro) {
        console.error('Erro ao buscar produtos:', erro);
    }
}

document.getElementById('formProduto').addEventListener('submit', async (e) => {
    e.preventDefault();
    
    const novoProduto = {
        nome: document.getElementById('prodNome').value,
        descricao: document.getElementById('prodDesc').value,
        preco: parseFloat(document.getElementById('prodPreco').value),
        quantidadeEstoque: parseInt(document.getElementById('prodQtd').value)
    };

    await fetch(`${API_URL_PRODUTOS}`, {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify(novoProduto)
    });

    alert('Produto cadastrado com sucesso!');
    carregarProdutos();
});

carregarProdutos();