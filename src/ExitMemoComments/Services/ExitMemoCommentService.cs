using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExitMemoComments.Infrastructure;
using ExitMemoComments.ViewModels;
using ExitMemoComments.Models;
using Microsoft.EntityFrameworkCore;

namespace ExitMemoComments.Services
{
    public class ExitMemoCommentService
    {
        public IGenericRepository _repo;

        public ExitMemoCommentService(IGenericRepository repo)
        {
            _repo = repo;
        }

        public IList<ExitMemoCommentVM> ListAllExitMemoComments()
        {
            var exitMemoComments = (from em in _repo.Query<ExitMemoComment>()
                                    select new ExitMemoCommentVM()
                                    {
                                        Title = em.Title,
                                        Narrative = em.Narrative
                                    }).ToList();
            return exitMemoComments;
        }

        public IList<ExitMemoCommentVM> ListExitMemoComments(string searchTerm)
        {
            var exitMemoComments = (from em in _repo.Query<ExitMemoComment>()
                                    where em.Title.Contains(searchTerm) || em.Narrative.Contains(searchTerm)
                                    select new ExitMemoCommentVM()
                                    {
                                        Narrative = em.Narrative,
                                        Title = em.Title
                                    }).ToList();
            
            return exitMemoComments;
        }

        public void AddNewExitMemoComment(string id, ExitMemoComment newExitMemoComment)
        {
            var currentUserName = (from u in _repo.Query<ApplicationUser>().Include(u=>u.ExitMemoComments)
                                   where u.UserName == id
                                   select u).FirstOrDefault();
            var exitMemoComment = new ExitMemoComment()
            {
                Title = newExitMemoComment.Title,
                Narrative = newExitMemoComment.Narrative,
                DateAdded = newExitMemoComment.DateAdded
            };
            currentUserName.ExitMemoComments.Add(exitMemoComment);
            _repo.Update(currentUserName);
        }

    }
}
