using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ITNews.Data.Repositories.Migrations
{
    public partial class newmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PostTag");

            //migrationBuilder.AlterColumn<string>(
            //    name: "Name",
            //    table: "AspNetUserTokens",
            //    nullable: false,
            //    oldClrType: typeof(string),
            //    oldMaxLength: 128);

            //migrationBuilder.AlterColumn<string>(
            //    name: "LoginProvider",
            //    table: "AspNetUserTokens",
            //    nullable: false,
            //    oldClrType: typeof(string),
            //    oldMaxLength: 128);

            //migrationBuilder.AlterColumn<string>(
            //    name: "ProviderKey",
            //    table: "AspNetUserLogins",
            //    nullable: false,
            //    oldClrType: typeof(string),
            //    oldMaxLength: 128);

            //migrationBuilder.AlterColumn<string>(
            //    name: "LoginProvider",
            //    table: "AspNetUserLogins",
            //    nullable: false,
            //    oldClrType: typeof(string),
            //    oldMaxLength: 128);

            migrationBuilder.CreateTable(
                name: "PostsTags",
                columns: table => new
                {
                    PostId = table.Column<int>(nullable: false),
                    TagId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostsTags", x => new { x.PostId, x.TagId });
                    table.ForeignKey(
                        name: "FK_PostsTags_Posts_PostId",
                        column: x => x.PostId,
                        principalTable: "Posts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PostsTags_Tags_TagId",
                        column: x => x.TagId,
                        principalTable: "Tags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            //migrationBuilder.CreateTable(
            //    name: "UserDomainModel",
            //    columns: table => new
            //    {
            //        Id = table.Column<string>(nullable: false),
            //        Blocked = table.Column<bool>(nullable: false),
            //        Email = table.Column<string>(nullable: true),
            //        EmailComfirmed = table.Column<bool>(nullable: false),
            //        ProfileId = table.Column<int>(nullable: false),
            //        UserName = table.Column<string>(nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_UserDomainModel", x => x.Id);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "CategoryDomainModel",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
            //        Name = table.Column<string>(nullable: true),
            //        UserId = table.Column<string>(nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_CategoryDomainModel", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK_CategoryDomainModel_UserDomainModel_UserId",
            //            column: x => x.UserId,
            //            principalTable: "UserDomainModel",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Restrict);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "PostDomainModel",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
            //        Title = table.Column<string>(nullable: true),
            //        Content = table.Column<string>(nullable: true),
            //        Published = table.Column<bool>(nullable: false),
            //        Created = table.Column<DateTime>(nullable: false),
            //        ShortDiscription = table.Column<string>(nullable: true),
            //        Rating = table.Column<int>(nullable: false),
            //        Updated = table.Column<DateTime>(nullable: false),
            //        UserId = table.Column<string>(nullable: true),
            //        CategoryId = table.Column<int>(nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_PostDomainModel", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK_PostDomainModel_CategoryDomainModel_CategoryId",
            //            column: x => x.CategoryId,
            //            principalTable: "CategoryDomainModel",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Restrict);
            //        table.ForeignKey(
            //            name: "FK_PostDomainModel_UserDomainModel_UserId",
            //            column: x => x.UserId,
            //            principalTable: "UserDomainModel",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Restrict);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "PostRatingDomainModel",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
            //        Mark = table.Column<int>(nullable: false),
            //        PostId = table.Column<int>(nullable: true),
            //        UserId = table.Column<string>(nullable: true),
            //        ApplicationUserId = table.Column<string>(nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_PostRatingDomainModel", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK_PostRatingDomainModel_AspNetUsers_ApplicationUserId",
            //            column: x => x.ApplicationUserId,
            //            principalTable: "AspNetUsers",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Restrict);
            //        table.ForeignKey(
            //            name: "FK_PostRatingDomainModel_PostDomainModel_PostId",
            //            column: x => x.PostId,
            //            principalTable: "PostDomainModel",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Restrict);
            //        table.ForeignKey(
            //            name: "FK_PostRatingDomainModel_UserDomainModel_UserId",
            //            column: x => x.UserId,
            //            principalTable: "UserDomainModel",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Restrict);
            //    });

            //migrationBuilder.CreateIndex(
            //    name: "IX_CategoryDomainModel_UserId",
            //    table: "CategoryDomainModel",
            //    column: "UserId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_PostDomainModel_CategoryId",
            //    table: "PostDomainModel",
            //    column: "CategoryId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_PostDomainModel_UserId",
            //    table: "PostDomainModel",
            //    column: "UserId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_PostRatingDomainModel_ApplicationUserId",
            //    table: "PostRatingDomainModel",
            //    column: "ApplicationUserId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_PostRatingDomainModel_PostId",
            //    table: "PostRatingDomainModel",
            //    column: "PostId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_PostRatingDomainModel_UserId",
            //    table: "PostRatingDomainModel",
            //    column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_PostsTags_TagId",
                table: "PostsTags",
                column: "TagId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropTable(
            //    name: "PostRatingDomainModel");

            migrationBuilder.DropTable(
                name: "PostsTags");

            //migrationBuilder.DropTable(
            //    name: "PostDomainModel");

            //migrationBuilder.DropTable(
            //    name: "CategoryDomainModel");

            //migrationBuilder.DropTable(
            //    name: "UserDomainModel");

            //migrationBuilder.AlterColumn<string>(
            //    name: "Name",
            //    table: "AspNetUserTokens",
            //    maxLength: 128,
            //    nullable: false,
            //    oldClrType: typeof(string));

            //migrationBuilder.AlterColumn<string>(
            //    name: "LoginProvider",
            //    table: "AspNetUserTokens",
            //    maxLength: 128,
            //    nullable: false,
            //    oldClrType: typeof(string));

            //migrationBuilder.AlterColumn<string>(
            //    name: "ProviderKey",
            //    table: "AspNetUserLogins",
            //    maxLength: 128,
            //    nullable: false,
            //    oldClrType: typeof(string));

            //migrationBuilder.AlterColumn<string>(
            //    name: "LoginProvider",
            //    table: "AspNetUserLogins",
            //    maxLength: 128,
            //    nullable: false,
            //    oldClrType: typeof(string));

            migrationBuilder.CreateTable(
                name: "PostTag",
                columns: table => new
                {
                    PostId = table.Column<int>(nullable: false),
                    TagId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostTag", x => new { x.PostId, x.TagId });
                    table.ForeignKey(
                        name: "FK_PostTag_Posts_PostId",
                        column: x => x.PostId,
                        principalTable: "Posts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PostTag_Tags_TagId",
                        column: x => x.TagId,
                        principalTable: "Tags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PostTag_TagId",
                table: "PostTag",
                column: "TagId");
        }
    }
}
