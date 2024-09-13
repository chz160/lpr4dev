﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace Lpr4dev.Migrations
{
    public partial class AddAttachmentCount : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AttachmentCount",
                table: "Messages",
                nullable: false,
                defaultValue: 0);
        }
        
    }
}
