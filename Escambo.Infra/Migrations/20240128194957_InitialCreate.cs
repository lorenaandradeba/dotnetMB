using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Escambo.Infra.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Conversa",
                columns: table => new
                {
                    ConversaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    DataHoraInicio = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    DataHoraFim = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Conversa", x => x.ConversaId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    UsuarioId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Email = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Senha = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CPF = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    RG = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Nascimento = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Endereço = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Credito = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    LinkLinkedln = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Sobre = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.UsuarioId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Anuncio",
                columns: table => new
                {
                    AnuncioId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    NomeServico = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Descricao = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Creditos = table.Column<decimal>(type: "decimal(65,30)", nullable: true),
                    Categoria = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Tipo = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    UsuarioId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Anuncio", x => x.AnuncioId);
                    table.ForeignKey(
                        name: "FK_Anuncio_Usuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuario",
                        principalColumn: "UsuarioId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ConversasHasUsuarios",
                columns: table => new
                {
                    ConversasIdMensagem = table.Column<int>(type: "int", nullable: false),
                    UsuariosIdUsuario = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConversasHasUsuarios", x => new { x.ConversasIdMensagem, x.UsuariosIdUsuario });
                    table.ForeignKey(
                        name: "FK_ConversasHasUsuarios_Conversa_ConversasIdMensagem",
                        column: x => x.ConversasIdMensagem,
                        principalTable: "Conversa",
                        principalColumn: "ConversaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ConversasHasUsuarios_Usuario_UsuariosIdUsuario",
                        column: x => x.UsuariosIdUsuario,
                        principalTable: "Usuario",
                        principalColumn: "UsuarioId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Mensagem",
                columns: table => new
                {
                    MensagemId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Texto = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DataEnvio = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    HoraEnvio = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    ConversaId = table.Column<int>(type: "int", nullable: false),
                    ConversasIdMensagem = table.Column<int>(type: "int", nullable: false),
                    UsuariosIdUsuario = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mensagem", x => x.MensagemId);
                    table.ForeignKey(
                        name: "FK_Mensagem_Conversa_ConversasIdMensagem",
                        column: x => x.ConversasIdMensagem,
                        principalTable: "Conversa",
                        principalColumn: "ConversaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Mensagem_Usuario_UsuariosIdUsuario",
                        column: x => x.UsuariosIdUsuario,
                        principalTable: "Usuario",
                        principalColumn: "UsuarioId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "PrestacaoServico",
                columns: table => new
                {
                    PrestacaoServicoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ServiçoId = table.Column<int>(type: "int", nullable: false),
                    Descrição = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Categoria = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Tipo = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Duração = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Data = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Credito = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    ContratanteId = table.Column<int>(type: "int", nullable: false),
                    PrestadorId = table.Column<int>(type: "int", nullable: false),
                    AnuncioIdAnuncio = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrestacaoServico", x => x.PrestacaoServicoId);
                    table.ForeignKey(
                        name: "FK_PrestacaoServico_Anuncio_AnuncioIdAnuncio",
                        column: x => x.AnuncioIdAnuncio,
                        principalTable: "Anuncio",
                        principalColumn: "AnuncioId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PrestacaoServico_Usuario_ContratanteId",
                        column: x => x.ContratanteId,
                        principalTable: "Usuario",
                        principalColumn: "UsuarioId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PrestacaoServico_Usuario_PrestadorId",
                        column: x => x.PrestadorId,
                        principalTable: "Usuario",
                        principalColumn: "UsuarioId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Avaliacao",
                columns: table => new
                {
                    AvaliacaoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Mensagem = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Estelas = table.Column<int>(type: "int", nullable: true),
                    PrestacaoServicoId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Avaliacao", x => x.AvaliacaoId);
                    table.ForeignKey(
                        name: "FK_Avaliacao_PrestacaoServico_PrestacaoServicoId",
                        column: x => x.PrestacaoServicoId,
                        principalTable: "PrestacaoServico",
                        principalColumn: "PrestacaoServicoId");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "PrestacaoServicoHasUsuarios",
                columns: table => new
                {
                    PrestacaoServicoIdPrestacaoServico = table.Column<int>(type: "int", nullable: false),
                    UsuariosIdUsuario = table.Column<int>(type: "int", nullable: false),
                    IsPrestador = table.Column<bool>(type: "tinyint(1)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrestacaoServicoHasUsuarios", x => new { x.PrestacaoServicoIdPrestacaoServico, x.UsuariosIdUsuario });
                    table.ForeignKey(
                        name: "FK_PrestacaoServicoHasUsuarios_PrestacaoServico_PrestacaoServic~",
                        column: x => x.PrestacaoServicoIdPrestacaoServico,
                        principalTable: "PrestacaoServico",
                        principalColumn: "PrestacaoServicoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PrestacaoServicoHasUsuarios_Usuario_UsuariosIdUsuario",
                        column: x => x.UsuariosIdUsuario,
                        principalTable: "Usuario",
                        principalColumn: "UsuarioId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "PrestacaoServicoHasAvaliacoes",
                columns: table => new
                {
                    PrestacaoServicoIdPrestacaoServico = table.Column<int>(type: "int", nullable: false),
                    AvaliacoesIdAvaliacoes = table.Column<int>(type: "int", nullable: false),
                    AvaliacoesAvaliacaoId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrestacaoServicoHasAvaliacoes", x => new { x.PrestacaoServicoIdPrestacaoServico, x.AvaliacoesIdAvaliacoes });
                    table.ForeignKey(
                        name: "FK_PrestacaoServicoHasAvaliacoes_Avaliacao_AvaliacoesAvaliacaoId",
                        column: x => x.AvaliacoesAvaliacaoId,
                        principalTable: "Avaliacao",
                        principalColumn: "AvaliacaoId");
                    table.ForeignKey(
                        name: "FK_PrestacaoServicoHasAvaliacoes_PrestacaoServico_PrestacaoServ~",
                        column: x => x.PrestacaoServicoIdPrestacaoServico,
                        principalTable: "PrestacaoServico",
                        principalColumn: "PrestacaoServicoId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Anuncio_UsuarioId",
                table: "Anuncio",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Avaliacao_PrestacaoServicoId",
                table: "Avaliacao",
                column: "PrestacaoServicoId");

            migrationBuilder.CreateIndex(
                name: "IX_ConversasHasUsuarios_UsuariosIdUsuario",
                table: "ConversasHasUsuarios",
                column: "UsuariosIdUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_Mensagem_ConversasIdMensagem",
                table: "Mensagem",
                column: "ConversasIdMensagem");

            migrationBuilder.CreateIndex(
                name: "IX_Mensagem_UsuariosIdUsuario",
                table: "Mensagem",
                column: "UsuariosIdUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_PrestacaoServico_AnuncioIdAnuncio",
                table: "PrestacaoServico",
                column: "AnuncioIdAnuncio");

            migrationBuilder.CreateIndex(
                name: "IX_PrestacaoServico_ContratanteId",
                table: "PrestacaoServico",
                column: "ContratanteId");

            migrationBuilder.CreateIndex(
                name: "IX_PrestacaoServico_PrestadorId",
                table: "PrestacaoServico",
                column: "PrestadorId");

            migrationBuilder.CreateIndex(
                name: "IX_PrestacaoServicoHasAvaliacoes_AvaliacoesAvaliacaoId",
                table: "PrestacaoServicoHasAvaliacoes",
                column: "AvaliacoesAvaliacaoId");

            migrationBuilder.CreateIndex(
                name: "IX_PrestacaoServicoHasUsuarios_UsuariosIdUsuario",
                table: "PrestacaoServicoHasUsuarios",
                column: "UsuariosIdUsuario");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ConversasHasUsuarios");

            migrationBuilder.DropTable(
                name: "Mensagem");

            migrationBuilder.DropTable(
                name: "PrestacaoServicoHasAvaliacoes");

            migrationBuilder.DropTable(
                name: "PrestacaoServicoHasUsuarios");

            migrationBuilder.DropTable(
                name: "Conversa");

            migrationBuilder.DropTable(
                name: "Avaliacao");

            migrationBuilder.DropTable(
                name: "PrestacaoServico");

            migrationBuilder.DropTable(
                name: "Anuncio");

            migrationBuilder.DropTable(
                name: "Usuario");
        }
    }
}
