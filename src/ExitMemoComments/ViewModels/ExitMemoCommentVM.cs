using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExitMemoComments.ViewModels
{
    public class ExitMemoCommentVM
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Narrative { get; set; }
        public DateTime DateAdded { get; set; }
    }
}
