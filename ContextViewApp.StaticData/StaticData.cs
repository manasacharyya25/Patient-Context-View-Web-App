using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContextViewApp.Models;

namespace ContextViewApp.StaticData
{
    public static class PatientData
    {      
        public static Patient patient1 = new Patient("MRN001", "Freddy Mercury", "53", "NYC", "Male", "ICU001", "BED001", "97 F", "80", "70", "23.5", "130/80", "7.8 mmo/L");
        public static Patient patient2 = new Patient("MRN002", "John Bellion", "50", "NYC", "Male", "ICU002", "BED003", "97 F", "80", "70", "23.5", "130/80", "7.8 mmo/L");
        public static Patient patient3 = new Patient("MRN003", "Marcus Reeds", "27", "NYC", "Male", "ICU001", "BED002", "97 F", "80", "70", "23.5", "130/80", "7.8 mmo/L");
        public static Patient patient4 = new Patient("MRN004", "Patient", "53", "NYC", "Male", "ICU001", "BED001", "97 F", "80", "70", "23.5", "130/80", "7.8 mmo/L");
    }
}
