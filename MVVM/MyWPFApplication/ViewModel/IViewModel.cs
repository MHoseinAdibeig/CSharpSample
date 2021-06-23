using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public interface IViewModel: INotifyPropertyChanged
    {
        bool IsModified { get; set; }

        bool IsLoading { get; set; }
    }
}
