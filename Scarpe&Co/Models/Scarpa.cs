using System.Collections.Generic;


public class Scarpa
{
    public string Nome { get; set; }
    public decimal Prezzo { get; set; }
    public string Descrizione { get; set; }
    public string imgCopertina { get; set; }
    public List<string> imgAggiuntive { get; set; }

    // Costruttore vuoto
    public Scarpa() { }

    // Costruttore con tutti parametri
    public Scarpa(string nome, decimal prezzo, string descrizione, string imgCopertina, List<string> imgAggiuntive)
    {
        Nome = nome;
        Prezzo = prezzo;
        Descrizione = descrizione;
        this.imgCopertina = imgCopertina;
        this.imgAggiuntive = imgAggiuntive;
    }

    // Costruttore senza immagini aggiuntive
    public Scarpa(string nome, decimal prezzo, string descrizione, string imgCopertina)
    {
        Nome = nome;
        Prezzo = prezzo;
        Descrizione = descrizione;
        this.imgCopertina = imgCopertina;
    }

    // Metodo per aggiungere un'immagine aggiuntiva
    public void AggiungiImmagineAggiuntiva(string immagine)
    {
        if (imgAggiuntive == null)
        {
            imgAggiuntive = new List<string>();
        }
        imgAggiuntive.Add(immagine);
    }

}
