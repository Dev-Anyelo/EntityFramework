using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EntityFramework.Migrations
{
    /// <inheritdoc />
    public partial class DataSeedGeneral : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "content",
                table: "Comments",
                newName: "Content");

            migrationBuilder.InsertData(
                table: "Actors",
                columns: new[] { "Id", "Birthdate", "Name", "Salary" },
                values: new object[,]
                {
                    { 2, new DateTime(1966, 9, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "Adan Sandler", 1200m },
                    { 3, new DateTime(1965, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kevin James", 1200m }
                });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "Description", "InTheaters", "ReleaseDate", "Title" },
                values: new object[,]
                {
                    { 4, "ABCDE", true, new DateTime(2012, 5, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Avengers" },
                    { 5, "ABCDE", true, new DateTime(2004, 6, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Notebook" },
                    { 6, "ABCDE", true, new DateTime(2005, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mr. & Mrs. Smith" }
                });

            migrationBuilder.InsertData(
                table: "ActorsMovies",
                columns: new[] { "ActorId", "MovieId", "Character", "Order" },
                values: new object[,]
                {
                    { 2, 6, "John Smith", 1 },
                    { 3, 5, "El loco", 2 }
                });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "Content", "IsApproved", "MovieId" },
                values: new object[,]
                {
                    { 3, "The best movie ever", true, 4 },
                    { 4, "I cried a lot", false, 5 },
                    { 5, "I love this movie", true, 6 }
                });

            migrationBuilder.InsertData(
                table: "GenderMovie",
                columns: new[] { "GendersId", "MoviesId" },
                values: new object[,]
                {
                    { 5, 4 },
                    { 6, 6 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ActorsMovies",
                keyColumns: new[] { "ActorId", "MovieId" },
                keyValues: new object[] { 2, 6 });

            migrationBuilder.DeleteData(
                table: "ActorsMovies",
                keyColumns: new[] { "ActorId", "MovieId" },
                keyValues: new object[] { 3, 5 });

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "GenderMovie",
                keyColumns: new[] { "GendersId", "MoviesId" },
                keyValues: new object[] { 5, 4 });

            migrationBuilder.DeleteData(
                table: "GenderMovie",
                keyColumns: new[] { "GendersId", "MoviesId" },
                keyValues: new object[] { 6, 6 });

            migrationBuilder.DeleteData(
                table: "Actors",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Actors",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.RenameColumn(
                name: "Content",
                table: "Comments",
                newName: "content");
        }
    }
}
