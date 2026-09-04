const API_URL_CLIENTES = 'https://localhost:7281/api/Clientes';

var qtd_clientes = 0
async function carregarClientes() {
    try {
        const response = await fetch(API_URL_CLIENTES)
        const clientes = await response.json();

        const ClienteTable = document.querySelector('#tabelaClientes tbody')

        ClienteTable.innerHTML = '';

        clientes.forEach(cliente => {
            qtd_clientes = qtd_clientes + 1
            ClienteTable.innerHTML += `
                <tr>
                    <td>${cliente.Cod_cliente}</td>
                    <td>${cliente.nome}</td>
                    <td>${cliente.rua}</td>
                    <td>${cliente.num_casa}</td>
                    <td>${cliente.bairro}</td>
                </tr>
            `
        });
    } catch (erro) {
        console.error('Erro ao buscar clientes: ', erro)
    }
}

async function cadastrarCliente() {
    const nome = document.getElementById("cliNome").value;
    const rua = document.getElementById("cliRua").value;
    const num_casa = parseInt(document.getElementById("cliNumCasa").value);
    const bairro = document.getElementById("cliBairro").value;

    const novo_cliente = {
        nome: nome,
        rua: rua,
        num_casa: num_casa,
        bairro: bairro
    }
    try {
        const response = await fetch(API_URL_CLIENTES, {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(novo_cliente)
        })

        const result = await response.json();
        console.log("Sucesso: ", result)
    } catch (error) {
        console.log("Erro: " + error)
    }
    await carregarClientes()
}