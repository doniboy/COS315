

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace TicketReservation.Models
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        public decimal Wallet { get; set; }
        //public string FirstName { get; set; }
        //public string LastName { get; set; }
    }
}
