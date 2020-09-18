using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FitOl.Repository.Migrations
{
    public partial class FitOlDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    Age = table.Column<int>(nullable: false),
                    Calorie = table.Column<int>(nullable: false),
                    Weight = table.Column<int>(nullable: false),
                    Height = table.Column<double>(nullable: false),
                    FatRate = table.Column<double>(nullable: false),
                    IsAdmin = table.Column<bool>(nullable: false),
                    ImagePath = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FT_Food",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    CaloriValue = table.Column<double>(nullable: false),
                    ProteinValue = table.Column<double>(nullable: false),
                    CarbohydrateValue = table.Column<double>(nullable: false),
                    OilValue = table.Column<double>(nullable: false),
                    FiberValue = table.Column<double>(nullable: false),
                    ImagePath = table.Column<string>(nullable: true),
                    EnumFoodType = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FT_Food", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FT_Movement",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MovementName = table.Column<string>(nullable: false),
                    ImagePath = table.Column<string>(nullable: true),
                    MovementDescription = table.Column<string>(nullable: false),
                    EnumMovementType = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FT_Movement", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FT_NutritionList",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    TotalCaloriValue = table.Column<double>(nullable: false),
                    EnumNutritionType = table.Column<int>(nullable: false),
                    EnumNutritionKind = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FT_NutritionList", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FT_SportList",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: false),
                    EnumSportType = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FT_SportList", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<int>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
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
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
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
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<int>(nullable: false)
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
                    UserId = table.Column<int>(nullable: false),
                    RoleId = table.Column<int>(nullable: false)
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
                    UserId = table.Column<int>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
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
                name: "FT_NutritionDay",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    FKNutritionListId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FT_NutritionDay", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FT_NutritionDay_FT_NutritionList_FKNutritionListId",
                        column: x => x.FKNutritionListId,
                        principalTable: "FT_NutritionList",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FT_UserNutritionLists",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FKUserId = table.Column<int>(nullable: false),
                    FKNutritionListId = table.Column<int>(nullable: false),
                    UserId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FT_UserNutritionLists", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FT_UserNutritionLists_FT_NutritionList_FKNutritionListId",
                        column: x => x.FKNutritionListId,
                        principalTable: "FT_NutritionList",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FT_UserNutritionLists_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FT_SportDay",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    FKSportListId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FT_SportDay", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FT_SportDay_FT_SportList_FKSportListId",
                        column: x => x.FKSportListId,
                        principalTable: "FT_SportList",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FT_UserSportLists",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FKUserId = table.Column<int>(nullable: false),
                    FKSportListId = table.Column<int>(nullable: false),
                    UserId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FT_UserSportLists", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FT_UserSportLists_FT_SportList_FKSportListId",
                        column: x => x.FKSportListId,
                        principalTable: "FT_SportList",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FT_UserSportLists_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FT_ThatDay",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    FKNutritionDayId = table.Column<int>(nullable: false),
                    EnumMealType = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FT_ThatDay", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FT_ThatDay_FT_NutritionDay_FKNutritionDayId",
                        column: x => x.FKNutritionDayId,
                        principalTable: "FT_NutritionDay",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FT_Area",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    FKDayId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FT_Area", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FT_Area_FT_SportDay_FKDayId",
                        column: x => x.FKDayId,
                        principalTable: "FT_SportDay",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FT_MealFoods",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FKFoodId = table.Column<int>(nullable: false),
                    FKThatDayId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FT_MealFoods", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FT_MealFoods_FT_Food_FKFoodId",
                        column: x => x.FKFoodId,
                        principalTable: "FT_Food",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FT_MealFoods_FT_ThatDay_FKThatDayId",
                        column: x => x.FKThatDayId,
                        principalTable: "FT_ThatDay",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FT_AreaMovements",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FKAreaId = table.Column<int>(nullable: false),
                    FKMovementId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FT_AreaMovements", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FT_AreaMovements_FT_Area_FKAreaId",
                        column: x => x.FKAreaId,
                        principalTable: "FT_Area",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FT_AreaMovements_FT_Movement_FKMovementId",
                        column: x => x.FKMovementId,
                        principalTable: "FT_Movement",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_FT_Area_FKDayId",
                table: "FT_Area",
                column: "FKDayId");

            migrationBuilder.CreateIndex(
                name: "IX_FT_AreaMovements_FKMovementId",
                table: "FT_AreaMovements",
                column: "FKMovementId");

            migrationBuilder.CreateIndex(
                name: "IX_FT_AreaMovements_FKAreaId_FKMovementId",
                table: "FT_AreaMovements",
                columns: new[] { "FKAreaId", "FKMovementId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_FT_MealFoods_FKThatDayId",
                table: "FT_MealFoods",
                column: "FKThatDayId");

            migrationBuilder.CreateIndex(
                name: "IX_FT_MealFoods_FKFoodId_FKThatDayId",
                table: "FT_MealFoods",
                columns: new[] { "FKFoodId", "FKThatDayId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_FT_NutritionDay_FKNutritionListId",
                table: "FT_NutritionDay",
                column: "FKNutritionListId");

            migrationBuilder.CreateIndex(
                name: "IX_FT_SportDay_FKSportListId",
                table: "FT_SportDay",
                column: "FKSportListId");

            migrationBuilder.CreateIndex(
                name: "IX_FT_ThatDay_FKNutritionDayId",
                table: "FT_ThatDay",
                column: "FKNutritionDayId");

            migrationBuilder.CreateIndex(
                name: "IX_FT_UserNutritionLists_FKNutritionListId",
                table: "FT_UserNutritionLists",
                column: "FKNutritionListId");

            migrationBuilder.CreateIndex(
                name: "IX_FT_UserNutritionLists_UserId",
                table: "FT_UserNutritionLists",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_FT_UserNutritionLists_FKUserId_FKNutritionListId",
                table: "FT_UserNutritionLists",
                columns: new[] { "FKUserId", "FKNutritionListId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_FT_UserSportLists_FKSportListId",
                table: "FT_UserSportLists",
                column: "FKSportListId");

            migrationBuilder.CreateIndex(
                name: "IX_FT_UserSportLists_UserId",
                table: "FT_UserSportLists",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_FT_UserSportLists_FKUserId_FKSportListId",
                table: "FT_UserSportLists",
                columns: new[] { "FKUserId", "FKSportListId" },
                unique: true);
        }

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
                name: "FT_AreaMovements");

            migrationBuilder.DropTable(
                name: "FT_MealFoods");

            migrationBuilder.DropTable(
                name: "FT_UserNutritionLists");

            migrationBuilder.DropTable(
                name: "FT_UserSportLists");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "FT_Area");

            migrationBuilder.DropTable(
                name: "FT_Movement");

            migrationBuilder.DropTable(
                name: "FT_Food");

            migrationBuilder.DropTable(
                name: "FT_ThatDay");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "FT_SportDay");

            migrationBuilder.DropTable(
                name: "FT_NutritionDay");

            migrationBuilder.DropTable(
                name: "FT_SportList");

            migrationBuilder.DropTable(
                name: "FT_NutritionList");
        }
    }
}
