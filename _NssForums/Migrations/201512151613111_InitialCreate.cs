namespace _NssForums.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Message = c.String(),
                        Username = c.String(),
                        DatePosted = c.DateTime(nullable: false),
                        ParentPost_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Posts", t => t.ParentPost_Id)
                .Index(t => t.ParentPost_Id);
            
            CreateTable(
                "dbo.Posts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Message = c.String(),
                        Username = c.String(),
                        DatePosted = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Comments", "ParentPost_Id", "dbo.Posts");
            DropIndex("dbo.Comments", new[] { "ParentPost_Id" });
            DropTable("dbo.Posts");
            DropTable("dbo.Comments");
        }
    }
}
