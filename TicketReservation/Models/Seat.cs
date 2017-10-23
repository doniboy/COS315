using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TicketReservation.Models
{
    public class Seat
    {
        [Key]
        public int Id { get; set; }

        public string Direction { get; set; }

        public string Number { get; set; }

        public string UserId { get; set; }

        [ForeignKey(nameof(UserId))]
        public virtual ApplicationUser User { get; set; }

        public int JourneyId { get; set; }

        [ForeignKey(nameof(JourneyId))]
        public virtual Journey Journey { get; set; }
    }
}
