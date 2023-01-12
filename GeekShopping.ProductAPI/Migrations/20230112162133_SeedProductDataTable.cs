using Microsoft.EntityFrameworkCore.Migrations;

namespace GeekShopping.ProductAPI.Migrations
{
    public partial class SeedProductDataTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "product",
                columns: new[] { "id", "category_name", "image_url", "name", "price", "description" },
                values: new object[] { 2L, "Action Figure", "https://github.com/leandrocgsi/erudio-microservices-dotnet6/blob/dot_net6_LTS/ShoppingImages/4_storm_tropper.jpg?raw=true", "Star Wars- Storm Tropper 2", 89.9m, "Action Figure Star Wars, Storm Tropper Imperial" });

            migrationBuilder.InsertData(
                table: "product",
                columns: new[] { "id", "category_name", "image_url", "name", "price", "description" },
                values: new object[] { 3L, "Action Figure", "https://github.com/leandrocgsi/erudio-microservices-dotnet6/blob/dot_net6_LTS/ShoppingImages/4_storm_tropper.jpg?raw=true", "Star Wars- Storm Tropper 3", 99.9m, "Action Figure Star Wars, Storm Tropper Imperial" });

            migrationBuilder.InsertData(
                table: "product",
                columns: new[] { "id", "category_name", "image_url", "name", "price", "description" },
                values: new object[] { 4L, "Action Figure", "https://github.com/leandrocgsi/erudio-microservices-dotnet6/blob/dot_net6_LTS/ShoppingImages/4_storm_tropper.jpg?raw=true", "Star Wars- Dart Vader", 129.9m, "Action Figure Star Wars, General Sith" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "product",
                keyColumn: "id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "product",
                keyColumn: "id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "product",
                keyColumn: "id",
                keyValue: 4L);
        }
    }
}
