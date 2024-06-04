using KampfsportVerwaltung.Models;
using Npgsql;

namespace KampfsportVerwaltung.Repositories;

public class KaempferRepository
{

    private NpgsqlConnection ConnectToDB()
    {
        string connectionString = "Host=localhost;Database=Kampfsportverwaltung;User Id=dbuser;Password=dbuser;";
        NpgsqlConnection connection = new NpgsqlConnection(connectionString);
        
        connection.Open();
        return connection;
    }
    public List<Kaempfer> GetAllKaempfer()
        {

        NpgsqlConnection myConnection = ConnectToDB();
        
        using NpgsqlCommand cmd = new NpgsqlCommand(cmdText:"select * from kaempfer", myConnection);

        using NpgsqlDataReader reader = cmd.ExecuteReader();

        List <Kaempfer> kaempfers = new List<Kaempfer>();
        

        while (reader.Read())
        {
            Kaempfer newKaempfer = new Kaempfer();
            newKaempfer.kaempferId = (int)reader["kaempferId"];
            newKaempfer.vorname = (string)reader["vorname"];
            newKaempfer.nachname = (string)reader["nachname"];
            newKaempfer.herkunft = (string)reader["herkunft"];
            newKaempfer.alter = (int)reader["alter"];
            newKaempfer.geschlecht = (string)reader["geschlecht"];
            newKaempfer.gewicht = (decimal)reader["gewicht"];
            
            kaempfers.Add(newKaempfer);
        }
        
        myConnection.Close();
        return kaempfers;
    }

    public void CreatKaempfer(Kaempfer kaempfer)
    {
        NpgsqlConnection myConnection = ConnectToDB();
        
        using NpgsqlCommand cmd = new NpgsqlCommand(
            "INSERT INTO Kaempfer (Vorname, Nachname, Herkunft, Alter, Geschlecht, Gewicht) VALUES (:v1,:v2,:v3,:v4,:v5,:v6)", myConnection);
        cmd.Parameters.AddWithValue("v1", kaempfer.vorname);
        cmd.Parameters.AddWithValue("v2", kaempfer.nachname);
        cmd.Parameters.AddWithValue("v3", kaempfer.herkunft);
        cmd.Parameters.AddWithValue("v4", kaempfer.alter);
        cmd.Parameters.AddWithValue("v5", kaempfer.geschlecht);
        cmd.Parameters.AddWithValue("v6", kaempfer.gewicht);
        

        int rowsAffected = cmd.ExecuteNonQuery();
        myConnection.Close();
    }
    
    public void DeleteKaempfer(int kaempferId)
    {
        
    }

    public void UpdateKampfer(Kaempfer kaempfer)
    {
        
    }
}