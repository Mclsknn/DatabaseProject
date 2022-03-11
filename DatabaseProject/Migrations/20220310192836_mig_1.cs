using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DatabaseProject.Migrations
{
    public partial class mig_1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CarDetails",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CarType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CarModel = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarDetails", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CountryName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "TyreDetails",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TyreType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExpirationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CarID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TyreDetails", x => x.ID);
                    table.ForeignKey(
                        name: "FK_TyreDetails_CarDetails_CarID",
                        column: x => x.CarID,
                        principalTable: "CarDetails",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CityName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CountryID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Cities_Countries_CountryID",
                        column: x => x.CountryID,
                        principalTable: "Countries",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "DeliveryDetails",
                columns: table => new
                {
                    DeliveryID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DeliveryStartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeliveryEndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AddressDetail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CarDetailID = table.Column<int>(type: "int", nullable: true),
                    CityDepartureId = table.Column<int>(type: "int", nullable: true),
                    CityDestinationId = table.Column<int>(type: "int", nullable: true),
                    CountryDepartureId = table.Column<int>(type: "int", nullable: true),
                    CountryDestinationId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeliveryDetails", x => x.DeliveryID);
                    table.ForeignKey(
                        name: "FK_DeliveryDetails_CarDetails_CarDetailID",
                        column: x => x.CarDetailID,
                        principalTable: "CarDetails",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DeliveryDetails_Cities_CityDepartureId",
                        column: x => x.CityDepartureId,
                        principalTable: "Cities",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DeliveryDetails_Cities_CityDestinationId",
                        column: x => x.CityDestinationId,
                        principalTable: "Cities",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DeliveryDetails_Countries_CountryDepartureId",
                        column: x => x.CountryDepartureId,
                        principalTable: "Countries",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DeliveryDetails_Countries_CountryDestinationId",
                        column: x => x.CountryDestinationId,
                        principalTable: "Countries",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Drivers",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DriverName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DriverLastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdentityNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DriverBirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeliveryDetailID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Drivers", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Drivers_DeliveryDetails_DeliveryDetailID",
                        column: x => x.DeliveryDetailID,
                        principalTable: "DeliveryDetails",
                        principalColumn: "DeliveryID",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "LoadDetails",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LoadType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LoadWidth = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    LoadHeight = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    LoadDepth = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DeliveryDetailID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoadDetails", x => x.ID);
                    table.ForeignKey(
                        name: "FK_LoadDetails_DeliveryDetails_DeliveryDetailID",
                        column: x => x.DeliveryDetailID,
                        principalTable: "DeliveryDetails",
                        principalColumn: "DeliveryID",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cities_CountryID",
                table: "Cities",
                column: "CountryID");

            migrationBuilder.CreateIndex(
                name: "IX_DeliveryDetails_CarDetailID",
                table: "DeliveryDetails",
                column: "CarDetailID",
                unique: true,
                filter: "[CarDetailID] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_DeliveryDetails_CityDepartureId",
                table: "DeliveryDetails",
                column: "CityDepartureId");

            migrationBuilder.CreateIndex(
                name: "IX_DeliveryDetails_CityDestinationId",
                table: "DeliveryDetails",
                column: "CityDestinationId");

            migrationBuilder.CreateIndex(
                name: "IX_DeliveryDetails_CountryDepartureId",
                table: "DeliveryDetails",
                column: "CountryDepartureId");

            migrationBuilder.CreateIndex(
                name: "IX_DeliveryDetails_CountryDestinationId",
                table: "DeliveryDetails",
                column: "CountryDestinationId");

            migrationBuilder.CreateIndex(
                name: "IX_Drivers_DeliveryDetailID",
                table: "Drivers",
                column: "DeliveryDetailID");

            migrationBuilder.CreateIndex(
                name: "IX_LoadDetails_DeliveryDetailID",
                table: "LoadDetails",
                column: "DeliveryDetailID");

            migrationBuilder.CreateIndex(
                name: "IX_TyreDetails_CarID",
                table: "TyreDetails",
                column: "CarID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Drivers");

            migrationBuilder.DropTable(
                name: "LoadDetails");

            migrationBuilder.DropTable(
                name: "TyreDetails");

            migrationBuilder.DropTable(
                name: "DeliveryDetails");

            migrationBuilder.DropTable(
                name: "CarDetails");

            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropTable(
                name: "Countries");
        }
    }
}
