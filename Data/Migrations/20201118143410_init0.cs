using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BlogDiscussion2.Data.Migrations
{
    public partial class init0 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Notifications_AspNetUsers_UserId",
                table: "Notifications");

            migrationBuilder.DropForeignKey(
                name: "FK_Replies_Blogs_BlogId",
                table: "Replies");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Replies",
                table: "Replies");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Notifications",
                table: "Notifications");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Blogs",
                table: "Blogs");

            migrationBuilder.DropColumn(
                name: "ReplyId",
                table: "Replies");

            migrationBuilder.DropColumn(
                name: "ReplyContent",
                table: "Replies");

            migrationBuilder.DropColumn(
                name: "ReplyLikeCount",
                table: "Replies");

            migrationBuilder.DropColumn(
                name: "NotificationId",
                table: "Notifications");

            migrationBuilder.DropColumn(
                name: "NotificationContent",
                table: "Notifications");

            migrationBuilder.DropColumn(
                name: "NotificationLabel",
                table: "Notifications");

            migrationBuilder.DropColumn(
                name: "BlogId",
                table: "Blogs");

            migrationBuilder.DropColumn(
                name: "BlogCategory",
                table: "Blogs");

            migrationBuilder.DropColumn(
                name: "BlogContent",
                table: "Blogs");

            migrationBuilder.DropColumn(
                name: "BlogCreateDate",
                table: "Blogs");

            migrationBuilder.DropColumn(
                name: "BlogLikeCount",
                table: "Blogs");

            migrationBuilder.DropColumn(
                name: "BlogPublished",
                table: "Blogs");

            migrationBuilder.DropColumn(
                name: "BlogTitle",
                table: "Blogs");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Notifications",
                newName: "userId");

            migrationBuilder.RenameIndex(
                name: "IX_Notifications_UserId",
                table: "Notifications",
                newName: "IX_Notifications_userId");

            migrationBuilder.AlterColumn<int>(
                name: "BlogId",
                table: "Replies",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "id",
                table: "Replies",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<string>(
                name: "body",
                table: "Replies",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "likes",
                table: "Replies",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "id",
                table: "Notifications",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<string>(
                name: "body",
                table: "Notifications",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "label",
                table: "Notifications",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "id",
                table: "Blogs",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<string>(
                name: "body",
                table: "Blogs",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "category",
                table: "Blogs",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "createdOn",
                table: "Blogs",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "isPublished",
                table: "Blogs",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "likes",
                table: "Blogs",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "title",
                table: "Blogs",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Replies",
                table: "Replies",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Notifications",
                table: "Notifications",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Blogs",
                table: "Blogs",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Notifications_AspNetUsers_userId",
                table: "Notifications",
                column: "userId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Replies_Blogs_BlogId",
                table: "Replies",
                column: "BlogId",
                principalTable: "Blogs",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Notifications_AspNetUsers_userId",
                table: "Notifications");

            migrationBuilder.DropForeignKey(
                name: "FK_Replies_Blogs_BlogId",
                table: "Replies");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Replies",
                table: "Replies");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Notifications",
                table: "Notifications");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Blogs",
                table: "Blogs");

            migrationBuilder.DropColumn(
                name: "id",
                table: "Replies");

            migrationBuilder.DropColumn(
                name: "body",
                table: "Replies");

            migrationBuilder.DropColumn(
                name: "likes",
                table: "Replies");

            migrationBuilder.DropColumn(
                name: "id",
                table: "Notifications");

            migrationBuilder.DropColumn(
                name: "body",
                table: "Notifications");

            migrationBuilder.DropColumn(
                name: "label",
                table: "Notifications");

            migrationBuilder.DropColumn(
                name: "id",
                table: "Blogs");

            migrationBuilder.DropColumn(
                name: "body",
                table: "Blogs");

            migrationBuilder.DropColumn(
                name: "category",
                table: "Blogs");

            migrationBuilder.DropColumn(
                name: "createdOn",
                table: "Blogs");

            migrationBuilder.DropColumn(
                name: "isPublished",
                table: "Blogs");

            migrationBuilder.DropColumn(
                name: "likes",
                table: "Blogs");

            migrationBuilder.DropColumn(
                name: "title",
                table: "Blogs");

            migrationBuilder.RenameColumn(
                name: "userId",
                table: "Notifications",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Notifications_userId",
                table: "Notifications",
                newName: "IX_Notifications_UserId");

            migrationBuilder.AlterColumn<int>(
                name: "BlogId",
                table: "Replies",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ReplyId",
                table: "Replies",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<string>(
                name: "ReplyContent",
                table: "Replies",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ReplyLikeCount",
                table: "Replies",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "NotificationId",
                table: "Notifications",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<string>(
                name: "NotificationContent",
                table: "Notifications",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NotificationLabel",
                table: "Notifications",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "BlogId",
                table: "Blogs",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<string>(
                name: "BlogCategory",
                table: "Blogs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BlogContent",
                table: "Blogs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "BlogCreateDate",
                table: "Blogs",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "BlogLikeCount",
                table: "Blogs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "BlogPublished",
                table: "Blogs",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "BlogTitle",
                table: "Blogs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Replies",
                table: "Replies",
                column: "ReplyId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Notifications",
                table: "Notifications",
                column: "NotificationId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Blogs",
                table: "Blogs",
                column: "BlogId");

            migrationBuilder.AddForeignKey(
                name: "FK_Notifications_AspNetUsers_UserId",
                table: "Notifications",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Replies_Blogs_BlogId",
                table: "Replies",
                column: "BlogId",
                principalTable: "Blogs",
                principalColumn: "BlogId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
