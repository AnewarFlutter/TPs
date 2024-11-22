using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UsageCollections
{
   public class Etudiant
    {
        public string Nom { get; set; }
        public double NoteCC { get; set; }
        public double NoteDevoir { get; set; }

        public double CalculerMoyenne()
        {
            return (NoteCC * 0.33) + (NoteDevoir * 0.67);
        }
    }
}
