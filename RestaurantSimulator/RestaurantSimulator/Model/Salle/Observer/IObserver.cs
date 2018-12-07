using Restaurant.Model.Shared;

namespace RestaurantSimulator.Model.Salle.Observer
{
    public interface IObserver
    {
        void Update(Group group);
    }
}
