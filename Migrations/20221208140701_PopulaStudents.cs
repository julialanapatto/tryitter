using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace tryitter.Migrations
{
  public partial class PopulaStudents : Migration
  {
    protected override void Up(MigrationBuilder migrationBuilder)
    {
      migrationBuilder.Sql("Insert into Students(Nome, Email, Modulo, Status, Senha, ImagemUrl) Values ('Julia', 'julia@email.com.br', 'xpA', 'finalizando aceleração', 'minhasenhasecreta',  'https://pbs.twimg.com/media/EIDd9qLU0AAyPN4.jpg')");

      migrationBuilder.Sql("Insert into Students(Nome, Email, Modulo, Status, Senha, ImagemUrl) Values ('Kleicyanny', 'kleicyanny@email.com.br', 'xpB', 'finalizando aceleração', 'minhasenha', 'https://i.pinimg.com/236x/33/32/6d/33326dcddbf15c56d631e374b62338dc.jpg')");
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.Sql("Delete from Students");
    }
  }
}
