using Miniprojekt.Model;
namespace Miniprojekt.Services;

public class KundeRepository
{
        // instansfelt
        Dictionary<int, Kunde> _katalog;
        
        // properties
        public Dictionary<int, Kunde> Katalog
        {
            get { return _katalog; }
            set { _katalog = value; }
        }

        // konstruktør
        public KundeRepository(bool mockData = false)
        {
            _katalog = new Dictionary<int, Kunde>();

            if (mockData)
            {
                PopulateKundeRepository();
            }
        }

        private void PopulateKundeRepository()
        {
            _katalog.Clear();
            
            Katalog.Add(1, new Kunde(1, "Niklas", "11111111"));
            Katalog.Add(2, new Kunde(2, "Jens", "22222222"));
            Katalog.Add(3, new Kunde(3, "Kris", "33333333"));
            Katalog.Add(4, new Kunde(4, "Christian", "44444444"));
            Katalog.Add(5, new Kunde(5, "Emil", "55555555"));
        }



        //metoder
                 public Kunde Tilføj(Kunde kunde)
                {
                    _katalog.Add(kunde.KundeNummer, kunde);

                    return kunde;
                }

        public Kunde Slet(int kundenummer)
        {
            if (_katalog.ContainsKey(kundenummer))
            {
                Kunde slettetKunde = _katalog[kundenummer];
                _katalog.Remove(kundenummer);
                return slettetKunde;
                
            }
            else
            {
                return null;
            }
        }

        public Kunde HentKunde(int kundenummer)
        {
            if (_katalog.ContainsKey(kundenummer))
            {
                return _katalog[kundenummer];

            }
            else
            {
                // opdaget en fejl
                throw new KeyNotFoundException("kundenummer findes ikke");
                


                //return null;
            }
        }

        public List<Kunde> HentAlleKunder()
        {
            return _katalog.Values.ToList();
        }


        public Kunde HentKundeUdFraTlf(string tlf)
        {
            Kunde resKunde = null;

            foreach (Kunde k in _katalog.Values)
            {
                if (k.Tlf == tlf)
                {
                    return k;
                }
            }

            return resKunde;
        }

        public override string ToString()
        {
            String pænTekst = String.Join(", ", _katalog.Values);

            return $"{{{nameof(Katalog)}={pænTekst}}}";
        }
}
