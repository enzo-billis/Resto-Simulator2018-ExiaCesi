using Restaurant.Model.Shared;
using RestaurantSimulator.Controller.Salle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RestaurantSimulator.Controller
{
    public class EventHandlerGroup
    {
        private static EventHandlerGroup instance;

        private EventHandlerGroup() { }

        public static EventHandlerGroup Instance
        {
            get
            {
                if (instance == null)
                    instance = new EventHandlerGroup();
                return instance;
            }
        }

        public void Update(Group group)
        {
            switch (group.State)
            {
                case GroupState.WaitPlate:
                    SalleCommandsController.ConnectAndSendCommand(group);

                    break;
                case GroupState.WaitDessert:
                    SalleCommandsController.ConnectAndSendCommand(group);

                    break;
            }
        }

        private void UpdateCallBack()
        {
            Thread.Sleep(2000);
        }
    }
}
