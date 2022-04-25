using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestoreEventi
{
    static class Errori
    {
        public static DateTime DataValida(string dataStringa)
        {
            try
            {
                DateTime dateTime = DateTime.Parse(dataStringa);
                return dateTime;
            }
            catch (Exception)
            {
                throw new Exception("Data errata !");
            }

        }
        public static bool ControllaData(DateTime data)
        {
            bool dataGiusta = true;
            if (data < DateTime.Now)
            {
                dataGiusta = false;
                Console.WriteLine("La data non può essere inferiore a quella di oggi! ");
            }
            return dataGiusta;
        }

        public static int numeroValido(string messaggio)
        {
            int numero = 0;
            while (numero == 0)
            {
                Console.Write(messaggio);
                numero = int.TryParse(Console.ReadLine(), out numero) ? numero : 0;
            }
            return numero;
        }


    }

    public class Evento
    {
        public string TitoloEvento;
        public DateTime DataEvento;
        private int NumeroPostiTotaliEvento;
        private int NumeroPostiEventoPrenotati = 0;


        public Evento(string TitoloEvento, DateTime DataEvento, int NumeroPostiTotaliEvento)
        {
            this.TitoloEvento = TitoloEvento;
            this.DataEvento = DataEvento;
            this.NumeroPostiTotaliEvento = NumeroPostiTotaliEvento;
        }

        public int GetNumeroPostiDisponibili()
        {
            int numeroPostiDisponibili = NumeroPostiTotaliEvento - NumeroPostiEventoPrenotati;
            return numeroPostiDisponibili;
        }

        public int GetNumeroPostiTotaliEvento()
        {
            return NumeroPostiTotaliEvento;
        }

        public int GetNumeroPostiEventoPrenotati()
        {
            return NumeroPostiEventoPrenotati;
        }

        public DateTime GetDataEvento()
        {
            return this.DataEvento;
        }




        public void ControllaTitolo(string TitoloEvento)
        {
            if (String.IsNullOrEmpty(TitoloEvento))
            {
                Console.WriteLine("Inserisci un titolo corretto");
            }
        }

        public void ControllaPosti(int NumeroPosti)
        {
            if (NumeroPosti < 0)
            {
                Console.WriteLine("Inserisci un numero di posti maggiore di 0");
            }
        }

        public int PrenotaPosti(int PostiVoluti)
        {
            // verifica se non sto prenotando oltre il totale, l'evento non deve essere già passato
            this.NumeroPostiEventoPrenotati = this.NumeroPostiEventoPrenotati + PostiVoluti;

            int NumeroPostiaDisposizione = NumeroPostiTotaliEvento - PostiVoluti;
            //Console.WriteLine("Numero posti a disposizione " + NumeroPostiaDisposizione);
            return NumeroPostiaDisposizione;
        }

        public int DisdiciPosti(int PostiDaDisdire)
        {
            // non devo andare sotto zero, l'evento non deve essere già passato
            this.NumeroPostiEventoPrenotati = this.NumeroPostiEventoPrenotati - PostiDaDisdire;

            int NumeroPostiaDisposizione = NumeroPostiTotaliEvento - PostiDaDisdire;
            Console.WriteLine("Numero posti a disposizione " + NumeroPostiaDisposizione);
            return NumeroPostiaDisposizione;
        }

        public override string ToString()
        {
            return string.Format("NomeEvento: {0}\nData: {1}\n",
            this.TitoloEvento,
            this.DataEvento.ToString("dd.MM.yyyy"));
        }

        public bool validateTime(string dateInString)
        {
            DateTime temp;
            if (DateTime.TryParse(dateInString, out temp))
            {
                return true;
            }
            return false;
        }

    }
    public class ProgrammaEventi
    {
        private string titolo;
        private List<Evento> eventi = new List<Evento>();
        public ProgrammaEventi(string titolo)
        {
            this.titolo = titolo;
        }
        public void aggiungiEventi()
        {
            int numeroEventi = 0;
            numeroEventi = Errori.numeroValido("Numero di eventi?");

            if (numeroEventi > 0)
            {
                for (int i = 0; i < numeroEventi; i++)
                {

                    string nome = "";
                    while (string.IsNullOrEmpty(nome))
                    {
                        Console.Write("Inserisci il nome dell'evento: ");
                        nome = Console.ReadLine();
                    }

                    bool dataCorretta = false;
                    DateTime dataNuoviEventi = DateTime.Now;
                    while (!dataCorretta)
                    {
                        Console.Write("data evento formato gg/mm/aaaa: ");
                        string sdataEventoUno = Console.ReadLine();
                        try
                        {
                            dataNuoviEventi = Errori.DataValida(sdataEventoUno);
                            dataCorretta = true;
                            if (dataNuoviEventi < DateTime.Now)
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

                    int capienzaSpettatori = 0;
                    capienzaSpettatori = Errori.numeroValido("nr. i spettatori: ");

                    Console.Clear();
                    eventi.Add(new Evento(nome, dataNuoviEventi, capienzaSpettatori));
                }
            }
        }
        public void AggiungiEvento(Evento evento1)
        {
            eventi.Add(evento1);
        }

        public void StampaListaEventi()
        {
            Console.WriteLine("Programma Evento: " + titolo);
            foreach (Evento eventoNellaLista in eventi)
            {
                Console.Write(eventoNellaLista);
            }
        }
        public void NrEventi()
        {
            Console.WriteLine("Il numero di eventi è:  " + eventi.Count);
        }

        public void EventoDateUguali(DateTime dataScelta)
        {
            for (int i = 0; i < eventi.Count; i++)
            {
                if (eventi[i].GetDataEvento() == dataScelta)
                {
                    Console.WriteLine(eventi[i]);
                }
            }
        }
        public void CancellaEventi()
        {
            eventi.Clear();
        }
    }
}
