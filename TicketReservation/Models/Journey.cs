namespace TicketReservation.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
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