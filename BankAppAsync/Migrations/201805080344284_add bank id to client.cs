namespace BankAppAsync.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addbankidtoclient : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Clients", "Bank_Id", "dbo.Banks");
            DropIndex("dbo.Clients", new[] { "Bank_Id" });
            RenameColumn(table: "dbo.Clients", name: "Bank_Id", newName: "BankId");
            AlterColumn("dbo.Clients", "BankId", c => c.Int(nullable: false));
            CreateIndex("dbo.Clients", "BankId");
            AddForeignKey("dbo.Clients", "BankId", "dbo.Banks", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Clients", "BankId", "dbo.Banks");
            DropIndex("dbo.Clients", new[] { "BankId" });
            AlterColumn("dbo.Clients", "BankId", c => c.Int());
            RenameColumn(table: "dbo.Clients", name: "BankId", newName: "Bank_Id");
            CreateIndex("dbo.Clients", "Bank_Id");
            AddForeignKey("dbo.Clients", "Bank_Id", "dbo.Banks", "Id");
        }
    }
}
