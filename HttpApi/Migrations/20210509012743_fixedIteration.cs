using Microsoft.EntityFrameworkCore.Migrations;

namespace HttpApi.Migrations
{
    public partial class fixedIteration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Adults_Job_JobTitleId",
                table: "Adults");

            migrationBuilder.DropForeignKey(
                name: "FK_Child_Families_FamilyId",
                table: "Child");

            migrationBuilder.DropForeignKey(
                name: "FK_Interest_Child_ChildId",
                table: "Interest");

            migrationBuilder.DropForeignKey(
                name: "FK_Pet_Child_ChildId",
                table: "Pet");

            migrationBuilder.DropForeignKey(
                name: "FK_Pet_Families_FamilyId",
                table: "Pet");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Pet",
                table: "Pet");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Job",
                table: "Job");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Interest",
                table: "Interest");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Child",
                table: "Child");

            migrationBuilder.RenameTable(
                name: "Pet",
                newName: "Pets");

            migrationBuilder.RenameTable(
                name: "Job",
                newName: "Jobs");

            migrationBuilder.RenameTable(
                name: "Interest",
                newName: "Interests");

            migrationBuilder.RenameTable(
                name: "Child",
                newName: "Children");

            migrationBuilder.RenameIndex(
                name: "IX_Pet_FamilyId",
                table: "Pets",
                newName: "IX_Pets_FamilyId");

            migrationBuilder.RenameIndex(
                name: "IX_Pet_ChildId",
                table: "Pets",
                newName: "IX_Pets_ChildId");

            migrationBuilder.RenameIndex(
                name: "IX_Interest_ChildId",
                table: "Interests",
                newName: "IX_Interests_ChildId");

            migrationBuilder.RenameIndex(
                name: "IX_Child_FamilyId",
                table: "Children",
                newName: "IX_Children_FamilyId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Pets",
                table: "Pets",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Jobs",
                table: "Jobs",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Interests",
                table: "Interests",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Children",
                table: "Children",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Username = table.Column<string>(type: "TEXT", nullable: false),
                    Password = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Adults_Jobs_JobTitleId",
                table: "Adults",
                column: "JobTitleId",
                principalTable: "Jobs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Children_Families_FamilyId",
                table: "Children",
                column: "FamilyId",
                principalTable: "Families",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Interests_Children_ChildId",
                table: "Interests",
                column: "ChildId",
                principalTable: "Children",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Pets_Children_ChildId",
                table: "Pets",
                column: "ChildId",
                principalTable: "Children",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Pets_Families_FamilyId",
                table: "Pets",
                column: "FamilyId",
                principalTable: "Families",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Adults_Jobs_JobTitleId",
                table: "Adults");

            migrationBuilder.DropForeignKey(
                name: "FK_Children_Families_FamilyId",
                table: "Children");

            migrationBuilder.DropForeignKey(
                name: "FK_Interests_Children_ChildId",
                table: "Interests");

            migrationBuilder.DropForeignKey(
                name: "FK_Pets_Children_ChildId",
                table: "Pets");

            migrationBuilder.DropForeignKey(
                name: "FK_Pets_Families_FamilyId",
                table: "Pets");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Pets",
                table: "Pets");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Jobs",
                table: "Jobs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Interests",
                table: "Interests");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Children",
                table: "Children");

            migrationBuilder.RenameTable(
                name: "Pets",
                newName: "Pet");

            migrationBuilder.RenameTable(
                name: "Jobs",
                newName: "Job");

            migrationBuilder.RenameTable(
                name: "Interests",
                newName: "Interest");

            migrationBuilder.RenameTable(
                name: "Children",
                newName: "Child");

            migrationBuilder.RenameIndex(
                name: "IX_Pets_FamilyId",
                table: "Pet",
                newName: "IX_Pet_FamilyId");

            migrationBuilder.RenameIndex(
                name: "IX_Pets_ChildId",
                table: "Pet",
                newName: "IX_Pet_ChildId");

            migrationBuilder.RenameIndex(
                name: "IX_Interests_ChildId",
                table: "Interest",
                newName: "IX_Interest_ChildId");

            migrationBuilder.RenameIndex(
                name: "IX_Children_FamilyId",
                table: "Child",
                newName: "IX_Child_FamilyId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Pet",
                table: "Pet",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Job",
                table: "Job",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Interest",
                table: "Interest",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Child",
                table: "Child",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Adults_Job_JobTitleId",
                table: "Adults",
                column: "JobTitleId",
                principalTable: "Job",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Child_Families_FamilyId",
                table: "Child",
                column: "FamilyId",
                principalTable: "Families",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Interest_Child_ChildId",
                table: "Interest",
                column: "ChildId",
                principalTable: "Child",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Pet_Child_ChildId",
                table: "Pet",
                column: "ChildId",
                principalTable: "Child",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Pet_Families_FamilyId",
                table: "Pet",
                column: "FamilyId",
                principalTable: "Families",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
