using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TimeOffApp.Data;
using TimeOffApp.Models;

namespace TimeOffApp.Pages
{
    public class TimeOffListModel : PageModel
    {
        private readonly TimeOffDbContext _dbContext;

        public TimeOffListModel(TimeOffDbContext dbContext)
        {
            _dbContext = dbContext;
            Statuses = new List<SelectListItem>()
            {
                new SelectListItem()
                {
                    Text = TimeOffStatus.Pending,
                    Value = TimeOffStatus.Pending
                },
                 new SelectListItem()
                {
                    Text = TimeOffStatus.Aproved,
                    Value = TimeOffStatus.Aproved
                },
                   new SelectListItem()
                {
                    Text = TimeOffStatus.Rejected,
                    Value = TimeOffStatus.Rejected
                },
            };
        }
        public async Task OnGetAsync(int skip = 0, int take = 10)
        {
            await LoadTimeOffs(skip, take);
        }

        private async Task LoadTimeOffs(int skip, int take)
        {
            TimeOffs = await _dbContext.TimeOffs
                .Include(x => x.ApprovedBy)
                .OrderByDescending(x => x.Id).Skip(skip).Take(take)
                .ToListAsync();
        }

        public async Task OnPostAproveAsync(int id)
        {
            var timeOff = await _dbContext.TimeOffs.SingleAsync(x => x.Id == id);
            timeOff.Status = TimeOffStatus.Aproved;
            _dbContext.Update(timeOff);
            await _dbContext.SaveChangesAsync();
            await LoadTimeOffs(0, 10);
        }

        public async Task OnPostRejectAsync(int id)
        {
            var timeOff = await _dbContext.TimeOffs.SingleAsync(x => x.Id == id);
            timeOff.Status = TimeOffStatus.Rejected;
            _dbContext.Update(timeOff);
            await _dbContext.SaveChangesAsync();
            await LoadTimeOffs(0, 10);
        }

        public List<TimeOff> TimeOffs { get; set; } = new List<TimeOff>();

        public List<SelectListItem> Statuses { get; set; } = new List<SelectListItem>();
    }
}
