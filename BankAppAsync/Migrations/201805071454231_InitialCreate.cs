namespace BankAppAsync.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Accounts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Currency = c.String(),
                        Balance = c.Double(nullable: false),
                        ClientId = c.Int(nullable: false),
                        BankId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Banks", t => t.BankId, cascadeDelete: true)
                .ForeignKey("dbo.Clients", t => t.ClientId, cascadeDelete: true)
                .Index(t => t.ClientId)
                .Index(t => t.BankId);
            
            CreateTable(
                "dbo.Banks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Clients",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IIN = c.String(),
                        Name = c.String(),
                        Surname = c.String(),
                        PasswordHash = c.String(),
                        Bank_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Banks", t => t.Bank_Id)
                .Index(t => t.Bank_Id);
            
            CreateTable(
                "dbo.Transactions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Time = c.DateTime(nullable: false),
                        Sum = c.Double(nullable: false),
                        AccountId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Accounts", t => t.AccountId, cascadeDelete: true)
                .Index(t => t.AccountId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Transactions", "AccountId", "dbo.Accounts");
            DropForeignKey("dbo.Accounts", "ClientId", "dbo.Clients");
            DropForeignKey("dbo.Accounts", "BankId", "dbo.Banks");
            DropForeignKey("dbo.Clients", "Bank_Id", "dbo.Banks");
            DropIndex("dbo.Transactions", new[] { "AccountId" });
            DropIndex("dbo.Clients", new[] { "Bank_Id" });
            DropIndex("dbo.Accounts", new[] { "BankId" });
            DropIndex("dbo.Accounts", new[] { "ClientId" });
            DropTable("dbo.Transactions");
            DropTable("dbo.Clients");
            DropTable("dbo.Banks");
            DropTable("dbo.Accounts");
        }
    }
}
