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
                .WithColumn("Nome Aluno").AsString()
                .WithColumn("CPF").AsString()
                .WithColumn("Telefone").AsString()
                .WithColumn("Data de Nascimento").AsDateTime();
        }

        public override void Down()
        {
            Delete.Table("tb_aluno");
        }
    }
}
