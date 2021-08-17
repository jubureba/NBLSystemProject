using LiveCharts;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace NBLSystemProject.pages.entity {
    public class GanhosPotenciais {
        public int id { get; set; }
        public string titulos { set; get; }
        public ChartValues<double> valores { set; get; }
    }
}
