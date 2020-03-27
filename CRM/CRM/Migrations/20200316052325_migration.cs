using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CRM.Migrations
{
    public partial class migration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Houses",
                columns: table => new
                {
                    H_ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    H_Name = table.Column<string>(unicode: false, maxLength: 20, nullable: false),
                    H_Remark = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    H_MaleOrFemale = table.Column<byte>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Houses", x => x.H_ID);
                });

            migrationBuilder.CreateTable(
                name: "Provinces",
                columns: table => new
                {
                    P_ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    P_Name = table.Column<string>(unicode: false, maxLength: 20, nullable: false),
                    P_Remark = table.Column<string>(unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Provinces", x => x.P_ID);
                });

            migrationBuilder.CreateTable(
                name: "RoomCategories",
                columns: table => new
                {
                    RC_ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RC_Name = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    RC_Count = table.Column<byte>(nullable: true),
                    RC_MoneyPerMonth = table.Column<decimal>(type: "decimal(18, 0)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomCategories", x => x.RC_ID);
                });

            migrationBuilder.CreateTable(
                name: "Specialties",
                columns: table => new
                {
                    Specialty_ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Specialty_Name = table.Column<string>(unicode: false, maxLength: 100, nullable: false),
                    Specialty_Description = table.Column<string>(unicode: false, maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Specialties", x => x.Specialty_ID);
                });

            migrationBuilder.CreateTable(
                name: "Stations",
                columns: table => new
                {
                    Station_ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Station_Name = table.Column<string>(unicode: false, maxLength: 20, nullable: false),
                    Station_Duty = table.Column<string>(unicode: false, maxLength: 300, nullable: false),
                    Station_NeedTechnique = table.Column<string>(unicode: false, maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stations", x => x.Station_ID);
                });

            migrationBuilder.CreateTable(
                name: "Teachers",
                columns: table => new
                {
                    T_ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    T_Name = table.Column<string>(unicode: false, maxLength: 20, nullable: false),
                    T_Sex = table.Column<string>(unicode: false, maxLength: 2, nullable: false),
                    T_Tel = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    T_Category = table.Column<byte>(nullable: false),
                    T_LoginName = table.Column<string>(unicode: false, maxLength: 20, nullable: false),
                    T_Pwd = table.Column<string>(unicode: false, maxLength: 20, nullable: false),
                    T_Role = table.Column<byte>(nullable: false),
                    T_IsEnabled = table.Column<bool>(nullable: false),
                    T_LastLoginTime = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teachers", x => x.T_ID);
                });

            migrationBuilder.CreateTable(
                name: "TrainClasses",
                columns: table => new
                {
                    TC_ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TC_Name = table.Column<string>(unicode: false, maxLength: 20, nullable: false),
                    TC_Grade = table.Column<string>(unicode: false, maxLength: 20, nullable: false),
                    TC_BeginTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    TC_EndTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    TC_MaxAmount = table.Column<byte>(nullable: false),
                    TC_MaleAmount = table.Column<byte>(nullable: true),
                    TC_FemaleAmount = table.Column<byte>(nullable: true),
                    TC_Period = table.Column<byte>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrainClasses", x => x.TC_ID);
                });

            migrationBuilder.CreateTable(
                name: "Floors",
                columns: table => new
                {
                    F_ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    H_ID = table.Column<int>(nullable: true),
                    F_Name = table.Column<string>(unicode: false, maxLength: 20, nullable: false),
                    F_Remark = table.Column<string>(unicode: false, maxLength: 200, nullable: true),
                    F_MaleOrFemale = table.Column<byte>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Floors", x => x.F_ID);
                    table.ForeignKey(
                        name: "FK_FLOORS_REFERENCE_HOUSES",
                        column: x => x.H_ID,
                        principalTable: "Houses",
                        principalColumn: "H_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Schools",
                columns: table => new
                {
                    School_ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    P_ID = table.Column<int>(nullable: true),
                    School_Code = table.Column<string>(unicode: false, maxLength: 10, nullable: false),
                    School_Name = table.Column<string>(unicode: false, maxLength: 30, nullable: false),
                    School_Remark = table.Column<string>(unicode: false, maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Schools", x => x.School_ID);
                    table.ForeignKey(
                        name: "FK_SCHOOLS_REFERENCE_PROVINCE",
                        column: x => x.P_ID,
                        principalTable: "Provinces",
                        principalColumn: "P_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OperationLogs",
                columns: table => new
                {
                    PL_ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    T_ID = table.Column<int>(nullable: true),
                    PL_TableName = table.Column<string>(unicode: false, maxLength: 20, nullable: true),
                    PL_Operation = table.Column<string>(unicode: false, maxLength: 20, nullable: true),
                    PL_Description = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    PL_Time = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OperationLogs", x => x.PL_ID);
                    table.ForeignKey(
                        name: "FK_OPERATIO_REFERENCE_TEACHERS",
                        column: x => x.T_ID,
                        principalTable: "Teachers",
                        principalColumn: "T_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Rooms",
                columns: table => new
                {
                    R_ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    F_ID = table.Column<int>(nullable: true),
                    RC_ID = table.Column<int>(nullable: true),
                    R_Name = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    R_MaleOrFemale = table.Column<byte>(nullable: true),
                    R_IsHasFull = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rooms", x => x.R_ID);
                    table.ForeignKey(
                        name: "FK_ROOMS_REFERENCE_FLOORS",
                        column: x => x.F_ID,
                        principalTable: "Floors",
                        principalColumn: "F_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ROOMS_REFERENCE_ROOMCATE",
                        column: x => x.RC_ID,
                        principalTable: "RoomCategories",
                        principalColumn: "RC_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SchoolClasses",
                columns: table => new
                {
                    SC_ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    School_ID = table.Column<int>(nullable: true),
                    Specialty_ID = table.Column<int>(nullable: true),
                    SC_Name = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    SC_FemaleAmount = table.Column<int>(nullable: true),
                    SC_MaleAmount = table.Column<int>(nullable: true),
                    SC_Teacher = table.Column<string>(unicode: false, maxLength: 20, nullable: true),
                    SC_Supervisor = table.Column<string>(unicode: false, maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SchoolClasses", x => x.SC_ID);
                    table.ForeignKey(
                        name: "FK_SCHOOLCL_REFERENCE_SCHOOLS",
                        column: x => x.School_ID,
                        principalTable: "Schools",
                        principalColumn: "School_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SCHOOLCL_REFERENCE_SPECIALT",
                        column: x => x.Specialty_ID,
                        principalTable: "Specialties",
                        principalColumn: "Specialty_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SelectStationPeriods",
                columns: table => new
                {
                    SSP_ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    School_ID = table.Column<int>(nullable: true),
                    Specialty_ID = table.Column<int>(nullable: true),
                    SSP_PreachDate = table.Column<DateTime>(type: "date", nullable: false),
                    SSP_OverDay = table.Column<byte>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SelectStationPeriods", x => x.SSP_ID);
                    table.ForeignKey(
                        name: "FK_SELECTST_REFERENCE_SCHOOLS",
                        column: x => x.School_ID,
                        principalTable: "Schools",
                        principalColumn: "School_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SELECTST_REFERENCE_SPECIALT",
                        column: x => x.Specialty_ID,
                        principalTable: "Specialties",
                        principalColumn: "Specialty_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Student_ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    SC_ID = table.Column<int>(nullable: true),
                    Student_NO = table.Column<string>(unicode: false, maxLength: 20, nullable: true),
                    Student_Name = table.Column<string>(unicode: false, maxLength: 10, nullable: true),
                    Student_NameSpell = table.Column<string>(unicode: false, maxLength: 20, nullable: true),
                    Student_Sex = table.Column<string>(unicode: false, maxLength: 5, nullable: true),
                    Student_IdentityNumber = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    Student_State = table.Column<string>(unicode: false, maxLength: 20, nullable: true),
                    Student_Exam = table.Column<string>(unicode: false, maxLength: 20, nullable: true),
                    Student_Education = table.Column<string>(unicode: false, maxLength: 20, nullable: true),
                    Student_Specialty = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    Student_Schoolofgraduation = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    Student_PersonalTel = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    Student_FamilyTel = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    Student_QQ = table.Column<string>(unicode: false, maxLength: 20, nullable: true),
                    Student_Address = table.Column<string>(unicode: false, maxLength: 80, nullable: true),
                    Student_PostCode = table.Column<string>(unicode: false, maxLength: 10, nullable: true),
                    Student_EducationMoney = table.Column<string>(unicode: false, maxLength: 20, nullable: true),
                    Student_SkillTrainingMoney = table.Column<string>(unicode: false, maxLength: 20, nullable: true),
                    Student_TrainResideMoney = table.Column<string>(unicode: false, maxLength: 20, nullable: true),
                    Student_Evaluate1 = table.Column<string>(unicode: false, maxLength: 500, nullable: true),
                    Student_Evaluate2 = table.Column<string>(unicode: false, maxLength: 500, nullable: true),
                    Student_Remark = table.Column<string>(unicode: false, maxLength: 500, nullable: true),
                    Station_ID = table.Column<int>(nullable: true),
                    Stationt_SelectStationCount = table.Column<byte>(nullable: true, defaultValueSql: "((0))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Student_ID);
                    table.ForeignKey(
                        name: "FK_STUDENTS_REFERENCE_SCHOOLCL",
                        column: x => x.SC_ID,
                        principalTable: "SchoolClasses",
                        principalColumn: "SC_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_STUDENTS_REFERENCE_STATIONS",
                        column: x => x.Station_ID,
                        principalTable: "Stations",
                        principalColumn: "Station_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Floors_H_ID",
                table: "Floors",
                column: "H_ID");

            migrationBuilder.CreateIndex(
                name: "IX_OperationLogs_T_ID",
                table: "OperationLogs",
                column: "T_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_F_ID",
                table: "Rooms",
                column: "F_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_RC_ID",
                table: "Rooms",
                column: "RC_ID");

            migrationBuilder.CreateIndex(
                name: "IX_SchoolClasses_School_ID",
                table: "SchoolClasses",
                column: "School_ID");

            migrationBuilder.CreateIndex(
                name: "IX_SchoolClasses_Specialty_ID",
                table: "SchoolClasses",
                column: "Specialty_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Schools_P_ID",
                table: "Schools",
                column: "P_ID");

            migrationBuilder.CreateIndex(
                name: "IX_SelectStationPeriods_School_ID",
                table: "SelectStationPeriods",
                column: "School_ID");

            migrationBuilder.CreateIndex(
                name: "IX_SelectStationPeriods_Specialty_ID",
                table: "SelectStationPeriods",
                column: "Specialty_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Students_SC_ID",
                table: "Students",
                column: "SC_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Students_Station_ID",
                table: "Students",
                column: "Station_ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OperationLogs");

            migrationBuilder.DropTable(
                name: "Rooms");

            migrationBuilder.DropTable(
                name: "SelectStationPeriods");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "TrainClasses");

            migrationBuilder.DropTable(
                name: "Teachers");

            migrationBuilder.DropTable(
                name: "Floors");

            migrationBuilder.DropTable(
                name: "RoomCategories");

            migrationBuilder.DropTable(
                name: "SchoolClasses");

            migrationBuilder.DropTable(
                name: "Stations");

            migrationBuilder.DropTable(
                name: "Houses");

            migrationBuilder.DropTable(
                name: "Schools");

            migrationBuilder.DropTable(
                name: "Specialties");

            migrationBuilder.DropTable(
                name: "Provinces");
        }
    }
}
