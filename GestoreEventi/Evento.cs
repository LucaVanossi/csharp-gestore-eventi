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
        private int NumeroPostiEventoPrenotati;


    public Evento(string NomeEvento, DateTime DataEvento, int NumeroPostiTotaleEvento)
    {
            this.TitoloEvento = TitoloEvento;
            this.DataEvento = DataEvento;
            this.NumeroPostiTotaleEvento = NumeroPostiTotaleEvento;
    }

    private int GetNumeroPostiTotaliEvento()
    {
        return NumeroPostiTotaliEvento;
    }

    private int GetNumeroPostiEventoPrenotati()
    {
            return NumeroPostiEventoPrenotati;
    }

     public void ControllaData()
     {
            if (this.DataEvento < DateTime.Now)
            {
                throw new InvalidTimeZoneException("Data non valida");
            }
     }

        public void ControllaTitolo()
        {
            if (String.IsNullOrEmpty(TitoloEvento))
            {
                Console.WriteLine("Inserisci un titolo corretto");
            }
        }

        public void ControllaPosti ()
        {
            if (NumeroPostiEventoPrenotati < 0)
            {
                Console.WriteLine("Inserisci un numero di posti maggiore di 0");
            } 
        }

        public void PrenotaPosti()
        {

        }

        public void DisdiciPosti ()
        { 
        
        }

        public override string ToString()
        {
            return string.Format("Titolo: {0}\nData: {1}\n",
            this.TitoloEvento,
            this.DataEvento.ToString("dd.MM.yyyy"));
        }


    }

}
