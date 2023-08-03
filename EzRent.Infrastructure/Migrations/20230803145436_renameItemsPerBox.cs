using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EzRent.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class renameItemsPerBox : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "QuantityPerBox",
                table: "Products",
                newName: "ItemsPerBox");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ItemsPerBox",
                table: "Products",
                newName: "QuantityPerBox");
        }
    }
}
