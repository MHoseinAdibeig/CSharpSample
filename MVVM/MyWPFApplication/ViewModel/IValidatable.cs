using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public interface IValidatable : IDataErrorInfo
    {
        /// <summary>
        /// Gets if the entiy is valid
        /// </summary>
        bool IsValid { get; }
    }
}
