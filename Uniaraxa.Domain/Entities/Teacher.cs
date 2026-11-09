namespace Uniaraxa.Domain.Entities;

public class Teacher
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string EMail { get; set; } = string.Empty;
    public string UrlLattes { get; set; } = string.Empty;
    public DateTime DataAdmissao { get; set; }
}
