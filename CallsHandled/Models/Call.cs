using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CallsHandled.Models
{
    public class Call
    {
        [Key]
        public int ID { get; set; }

        //duration of call in seconds
        public int Seconds { get; set; }

        [Required]
        public string Resolution { get; set; }

        //flag for followup
        //should probably do: if Resolution == Follow-Up, Flag = true
        public bool Flag { get; set; }

        //nullable, only used if followup is desired
        [StringLength(1000)]
        public string Details { get; set; }

        public DateTime Timestamp { get; set; }

        //Tie data to user
        //public Agent Agent { get; set; }
        
        //Quality bools???
        //Used name, tenure statement, gave ticket number, dispositioned
    }

    public class CallContext : DbContext
    {
        public DbSet<Call> Calls { get; set; }
    }
}