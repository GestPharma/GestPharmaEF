using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestPharmaEF.DAL.Migrations
{
    public partial class V1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false, comment: "TRIAL"),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleEntity", x => x.Id)
                        .Annotation("SqlServer:Clustered", true);
                },
                comment: "TRIAL");

            migrationBuilder.CreateTable(
                name: "medecins",
                columns: table => new
                {
                    id_medecin = table.Column<long>(type: "bigint", nullable: false, comment: "TRIAL")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nom = table.Column<string>(type: "nvarchar(256)", nullable: false, comment: "TRIAL"),
                    inami = table.Column<string>(type: "nvarchar(256)", nullable: false, comment: "TRIAL"),
                    rue = table.Column<string>(type: "nvarchar(256)", nullable: false, comment: "TRIAL"),
                    telephone = table.Column<string>(type: "nvarchar(256)", nullable: false, comment: "TRIAL"),
                    gsm = table.Column<string>(type: "nvarchar(256)", nullable: false, comment: "TRIAL"),
                    fax = table.Column<string>(type: "nvarchar(256)", nullable: false, comment: "TRIAL"),
                    email = table.Column<string>(type: "nvarchar(256)", nullable: false, comment: "TRIAL"),
                    ville = table.Column<string>(type: "nvarchar(256)", nullable: false, comment: "TRIAL")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedecinEntity", x => x.id_medecin)
                        .Annotation("SqlServer:Clustered", true);
                },
                comment: "TRIAL");

            migrationBuilder.CreateTable(
                name: "medicaments",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false, comment: "TRIAL")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nom = table.Column<string>(type: "nvarchar(256)", nullable: false, comment: "TRIAL")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicamentEntity", x => x.id)
                        .Annotation("SqlServer:Clustered", true);
                },
                comment: "TRIAL");

            migrationBuilder.CreateTable(
                name: "pharmacies",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false, comment: "TRIAL")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    url = table.Column<string>(type: "nvarchar(256)", nullable: false, comment: "TRIAL"),
                    nom = table.Column<string>(type: "nvarchar(256)", nullable: false, comment: "TRIAL"),
                    titulaires = table.Column<string>(type: "nvarchar(256)", nullable: false, comment: "TRIAL"),
                    rue = table.Column<string>(type: "nvarchar(256)", nullable: false, comment: "TRIAL"),
                    villes = table.Column<string>(type: "nvarchar(256)", nullable: false, comment: "TRIAL"),
                    departement = table.Column<string>(type: "nvarchar(256)", nullable: false, comment: "TRIAL"),
                    region = table.Column<string>(type: "nvarchar(256)", nullable: false, comment: "TRIAL")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PharmacyEntity", x => x.id)
                        .Annotation("SqlServer:Clustered", true);
                },
                comment: "TRIAL");

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<long>(type: "bigint", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false, comment: "TRIAL"),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "Bit", nullable: false, comment: "TRIAL"),
                    currentroleid = table.Column<long>(type: "bigint", nullable: true, comment: "TRIAL"),
                    connectAs = table.Column<string>(type: "nvarchar(256)", nullable: false, comment: "TRIAL"),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonneEntity", x => x.Id)
                        .Annotation("SqlServer:Clustered", true);
                    table.ForeignKey(
                        name: "FK_Personne_Role_RoleId",
                        column: x => x.currentroleid,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id");
                },
                comment: "TRIAL");

            migrationBuilder.CreateTable(
                name: "armoires",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false, comment: "TRIAL")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nom = table.Column<string>(type: "nvarchar(256)", nullable: false, comment: "TRIAL"),
                    patientid = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArmoireEntity", x => x.id)
                        .Annotation("SqlServer:Clustered", true);
                    table.ForeignKey(
                        name: "FK_ArmoiresEntity_PersonnesEntity",
                        column: x => x.patientid,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "TRIAL");

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    RoleId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ordonnances",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    codebarre = table.Column<string>(type: "nvarchar(256)", nullable: false, comment: "TRIAL"),
                    datecree = table.Column<DateTime>(type: "date", nullable: false, comment: "TRIAL"),
                    dateexpire = table.Column<DateTime>(type: "date", nullable: false, comment: "TRIAL"),
                    medecinid = table.Column<long>(type: "bigint", nullable: false, comment: "TRIAL"),
                    pharmacieid = table.Column<long>(type: "bigint", nullable: false, comment: "TRIAL"),
                    patientid = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrdonnanceEntity", x => x.Id)
                        .Annotation("SqlServer:Clustered", true);
                    table.ForeignKey(
                        name: "FK_OrdonnanceEntity_MedecinEntity",
                        column: x => x.medecinid,
                        principalTable: "medecins",
                        principalColumn: "id_medecin",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrdonnanceEntity_PersonnesEntity",
                        column: x => x.patientid,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrdonnanceEntity_PharmacyEntity",
                        column: x => x.pharmacieid,
                        principalTable: "pharmacies",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "TRIAL");

            migrationBuilder.CreateTable(
                name: "armoires-stock",
                columns: table => new
                {
                    mediid = table.Column<long>(type: "bigint", nullable: false, comment: "TRIAL"),
                    medicamentid = table.Column<string>(type: "nvarchar(256)", nullable: false, comment: "TRIAL"),
                    armoireid = table.Column<long>(type: "bigint", nullable: false, comment: "TRIAL"),
                    ordonnanceid = table.Column<long>(type: "bigint", nullable: false, comment: "TRIAL"),
                    quantite = table.Column<long>(type: "bigint", nullable: false, comment: "TRIAL")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArmoiresStockEntity", x => x.mediid)
                        .Annotation("SqlServer:Clustered", true);
                    table.ForeignKey(
                        name: "FK_ArmoiresStockEntity_ArmoiresEntity",
                        column: x => x.armoireid,
                        principalTable: "armoires",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_ArmoiresStockEntity_OrdonnanceEntity",
                        column: x => x.ordonnanceid,
                        principalTable: "ordonnances",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MedicamentEntity_ArmoiresStockEntity",
                        column: x => x.mediid,
                        principalTable: "medicaments",
                        principalColumn: "id");
                },
                comment: "TRIAL");

            migrationBuilder.CreateTable(
                name: "medicaments-prescrits",
                columns: table => new
                {
                    ordonnanceid = table.Column<long>(type: "bigint", nullable: false, comment: "TRIAL"),
                    medicamentid = table.Column<long>(type: "bigint", nullable: false, comment: "TRIAL"),
                    quantite = table.Column<long>(type: "bigint", nullable: false, comment: "TRIAL"),
                    prise = table.Column<long>(type: "bigint", nullable: false, comment: "TRIAL")
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_MedicamentsPrescritEntity_MedicamentEntity",
                        column: x => x.medicamentid,
                        principalTable: "medicaments",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MedicamentsPrescritEntity_OrdonnanceEntity",
                        column: x => x.ordonnanceid,
                        principalTable: "ordonnances",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "TRIAL");

            migrationBuilder.CreateIndex(
                name: "IX_armoires_patientid",
                table: "armoires",
                column: "patientid");

            migrationBuilder.CreateIndex(
                name: "IX_armoires-stock_armoireid",
                table: "armoires-stock",
                column: "armoireid");

            migrationBuilder.CreateIndex(
                name: "IX_armoires-stock_ordonnanceid",
                table: "armoires-stock",
                column: "ordonnanceid");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoles_Name",
                table: "AspNetRoles",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_currentroleid",
                table: "AspNetUsers",
                column: "currentroleid");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_email",
                table: "AspNetUsers",
                column: "email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_medicaments-prescrits_medicamentid",
                table: "medicaments-prescrits",
                column: "medicamentid");

            migrationBuilder.CreateIndex(
                name: "IX_medicaments-prescrits_ordonnanceid",
                table: "medicaments-prescrits",
                column: "ordonnanceid");

            migrationBuilder.CreateIndex(
                name: "IX_ordonnances_medecinid",
                table: "ordonnances",
                column: "medecinid");

            migrationBuilder.CreateIndex(
                name: "IX_ordonnances_patientid",
                table: "ordonnances",
                column: "patientid");

            migrationBuilder.CreateIndex(
                name: "IX_ordonnances_pharmacieid",
                table: "ordonnances",
                column: "pharmacieid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "armoires-stock");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "medicaments-prescrits");

            migrationBuilder.DropTable(
                name: "armoires");

            migrationBuilder.DropTable(
                name: "medicaments");

            migrationBuilder.DropTable(
                name: "ordonnances");

            migrationBuilder.DropTable(
                name: "medecins");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "pharmacies");

            migrationBuilder.DropTable(
                name: "AspNetRoles");
        }
    }
}
