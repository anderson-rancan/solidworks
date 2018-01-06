using CrossfireSW.Data.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossfireSW.Wpf.ViewModel
{
    public class ConfigViewModel
    {
        public ObservableCollection<NamingStandard> NamingStandards { get; set; }

        public ConfigViewModel()
        {
            NamingStandards = new ObservableCollection<NamingStandard>
            {
                new NamingStandard { NamePattern = "00000", FileType = FileType.SolidWorksPart  },
                new NamingStandard { NamePattern = "000", FileType = FileType.SolidWorksAssembly },
            };
        }
    }
}
