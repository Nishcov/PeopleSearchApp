using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace PeopleSearch.Migrations
{
    public partial class SeedDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO People (FirstName, LastName, Age) VALUES ('John', 'Doe', 37)");
            migrationBuilder.Sql("INSERT INTO Addresses (Address1, Locality, Province, PostCode, Country, PersonId) VALUES ('123 Fake St', 'Springfield', 'Illinois', '62629', 'USA', (SELECT Id FROM People WHERE FirstName = 'John' AND LastName = 'Doe'))");
            migrationBuilder.Sql("INSERT INTO Interests (Activity, PersonId) VALUES ('Movies', (SELECT Id FROM People WHERE FirstName = 'John' AND LastName = 'Doe'))");
            migrationBuilder.Sql("INSERT INTO Interests (Activity, PersonId) VALUES ('TV', (SELECT Id FROM People WHERE FirstName = 'John' AND LastName = 'Doe'))");

            migrationBuilder.Sql("INSERT INTO People (FirstName, LastName, Age) VALUES ('Jane', 'Doe', 42)");
            migrationBuilder.Sql("INSERT INTO Addresses (Address1, Locality, Province, PostCode, Country, PersonId) VALUES ('1337 Galaxy Ln', 'Tampa', 'Florida', '33601', 'USA', (SELECT Id FROM People WHERE FirstName = 'Jane' AND LastName = 'Doe'))");
            migrationBuilder.Sql("INSERT INTO Interests (Activity, PersonId) VALUES ('Books', (SELECT Id FROM People WHERE FirstName = 'Jane' AND LastName = 'Doe'))");
            migrationBuilder.Sql("INSERT INTO Interests (Activity, PersonId) VALUES ('Stargazing', (SELECT Id FROM People WHERE FirstName = 'Jane' AND LastName = 'Doe'))");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM People WHERE FirstName IN ('John', 'Jane') AND LastName IN ('Doe', 'Doe')");
        }
    }
}
