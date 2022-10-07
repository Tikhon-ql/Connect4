using Connect4Library.DAL.Context;
using Connect4Library.DAL.Interfaces.IWinnerRepositories;
using Connect4Library.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Connect4Library.DAL.Repositories
{
    public class WinnerRepository : IWinnerRepository
    {
        private WinnerContext context;
        public WinnerRepository(WinnerContext context)
        {
            this.context = context;
        }
        public void Create(Winner data)
        {
            if (data == null)
                throw new NullReferenceException();
            Winner winner = context.Winners.FirstOrDefault(d => d.Name == data.Name);
            if (winner != null)
            {
                if (data.IsWin)
                    winner.CountOfWins++;
                else
                    winner.CountOfLoses++;
                winner.LastWin = DateTime.Now;
                winner.ResetKD();
            }
            else
            {
                ///Shit code
                if (data.IsWin)
                    data.CountOfWins = 1;
                else
                    data.CountOfLoses = 1;
                context.Winners.Add(data);
            }
            context.SaveChanges();
        }

        public void Delete(Winner data)
        {
            if (data == null)
                throw new NullReferenceException();
            context.Winners.Remove(data);
            context.SaveChanges();
        }

        public void Delete(string id)
        {
            if (id == "")
                throw new ArgumentException("Id can not be empty!!!");
            Winner winner = context.Winners.Find(id);
            if (winner == null)
                throw new ArgumentException($"Winner with id: {id} was not found!!!");
            context.Winners.Remove(winner);
            context.SaveChanges();
        }

        public Winner Read(string id)
        {
            if (id == "")
                throw new ArgumentException("Id can not be empty!!!");
            Winner winner = context.Winners.Find(id);
            if (winner == null)
                throw new ArgumentException($"Winner with id: {id} was not found!!!");
            return winner;
        }

        public IEnumerable<Winner> ReadAll()
        {
            return context.Winners;
        }

        public void Update(Winner data)
        {
            context.Entry(data).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
        }
    }
}
