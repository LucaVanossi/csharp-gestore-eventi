// See https://aka.ms/new-console-template for more information

using GestoreEventi;

Console.WriteLine("Prego inserisci il tuo evento");

Console.WriteLine("Inserisci il nome dell'evento: ");
string TitoloEvento = Console.ReadLine();

Console.WriteLine("Inserisci la data dell'evento: ");
DateTime DataEvento = DateTime.Parse(Console.ReadLine());

Console.WriteLine("Inserisci il numero di posti totali: ");
int NumeroPostiTotaliEvento = Int32.Parse(Console.ReadLine());

Console.WriteLine("Quanti posti desideri prenotare? ");
int numeroPostiEventoPrenotati = Int32.Parse(Console.ReadLine());

Evento eventoNuovo = new Evento(TitoloEvento, DataEvento, NumeroPostiTotaliEvento);
Console.WriteLine(eventoNuovo.ToString());

Console.WriteLine("Numero di posti prenotati= " + numeroPostiEventoPrenotati);
eventoNuovo.PrenotaPosti(numeroPostiEventoPrenotati);

Console.WriteLine("Vuoi disdire dei posti (si/no)?");
int PostidaDisdire = 0;
while ((Console.ReadLine() == "si"))
{
    Console.WriteLine("Indicare il numero di posti da disdire: ");
    PostidaDisdire = Int32.Parse(Console.ReadLine());
    if (PostidaDisdire < numeroPostiEventoPrenotati)
    {
        Console.WriteLine("Numero di posti prenotati= " + (numeroPostiEventoPrenotati - PostidaDisdire));
        eventoNuovo.DisdiciPosti(PostidaDisdire);
    }
    else 
    {  
        Console.WriteLine("Hai esaurito i posti!");
    }
}
Console.WriteLine("Ok va bene!");
Console.WriteLine("Numero di posti prenotati= " + (numeroPostiEventoPrenotati - PostidaDisdire));
eventoNuovo.PrenotaPosti(numeroPostiEventoPrenotati - PostidaDisdire);

Console.ReadKey();
Console.Clear();

Console.WriteLine("Nome programma eventi");
string NomeEvento = Console.ReadLine();

Console.WriteLine("Numero eventi");
int  NrEventi = Int32.Parse(Console.ReadLine());
for (int i = 0; i < NrEventi; i++)
{
    Console.WriteLine("Inserisci il nome dell'evento: ");
    string TitoloEventoN = Console.ReadLine();

    Console.WriteLine("Inserisci la data dell'evento: ");
    DateTime DataEventoN = DateTime.Parse(Console.ReadLine());

    Console.WriteLine("Inserisci il numero di posti totali: ");
    int NumeroPostiTotaliEventoN = Int32.Parse(Console.ReadLine());

    Evento AggiungiEvento = new Evento(TitoloEventoN, DataEventoN, NumeroPostiTotaliEventoN);

    Console.WriteLine(AggiungiEvento.ToString());
    
    //Console.WriteLine(NumeroEventiInProgramma);

}




