using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace QuickMoviePickz.Models
{
    public class MovieWatcher
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Display(Name = "Country")]
        public string Country { get; set; }


        //[ForeignKey("Private Group")]
        //public int? PrivateGroupId { get; set; }
        //public PrivateGroup PrivateGroup { get; set; }

        public virtual PrivateGroup MyPrivateGroup { get; set; }

        [ForeignKey("Questionnaire")]
        public int? QuestionnaireId { get; set; }
        public Questionnaire Questionnaire { get; set; }

        [ForeignKey("IdentityUser")]
        public string IdentityUserId { get; set; }
        public IdentityUser IdentityUser { get; set; }
    }
}
