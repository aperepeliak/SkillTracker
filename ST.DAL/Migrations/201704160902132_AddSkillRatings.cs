namespace ST.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddSkillRatings : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SkillRatings",
                c => new
                    {
                        SkillId = c.Int(nullable: false),
                        DeveloperId = c.String(nullable: false, maxLength: 128),
                        Rating = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.SkillId, t.DeveloperId })
                .ForeignKey("dbo.Developers", t => t.DeveloperId, cascadeDelete: true)
                .ForeignKey("dbo.Skills", t => t.SkillId, cascadeDelete: true)
                .Index(t => t.SkillId)
                .Index(t => t.DeveloperId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SkillRatings", "SkillId", "dbo.Skills");
            DropForeignKey("dbo.SkillRatings", "DeveloperId", "dbo.Developers");
            DropIndex("dbo.SkillRatings", new[] { "DeveloperId" });
            DropIndex("dbo.SkillRatings", new[] { "SkillId" });
            DropTable("dbo.SkillRatings");
        }
    }
}
