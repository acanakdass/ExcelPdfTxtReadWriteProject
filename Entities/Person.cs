namespace ReadWriteConsoleApp.Models;

public class Person:IEntity
{
    public string PID { get; set; }
    public string AD { get; set; }
    public string SOYAD { get; set; }
    public string KIMLIKNO { get; set; }
    public string DOGUMYERI { get; set; }
    public string ULKEUYRUK { get; set; }
}