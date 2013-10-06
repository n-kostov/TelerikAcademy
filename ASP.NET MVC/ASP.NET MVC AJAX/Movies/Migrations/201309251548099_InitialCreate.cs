namespace Movies.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Actors",
                c => new
                    {
                        ActorId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        IsMale = c.Boolean(nullable: false),
                        Age = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ActorId);
            
            CreateTable(
                "dbo.Movies",
                c => new
                    {
                        MovieId = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Director = c.String(),
                        Year = c.DateTime(nullable: false),
                        Studio = c.String(),
                        StudioAddress = c.String(),
                        LeadingMaleActor_ActorId = c.Int(),
                        LeadingFemaleActor_ActorId = c.Int(),
                    })
                .PrimaryKey(t => t.MovieId)
                .ForeignKey("dbo.Actors", t => t.LeadingMaleActor_ActorId)
                .ForeignKey("dbo.Actors", t => t.LeadingFemaleActor_ActorId)
                .Index(t => t.LeadingMaleActor_ActorId)
                .Index(t => t.LeadingFemaleActor_ActorId);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.Movies", new[] { "LeadingFemaleActor_ActorId" });
            DropIndex("dbo.Movies", new[] { "LeadingMaleActor_ActorId" });
            DropForeignKey("dbo.Movies", "LeadingFemaleActor_ActorId", "dbo.Actors");
            DropForeignKey("dbo.Movies", "LeadingMaleActor_ActorId", "dbo.Actors");
            DropTable("dbo.Movies");
            DropTable("dbo.Actors");
        }
    }
}
