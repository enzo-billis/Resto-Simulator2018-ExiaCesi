using Restaurant.Model.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantSimulator.Model.Salle.Observer
{
    public interface ISubject
    {
        void Notify(Group group);

        void Subscribe(IObserver observer);

        void Unsubscribe(IObserver observer);
    }
}
