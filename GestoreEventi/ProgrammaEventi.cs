using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestoreEventi
{
    public class ProgrammaEventi
    {
        public string Titolo;
        public List<Evento> ListaEventi;

        public ProgrammaEventi(string Titolo)
        {
            this.Titolo = Titolo;
            ListaEventi = new List<Evento>();
        }

        public void AggiungiNuovoEvento(Evento NuovoEventoInAggiunta)
        {
            ListaEventi.Add(NuovoEventoInAggiunta);
        }

        public List<Evento> GetListaEventiStessaData(DateTime Data)
        {
            List<Evento> ListaEventiStessaData = new List<Evento> ();
            foreach (Evento Evento in ListaEventi) {
                if (Evento.DataEvento == Data)
                {
                    ListaEventiStessaData.Add (Evento);
                }
            }
            return ListaEventiStessaData;
        }

        public override string ToString()
        {
            StringBuilder t = new StringBuilder();
            foreach (Evento e in this.ListaEventi)
                t.AppendLine(string.Format("NomeEvento: {0}", e.TitoloEvento));
            return t.ToString();
        }

        public int  NumeroEventiInProgramma()
        {
           int numeroEventi = ListaEventi.Count; 
           return numeroEventi;
        }

        public void SvuotaListaEventi()
        {
            ListaEventi.Clear();
        }

        
       
    }
}
