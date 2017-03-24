using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExitMemoComments.Models
{
    public class ExitMemoComment
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Narrative { get; set; }
        public DateTime DateAdded { get; set; }

        public ApplicationUser Contributor { get; set; }
        [ForeignKey("Contributor")]
        public string ContributorId { get; set; }
    }
}
