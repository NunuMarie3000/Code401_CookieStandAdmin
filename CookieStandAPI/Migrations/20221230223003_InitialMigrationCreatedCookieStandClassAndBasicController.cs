using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CookieStandAPI.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigrationCreatedCookieStandClassAndBasicController : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CookieStands",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MinimumCustomersPerHour = table.Column<int>(name: "Minimum_Customers_Per_Hour", type: "int", nullable: false),
                    MaximumCustomersPerHour = table.Column<int>(name: "Maximum_Customers_Per_Hour", type: "int", nullable: false),
                    AverageCookiesPerSale = table.Column<decimal>(name: "Average_Cookies_Per_Sale", type: "decimal(18,2)", nullable: false),
                    Owner = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CookieStands", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CookieStands");
        }
    }
}
