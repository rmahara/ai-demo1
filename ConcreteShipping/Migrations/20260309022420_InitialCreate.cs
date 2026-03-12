using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ConcreteShipping.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    UserName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "INTEGER", nullable: false),
                    PasswordHash = table.Column<string>(type: "TEXT", nullable: true),
                    SecurityStamp = table.Column<string>(type: "TEXT", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "TEXT", nullable: true),
                    PhoneNumber = table.Column<string>(type: "TEXT", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "INTEGER", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "INTEGER", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "TEXT", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "INTEGER", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Address = table.Column<string>(type: "TEXT", nullable: false),
                    Phone = table.Column<string>(type: "TEXT", nullable: false),
                    ContactPerson = table.Column<string>(type: "TEXT", nullable: false),
                    UnitPrice = table.Column<decimal>(type: "TEXT", nullable: false),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Factories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Address = table.Column<string>(type: "TEXT", nullable: false),
                    Phone = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Factories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MixDesigns",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Code = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Strength = table.Column<int>(type: "INTEGER", nullable: false),
                    Slump = table.Column<int>(type: "INTEGER", nullable: false),
                    Aggregate = table.Column<string>(type: "TEXT", nullable: false),
                    UnitPrice = table.Column<decimal>(type: "TEXT", nullable: false),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MixDesigns", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Vehicles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    LicensePlate = table.Column<string>(type: "TEXT", nullable: false),
                    Capacity = table.Column<decimal>(type: "TEXT", nullable: false),
                    DriverName = table.Column<string>(type: "TEXT", nullable: false),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RoleId = table.Column<string>(type: "TEXT", nullable: false),
                    ClaimType = table.Column<string>(type: "TEXT", nullable: true),
                    ClaimValue = table.Column<string>(type: "TEXT", nullable: true)
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
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    ClaimType = table.Column<string>(type: "TEXT", nullable: true),
                    ClaimValue = table.Column<string>(type: "TEXT", nullable: true)
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
                    LoginProvider = table.Column<string>(type: "TEXT", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "TEXT", maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "TEXT", nullable: true),
                    UserId = table.Column<string>(type: "TEXT", nullable: false)
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
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    RoleId = table.Column<string>(type: "TEXT", nullable: false)
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
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    LoginProvider = table.Column<string>(type: "TEXT", maxLength: 128, nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 128, nullable: false),
                    Value = table.Column<string>(type: "TEXT", nullable: true)
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
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    OrderDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    CustomerId = table.Column<int>(type: "INTEGER", nullable: false),
                    MixDesignId = table.Column<int>(type: "INTEGER", nullable: false),
                    Quantity = table.Column<decimal>(type: "TEXT", nullable: false),
                    DeliveryDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DeliveryAddress = table.Column<string>(type: "TEXT", nullable: false),
                    OrderType = table.Column<string>(type: "TEXT", nullable: false),
                    Status = table.Column<string>(type: "TEXT", nullable: false),
                    Notes = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Orders_MixDesigns_MixDesignId",
                        column: x => x.MixDesignId,
                        principalTable: "MixDesigns",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Shipments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    OrderId = table.Column<int>(type: "INTEGER", nullable: false),
                    VehicleId = table.Column<int>(type: "INTEGER", nullable: false),
                    ShippedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Quantity = table.Column<decimal>(type: "TEXT", nullable: false),
                    Status = table.Column<string>(type: "TEXT", nullable: false),
                    Notes = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shipments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Shipments_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Shipments_Vehicles_VehicleId",
                        column: x => x.VehicleId,
                        principalTable: "Vehicles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Address", "ContactPerson", "IsActive", "Name", "Phone", "UnitPrice" },
                values: new object[,]
                {
                    { 1, "東京都江東区有明1-1-1", "山田太郎", true, "山田建設株式会社", "03-1234-5678", 12000m },
                    { 2, "東京都墨田区押上2-2-2", "鈴木一郎", true, "鈴木工務店", "03-2345-6789", 11500m },
                    { 3, "神奈川県横浜市中区3-3-3", "佐藤次郎", true, "佐藤土木建設", "045-345-6789", 11000m }
                });

            migrationBuilder.InsertData(
                table: "Factories",
                columns: new[] { "Id", "Address", "Name", "Phone" },
                values: new object[] { 1, "東京都江東区新木場4-4-4", "東京生コン第一工場", "03-4567-8901" });

            migrationBuilder.InsertData(
                table: "MixDesigns",
                columns: new[] { "Id", "Aggregate", "Code", "IsActive", "Name", "Slump", "Strength", "UnitPrice" },
                values: new object[,]
                {
                    { 1, "20mm", "21N-8-20", true, "普通コンクリート 21N", 8, 21, 12000m },
                    { 2, "20mm", "24N-12-20", true, "普通コンクリート 24N", 12, 24, 13000m },
                    { 3, "25mm", "18N-15-25", true, "軽量コンクリート 18N", 15, 18, 11000m }
                });

            migrationBuilder.InsertData(
                table: "Vehicles",
                columns: new[] { "Id", "Capacity", "DriverName", "IsActive", "LicensePlate" },
                values: new object[,]
                {
                    { 1, 10m, "田中運転手", true, "品川100 あ 1234" },
                    { 2, 8m, "中村運転手", true, "品川100 い 5678" },
                    { 3, 7m, "小林運転手", true, "品川100 う 9012" }
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "CustomerId", "DeliveryAddress", "DeliveryDate", "MixDesignId", "Notes", "OrderDate", "OrderType", "Quantity", "Status" },
                values: new object[,]
                {
                    { 1, 1, "東京都江東区有明1-1-1", new DateTime(2026, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "1便目 朝イチ希望", new DateTime(2026, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "PreOrder", 30m, "Completed" },
                    { 2, 2, "東京都墨田区押上2-2-2", new DateTime(2026, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "", new DateTime(2026, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Phone", 20m, "Completed" },
                    { 3, 3, "神奈川県横浜市中区3-3-3", new DateTime(2026, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "雨天延期可", new DateTime(2026, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "PreOrder", 15m, "Shipped" },
                    { 4, 1, "東京都江東区有明1-1-1 2工区", new DateTime(2026, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "", new DateTime(2026, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "PreOrder", 25m, "Assigned" },
                    { 5, 2, "東京都墨田区押上2-2-2", new DateTime(2026, 3, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "午後指定", new DateTime(2026, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Phone", 18m, "Pending" },
                    { 6, 3, "神奈川県横浜市中区3-3-3", new DateTime(2026, 3, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "", new DateTime(2026, 3, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "PreOrder", 40m, "Pending" },
                    { 7, 1, "東京都江東区有明1-1-1 3工区", new DateTime(2026, 3, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "", new DateTime(2026, 3, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "PreOrder", 12m, "Pending" },
                    { 8, 2, "東京都墨田区押上2-2-2", new DateTime(2026, 3, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "基礎工事用", new DateTime(2026, 3, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Phone", 22m, "Pending" },
                    { 9, 3, "神奈川県横浜市中区3-3-3", new DateTime(2026, 3, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "", new DateTime(2026, 3, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "PreOrder", 35m, "Pending" },
                    { 10, 1, "東京都江東区有明1-1-1 大型案件", new DateTime(2026, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "大型案件 要確認", new DateTime(2026, 3, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "PreOrder", 50m, "Pending" }
                });

            migrationBuilder.InsertData(
                table: "Shipments",
                columns: new[] { "Id", "Notes", "OrderId", "Quantity", "ShippedAt", "Status", "VehicleId" },
                values: new object[,]
                {
                    { 1, "", 1, 10m, new DateTime(2026, 3, 2, 8, 0, 0, 0, DateTimeKind.Unspecified), "Delivered", 1 },
                    { 2, "", 1, 10m, new DateTime(2026, 3, 2, 9, 0, 0, 0, DateTimeKind.Unspecified), "Delivered", 2 },
                    { 3, "", 1, 10m, new DateTime(2026, 3, 2, 10, 0, 0, 0, DateTimeKind.Unspecified), "Delivered", 3 },
                    { 4, "", 2, 10m, new DateTime(2026, 3, 2, 13, 0, 0, 0, DateTimeKind.Unspecified), "Delivered", 1 },
                    { 5, "", 2, 10m, new DateTime(2026, 3, 2, 14, 0, 0, 0, DateTimeKind.Unspecified), "Delivered", 2 },
                    { 6, "", 3, 8m, new DateTime(2026, 3, 3, 8, 0, 0, 0, DateTimeKind.Unspecified), "Delivered", 1 },
                    { 7, "", 3, 7m, new DateTime(2026, 3, 3, 9, 0, 0, 0, DateTimeKind.Unspecified), "Dispatched", 2 },
                    { 8, "", 4, 10m, new DateTime(2026, 3, 4, 8, 0, 0, 0, DateTimeKind.Unspecified), "Dispatched", 1 },
                    { 9, "", 4, 8m, new DateTime(2026, 3, 4, 9, 0, 0, 0, DateTimeKind.Unspecified), "Dispatched", 2 },
                    { 10, "", 4, 7m, new DateTime(2026, 3, 4, 10, 0, 0, 0, DateTimeKind.Unspecified), "Dispatched", 3 },
                    { 11, "完了確認", 2, 0m, new DateTime(2026, 3, 2, 15, 0, 0, 0, DateTimeKind.Unspecified), "Delivered", 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

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
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CustomerId",
                table: "Orders",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_MixDesignId",
                table: "Orders",
                column: "MixDesignId");

            migrationBuilder.CreateIndex(
                name: "IX_Shipments_OrderId",
                table: "Shipments",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Shipments_VehicleId",
                table: "Shipments",
                column: "VehicleId");
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
                name: "Factories");

            migrationBuilder.DropTable(
                name: "Shipments");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Vehicles");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "MixDesigns");
        }
    }
}
