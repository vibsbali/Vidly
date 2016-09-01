namespace Vidly.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class AddedGenre : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Movies",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Name = c.String(nullable: false),
                    ReleaseDate = c.DateTime(nullable: false),
                    DateAdded = c.DateTime(nullable: false),
                    StockLevel = c.Int(nullable: false),
                    GenreId = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Genres", t => t.GenreId, cascadeDelete: true)
                .Index(t => t.GenreId);

            CreateTable(
                "dbo.Genres",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Description = c.String(),
                })
                .PrimaryKey(t => t.Id);

            Sql("INSERT INTO dbo.Genres VALUES ('Comedy')");
            Sql("INSERT INTO dbo.Genres VALUES ('Action')");
            Sql("INSERT INTO dbo.Genres VALUES ('Family')");
            Sql("INSERT INTO dbo.Genres VALUES ('Romance')");
        }

        public override void Down()
        {
            DropForeignKey("dbo.Movies", "GenreId", "dbo.Genres");
            DropIndex("dbo.Movies", new[] { "GenreId" });
            DropTable("dbo.Genres");
            DropTable("dbo.Movies");
        }
    }
}
