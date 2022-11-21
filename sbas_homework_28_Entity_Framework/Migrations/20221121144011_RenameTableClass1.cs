using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace sbashomework28EntityFramework.Migrations
{
    /// <inheritdoc />
    public partial class RenameTableClass1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable("Class1s");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
