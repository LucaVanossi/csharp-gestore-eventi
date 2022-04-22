using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestoreEventi
{
    public class Evento
    {
        public string TitoloEvento;
        public DateTime DataEvento;
        private int NumeroPostiTotaliEvento;
        private int NumeroPostiEventoPrenotati=0;


    public Evento(string TitoloEvento, DateTime DataEvento, int NumeroPostiTotaliEvento)
    {
            this.TitoloEvento = TitoloEvento;
            this.DataEvento = DataEvento;
            this.NumeroPostiTotaliEvento = NumeroPostiTotaliEvento;
    }

    public int GetNumeroPostiTotaliEvento()
    {
        return NumeroPostiTotaliEvento;
    }

    public int GetNumeroPostiEventoPrenotati()
    {
            return NumeroPostiEventoPrenotati;
    }

     public void ControllaData(DateTime DataEvento)
     {
            if (this.DataEvento < DateTime.Now)
            {
                throw new InvalidTimeZoneException("Data non valida");
            }
     }

    public void ControllaTitolo(string TitoloEvento)
    {
        if (String.IsNullOrEmpty(TitoloEvento))
        {
        Console.WriteLine("Inserisci un titolo corretto");
        }
    }

        public void ControllaPosti (int NumeroPosti)
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
            Console.WriteLine("Numero posti a disposizione " + NumeroPostiaDisposizione);
            return NumeroPostiaDisposizione;
        }

        public int DisdiciPosti (int PostiDaDisdire)
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


    }

}
