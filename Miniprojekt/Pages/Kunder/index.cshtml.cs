using Microsoft.AspNetCore.Mvc.RazorPages;
using Miniprojekt.Model;
using Miniprojekt.Services;

//Controller

namespace Miniprojekt.Pages.Kunder
{
    public class index : PageModel
    {
        //property til view
        public List<Kunde> Kunder { get; set; }

        public void OnGet()
        {
            KundeRepository repo = new KundeRepository(true);

            Kunder = repo.HentAlleKunder();
        }
    }
}