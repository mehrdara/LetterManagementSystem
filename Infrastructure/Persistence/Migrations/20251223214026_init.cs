using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
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
                    { 1, 0, "c18ec524-0aeb-4bd9-8c3c-c7c9cc1506f3", "mehrdara1@gmail.com", true, "Mehr", "Dara", false, null, "MEHRDARA1@GMAIL.COM", "MEHRDARA1", "mehrdara1@gmail.com", "AQAAAAIAAYagAAAAEG/MT7Ol4Ep0B4KtE1YUoX98nZZ10UatuyX54DTDNih603h/qRmXBZcQIZqh67YsDw==", null, false, "dba3efa3-f1be-404e-95f6-2b5441f1691a", false, "mehrdara1" },
                    { 2, 0, "cea1cace-bc23-428b-a1ae-4b2b951d9053", "mehrdara2@gmail.com", true, "Mehr", "Dara", false, null, "MEHRDARA2@GMAIL.COM", "MEHRDARA2", "mehrdara2@gmail.com", "AQAAAAIAAYagAAAAEMw+Sf3g20xAFEyjp/QWjw1CT/Waejc1khTfDwppTC600TPUc64Qhfor28Gmxt56sA==", null, false, "6eee75d4-704b-4c78-b444-950a430c3686", false, "mehrdara2" },
                    { 3, 0, "deace663-2957-4629-a78f-f036980c3883", "mehrdara3@gmail.com", true, "Mehr", "Dara", false, null, "MEHRDARA3@GMAIL.COM", "MEHRDARA3", "mehrdara3@gmail.com", "AQAAAAIAAYagAAAAECPut6KDt1uu7DgZAQjddJBEj28MCkF1tgRcMAG20c+24RJihnjHNsz73sMQPAji2g==", null, false, "196dde20-feba-47cf-8b7e-adba07af6c8f", false, "mehrdara3" },
                    { 4, 0, "e164c672-7ff8-45fe-98f4-93d02f5713b2", "mehrdara4@gmail.com", true, "Mehr", "Dara", false, null, "MEHRDARA4@GMAIL.COM", "MEHRDARA4", "mehrdara4@gmail.com", "AQAAAAIAAYagAAAAEMPeQ05svicEzvg5a5TbpWuTXrHgzJ1kYnHZHyOQoLF3hxqVB4PBmrje0KZEbdTAYg==", null, false, "c2f4e9c1-47da-4fae-b54f-9938f2872949", false, "mehrdara4" },
                    { 5, 0, "eba1690e-13f6-40ba-83b0-69f02c3e9602", "mehrdara5@gmail.com", true, "Mehr", "Dara", false, null, "MEHRDARA5@GMAIL.COM", "MEHRDARA5", "mehrdara5@gmail.com", "AQAAAAIAAYagAAAAEAlKFJOOeygYCNMCfGwvlPrPSWElZFghpeB11b0D+1x/cqXwJe2R0hTJKbuLR9Ztvg==", null, false, "7000498c-d458-49fe-9b7a-d2d38da501ef", false, "mehrdara5" },
                    { 6, 0, "413b155d-4f86-430e-b58d-cafb23877674", "mehrdara6@gmail.com", true, "Mehr", "Dara", false, null, "MEHRDARA6@GMAIL.COM", "MEHRDARA6", "mehrdara6@gmail.com", "AQAAAAIAAYagAAAAEIgTAL8KEWCMfs2p1gJ6C6owq2w7VpnEKubFnVtmk1INmK0u9aEb6t2jiRucB0EjKQ==", null, false, "d32c8b67-95c5-4623-a5b8-9f2ddc3dea77", false, "mehrdara6" },
                    { 7, 0, "a1f6f989-ce4d-4489-af9c-08d2731eb30f", "mehrdara7@gmail.com", true, "Mehr", "Dara", false, null, "MEHRDARA7@GMAIL.COM", "MEHRDARA7", "mehrdara7@gmail.com", "AQAAAAIAAYagAAAAELqSV4mumBlPbNMlgTdTJSfyEPlx17sPeS0Tza8n4As2lvGZ/BiLmXA0ZEd1GLrhYQ==", null, false, "ea04585b-16d9-4023-84bb-3b7042db104c", false, "mehrdara7" },
                    { 8, 0, "2f74c066-b934-4b57-a919-fc86c1eee8e8", "mehrdara8@gmail.com", true, "Mehr", "Dara", false, null, "MEHRDARA8@GMAIL.COM", "MEHRDARA8", "mehrdara8@gmail.com", "AQAAAAIAAYagAAAAEG7LVLY0ZycuoRAaygeXUGa3EbIXEK4vhRdRQPPaWtNAmkJZG23swWif9oCR0Z04xQ==", null, false, "194a73a2-6ae9-416a-b7b8-6802cc199e54", false, "mehrdara8" },
                    { 9, 0, "3704569b-f5b8-462f-bf7e-91f07992621c", "mehrdara9@gmail.com", true, "Mehr", "Dara", false, null, "MEHRDARA9@GMAIL.COM", "MEHRDARA9", "mehrdara9@gmail.com", "AQAAAAIAAYagAAAAEEToSG7InvPeAB7WZN4l0G7iQPVWhupq/Z+V3T7ftTbITFFp+oV4brnvCRNRJlT4Bg==", null, false, "e911c85c-8d75-41cd-91dd-d5dc14811075", false, "mehrdara9" },
                    { 10, 0, "942b31c8-8562-4d5e-a037-a2e50ab86a9c", "mehrdara10@gmail.com", true, "Mehr", "Dara", false, null, "MEHRDARA10@GMAIL.COM", "MEHRDARA10", "mehrdara10@gmail.com", "AQAAAAIAAYagAAAAEOua3ryNw+3/owv9JBlOx/5ZB2apMtz0UFNE0RccjeixthazVsAcF3g/PWI6sbeN8g==", null, false, "d6192833-4ace-4dfc-b799-59bffd04bec7", false, "mehrdara10" }
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
