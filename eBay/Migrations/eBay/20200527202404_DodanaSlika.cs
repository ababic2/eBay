using Microsoft.EntityFrameworkCore.Migrations;

namespace eBay.Migrations.EBay
{
    public partial class DodanaSlika : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "URLSlike",
                table: "Proizvod",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "URLSlike",
                table: "Proizvod");
        }
    }
}
