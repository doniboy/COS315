using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TicketReservation.Models
{
    public class Journey
    {
        [Key]
        public int Id { get; set; }

        public string From { get; set; }

        public string To { get; set; }

        public DateTime Date { get; set; }

        //Use this field when cancelling a Journey
        public string IsActive { get; set; }

        public int TotalSeatsLeftDirection { get; set; }

        public int TotalSeatsRightDirection { get; set; }
    }
}