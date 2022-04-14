using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Diploma.Migrations
{
    public partial class initmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ExtremistOrgs",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExtremistOrgs", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Genders",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Nationalities",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nationalities", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Profiles",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Image = table.Column<string>(nullable: true),
                    Login = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    Firstname = table.Column<string>(nullable: true),
                    Surname = table.Column<string>(nullable: true),
                    Secondname = table.Column<string>(nullable: true),
                    Rank = table.Column<string>(nullable: true),
                    Position = table.Column<string>(nullable: true),
                    PrivateNumber = table.Column<string>(nullable: false),
                    UserSID = table.Column<string>(nullable: true),
                    Blocked = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Profiles", x => x.ID);
                    table.UniqueConstraint("AK_Profiles_PrivateNumber", x => x.PrivateNumber);
                });

            migrationBuilder.CreateTable(
                name: "Cases",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Photo = table.Column<string>(nullable: true),
                    IsWanted = table.Column<bool>(nullable: true),
                    CaseNumber = table.Column<int>(nullable: false),
                    Fullname = table.Column<string>(nullable: true),
                    Firstname = table.Column<string>(nullable: true),
                    Surname = table.Column<string>(nullable: true),
                    Secondname = table.Column<string>(nullable: true),
                    Nickname = table.Column<string>(nullable: true),
                    DateBirth = table.Column<string>(nullable: true),
                    PlaceBirth = table.Column<string>(nullable: true),
                    Citizenship = table.Column<string>(nullable: true),
                    Height = table.Column<string>(nullable: true),
                    Conviction = table.Column<string>(nullable: true),
                    OCGMember = table.Column<string>(nullable: true),
                    LivingPlace = table.Column<string>(nullable: true),
                    FamilyComposition = table.Column<string>(nullable: true),
                    HumanForm = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Contacts = table.Column<string>(nullable: true),
                    SocialNetwork = table.Column<string>(nullable: true),
                    Note = table.Column<string>(nullable: true),
                    PublishedDate = table.Column<string>(nullable: true),
                    ProfileID = table.Column<int>(nullable: false),
                    ExtremistOrgID = table.Column<int>(nullable: false),
                    GenderID = table.Column<int>(nullable: false),
                    NationalityID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cases", x => x.ID);
                    table.UniqueConstraint("AK_Cases_CaseNumber", x => x.CaseNumber);
                    table.ForeignKey(
                        name: "FK_Cases_ExtremistOrgs_ExtremistOrgID",
                        column: x => x.ExtremistOrgID,
                        principalTable: "ExtremistOrgs",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Cases_Genders_GenderID",
                        column: x => x.GenderID,
                        principalTable: "Genders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Cases_Nationalities_NationalityID",
                        column: x => x.NationalityID,
                        principalTable: "Nationalities",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Cases_Profiles_ProfileID",
                        column: x => x.ProfileID,
                        principalTable: "Profiles",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cases_ExtremistOrgID",
                table: "Cases",
                column: "ExtremistOrgID");

            migrationBuilder.CreateIndex(
                name: "IX_Cases_GenderID",
                table: "Cases",
                column: "GenderID");

            migrationBuilder.CreateIndex(
                name: "IX_Cases_NationalityID",
                table: "Cases",
                column: "NationalityID");

            migrationBuilder.CreateIndex(
                name: "IX_Cases_ProfileID",
                table: "Cases",
                column: "ProfileID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cases");

            migrationBuilder.DropTable(
                name: "ExtremistOrgs");

            migrationBuilder.DropTable(
                name: "Genders");

            migrationBuilder.DropTable(
                name: "Nationalities");

            migrationBuilder.DropTable(
                name: "Profiles");
        }
    }
}
