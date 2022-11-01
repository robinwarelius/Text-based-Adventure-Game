using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Escape.Interfaces
{
    public interface IMission
    {
        string Name { get; }
        string Player { get; }
        int DecreaseLife { get; }
        void GameOn() { }


    }
}
