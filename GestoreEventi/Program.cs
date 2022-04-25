// See https://aka.ms/new-console-template for more information

using GestoreEventi;

Console.WriteLine("Prego inserisci il tuo evento");
string TitoloEvento = "";
while (string.IsNullOrEmpty(TitoloEvento))
{
    Console.Write("Inserisci il nome dell'evento: ");
    TitoloEvento = Console.ReadLine();
}

bool DataCorretta = false;
DateTime DataEvento = DateTime.Now;
while (!DataCorretta)
{
    Console.Write("Inserisci la data nel formato gg/mm/aaaa: ");
    string sdataEvento = Console.ReadLine();
    try
    {
        DataEvento = Errori.DataValida(sdataEvento);
        DataCorretta = true;
        if (DataEvento < DateTime.Now)
        {
            Console.WriteLine("Data minore di oggi ");
            DataCorretta = false;
        }
    }
    catch (Exception e)
    {
        Console.WriteLine(e.Message);
    }

}

int NumeroPostiTotaliEvento = Errori.numeroValido("Numero Posti Totali Evento: ");
int numeroPostiEventoPrenotati = 0;
numeroPostiEventoPrenotati = Errori.numeroValido("Quanti posti desideri prenotare? ");

while (numeroPostiEventoPrenotati > NumeroPostiTotaliEvento)
{
    Console.WriteLine("I posti prenotati sono maggiori dei posti totali dell'evento!");
    numeroPostiEventoPrenotati = Errori.numeroValido("Quanti posti desideri prenotare? ");
}

Evento eventoNuovo = new Evento(TitoloEvento, DataEvento, NumeroPostiTotaliEvento);


Console.WriteLine("---------------------------");
Console.Write(eventoNuovo.ToString());
Console.WriteLine("---------------------------");

Console.WriteLine("Numero di posti prenotati= " + numeroPostiEventoPrenotati);
eventoNuovo.PrenotaPosti(numeroPostiEventoPrenotati);

int PostidaDisdire = 0;
Console.WriteLine("Vuoi disdire dei posti (si)?");

while ((Console.ReadLine() == "si"))
{

    PostidaDisdire = Errori.numeroValido("Indicare il numero di posti da disdire: ");
    if (PostidaDisdire < numeroPostiEventoPrenotati)
    {
        Console.WriteLine("Numero di posti prenotati= " + (numeroPostiEventoPrenotati - PostidaDisdire));
        eventoNuovo.DisdiciPosti(PostidaDisdire);
        Console.WriteLine("Vuoi disdire dei posti (si)?");
    }
    else
    {
        Console.WriteLine("Hai esaurito i posti!");
    }
}
Console.WriteLine("Ok va bene!");

Console.WriteLine("Numero posti prenotati: " + eventoNuovo.GetNumeroPostiEventoPrenotati());
Console.WriteLine("Numero posti disponibili: " + eventoNuovo.GetNumeroPostiDisponibili());


Console.ReadKey();
Console.Clear();

Console.WriteLine("Inserisci il nome del tuo programma Eventi");
string nomeProgrammaEvento = "";
while (string.IsNullOrEmpty(nomeProgrammaEvento))
{
    Console.Write("Inserisci il nome dell'evento: ");
    nomeProgrammaEvento = Console.ReadLine();
}

ProgrammaEventi eventi = new ProgrammaEventi(nomeProgrammaEvento);
eventi.aggiungiEventi();
eventi.StampaListaEventi();


bool dataCorretta = false;
DateTime dataEvento = DateTime.Now;
while (!dataCorretta)
{
    Console.Write("Inserisci una data da cercare nel formato gg/mm/aaaa: ");
    string sdataEventoUno = Console.ReadLine();
    try
    {
        dataEvento = Errori.DataValida(sdataEventoUno);
        dataCorretta = true;
        if (dataEvento < DateTime.Now)
        {
            Console.WriteLine("Data minore di oggi ");
            dataCorretta = false;
        }
    }
    catch (Exception e)
    {
        Console.WriteLine(e.Message);
    }

}

eventi.EventoDateUguali(dataEvento);




