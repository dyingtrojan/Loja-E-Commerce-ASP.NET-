using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Loja_e_commerce.Migrations
{
    /// <inheritdoc />
    public partial class CriarTabelaClientes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cliente",
                columns: table => new
                {
                    Cod_cliente = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    rua = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    num_casa = table.Column<int>(type: "int", nullable: false),
                    bairro = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.Cod_cliente);
                });

            migrationBuilder.CreateTable(
                name: "Estoque",
                columns: table => new
                {
                    Cod_Estoque = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cod_Funcionario = table.Column<int>(type: "int", nullable: false),
                    Cod_Produto = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estoque", x => x.Cod_Estoque);
                });

            migrationBuilder.CreateTable(
                name: "Funcionario",
                columns: table => new
                {
                    Cod_func = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    cargo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    salario = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Funcionario", x => x.Cod_func);
                });

            migrationBuilder.CreateTable(
                name: "Produto",
                columns: table => new
                {
                    Cod_Prod = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    descricao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    preco = table.Column<float>(type: "real", nullable: false),
                    qtd_estoque = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produto", x => x.Cod_Prod);
                });

            migrationBuilder.CreateTable(
                name: "Email",
                columns: table => new
                {
                    Cod_Email = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cod_cliente = table.Column<int>(type: "int", nullable: false),
                    str_Email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Email", x => x.Cod_Email);
                    table.ForeignKey(
                        name: "FK_Email_Cliente_Cod_cliente",
                        column: x => x.Cod_cliente,
                        principalTable: "Cliente",
                        principalColumn: "Cod_cliente",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Telefone",
                columns: table => new
                {
                    Cod_Telefone = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cod_cliente = table.Column<int>(type: "int", nullable: false),
                    str_Telefone = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Telefone", x => x.Cod_Telefone);
                    table.ForeignKey(
                        name: "FK_Telefone_Cliente_Cod_cliente",
                        column: x => x.Cod_cliente,
                        principalTable: "Cliente",
                        principalColumn: "Cod_cliente",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Compra",
                columns: table => new
                {
                    Cod_compra = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cod_Prod = table.Column<int>(type: "int", nullable: false),
                    valor_total = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Compra", x => x.Cod_compra);
                    table.ForeignKey(
                        name: "FK_Compra_Produto_Cod_Prod",
                        column: x => x.Cod_Prod,
                        principalTable: "Produto",
                        principalColumn: "Cod_Prod",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Compra_Cod_Prod",
                table: "Compra",
                column: "Cod_Prod");

            migrationBuilder.CreateIndex(
                name: "IX_Email_Cod_cliente",
                table: "Email",
                column: "Cod_cliente");

            migrationBuilder.CreateIndex(
                name: "IX_Telefone_Cod_cliente",
                table: "Telefone",
                column: "Cod_cliente");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Compra");

            migrationBuilder.DropTable(
                name: "Email");

            migrationBuilder.DropTable(
                name: "Estoque");

            migrationBuilder.DropTable(
                name: "Funcionario");

            migrationBuilder.DropTable(
                name: "Telefone");

            migrationBuilder.DropTable(
                name: "Produto");

            migrationBuilder.DropTable(
                name: "Cliente");
        }
    }
}
