using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace PeopleSearch.Migrations
{
    public partial class InsertInterests : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("UPDATE People SET Interests = 'Movies, TV' WHERE Id = (SELECT Id FROM People WHERE FirstName = 'John' AND LastName = 'Doe')");
            migrationBuilder.Sql("UPDATE People SET Interests = 'Books, stargazing' WHERE Id = (SELECT Id FROM People WHERE FirstName = 'Jane' AND LastName = 'Doe')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
