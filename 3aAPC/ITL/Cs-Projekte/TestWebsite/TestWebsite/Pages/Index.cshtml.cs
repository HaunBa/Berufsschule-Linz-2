using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace TestWebsite.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        public Timer timer1 { get; set; }

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public Timer GetTimer1()
        {            
            return timer1;
        }

        public void OnGet(Timer timer1)
        {
            Console.WriteLine("Test");
        }

        public void Btn_OnClick()
        {
            Console.WriteLine("Button click");
        }
    }
}