using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestaurantSimulator.Model.Salle.Characters;

namespace RestaurantSimulator.Model.Salle.Factory
{
    public abstract class AbstractClientFactory : IClientFactory
    {
        public abstract Client CreateClient();
    }
}
