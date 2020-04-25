using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace JobOffersWebsite.Models
{
    public class ApplyForJob
    {
        public int ID { get; set; }

        public string Message { get; set; }

        [Display(Name = "Apply Date")]
        public DateTime ApplyDate { get; set; }
        
        public virtual Job Job { get; set; }

        public virtual ApplicationUser User { get; set; }

        [Display(Name = "Job Title")]
        public int JobId { get; set; }

        [Display(Name = "User  Name")]
        public string UserId { get; set; }
    }
}