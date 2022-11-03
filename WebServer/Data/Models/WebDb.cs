using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebServer.Data.Models
{
    public class Npc
    {
        public int NpcId { get; set; }
        public string NpcName { get; set; }
        public string NpcMajor { get; set; }
        public string NpcPlace { get; set; }
        public float Score { get; set; }
        public ICollection<Script> Scripts { get; set; }
    }

    public class Script
    {
        public int ScriptId { get; set; }
        public string ScriptText { get; set; }
        public int Score { get; set; }
        public DateTime Date { get; set; }

        [ForeignKey("Npc")]
        public int OwnerId { get; set; }
        public Npc Owner { get; set; }
    }
}
