using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Model.Salle.Components
{

    enum EquipmentState
    {
        available,
        inUse,
        dirty
    };

    class Equipment
    {
        public EquipmentState state;
    }
}
