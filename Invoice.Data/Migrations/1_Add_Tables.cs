using FluentMigrator;

namespace Invoice.Data.Migrations
{
    [Migration(1)]
    public class AddTables : Migration
    {
        public override void Up()
        {
            Create.Table("contracts")
                .WithColumn("id_contract").AsGuid().PrimaryKey()
                .WithColumn("description").AsString()
                .WithColumn("amount").AsDecimal()
                .WithColumn("periods").AsInt32()
                .WithColumn("date").AsDateTime();
            Create.Table("payments")
                .WithColumn("id_payment").AsGuid().PrimaryKey()
                .WithColumn("id_contract").AsGuid().ForeignKey("contracts", "id_contract")
                .WithColumn("amount").AsInt32()
                .WithColumn("date").AsDateTime();
        }

        public override void Down()
        {
            Delete.Table("payments");
            Delete.Table("contracts");
        }
    }
}
