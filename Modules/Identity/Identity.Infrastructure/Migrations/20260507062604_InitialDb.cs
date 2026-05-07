using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Identity.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Identity");

            migrationBuilder.CreateTable(
                name: "ApiKeys",
                schema: "Identity",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    key = table.Column<string>(type: "text", nullable: false),
                    owner = table.Column<string>(type: "text", nullable: false),
                    ExpireAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()"),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()"),
                    is_active = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApiKeys", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Companies",
                schema: "Identity",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false),
                    address = table.Column<string>(type: "text", nullable: false),
                    description = table.Column<string>(type: "text", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()"),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()"),
                    is_active = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Countries",
                schema: "Identity",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false),
                    code = table.Column<string>(type: "text", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()"),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()"),
                    is_active = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Features",
                schema: "Identity",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()"),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()"),
                    is_active = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Features", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "PasswordRules",
                schema: "Identity",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    len = table.Column<int>(type: "integer", nullable: false),
                    is_digit = table.Column<bool>(type: "boolean", nullable: false),
                    is_lower = table.Column<bool>(type: "boolean", nullable: false),
                    is_symbol = table.Column<bool>(type: "boolean", nullable: false),
                    is_upper = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PasswordRules", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "RefreshTokenAudits",
                schema: "Identity",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    username = table.Column<string>(type: "text", nullable: false),
                    user_id = table.Column<string>(type: "text", nullable: false),
                    hashed_refresh_token = table.Column<string>(type: "text", nullable: false),
                    action = table.Column<string>(type: "text", nullable: false),
                    expired_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()"),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()"),
                    is_active = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefreshTokenAudits", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Departments",
                schema: "Identity",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false),
                    description = table.Column<string>(type: "text", nullable: false),
                    company_id = table.Column<int>(type: "integer", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()"),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()"),
                    is_active = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.id);
                    table.ForeignKey(
                        name: "FK_Departments_Companies_company_id",
                        column: x => x.company_id,
                        principalSchema: "Identity",
                        principalTable: "Companies",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Locations",
                schema: "Identity",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false),
                    description = table.Column<string>(type: "text", nullable: false),
                    country_id = table.Column<int>(type: "integer", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()"),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()"),
                    is_active = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.id);
                    table.ForeignKey(
                        name: "FK_Locations_Countries_country_id",
                        column: x => x.country_id,
                        principalSchema: "Identity",
                        principalTable: "Countries",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WeakPasswords",
                schema: "Identity",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    pattern = table.Column<string>(type: "text", nullable: false),
                    password_rule_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeakPasswords", x => x.id);
                    table.ForeignKey(
                        name: "FK_WeakPasswords_PasswordRules_password_rule_id",
                        column: x => x.password_rule_id,
                        principalSchema: "Identity",
                        principalTable: "PasswordRules",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Positions",
                schema: "Identity",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false),
                    description = table.Column<string>(type: "text", nullable: false),
                    department_id = table.Column<int>(type: "integer", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()"),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()"),
                    is_active = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Positions", x => x.id);
                    table.ForeignKey(
                        name: "FK_Positions_Departments_department_id",
                        column: x => x.department_id,
                        principalSchema: "Identity",
                        principalTable: "Departments",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                schema: "Identity",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false),
                    location_id = table.Column<int>(type: "integer", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()"),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()"),
                    is_active = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.id);
                    table.ForeignKey(
                        name: "FK_Roles_Locations_location_id",
                        column: x => x.location_id,
                        principalSchema: "Identity",
                        principalTable: "Locations",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Operators",
                schema: "Identity",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    operator_id = table.Column<string>(type: "text", nullable: false),
                    username = table.Column<string>(type: "text", nullable: false),
                    password = table.Column<string>(type: "text", nullable: false),
                    title = table.Column<string>(type: "text", nullable: false),
                    firstname = table.Column<string>(type: "text", nullable: false),
                    middlename = table.Column<string>(type: "text", nullable: false),
                    lastname = table.Column<string>(type: "text", nullable: false),
                    gender = table.Column<string>(type: "text", nullable: false),
                    email = table.Column<string>(type: "text", nullable: false),
                    mobile = table.Column<string>(type: "text", nullable: false),
                    role_id = table.Column<int>(type: "integer", nullable: false),
                    Companyid = table.Column<int>(type: "integer", nullable: true),
                    Departmentid = table.Column<int>(type: "integer", nullable: true),
                    Positionid = table.Column<int>(type: "integer", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()"),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()"),
                    is_active = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Operators", x => x.id);
                    table.ForeignKey(
                        name: "FK_Operators_Companies_Companyid",
                        column: x => x.Companyid,
                        principalSchema: "Identity",
                        principalTable: "Companies",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_Operators_Departments_Departmentid",
                        column: x => x.Departmentid,
                        principalSchema: "Identity",
                        principalTable: "Departments",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_Operators_Positions_Positionid",
                        column: x => x.Positionid,
                        principalSchema: "Identity",
                        principalTable: "Positions",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_Operators_Roles_role_id",
                        column: x => x.role_id,
                        principalSchema: "Identity",
                        principalTable: "Roles",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Permissions",
                schema: "Identity",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    role_id = table.Column<int>(type: "integer", nullable: false),
                    feature_id = table.Column<int>(type: "integer", nullable: false),
                    is_enabled = table.Column<bool>(type: "boolean", nullable: false),
                    is_created = table.Column<bool>(type: "boolean", nullable: false),
                    is_updated = table.Column<bool>(type: "boolean", nullable: false),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()"),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()"),
                    is_active = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permissions", x => x.id);
                    table.ForeignKey(
                        name: "FK_Permissions_Features_feature_id",
                        column: x => x.feature_id,
                        principalSchema: "Identity",
                        principalTable: "Features",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Permissions_Roles_role_id",
                        column: x => x.role_id,
                        principalSchema: "Identity",
                        principalTable: "Roles",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OperatorLocations",
                schema: "Identity",
                columns: table => new
                {
                    operator_id = table.Column<int>(type: "integer", nullable: false),
                    location_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OperatorLocations", x => new { x.location_id, x.operator_id });
                    table.ForeignKey(
                        name: "FK_OperatorLocations_Locations_location_id",
                        column: x => x.location_id,
                        principalSchema: "Identity",
                        principalTable: "Locations",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OperatorLocations_Operators_operator_id",
                        column: x => x.operator_id,
                        principalSchema: "Identity",
                        principalTable: "Operators",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "Countries",
                columns: new[] { "id", "code", "is_active", "name" },
                values: new object[,]
                {
                    { 1, "AD", true, "Andorra" },
                    { 2, "AE", true, "United Arab Emirates" },
                    { 3, "AF", true, "Afghanistan" },
                    { 4, "AG", true, "Antigua and Barbuda" },
                    { 5, "AI", true, "Anguilla" },
                    { 6, "AL", true, "Albania" },
                    { 7, "AM", true, "Armenia" },
                    { 8, "AN", true, "Netherlands Antilles" },
                    { 9, "AO", true, "Angola" },
                    { 10, "AQ", true, "Antarctica" },
                    { 11, "AR", true, "Argentina" },
                    { 12, "AS", true, "American Samoa" },
                    { 13, "AT", true, "Austria" },
                    { 14, "AU", true, "Australia" },
                    { 15, "AW", true, "Aruba" },
                    { 16, "AZ", true, "Azerbaijan" },
                    { 17, "BA", true, "Bosnia and Herzegovina" },
                    { 18, "BB", true, "Barbados" },
                    { 19, "BD", true, "Bangladesh" },
                    { 20, "BE", true, "Belgium" },
                    { 21, "BF", true, "Burkina Faso" },
                    { 22, "BG", true, "Bulgaria" },
                    { 23, "BH", true, "Bahrain" },
                    { 24, "BI", true, "Burundi" },
                    { 25, "BJ", true, "Benin" },
                    { 26, "BM", true, "Bermuda" },
                    { 27, "BN", true, "Brunei" },
                    { 28, "BO", true, "Bolivia" },
                    { 29, "BR", true, "Brazil" },
                    { 30, "BS", true, "Bahamas" },
                    { 31, "BT", true, "Bhutan" },
                    { 32, "BV", true, "Bouvet Island" },
                    { 33, "BW", true, "Botswana" },
                    { 34, "BY", true, "Belarus" },
                    { 35, "BZ", true, "Belize" },
                    { 36, "CA", true, "Canada" },
                    { 37, "CC", true, "Cocos (Keeling) Islands" },
                    { 38, "CD", true, "Congo (DRC)" },
                    { 39, "CF", true, "Central African Republic" },
                    { 40, "CG", true, "Congo (Republic)" },
                    { 41, "CH", true, "Switzerland" },
                    { 42, "CI", true, "Côte d'Ivoire" },
                    { 43, "CK", true, "Cook Islands" },
                    { 44, "CL", true, "Chile" },
                    { 45, "CM", true, "Cameroon" },
                    { 46, "CN", true, "China" },
                    { 47, "CO", true, "Colombia" },
                    { 48, "CR", true, "Costa Rica" },
                    { 49, "CU", true, "Cuba" },
                    { 50, "CV", true, "Cape Verde" },
                    { 51, "CX", true, "Christmas Island" },
                    { 52, "CY", true, "Cyprus" },
                    { 53, "CZ", true, "Czech Republic" },
                    { 54, "DE", true, "Germany" },
                    { 55, "DJ", true, "Djibouti" },
                    { 56, "DK", true, "Denmark" },
                    { 57, "DM", true, "Dominica" },
                    { 58, "DO", true, "Dominican Republic" },
                    { 59, "DZ", true, "Algeria" },
                    { 60, "EC", true, "Ecuador" },
                    { 61, "EE", true, "Estonia" },
                    { 62, "EG", true, "Egypt" },
                    { 63, "EH", true, "Western Sahara" },
                    { 64, "ER", true, "Eritrea" },
                    { 65, "ES", true, "Spain" },
                    { 66, "ET", true, "Ethiopia" },
                    { 67, "FI", true, "Finland" },
                    { 68, "FJ", true, "Fiji" },
                    { 69, "FK", true, "Falkland Islands" },
                    { 70, "FM", true, "Micronesia" },
                    { 71, "FO", true, "Faroe Islands" },
                    { 72, "FR", true, "France" },
                    { 73, "GA", true, "Gabon" },
                    { 74, "GB", true, "United Kingdom" },
                    { 75, "GD", true, "Grenada" },
                    { 76, "GE", true, "Georgia" },
                    { 77, "GF", true, "French Guiana" },
                    { 78, "GG", true, "Guernsey" },
                    { 79, "GH", true, "Ghana" },
                    { 80, "GI", true, "Gibraltar" },
                    { 81, "GL", true, "Greenland" },
                    { 82, "GM", true, "Gambia" },
                    { 83, "GN", true, "Guinea" },
                    { 84, "GP", true, "Guadeloupe" },
                    { 85, "GQ", true, "Equatorial Guinea" },
                    { 86, "GR", true, "Greece" },
                    { 87, "GT", true, "Guatemala" },
                    { 88, "GU", true, "Guam" },
                    { 89, "GW", true, "Guinea-Bissau" },
                    { 90, "GY", true, "Guyana" },
                    { 91, "HK", true, "Hong Kong" },
                    { 92, "HN", true, "Honduras" },
                    { 93, "HR", true, "Croatia" },
                    { 94, "HT", true, "Haiti" },
                    { 95, "HU", true, "Hungary" },
                    { 96, "ID", true, "Indonesia" },
                    { 97, "IE", true, "Ireland" },
                    { 98, "IL", true, "Israel" },
                    { 99, "IN", true, "India" },
                    { 100, "IQ", true, "Iraq" },
                    { 101, "IR", true, "Iran" },
                    { 102, "IS", true, "Iceland" },
                    { 103, "IT", true, "Italy" },
                    { 104, "JM", true, "Jamaica" },
                    { 105, "JO", true, "Jordan" },
                    { 106, "JP", true, "Japan" },
                    { 107, "KE", true, "Kenya" },
                    { 108, "KH", true, "Cambodia" },
                    { 109, "KR", true, "South Korea" },
                    { 110, "KW", true, "Kuwait" },
                    { 111, "KZ", true, "Kazakhstan" },
                    { 112, "LA", true, "Laos" },
                    { 113, "LB", true, "Lebanon" },
                    { 114, "LK", true, "Sri Lanka" },
                    { 115, "LR", true, "Liberia" },
                    { 116, "LS", true, "Lesotho" },
                    { 117, "LT", true, "Lithuania" },
                    { 118, "LU", true, "Luxembourg" },
                    { 119, "LV", true, "Latvia" },
                    { 120, "LY", true, "Libya" },
                    { 121, "MA", true, "Morocco" },
                    { 122, "MC", true, "Monaco" },
                    { 123, "MD", true, "Moldova" },
                    { 124, "ME", true, "Montenegro" },
                    { 125, "MG", true, "Madagascar" },
                    { 126, "MV", true, "Maldives" },
                    { 127, "MX", true, "Mexico" },
                    { 128, "MY", true, "Malaysia" },
                    { 129, "MZ", true, "Mozambique" },
                    { 130, "NA", true, "Namibia" },
                    { 131, "NG", true, "Nigeria" },
                    { 132, "NL", true, "Netherlands" },
                    { 133, "NO", true, "Norway" },
                    { 134, "NP", true, "Nepal" },
                    { 135, "NZ", true, "New Zealand" },
                    { 136, "OM", true, "Oman" },
                    { 137, "PA", true, "Panama" },
                    { 138, "PE", true, "Peru" },
                    { 139, "PH", true, "Philippines" },
                    { 140, "PK", true, "Pakistan" },
                    { 141, "PL", true, "Poland" },
                    { 142, "PT", true, "Portugal" },
                    { 143, "QA", true, "Qatar" },
                    { 144, "RO", true, "Romania" },
                    { 145, "RS", true, "Serbia" },
                    { 146, "RU", true, "Russia" },
                    { 147, "RW", true, "Rwanda" },
                    { 148, "SA", true, "Saudi Arabia" },
                    { 149, "SE", true, "Sweden" },
                    { 150, "SG", true, "Singapore" },
                    { 151, "SI", true, "Slovenia" },
                    { 152, "SK", true, "Slovakia" },
                    { 153, "SN", true, "Senegal" },
                    { 154, "SO", true, "Somalia" },
                    { 155, "SR", true, "Suriname" },
                    { 156, "SV", true, "El Salvador" },
                    { 157, "SY", true, "Syria" },
                    { 158, "TH", true, "Thailand" },
                    { 159, "TJ", true, "Tajikistan" },
                    { 160, "TL", true, "Timor-Leste" },
                    { 161, "TM", true, "Turkmenistan" },
                    { 162, "TN", true, "Tunisia" },
                    { 163, "TR", true, "Turkey" },
                    { 164, "TW", true, "Taiwan" },
                    { 165, "TZ", true, "Tanzania" },
                    { 166, "UA", true, "Ukraine" },
                    { 167, "UG", true, "Uganda" },
                    { 168, "US", true, "United States" },
                    { 169, "UY", true, "Uruguay" },
                    { 170, "UZ", true, "Uzbekistan" },
                    { 171, "VA", true, "Vatican City" },
                    { 172, "VE", true, "Venezuela" },
                    { 173, "VN", true, "Vietnam" },
                    { 174, "YE", true, "Yemen" },
                    { 175, "ZA", true, "South Africa" },
                    { 176, "ZM", true, "Zambia" },
                    { 177, "ZW", true, "Zimbabwe" }
                });

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "Features",
                columns: new[] { "id", "is_active", "name" },
                values: new object[,]
                {
                    { 1, true, "dashboard" },
                    { 2, true, "events" },
                    { 3, true, "location" },
                    { 4, true, "alert" },
                    { 5, true, "operator" },
                    { 6, true, "device" },
                    { 7, true, "control" },
                    { 8, true, "monitor" },
                    { 9, true, "monitorgroup" },
                    { 10, true, "acr" },
                    { 11, true, "user" },
                    { 12, true, "group" },
                    { 13, true, "area" },
                    { 14, true, "time" },
                    { 15, true, "trigger" },
                    { 16, true, "map" },
                    { 17, true, "report" },
                    { 18, true, "setting" },
                    { 19, true, "tools" }
                });

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "PasswordRules",
                columns: new[] { "id", "is_digit", "is_lower", "is_symbol", "is_upper", "len" },
                values: new object[] { 1, false, false, false, false, 4 });

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "Locations",
                columns: new[] { "id", "country_id", "description", "is_active", "name" },
                values: new object[] { 1, 158, "Default Location", true, "Main" });

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "WeakPasswords",
                columns: new[] { "id", "password_rule_id", "pattern" },
                values: new object[,]
                {
                    { 1, 1, "P@ssw0rd" },
                    { 2, 1, "password" },
                    { 3, 1, "admin" },
                    { 4, 1, "123456" }
                });

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "Roles",
                columns: new[] { "id", "is_active", "location_id", "name" },
                values: new object[] { 1, true, 1, "Administrator" });

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "Operators",
                columns: new[] { "id", "Companyid", "Departmentid", "Positionid", "email", "firstname", "gender", "is_active", "lastname", "middlename", "mobile", "operator_id", "password", "role_id", "title", "username" },
                values: new object[] { 1, null, null, null, "admin@sentrix.com", "Administrator", "Male", true, "SentriX", "", "", "ADMIN001", "100000.lG1/4V/VRPZsbhf/Zqc4xw==.6vYcf+wEMSgqcaNhoZEdM9PaPxx2ZUErZhQbeMxo5OY=", 1, "Mr", "admin" });

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "Permissions",
                columns: new[] { "id", "feature_id", "is_active", "is_created", "is_deleted", "is_enabled", "is_updated", "role_id" },
                values: new object[,]
                {
                    { 1, 1, true, true, true, true, true, 1 },
                    { 2, 2, true, true, true, true, true, 1 },
                    { 3, 3, true, true, true, true, true, 1 },
                    { 4, 4, true, true, true, true, true, 1 },
                    { 5, 5, true, true, true, true, true, 1 },
                    { 6, 6, true, true, true, true, true, 1 },
                    { 7, 7, true, true, true, true, true, 1 },
                    { 8, 8, true, true, true, true, true, 1 },
                    { 9, 9, true, true, true, true, true, 1 },
                    { 10, 10, true, true, true, true, true, 1 },
                    { 11, 11, true, true, true, true, true, 1 },
                    { 12, 12, true, true, true, true, true, 1 },
                    { 13, 13, true, true, true, true, true, 1 },
                    { 14, 14, true, true, true, true, true, 1 },
                    { 15, 15, true, true, true, true, true, 1 },
                    { 16, 16, true, true, true, true, true, 1 },
                    { 17, 17, true, true, true, true, true, 1 },
                    { 18, 18, true, true, true, true, true, 1 },
                    { 19, 19, true, true, true, true, true, 1 }
                });

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "OperatorLocations",
                columns: new[] { "location_id", "operator_id" },
                values: new object[] { 1, 1 });

            migrationBuilder.CreateIndex(
                name: "IX_Departments_company_id",
                schema: "Identity",
                table: "Departments",
                column: "company_id");

            migrationBuilder.CreateIndex(
                name: "IX_Locations_country_id",
                schema: "Identity",
                table: "Locations",
                column: "country_id");

            migrationBuilder.CreateIndex(
                name: "IX_OperatorLocations_operator_id",
                schema: "Identity",
                table: "OperatorLocations",
                column: "operator_id");

            migrationBuilder.CreateIndex(
                name: "IX_Operators_Companyid",
                schema: "Identity",
                table: "Operators",
                column: "Companyid");

            migrationBuilder.CreateIndex(
                name: "IX_Operators_Departmentid",
                schema: "Identity",
                table: "Operators",
                column: "Departmentid");

            migrationBuilder.CreateIndex(
                name: "IX_Operators_Positionid",
                schema: "Identity",
                table: "Operators",
                column: "Positionid");

            migrationBuilder.CreateIndex(
                name: "IX_Operators_role_id",
                schema: "Identity",
                table: "Operators",
                column: "role_id");

            migrationBuilder.CreateIndex(
                name: "IX_Permissions_feature_id",
                schema: "Identity",
                table: "Permissions",
                column: "feature_id");

            migrationBuilder.CreateIndex(
                name: "IX_Permissions_role_id",
                schema: "Identity",
                table: "Permissions",
                column: "role_id");

            migrationBuilder.CreateIndex(
                name: "IX_Positions_department_id",
                schema: "Identity",
                table: "Positions",
                column: "department_id");

            migrationBuilder.CreateIndex(
                name: "IX_Roles_location_id",
                schema: "Identity",
                table: "Roles",
                column: "location_id");

            migrationBuilder.CreateIndex(
                name: "IX_WeakPasswords_password_rule_id",
                schema: "Identity",
                table: "WeakPasswords",
                column: "password_rule_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApiKeys",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "OperatorLocations",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "Permissions",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "RefreshTokenAudits",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "WeakPasswords",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "Operators",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "Features",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "PasswordRules",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "Positions",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "Roles",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "Departments",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "Locations",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "Companies",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "Countries",
                schema: "Identity");
        }
    }
}
