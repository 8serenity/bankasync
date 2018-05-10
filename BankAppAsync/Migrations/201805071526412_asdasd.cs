namespace BankAppAsync.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class asdasd : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Accounts", "BankId", "dbo.Banks");
            DropIndex("dbo.Accounts", new[] { "BankId" });
            DropColumn("dbo.Accounts", "BankId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Accounts", "BankId", c => c.Int(nullable: false));
            CreateIndex("dbo.Accounts", "BankId");
            AddForeignKey("dbo.Accounts", "BankId", "dbo.Banks", "Id", cascadeDelete: true);
        }
    }
}
