using Microsoft.EntityFrameworkCore.Migrations;

namespace SensorDataChallenge.Migrations
{
    public partial class newDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UruguayLooseCargoTransit",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UruguayLooseCargoTransit", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UruguayTransit",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UruguayTransit", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Zone",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zone", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ClientUruguayLooseCargoTransit",
                columns: table => new
                {
                    ClientsId = table.Column<int>(type: "int", nullable: false),
                    UruguayLooseCargoTransitId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientUruguayLooseCargoTransit", x => new { x.ClientsId, x.UruguayLooseCargoTransitId });
                    table.ForeignKey(
                        name: "FK_ClientUruguayLooseCargoTransit_Client_ClientsId",
                        column: x => x.ClientsId,
                        principalTable: "Client",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClientUruguayLooseCargoTransit_UruguayLooseCargoTransit_UruguayLooseCargoTransitId",
                        column: x => x.UruguayLooseCargoTransitId,
                        principalTable: "UruguayLooseCargoTransit",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ClientUruguayTransit",
                columns: table => new
                {
                    ClientsId = table.Column<int>(type: "int", nullable: false),
                    UruguayTransitId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientUruguayTransit", x => new { x.ClientsId, x.UruguayTransitId });
                    table.ForeignKey(
                        name: "FK_ClientUruguayTransit_Client_ClientsId",
                        column: x => x.ClientsId,
                        principalTable: "Client",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClientUruguayTransit_UruguayTransit_UruguayTransitId",
                        column: x => x.UruguayTransitId,
                        principalTable: "UruguayTransit",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ClientZone",
                columns: table => new
                {
                    ClientsId = table.Column<int>(type: "int", nullable: false),
                    ZoneId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientZone", x => new { x.ClientsId, x.ZoneId });
                    table.ForeignKey(
                        name: "FK_ClientZone_Client_ClientsId",
                        column: x => x.ClientsId,
                        principalTable: "Client",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClientZone_Zone_ZoneId",
                        column: x => x.ZoneId,
                        principalTable: "Zone",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Client",
                columns: new[] { "Id", "Address", "BusinessName", "City", "Country", "Email", "Fax", "IsActive", "Phone", "PostalCode", "RucNum", "Web" },
                values: new object[,]
                {
                    { 1, "9 de Julio 1324", "Client1 SRL", "Rosario", "Argentina", "client1srl@client1srl.com", "2598741", true, "3145788845", 2000, 123456, "www.client1srl.com" },
                    { 2, "9 de Julio 1324", "Client2 SRL", "Rosario", "Argentina", "client2srl@client2srl.com", "2598741", true, "3145788845", 2000, 123456, "www.client2srl.com" },
                    { 3, "9 de Julio 1324", "Client3 SRL", "Rosario", "Argentina", "client3srl@client3srl.com", "2598741", true, "3145788845", 2000, 123456, "www.client3srl.com" },
                    { 4, "9 de Julio 1324", "Client4 SRL", "Rosario", "Argentina", "client4srl@client4srl.com", "2598741", true, "3145788845", 2000, 123456, "www.client4srl.com" },
                    { 5, "9 de Julio 1324", "Client5 SRL", "Rosario", "Argentina", "client5srl@client5srl.com", "2598741", true, "3145788845", 2000, 123456, "www.client5srl.com" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ClientUruguayLooseCargoTransit_UruguayLooseCargoTransitId",
                table: "ClientUruguayLooseCargoTransit",
                column: "UruguayLooseCargoTransitId");

            migrationBuilder.CreateIndex(
                name: "IX_ClientUruguayTransit_UruguayTransitId",
                table: "ClientUruguayTransit",
                column: "UruguayTransitId");

            migrationBuilder.CreateIndex(
                name: "IX_ClientZone_ZoneId",
                table: "ClientZone",
                column: "ZoneId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClientUruguayLooseCargoTransit");

            migrationBuilder.DropTable(
                name: "ClientUruguayTransit");

            migrationBuilder.DropTable(
                name: "ClientZone");

            migrationBuilder.DropTable(
                name: "UruguayLooseCargoTransit");

            migrationBuilder.DropTable(
                name: "UruguayTransit");

            migrationBuilder.DropTable(
                name: "Zone");

            migrationBuilder.DeleteData(
                table: "Client",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Client",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Client",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Client",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Client",
                keyColumn: "Id",
                keyValue: 5);
        }
    }
}
