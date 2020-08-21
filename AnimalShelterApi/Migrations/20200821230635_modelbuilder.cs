using Microsoft.EntityFrameworkCore.Migrations;

namespace AnimalShelterApi.Migrations
{
    public partial class modelbuilder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Cats",
                columns: new[] { "CatId", "Color", "Description", "Name", "Temperament" },
                values: new object[,]
                {
                    { 1, "Black", "testDesc", "Cat1", "Calm" },
                    { 2, "Tan", "testDesc", "Cat2", "Anxious" },
                    { 3, "White", "testDesc", "Cat3", "Hyper" },
                    { 4, "Cream", "testDesc", "Cat4", "Energetic" },
                    { 5, "Black", "testDesc", "Cat5", "lazy" }
                });

            migrationBuilder.InsertData(
                table: "Dogs",
                columns: new[] { "DogId", "Color", "Description", "Name", "Temperament" },
                values: new object[,]
                {
                    { 1, "Black", "testDesc", "Dog1", "Calm" },
                    { 2, "Tan", "testDesc", "Dog2", "Anxious" },
                    { 3, "White", "testDesc", "Dog3", "Hyper" },
                    { 4, "Cream", "testDesc", "Dog4", "Energetic" },
                    { 5, "Black", "testDesc", "Dog5", "lazy" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Cats",
                keyColumn: "CatId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Cats",
                keyColumn: "CatId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Cats",
                keyColumn: "CatId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Cats",
                keyColumn: "CatId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Cats",
                keyColumn: "CatId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Dogs",
                keyColumn: "DogId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Dogs",
                keyColumn: "DogId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Dogs",
                keyColumn: "DogId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Dogs",
                keyColumn: "DogId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Dogs",
                keyColumn: "DogId",
                keyValue: 5);
        }
    }
}
