const API_URL_COMPRAS = 'https://localhost:7281/api/Compras';

var qtd_compras = 0;
async function carregarCompras() {
    try {
        const response = await fetch(API_URL_COMPRAS);
        const compras = await response.json();

        const CompraTable = document.querySelector('#tabelaCompras tbody');

        CompraTable.innerHTML = '';

        compras.forEach(compra => {
            qtd_compras = qtd_compras + 1;
            CompraTable.innerHTML += `
                <tr>
                    <td>${compra.Cod_compra}</td>
                    <td>${compra.valor_total}</td>
                    <td>${compra.data_compra}</td>
                </tr>
            `;
        });
    } catch (erro) {
        console.error('Erro ao buscar compras: ', erro);
    }
}

async function cadastrarCompra() {
    const valor_total = parseFloat(document.getElementById("compValorTotal").value);
    const data_compra = document.getElementById("compDataCompra").value;

    const nova_compra = {
        valor_total: valor_total,
        data_compra: data_compra
    };

    try {
        const response = await fetch(API_URL_COMPRAS, {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(nova_compra)
        });

        const result = await response.json();
        console.log("Sucesso: ", result);
    } catch (error) {
        console.log("Erro: " + error);
    }
    await carregarCompras();
}