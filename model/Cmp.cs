using System;
using System.Collections.Generic;

namespace cmp
{
    public class Cmp
    {
        public string NationalCode { get; set; }
        public string MbVendor { get; set; }
        public string Mb { get; set; }
        public string Ram { get; set; }
        public string RamModule { get; set; }
        public string RamVendor { get; set; }
        public List<Tuple<string, string>> Hdd { get; set; }
        public string CpuVendor { get; set; }
        public string Cpu { get; set; }
        public string GpuModel { get; set; }
        public string Gpu { get; set; }
        public string Monitor { get; set; }
        public string MonitorModel { get; set; }
        public List<Tuple<string, string>> OpticDriver { get; set; }
        public string User { get; set; }
    }
}
