using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JobOffersWebsite.Models
{
    public class Job
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Job Title")]
        public string JobTitle { get; set; }

        [Required]
        [AllowHtml]
        [Display(Name = "Job Content")]
        public string JobContent { get; set; }

        [Required]
        [Display(Name = "Job Image")]
        public string JobImage { get; set; }

        [Required]
        [Display(Name = "Category")]
        public int CategoryId { get; set; }

        public virtual Category category { get; set; }

        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }
    }
}