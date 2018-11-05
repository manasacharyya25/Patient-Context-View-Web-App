using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContextViewApp.Models
{
    public class Patient
    {
        public string mrn { get; set; }
        public string name { get; set; }
        public string age { get; set; }
        public string address { get; set; }
        public string sex { get; set; }

        public string icu { get; set; }
        public string bed { get; set; }


        public string temperature { get; set; }
        public string heartRate { get; set; }
        public string pulseRate { get; set; }
        public string bmi { get; set; }
        public string bp { get; set; }
        public string glucoseLevel { get; set; }

        public Patient(string mrn, string name, string age, string address, string sex, string icu, string bed, string temperature, string heartRate, string pulseRate, string bmi, string bp, string glucoseLevel)
        {
            this.mrn = mrn;
            this.name = name;
            this.age = age;
            this.address = address;
            this.sex = sex;
            this.icu = icu;
            this.bed = bed;
            this.temperature = temperature;
            this.pulseRate = pulseRate;
            this.bmi = bmi;
            this.bp = bp;
            this.glucoseLevel = glucoseLevel;
        }
    }
}
