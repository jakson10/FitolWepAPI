using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitOl.WebAPI.Models
{
    public class QuestionModel
    {
        public BesinDegeri BesinDegeri { get; set; }
        public Vejeteryan Vejeteryan { get; set; }
    }
    public enum Vejeteryan
    {
        Evet = 1,
        Hayır = 2
    }

    public enum BesinDegeri
    {
        DusukBesinDegeri = 1,
        OrtaBesinDegeri = 2,
        YuksekBesinDegeri = 3
    }
}
