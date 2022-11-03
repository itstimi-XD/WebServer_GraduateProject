using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebServer.Data.Models;

namespace WebServer.Data.Services
{
    public class BoardService
    {
        ApplicationDbContext _context;

        public BoardService(ApplicationDbContext context)
        {
            _context = context;
        }

        //CRUD

        //Create
        public Task<Script> AddScript(Script script)
        {
            _context.ScriptDb.Add(script);
            _context.SaveChanges();

            return Task.FromResult(script);
        }

        //Read
        public Task<List<Npc>> GetAllNpcsAsync()
        {
            List<Npc> results = _context.NpcDb 
                .ToList();

            return Task.FromResult(results);
        }

        public Task<Npc> GetNpcByIdAsync(int id)
        {
            Npc results = _context.NpcDb
                .Where(n => n.NpcId == id)
                .FirstOrDefault();

            return Task.FromResult(results);
        }

        public Task<List<Npc>> GetNpcsByIdAsync(int id)
        {
            List<Npc> results = _context.NpcDb
                .Where(n => n.NpcId == id)
                .ToList();

            return Task.FromResult(results);
        }

        public Task<List<Npc>> GetNpcsByMajorAsync(string Major)
        {
            List<Npc> results = _context.NpcDb
                .FromSqlRaw($"select * from dbo.NpcDb where NpcMajor = '{Major}'")
                .ToList();

            return Task.FromResult(results);
        }

        public Task<List<Script>> GetScriptsByNpcAsync(Npc npc)
        {
            List<Script> results = _context.ScriptDb
                .Where(s => s.OwnerId == npc.NpcId)
                .Include(s => s.Owner)
                .OrderByDescending(s => s.Date).ToList();

            return Task.FromResult(results);
        }

        //Update
        public Task<bool> UpdateNpcScore(Script script)
        {
            var findResult = _context.NpcDb
                .Where(x => x.NpcId == script.OwnerId)
                .FirstOrDefault();

            if (findResult == null)
                return Task.FromResult(false);

            findResult.Score = (findResult.Score + script.Score) / findResult.Scripts.Count;
            _context.SaveChanges();

            return Task.FromResult(true);
        }
        public Task<bool> UpdateScript(Script script)
        {
            var findResult = _context.ScriptDb
                .Where(x => x.OwnerId == script.OwnerId)
                .FirstOrDefault();

            if (findResult == null)
                return Task.FromResult(false);

            findResult.ScriptText = script.ScriptText;
            findResult.Owner.Score = script.Owner.Score;
            _context.SaveChanges();

            return Task.FromResult(true);
        }


        //Delete
        public Task<bool> DeleteScript(Script script)
        {
            var findResult = _context.ScriptDb
               .Where(x => x.OwnerId == script.OwnerId)
               .FirstOrDefault();

            if (findResult == null)
                return Task.FromResult(false);

            _context.ScriptDb.Remove(script);
            _context.SaveChanges();

            return Task.FromResult(true);
        }
    }
}
