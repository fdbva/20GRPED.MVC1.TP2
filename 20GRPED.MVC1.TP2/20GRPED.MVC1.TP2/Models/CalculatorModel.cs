using System;

namespace _20GRPED.MVC1.TP2.Models
{
    public class CalculatorModel
    {
        public int Id { get; set; }
        public string Operator { get; set; }
        public decimal Left { get; set; }
        public decimal Right { get; set; }
        public string Result { get; set; }
        public DateTime Hora { get; set; }
    }
}
