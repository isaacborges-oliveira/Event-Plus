using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Event_plus.Migrations
{
    /// <inheritdoc />
    public partial class EventsPlus : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Instituicao",
                columns: table => new
                {
                    InstituicaoID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    InstituicaoName = table.Column<string>(type: "Varchar(40)", nullable: false),
                    CNPJ = table.Column<string>(type: "CHAR(14)", maxLength: 14, nullable: false),
                    Fantasia = table.Column<string>(type: "Varchar(50)", nullable: false),
                    endereco = table.Column<string>(type: "Varchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Instituicao", x => x.InstituicaoID);
                });

            migrationBuilder.CreateTable(
                name: "TipoEvento",
                columns: table => new
                {
                    TipoEventoID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TipoEventoName = table.Column<string>(type: "Varchar(30)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoEvento", x => x.TipoEventoID);
                });

            migrationBuilder.CreateTable(
                name: "TipoUsuario",
                columns: table => new
                {
                    TipoUsuarioID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TipoUsuarioName = table.Column<string>(type: "Varchar(30)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoUsuario", x => x.TipoUsuarioID);
                });

            migrationBuilder.CreateTable(
                name: "Eventos",
                columns: table => new
                {
                    EventoID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Evento = table.Column<string>(type: "VARCHAR(100)", nullable: false),
                    DataEvento = table.Column<DateTime>(type: "DATE", nullable: false),
                    Descricao = table.Column<string>(type: "TEXT", nullable: false),
                    TipoEventoID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    InstituicaoID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Eventos", x => x.EventoID);
                    table.ForeignKey(
                        name: "FK_Eventos_Instituicao_InstituicaoID",
                        column: x => x.InstituicaoID,
                        principalTable: "Instituicao",
                        principalColumn: "InstituicaoID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Eventos_TipoEvento_TipoEventoID",
                        column: x => x.TipoEventoID,
                        principalTable: "TipoEvento",
                        principalColumn: "TipoEventoID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    UsuarioID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TiposUsuarioID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TipoUsuarioID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Nome = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    Email = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    Senha = table.Column<string>(type: "VARCHAR(60)", maxLength: 60, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.UsuarioID);
                    table.ForeignKey(
                        name: "FK_Usuario_TipoUsuario_TipoUsuarioID",
                        column: x => x.TipoUsuarioID,
                        principalTable: "TipoUsuario",
                        principalColumn: "TipoUsuarioID");
                });

            migrationBuilder.CreateTable(
                name: "ComentarioEvento",
                columns: table => new
                {
                    ComentarioID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UsuarioID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    EventoID = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComentarioEvento", x => x.ComentarioID);
                    table.ForeignKey(
                        name: "FK_ComentarioEvento_Eventos_EventoID",
                        column: x => x.EventoID,
                        principalTable: "Eventos",
                        principalColumn: "EventoID");
                    table.ForeignKey(
                        name: "FK_ComentarioEvento_Usuario_UsuarioID",
                        column: x => x.UsuarioID,
                        principalTable: "Usuario",
                        principalColumn: "UsuarioID");
                });

            migrationBuilder.CreateTable(
                name: "Presenca",
                columns: table => new
                {
                    PresencaID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Situcao = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UsuarioID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EventoID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Presenca", x => x.PresencaID);
                    table.ForeignKey(
                        name: "FK_Presenca_Eventos_EventoID",
                        column: x => x.EventoID,
                        principalTable: "Eventos",
                        principalColumn: "EventoID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Presenca_Usuario_UsuarioID",
                        column: x => x.UsuarioID,
                        principalTable: "Usuario",
                        principalColumn: "UsuarioID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ComentarioEvento_EventoID",
                table: "ComentarioEvento",
                column: "EventoID");

            migrationBuilder.CreateIndex(
                name: "IX_ComentarioEvento_UsuarioID",
                table: "ComentarioEvento",
                column: "UsuarioID");

            migrationBuilder.CreateIndex(
                name: "IX_Eventos_InstituicaoID",
                table: "Eventos",
                column: "InstituicaoID");

            migrationBuilder.CreateIndex(
                name: "IX_Eventos_TipoEventoID",
                table: "Eventos",
                column: "TipoEventoID");

            migrationBuilder.CreateIndex(
                name: "IX_Instituicao_CNPJ",
                table: "Instituicao",
                column: "CNPJ",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Presenca_EventoID",
                table: "Presenca",
                column: "EventoID");

            migrationBuilder.CreateIndex(
                name: "IX_Presenca_UsuarioID",
                table: "Presenca",
                column: "UsuarioID");

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_Email",
                table: "Usuario",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_TipoUsuarioID",
                table: "Usuario",
                column: "TipoUsuarioID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ComentarioEvento");

            migrationBuilder.DropTable(
                name: "Presenca");

            migrationBuilder.DropTable(
                name: "Eventos");

            migrationBuilder.DropTable(
                name: "Usuario");

            migrationBuilder.DropTable(
                name: "Instituicao");

            migrationBuilder.DropTable(
                name: "TipoEvento");

            migrationBuilder.DropTable(
                name: "TipoUsuario");
        }
    }
}
