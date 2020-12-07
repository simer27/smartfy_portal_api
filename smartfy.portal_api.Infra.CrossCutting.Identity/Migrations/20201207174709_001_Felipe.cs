using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace smartfy.portal_api.Infra.CrossCutting.Identity.Migrations
{
    public partial class _001_Felipe : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Files");

            migrationBuilder.DropTable(
                name: "Regions");

            migrationBuilder.DropTable(
                name: "Cameras");

            migrationBuilder.DropTable(
                name: "Disks");

            migrationBuilder.DropTable(
                name: "Teams");

            migrationBuilder.DropTable(
                name: "Dockstations");

            migrationBuilder.DropTable(
                name: "Areas");

            migrationBuilder.DropTable(
                name: "Partners");

            migrationBuilder.AddColumn<DateTime>(
                name: "DtVencimento",
                table: "Produto",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DtVencimento",
                table: "Produto");

            migrationBuilder.CreateTable(
                name: "Areas",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    Excluded = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Areas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Partners",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Contact = table.Column<string>(nullable: true),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    Email = table.Column<string>(nullable: true),
                    Excluded = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Partners", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Regions",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Code = table.Column<string>(nullable: true),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    Excluded = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Regions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Dockstations",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Code = table.Column<string>(nullable: true),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    DtActivation = table.Column<DateTime>(nullable: false),
                    DtLastCopy = table.Column<DateTime>(nullable: false),
                    DtLastSeen = table.Column<DateTime>(nullable: false),
                    Excluded = table.Column<bool>(nullable: false),
                    LastTotalLength = table.Column<long>(nullable: false),
                    LastUsageLength = table.Column<long>(nullable: false),
                    PartnerId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dockstations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Dockstations_Partners_PartnerId",
                        column: x => x.PartnerId,
                        principalTable: "Partners",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Teams",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    AreaId = table.Column<Guid>(nullable: false),
                    Code = table.Column<string>(nullable: true),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    DtActivation = table.Column<DateTime>(nullable: false),
                    DtLastCopy = table.Column<DateTime>(nullable: false),
                    DtLastSeen = table.Column<DateTime>(nullable: false),
                    Excluded = table.Column<bool>(nullable: false),
                    PartnerId = table.Column<Guid>(nullable: false),
                    Plate = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teams", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Teams_Areas_AreaId",
                        column: x => x.AreaId,
                        principalTable: "Areas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Teams_Partners_PartnerId",
                        column: x => x.PartnerId,
                        principalTable: "Partners",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Disks",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    DockstationId = table.Column<Guid>(nullable: false),
                    DtLastCopy = table.Column<DateTime>(nullable: false),
                    Excluded = table.Column<bool>(nullable: false),
                    LengthGB = table.Column<long>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Disks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Disks_Dockstations_DockstationId",
                        column: x => x.DockstationId,
                        principalTable: "Dockstations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cameras",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Code = table.Column<string>(nullable: true),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    DtActivation = table.Column<DateTime>(nullable: false),
                    DtLastCopy = table.Column<DateTime>(nullable: false),
                    DtLastSeen = table.Column<DateTime>(nullable: false),
                    Excluded = table.Column<bool>(nullable: false),
                    InOperation = table.Column<bool>(nullable: false),
                    LastTotalLength = table.Column<long>(nullable: false),
                    LastUsageLength = table.Column<long>(nullable: false),
                    Manufacturer = table.Column<string>(nullable: true),
                    Model = table.Column<string>(nullable: true),
                    TeamId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cameras", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cameras_Teams_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Files",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CameraId = table.Column<Guid>(nullable: false),
                    Checksum = table.Column<string>(nullable: true),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    DirectoryName = table.Column<string>(nullable: true),
                    DiskId = table.Column<Guid>(nullable: false),
                    DtCopy = table.Column<DateTime>(nullable: false),
                    Excluded = table.Column<bool>(nullable: false),
                    Extension = table.Column<string>(nullable: true),
                    FullPath = table.Column<string>(nullable: true),
                    HashCode = table.Column<int>(nullable: false),
                    LastAccessTime = table.Column<DateTime>(nullable: false),
                    LastWriteTime = table.Column<DateTime>(nullable: false),
                    Length = table.Column<long>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Files", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Files_Cameras_CameraId",
                        column: x => x.CameraId,
                        principalTable: "Cameras",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Files_Disks_DiskId",
                        column: x => x.DiskId,
                        principalTable: "Disks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cameras_TeamId",
                table: "Cameras",
                column: "TeamId");

            migrationBuilder.CreateIndex(
                name: "IX_Disks_DockstationId",
                table: "Disks",
                column: "DockstationId");

            migrationBuilder.CreateIndex(
                name: "IX_Dockstations_PartnerId",
                table: "Dockstations",
                column: "PartnerId");

            migrationBuilder.CreateIndex(
                name: "IX_Files_CameraId",
                table: "Files",
                column: "CameraId");

            migrationBuilder.CreateIndex(
                name: "IX_Files_DiskId",
                table: "Files",
                column: "DiskId");

            migrationBuilder.CreateIndex(
                name: "IX_Teams_AreaId",
                table: "Teams",
                column: "AreaId");

            migrationBuilder.CreateIndex(
                name: "IX_Teams_PartnerId",
                table: "Teams",
                column: "PartnerId");
        }
    }
}
