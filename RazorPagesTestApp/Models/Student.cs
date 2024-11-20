using System.ComponentModel.DataAnnotations.Schema;

namespace RazorPagesTestApp.Models;

public class Student
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }

    [NotMapped]
    public string FullName => $"{LastName} {FirstName}";

    public DateTime LastLoggedIn { get; set; }
    public PresenceStatus PresenceType { get; set; }
    public bool IsOnline { get; set; }
    public int Grade { get; set; }
    public int DiamondsCount { get; set; }
    public string? Comment { get; set; }
}