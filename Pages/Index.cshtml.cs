using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TimeOffApp.Data;
using TimeOffApp.Models;

namespace TimeOffApp.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly TimeOffDbContext _dbContext;

        public IndexModel(ILogger<IndexModel> logger, TimeOffDbContext dbContext )
        {
            _logger = logger;
            _dbContext = dbContext;
            TimeOff = new TimeOff();
            Assignees = new List<SelectListItem>()
            {
                new SelectListItem()
                {
                    Text = "Amanda",
                    Value = "Amanda"
                },
                 new SelectListItem()
                {
                    Text = "Abdullah",
                    Value = "Abdullah"
                },
            };
        }



        public void OnGet()
        {
           
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                var savedRequest = await _dbContext.AddAsync(TimeOff);
                await _dbContext.SaveChangesAsync();
                TimeOff = savedRequest.Entity;
            }
            return Page();
        }

        [BindProperty]
        public TimeOff TimeOff { get; set; }

        public List<SelectListItem> Assignees { get; set; } = new List<SelectListItem>();
    }
}