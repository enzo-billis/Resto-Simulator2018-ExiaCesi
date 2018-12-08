﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Model.Salle.Components
{

    public enum EquipmentState
    {
        Available,
        InUse,
        Dirty
    };

    public class Equipment
    {
        private EquipmentState state;

        public EquipmentState State { get => state; set => state = value; }

        public Equipment()
        {
            this.state = EquipmentState.Available;
        }
    }
}
