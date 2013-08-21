namespace StudentSystem.DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        StudentId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Age = c.Int(nullable: false),
                        Grade = c.Int(nullable: false),
                        School_SchoolId = c.Int(),
                    })
                .PrimaryKey(t => t.StudentId)
                .ForeignKey("dbo.Schools", t => t.School_SchoolId)
                .Index(t => t.School_SchoolId);
            
            CreateTable(
                "dbo.Marks",
                c => new
                    {
                        MarkId = c.Int(nullable: false, identity: true),
                        Subject = c.String(),
                        Value = c.Double(nullable: false),
                        Student_StudentId = c.Int(),
                    })
                .PrimaryKey(t => t.MarkId)
                .ForeignKey("dbo.Students", t => t.Student_StudentId)
                .Index(t => t.Student_StudentId);
            
            CreateTable(
                "dbo.Schools",
                c => new
                    {
                        SchoolId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Location = c.String(),
                    })
                .PrimaryKey(t => t.SchoolId);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.Marks", new[] { "Student_StudentId" });
            DropIndex("dbo.Students", new[] { "School_SchoolId" });
            DropForeignKey("dbo.Marks", "Student_StudentId", "dbo.Students");
            DropForeignKey("dbo.Students", "School_SchoolId", "dbo.Schools");
            DropTable("dbo.Schools");
            DropTable("dbo.Marks");
            DropTable("dbo.Students");
        }
    }
}
