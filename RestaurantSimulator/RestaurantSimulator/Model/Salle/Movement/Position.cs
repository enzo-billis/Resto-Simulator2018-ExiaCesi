﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Model.Salle.Movement
{
    public class Position : IPosition
    {
        private int posX;
        private int posY;

        public Position(int posX, int posY)
        {
            this.posX = (posX >= 0) ? posX : 0;
            this.PosY = (posY >= 0) ? posY : 0;
        }

        public Position()
        {
            this.posX = 0;
            this.posY = 0;
        }

        public int PosX
        {
            get
            {
                return this.posX;
            }
            set
            {
                this.posX = (value >= 0) ? value : 0;
            }
        }
        public int PosY
        {
            get
            {
                return this.posY;
            }
            set
            {
                this.posY = (value >= 0) ? value : 0;
            }
        }
    }
}
