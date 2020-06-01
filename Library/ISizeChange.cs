using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Visual_path_finding.Library
{
    public interface ISizeChange
    {
        event EventHandler GridSizeChanged;
    }
}
