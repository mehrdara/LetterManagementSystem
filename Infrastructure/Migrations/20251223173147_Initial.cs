using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    OrganizationMail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
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
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<int>(type: "int", nullable: false),
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
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
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
                    UserId = table.Column<int>(type: "int", nullable: false)
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
                    UserId = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false)
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
                    UserId = table.Column<int>(type: "int", nullable: false),
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
                name: "Letters",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LetterNumber = table.Column<long>(type: "bigint", nullable: false),
                    Subject = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Body = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    File = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LetterType = table.Column<byte>(type: "tinyint", nullable: false),
                    SenderId = table.Column<int>(type: "int", nullable: false),
                    ParentLetterId = table.Column<int>(type: "int", nullable: true),
                    CreatedUserId = table.Column<int>(type: "int", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedUserId = table.Column<int>(type: "int", nullable: true),
                    ModifiedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Letters", x => x.Id);
                    table.CheckConstraint("CK_Letter_Body_NotEmpty", "LEN(TRIM(Body)) > 0");
                    table.CheckConstraint("CK_Letter_Subject_NotEmpty", "LEN(TRIM(Subject)) > 0");
                    table.CheckConstraint("CK_Letter_Type", "[LetterType] IN (1, 2, 3)");
                    table.ForeignKey(
                        name: "FK_Letters_AspNetUsers_SenderId",
                        column: x => x.SenderId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Letters_Letters_ParentLetterId",
                        column: x => x.ParentLetterId,
                        principalTable: "Letters",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "LetterRecipient",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LetterId = table.Column<int>(type: "int", nullable: false),
                    RecipientId = table.Column<int>(type: "int", nullable: false),
                    ForwardedByUserId = table.Column<int>(type: "int", nullable: true),
                    IsRead = table.Column<bool>(type: "bit", nullable: false),
                    ReadAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedUserId = table.Column<int>(type: "int", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedUserId = table.Column<int>(type: "int", nullable: true),
                    ModifiedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LetterRecipient", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LetterRecipient_AspNetUsers_ForwardedByUserId",
                        column: x => x.ForwardedByUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LetterRecipient_AspNetUsers_RecipientId",
                        column: x => x.RecipientId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LetterRecipient_Letters_LetterId",
                        column: x => x.LetterId,
                        principalTable: "Letters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "OrganizationMail", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { 1, 0, "3c44eb86-3d41-4229-9696-6caa57fb504e", "mehrdara1@gmail.com", true, "Mehr", "Dara", false, null, "MEHRDARA1@GMAIL.COM", "MEHRDARA1", "mehrdara1@gmail.com", "AQAAAAIAAYagAAAAEIXjHQxfUO9jTjQa5LMDIPFYRnb0DAsiH2uaQdZFb8MBIG00z3t7Hm2X0mxjcClB1g==", null, false, "6b89e8eb-e0da-4c58-82c5-b88b65cbcde6", false, "mehrdara1" },
                    { 2, 0, "7282908d-eb50-426f-b86f-483a95a2dcb4", "mehrdara2@gmail.com", true, "Mehr", "Dara", false, null, "MEHRDARA2@GMAIL.COM", "MEHRDARA2", "mehrdara2@gmail.com", "AQAAAAIAAYagAAAAEKwZbQ41oxC48yb0us5WDAjgx7gjh5FiblK3ASYf+Xhh6CZ5Dfc2pH5rKgiykzAWrw==", null, false, "c1250ea2-9bdf-4102-883e-b6eaf2e2f161", false, "mehrdara2" },
                    { 3, 0, "f0a3a91b-b607-42e3-aadf-1fb4c2adac63", "mehrdara3@gmail.com", true, "Mehr", "Dara", false, null, "MEHRDARA3@GMAIL.COM", "MEHRDARA3", "mehrdara3@gmail.com", "AQAAAAIAAYagAAAAEPYaX5pdGR7+Q4CR1jv6vuQAV/sR2GWCiKbaVMlidAwE6cemSFoAMTdCXhWDS8b72Q==", null, false, "bb47fb7b-8ec0-42e8-99fc-17349c267954", false, "mehrdara3" },
                    { 4, 0, "4687a540-db49-45d0-985f-83f34afedfda", "mehrdara4@gmail.com", true, "Mehr", "Dara", false, null, "MEHRDARA4@GMAIL.COM", "MEHRDARA4", "mehrdara4@gmail.com", "AQAAAAIAAYagAAAAEEFZnh9AvjCN0kClnoVD4Hmk8YdRRFikfNHLrIIE1R/3TLseGI/USO5aN902/P2FMg==", null, false, "74075db2-fd62-4908-85b8-c90d1d5032df", false, "mehrdara4" },
                    { 5, 0, "d75a1866-f636-4409-a83f-f33121db0c6c", "mehrdara5@gmail.com", true, "Mehr", "Dara", false, null, "MEHRDARA5@GMAIL.COM", "MEHRDARA5", "mehrdara5@gmail.com", "AQAAAAIAAYagAAAAEOuutCneRmRdFkNHQxwn/jejqbwvHe/sZW7LrnKuPlEhI+tMPPbV8Xaq5wp87aBKjA==", null, false, "8a0566c4-cf4e-4c2a-bdfd-b8cb7b41c87b", false, "mehrdara5" },
                    { 6, 0, "fd855e00-ef0a-4dac-a03b-2fee653324a1", "mehrdara6@gmail.com", true, "Mehr", "Dara", false, null, "MEHRDARA6@GMAIL.COM", "MEHRDARA6", "mehrdara6@gmail.com", "AQAAAAIAAYagAAAAEHAIoIE14iDluZpY1i7ev4pZbeclTSq+03m1Z6d6L+QHy6Url/+2Li8LLY0s/6h2dg==", null, false, "7e23a298-31a1-4d43-93d0-2d777993fbfc", false, "mehrdara6" },
                    { 7, 0, "e60dcda6-19cf-4031-bca8-660a1a1918bd", "mehrdara7@gmail.com", true, "Mehr", "Dara", false, null, "MEHRDARA7@GMAIL.COM", "MEHRDARA7", "mehrdara7@gmail.com", "AQAAAAIAAYagAAAAEJuVQHb5nn63kFfcYUMs7wB8yTBEjMpAPktHZwhTkV4Pnlf0hKwImEHq7pzC2oGq7w==", null, false, "4c74704f-f9b0-4de5-aa06-03076b60e6dd", false, "mehrdara7" },
                    { 8, 0, "49ec161e-4c9d-48fe-bdf0-3a3d8cf96928", "mehrdara8@gmail.com", true, "Mehr", "Dara", false, null, "MEHRDARA8@GMAIL.COM", "MEHRDARA8", "mehrdara8@gmail.com", "AQAAAAIAAYagAAAAEC1kdYcv0o/tG4Ok1fpG8Cy6dtnc9KPwjNq6sOurnep6OBDbGi8kVBU+61yD1NdmgQ==", null, false, "9dd64414-d786-4d48-87be-8bb3a7b8c57c", false, "mehrdara8" },
                    { 9, 0, "0a2920e9-547e-477e-8478-c329047c950c", "mehrdara9@gmail.com", true, "Mehr", "Dara", false, null, "MEHRDARA9@GMAIL.COM", "MEHRDARA9", "mehrdara9@gmail.com", "AQAAAAIAAYagAAAAEEXyr0lsKfoW3INlBuCarDIWW2c1DDxKhkRlnsptSkZ18eQjtVFZAnRIwmgVBkYXFA==", null, false, "bca3901a-5cb6-44df-ada3-540d3fb5b6e5", false, "mehrdara9" },
                    { 10, 0, "2b705fe8-4881-4c67-86f2-83865cd5d2cc", "mehrdara10@gmail.com", true, "Mehr", "Dara", false, null, "MEHRDARA10@GMAIL.COM", "MEHRDARA10", "mehrdara10@gmail.com", "AQAAAAIAAYagAAAAEOijlVTmWe/90gokssArWMZ1qPuYEvlJJxxIlL27z6jdA+tJjzPnYRS8LBINEXR3pQ==", null, false, "90788236-7ad9-40f2-aeda-a9446fad8ded", false, "mehrdara10" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

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
                name: "IX_AspNetUsers_Email",
                table: "AspNetUsers",
                column: "Email",
                unique: true,
                filter: "[Email] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_UserName",
                table: "AspNetUsers",
                column: "UserName",
                unique: true,
                filter: "[UserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_LetterRecipient_ForwardedByUserId",
                table: "LetterRecipient",
                column: "ForwardedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_LetterRecipient_LetterId_RecipientId",
                table: "LetterRecipient",
                columns: new[] { "LetterId", "RecipientId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_LetterRecipient_RecipientId",
                table: "LetterRecipient",
                column: "RecipientId");

            migrationBuilder.CreateIndex(
                name: "IX_Letters_ParentLetterId",
                table: "Letters",
                column: "ParentLetterId");

            migrationBuilder.CreateIndex(
                name: "IX_Letters_SenderId",
                table: "Letters",
                column: "SenderId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
                name: "LetterRecipient");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Letters");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
