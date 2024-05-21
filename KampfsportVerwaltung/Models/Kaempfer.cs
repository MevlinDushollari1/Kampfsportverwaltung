namespace KampfsportVerwaltung.Models;

public class Kaempfer
{
    public int kaempferId { get; set; }
    public string vorname { get; set; }
    public string nachname { get; set; }
    public string herkunft { get; set; }
    public int alter { get; set; }
    public string geschlecht { get; set; }
    public decimal gewicht { get; set; }
    
}