using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace SampleMunicornNotion.DAL.Migrations
{
	public partial class InitialModels : Migration
	{
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.CreateTable(
				name: "AndroidNotifications",
				columns: table => new
				{
					Id = table.Column<long>(type: "bigint", nullable: false)
						.Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
					DeviceToken = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
					Message = table.Column<string>(type: "character varying(2000)", maxLength: 2000, nullable: false),
					Title = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
					Condition = table.Column<string>(type: "character varying(2000)", maxLength: 2000, nullable: true),
					CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "now() at time zone 'utc'"),
					ProcessedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
					Status = table.Column<int>(type: "integer", nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_AndroidNotifications", x => x.Id);
				});

			migrationBuilder.CreateTable(
				name: "IosNotifications",
				columns: table => new
				{
					Id = table.Column<long>(type: "bigint", nullable: false)
						.Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
					PushToken = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
					Alert = table.Column<string>(type: "character varying(2000)", maxLength: 2000, nullable: false),
					Priority = table.Column<int>(type: "integer", nullable: false, defaultValue: 10),
					IsBackground = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
					CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "now() at time zone 'utc'"),
					ProcessedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
					Status = table.Column<int>(type: "integer", nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_IosNotifications", x => x.Id);
				});
		}

		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropTable(
				name: "AndroidNotifications");

			migrationBuilder.DropTable(
				name: "IosNotifications");
		}
	}
}
