const API_URL_CLIENTES = 'https://localhost:7281/api/Clientes';

function mostrarAba(idAba) {
    document.querySelectorAll('.aba').forEach(sec => sec.style.display = 'none');
    document.getElementById(idAba).style.display = 'block';
}

async function carregarClientes() {
    try {
        const response = await fetch(`${API_URL_CLIENTES}`);
        const Clientes = await response.json();
        
        const tbody = document.querySelector('#tabelaClientes tbody');
        tbody.innerHTML = '';
        
        Clientes.forEach(p => {
            tbody.innerHTML += `
                <tr>
                    <td>${p.id}</td>
                    <td>${p.nome}</td>
                    <td>${p.endereco}</td>
                    <td>${p.telefone}</td>
                    <td>${p.email}</td>
                </tr>
            `;
        });
    } catch (erro) {
        console.error('Erro ao buscar Clientes:', erro);
    }
}


document.getElementById('formCliente').addEventListener('submit', async (e) => {
    e.preventDefault();
    
    const novoCliente = {
        nome: document.getElementById('cliNome').value,
        endereco: document.getElementById('cliEndereco').value,
        telefone: document.getElementById('cliTelefone').value,
        email: document.getElementById('cliEmail').value,     
    };

    await fetch(`${API_URL_CLIENTES}`, {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify(novoCliente)
    });

    alert('Cliente cadastrado com sucesso!');
    carregarClientes();
});
carregarClientes();