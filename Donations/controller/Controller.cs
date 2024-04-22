using System.Windows.Forms;
using Donations.service;

namespace Donations.Controllers
{
    public class Controller
    {
        protected Service service;
        protected Form form;

        // Constructor
        public Controller(Service service, Form form)
        {
            this.service = service;
            this.form = form;
        }

        // Metoda pentru a seta serviciul și fereastra
        public void Set(Service service, Form form)
        {
            this.service = service;
            this.form = form;
        }
    }
}