using System;
using System.Data;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using System.Xml.XPath;
using System.Linq;
using System.Collections.Generic;
using cmp;

namespace db.Xmls
{
    public class MyXmlReader
    {
        public IList<Cmp> procXml(string path)
        {var files = Directory.GetFiles(path);

            StringBuilder sb = new StringBuilder(1024);
            var computers = new List<Cmp>();
            for (int i = 0; i < files.Length - 1; i++)
            {
                XDocument xd;
                xd = XDocument.Load(files[i]);var mbVendor = ((XElement)xd.XPathSelectElement("/HWINFO/COMPUTER/SubNodes/MOBO/Property/Entry[text() = 'Computer Brand Name']")?.NextNode)?.Value;
                var mb = ((XElement)xd.XPathSelectElement("/HWINFO/COMPUTER/SubNodes/MOBO/Property/Entry[text() = 'Motherboard Model']")?.NextNode)?.Value;
                var ram = ((XElement)xd.XPathSelectElement("/HWINFO/COMPUTER/SubNodes/MEMORY/Property/Entry[text() = 'Total Memory Size']")?.NextNode)?.Value;
                var ramModule = ((XElement)xd.XPathSelectElement("/HWINFO/COMPUTER/SubNodes/MEMORY/SubNode/Property/Entry[text() = 'Memory Type']")?.NextNode)?.Value;
                var ramVendor = ((XElement)xd.XPathSelectElement("/HWINFO/COMPUTER/SubNodes/MEMORY/SubNode/Property/Entry[text() = 'Module Manufacturer']")?.NextNode)?.Value;
                var hdds = new List<Tuple<string, string>>();
                var hddVendors = (xd.XPathSelectElements("/HWINFO/COMPUTER/SubNodes/DRIVES/SubNode/SubNode/Property/PropertyType[text() = 'HDD']"));
                foreach (var hddVendor in hddVendors)
                { hdds.Add(new Tuple<string, string>(((XElement)hddVendor.PreviousNode)?.Value, ((XElement)hddVendor?.Parent?.Parent?.XPathSelectElement("Property/Entry[text() = 'Drive Capacity']")?.NextNode)?.Value));
                }
                // var hdds = (xd.XPathSelectElement("/HWINFO/COMPUTER/SubNodes/DRIVES/SubNode/SubNode/Property/PropertyType[text() = 'HDD']").Parent.Parent.XPathSelectElement("Property/Entry[text() = 'Drive Capacity']").NextNode);
                var hddCount = hdds.Count;
                var cpu = ((XElement)xd.XPathSelectElement("/HWINFO/COMPUTER/SubNodes/CPU/SubNode/Property/Entry[text() = 'Processor Name']")?.NextNode)?.Value;
                var cpuVendor = ((XElement)xd.XPathSelectElement("/HWINFO/COMPUTER/SubNodes/CPU/SubNode/Property/Entry[text() = 'CPU Vendor']")?.NextNode)?.Value;
                var gpuModel = xd.XPathSelectElement("/HWINFO/COMPUTER/SubNodes/VIDEO/NodeName[text() = 'Video Adapter']")?.Parent?.XPathSelectElement("SubNode/NodeName")?.Value;
                var gpu = ((XElement)xd.XPathSelectElement("/HWINFO/COMPUTER/SubNodes/VIDEO/NodeName[text() = 'Video Adapter']")?.Parent?.XPathSelectElement("SubNode/NodeName")?.Parent?.XPathSelectElement("Property/Entry[text() = 'Video Memory']")?.NextNode)?.Value;
                 var monitor = ((XElement)xd.XPathSelectElement("/HWINFO/COMPUTER/SubNodes/MONITOR/SubNode/Property/Entry[text() = 'Monitor Name']")?.NextNode)?.Value;
                var monitorModel = ((XElement)xd.XPathSelectElement("/HWINFO/COMPUTER/SubNodes/MONITOR/SubNode/Property/Entry[text() = 'Monitor Name (Manuf)']")?.NextNode)?.Value;
                var opticDrives = new List<Tuple<string, string>>();
                var opticDriveVendros = (xd.XPathSelectElements("/HWINFO/COMPUTER/SubNodes/DRIVES/SubNode/SubNode[contains(NodeName, 'DVD') or contains(NodeName, 'CD')]"));
                foreach (var opticDrive in opticDriveVendros)
                { opticDrives.Add(new Tuple<string, string>(((XElement)opticDrive.XPathSelectElement("Property/Entry[text() = 'Drive Model']")?.NextNode)?.Value, ((XElement)opticDrive.XPathSelectElement("Property[contains(Entry, 'Device Type') or contains(Entry, 'Drive Type')]")?.NextNode)?.Value));
                }
                computers.Add(new Cmp { MbVendor = mbVendor, Mb = mb, Ram = ram, RamModule = ramModule, RamVendor = ramVendor,
                    Hdd = hdds,
                    Cpu = cpu,
                    CpuVendor = cpuVendor,
                    GpuModel = gpuModel,
                    Gpu = gpu,
                    Monitor = monitor,
                    MonitorModel = monitorModel,
                    OpticDriver = opticDrives,
                    User = Path.GetFileNameWithoutExtension(files[i]),
                    NationalCode = Path.GetFileNameWithoutExtension(files[i]),
                });
            }//File.WriteAllText(@"C:\Hardware LOG\Results.txt", content);
            return computers;
        }
    }
}
