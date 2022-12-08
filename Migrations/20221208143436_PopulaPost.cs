using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace tryitter.Migrations
{
  public partial class PopulaPost : Migration
  {
    protected override void Up(MigrationBuilder migrationBuilder)
    {
      migrationBuilder.Sql("Insert into Post(Descricao, imagemUrl, StudentId)" + "Values ('A trybe e a xp: Tudo certo agora que entregou os projetos?', 'https://pbs.twimg.com/media/EIDd9qLU0AAyPN4.jpg', 1)");

      migrationBuilder.Sql("Insert into Post(Descricao, imagemUrl, StudentId)" + "Values ('A trybe e a xp: em qual projeto de tecnologia você sonha trabalhar?', 'https://i.pinimg.com/236x/33/32/6d/33326dcddbf15c56d631e374b62338dc.jpg', 2)");
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.Sql("Delete from Post");
    }
  }
}
