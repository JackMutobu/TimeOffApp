using System.ComponentModel.DataAnnotations;

namespace TimeOffApp.Models
{
    public class TimeOff
    {
        public int Id { get; set; }

        [Required]
        public string Subject { get; set; } = null!;

        [Required]
        public string Reason { get; set; } = null!;

        [Required]
        public DateTime From { get; set; } = DateTime.Now;

        [Required]
        [GreaterThan(nameof(From))] 
        public DateTime To { get; set; } = DateTime.Now;

        [Required]
        public string Assignee { get; set; } = null!;

        public string? ApprovedById { get; set; } = null!;
        public User? ApprovedBy { get; set; }

        public string Status { get; set; } = TimeOffStatus.Pending;
    }

    public class TimeOffStatus
    {
        public const string Pending = nameof(Pending);

        public const string Aproved = nameof(Aproved);

        public const string Rejected = nameof(Rejected);

        public static IEnumerable<string> All() => new List<string>()
        {
            Pending, Aproved, Rejected
        };
    }
}
