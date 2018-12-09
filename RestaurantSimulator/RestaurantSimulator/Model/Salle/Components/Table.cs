﻿using Restaurant.Model.Salle.Components;
using Restaurant.Model.Salle.Movement;
using Restaurant.Model.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantSimulator.Model.Salle.Components
{
    public class Table : Equipment, IPosition
    {
        private int nbPlaces;
        private Group group;
        private bool entree = false;
        private bool plate = false;
        private bool dessert = false;
        private int posX = 0;
        private int posY = 0;

        public Table(int nbPlaces)
        {
            this.nbPlaces = nbPlaces;
        }

        public Table(int nbPlaces, int posX, int posY)
        {
            this.nbPlaces = nbPlaces;
            this.posX = posX;
            this.posY = posY;
        }

        public int NbPlaces { get => nbPlaces; set => nbPlaces = value; }
        public Group Group { get => group; set => group = value; }
        public bool Entree { get => entree; set => entree = value; }
        public bool Plate { get => plate; set => plate = value; }
        public bool Dessert { get => dessert; set => dessert = value; }
        public int PosX { get => posX; set => posX = value; }
        public int PosY { get => posY; set => posY = value; }
    }
}
