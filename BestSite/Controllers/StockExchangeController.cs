using System.Globalization;

namespace BestSite.Controllers
{
    public class StockExchangeController : Controller
    {
        StockExchangeContext SEdb = new StockExchangeContext();

        public IActionResult Index()
        {
            return View();
        }

        #region Таблица Акционеры
        public IActionResult ShareHolderList() 
        {
            var query = SEdb.Shareholders.ToList();
            return View(query);
        }

        [HttpGet]
        public ActionResult CreateSH()
        {
            return View();
        }
        [HttpPost]

        public ActionResult CreateSH(Shareholder shareholder)
        {
            try
            {
                SEdb.Shareholders.Add(shareholder);
                SEdb.SaveChanges();
            }
            catch (Exception ex)
            {
                return View(ex.Message);
            }
            return RedirectToAction("ShareHolderList");
        }

        public ActionResult DeleteSH(int id)
        {
            Shareholder item = SEdb.Shareholders.Find(id);
            if (item != null)
            {
                SEdb.Shareholders.Remove(item);
                SEdb.SaveChanges();
            }
            return RedirectToAction("ShareHolderList");
        }

        [HttpGet]
        public ActionResult EditSH(int id)
        {
            Shareholder shareholder = SEdb.Shareholders.Find(id);
            return View(shareholder);
        }
        [HttpPost]

        public ActionResult EditSH(Shareholder shareholder)
        {
            SEdb.Entry(shareholder).State = EntityState.Modified;
            SEdb.SaveChanges();
            return RedirectToAction("ShareHolderList");
        }

        public async Task<IActionResult> SearchSH(string Searching)
        {
            ViewData["Search"] = Searching;
            var query = from x in SEdb.Shareholders select x;
            if (!String.IsNullOrEmpty(Searching))
            {
                query = query.Where(x =>
                x.FirstName.Contains(Searching) ||
                x.LastName.Contains(Searching) ||
                x.MiddleName.Contains(Searching) ||
                x.PassportNumber.Contains(Searching) ||
                x.PassportSerial.Contains(Searching) ||
                x.PhoneNumber.Contains(Searching) ||
                x.City.Contains(Searching) ||
                x.BirthDate.Equals(DateTime.ParseExact(IsStringDateHasValidFormat(Searching.Replace(".", "/").Trim(' ')), "dd/MM/yyyy", CultureInfo.InvariantCulture)));
            }
            return View(await query.AsNoTracking().ToListAsync());
        }

        private string IsStringDateHasValidFormat(string Searching)
        {
            if (Searching.Length == 10) return Searching;
            else return Searching = "01/01/1901";
        }
        #endregion

        #region Таблица Сертификаты
        public IActionResult ShareCertificates()
        {
            var query = SEdb.Sharecertificates.ToList();
            return View(query);
        }

        [HttpGet]
        public ActionResult CreateSC()
        {
            return View();
        }
        [HttpPost]

        public ActionResult CreateSC(Sharecertificate sharecertificate)
        {
            try
            {
                SEdb.Sharecertificates.Add(sharecertificate);
                SEdb.SaveChanges();
            }
            catch (Exception ex)
            {
                return View(ex.Message);
            }
            return RedirectToAction("ShareCertificates");
        }

        public ActionResult DeleteSС(int id)
        {
            Sharecertificate item = SEdb.Sharecertificates.Find(id);
            if (item != null)
            {
                SEdb.Sharecertificates.Remove(item);
                SEdb.SaveChanges();
            }
            return RedirectToAction("ShareCertificates");
        }

        [HttpGet]
        public ActionResult EditSC(int id)
        {
            Sharecertificate sharecertificate = SEdb.Sharecertificates.Find(id);
            return View(sharecertificate);
        }
        [HttpPost]

        public ActionResult EditSC(Sharecertificate sharecertificate)
        {
            SEdb.Entry(sharecertificate).State = EntityState.Modified;
            SEdb.SaveChanges();
            return RedirectToAction("ShareCertificates");
        }

        public async Task<IActionResult> SearchSС(string Searching)
        {
            ViewData["Search"] = Searching;

            var query = from x in SEdb.Sharecertificates select x;
            if (!String.IsNullOrEmpty(Searching))
            {
                query = query.Where(x =>
                x.BuySharecount.ToString().Contains(Searching) ||
                x.Totalprice.ToString().Contains(Searching) ||
                x.Priceforone.ToString().Contains(Searching) ||
                x.Buyinfo.Equals(DateTime.ParseExact(IsStringDateHasValidFormat(Searching.Replace(".", "/").Trim(' ')), "dd/MM/yyyy", CultureInfo.InvariantCulture)));
            }
            return View(await query.AsNoTracking().ToListAsync());
        }
        #endregion

        #region Таблица Инф. об акциях
        public IActionResult ShareInfo()
        {
            var query = SEdb.Shareinfos.ToList();
            return View(query);
        }

        [HttpGet]
        public ActionResult CreateSI() 
        {
            return View();
        }
        [HttpPost]

        public ActionResult CreateSI(Shareinfo shareinfo)
        {
            try
            {
                SEdb.Shareinfos.Add(shareinfo);
                SEdb.SaveChanges();
            }
            catch (Exception ex)
            {
                return View(ex.Message);
            }
            return RedirectToAction("ShareInfo");
        }

        public ActionResult DeleteSI(int id)
        {
            Shareinfo item = SEdb.Shareinfos.Find(id);
            if (item != null)
            {
                SEdb.Shareinfos.Remove(item);
                SEdb.SaveChanges();
            }
            return RedirectToAction("ShareInfo");
        }

        [HttpGet]
        public ActionResult EditSI(int id)
        {
            Shareinfo shareinfo = SEdb.Shareinfos.Find(id);
            return View(shareinfo);
        }
        [HttpPost]

        public ActionResult EditSI(Shareinfo shareinfo)
        {
            SEdb.Entry(shareinfo).State = EntityState.Modified;
            SEdb.SaveChanges();
            return RedirectToAction("ShareInfo");
        }

        public async Task<IActionResult> SearchSI(string Searching)
        {
            ViewData["Search"] = Searching;

            var query = from x in SEdb.Shareinfos select x;
            if (!String.IsNullOrEmpty(Searching))
            {
                query = query.Where(x =>
                x.Sharetype.Contains(Searching) ||
                x.Issuer.Contains(Searching) ||
                x.Sharecount.ToString().Contains(Searching) ||
                x.Shareissuedate.Equals(DateTime.ParseExact(IsStringDateHasValidFormat(Searching.Replace(".", "/").Trim(' ')), "dd/MM/yyyy", CultureInfo.InvariantCulture)));
            }
            return View(await query.AsNoTracking().ToListAsync());
        }
        #endregion
    }
}
