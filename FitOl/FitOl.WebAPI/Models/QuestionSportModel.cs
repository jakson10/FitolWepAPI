using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitOl.WebAPI.Models
{
    public class QuestionSportModel
    {
        public Bolge Bolge { get; set; }
        public Haraket Haraket { get; set; }
    }
    public enum Bolge
    {
        FullBody = 1,
        Karın = 2,
        Omuz = 3,
        Bacak = 4

    }
    public enum Haraket
    {
        Zayıflama = 1,
        Koruma = 2,
        Gelisme = 3
    }
}
