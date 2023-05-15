using FluentMigrator;

namespace Infra
{

    [Migration(20230504114300)]
    public class AddLogTable : Migration
    {
        public override void Up()
        {
            Create.Table("Aluno")
                .WithColumn("Id").AsInt64().PrimaryKey().Identity()
                .WithColumn("Nome").AsString().NotNullable()
                .WithColumn("Cpf").AsString().Unique().NotNullable()
                .WithColumn("Telefone").AsString().NotNullable()
                .WithColumn("Nascimento").AsDateTime().NotNullable();
        }
        public override void Down()
        {
            Delete.Table("Aluno");
        }
    }
}
