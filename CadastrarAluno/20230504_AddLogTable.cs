using FluentMigrator;

namespace CadastrarAluno
{

    [Migration(20230504114300)]
    public class AddLogTable : Migration
    {
        public override void Up()
        {
            Create.Table("tb_aluno")
                .WithColumn("Id").AsInt64().PrimaryKey().Identity()
                .WithColumn("Nome Aluno").AsString().NotNullable()
                .WithColumn("CPF").AsString().Unique().NotNullable()
                .WithColumn("Telefone").AsString().NotNullable()
                .WithColumn("Data de Nascimento").AsDateTime().NotNullable();
        }

        public override void Down()
        {
            Delete.Table("tb_aluno");
        }
    }
}
