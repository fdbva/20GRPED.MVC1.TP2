using System.Collections.Generic;

namespace _20GRPED.MVC1.TP2.Models
{
    public class CalculatorIndexViewModel
    {
        public CalculatorModel CalculatorModel { get; set; }
        public IEnumerable<CalculatorModel> History { get; set; }
    }
}
