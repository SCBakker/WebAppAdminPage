using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppAdminPageCultuurplein1DB.Data.WebAppAdminPageCultuurplein1;

namespace WebAppAdminPageCultuurplein1.Services
{
    public class Interfaceservice
    {
        private readonly AdminContext _context;

        // Geeft de afbeelding uit de database weer
        public List<Shows> DisplayImages()
        {
            return _context.Shows.ToList();
        }

        // Maakt een variabele ic aan waarmee een afbeelding
        // geupload kan worden naar de database
        public bool Uploadimg(Shows ic)
        {
            _context.Shows.Add(ic);
            _context.SaveChanges();
            return true;
        }

        public Interfaceservice(AdminContext context)
        {
            _context = context;
        }

        // Maakt een lijst van alle voorstellingen die in de database staan
        // en geeft deze terug aan de frontend
        public Task<List<Shows>>
            GetShowAsync(string strCurrentShow)
        {
            List<Shows> colAdminPage =
                new List<Shows>();
            colAdminPage =
                (from adminPage in _context.Shows
                 select adminPage).ToList();
            return Task.FromResult(colAdminPage);
        }

        // Maakt een nieuwe show aan doormiddel van objAdminPage
        // en plaatst deze in de database
        public Task<Shows>
            CreateShowAsync(Shows objAdminPage)
        {
            _context.Shows.Add(objAdminPage);
            _context.SaveChanges();

            return Task.FromResult(objAdminPage);

        }

        // Haalt een bestaande voorstelling uit de database en 
        // biedt de mogelijkheid deze aan te passen
        public Task<bool>
            UpdateShowAsync(Shows objAdminPage)
        {
            var ExistingShow =
                _context.Shows
                    .Where(x => x.Id == objAdminPage.Id)
                    .FirstOrDefault();
            if (ExistingShow != null)
            {
                ExistingShow.Voorstelling =
                    objAdminPage.Voorstelling;
                ExistingShow.Beschrijving =
                    objAdminPage.Beschrijving;
                ExistingShow.Afbeelding =
                    objAdminPage.Afbeelding;
                _context.SaveChanges();
            }
            else
            {
                return Task.FromResult(false);
            }

            return Task.FromResult(true);
        }

        // Haalt een voorstelling uit de database en 
        // biedt de mogelijkheid deze te verwijderen
        public Task<bool>
            DeleteShowAsync(Shows objAdminPage)
        {
            var ExistingShows =
                _context.Shows
                    .Where(x => x.Id == objAdminPage.Id)
                    .FirstOrDefault();
            if (ExistingShows != null)
            {
                _context.Shows.Remove(ExistingShows);
                _context.SaveChanges();
            }
            else
            {
                return Task.FromResult(false);
            }

            return Task.FromResult(true);
        }
    }
}
