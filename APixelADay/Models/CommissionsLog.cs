using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace APixelADay.Models
{
    public class CommissionsLog
    {
        [Key]
        public int ComissionID { get; set; }
        public string Title { get; set; }
        [DisplayName("Price: ")]
        public decimal Price { get; set; }
        [DisplayName("Completion Status: ")]
        public bool CompletionStatus { get; set; }
        [DataType(DataType.Date)]
        [DisplayName("Date Started: ")]
        public DateTime DateStarted { get; set; }

        [DataType(DataType.Date)]
        [DisplayName("Date Completed: ")]
        public DateTime DateCompleted { get; set; }
    }
}
