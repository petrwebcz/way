using System;

namespace WhereAreYou.MobileApp.ViewModels
{
    public class EnterTheMeetViewModel : BaseViewModel
    {
        public EnterTheMeetViewModel(Core.Requests.EnterTheMeet enterTheMeet)
        {
            EnterTheMeet = enterTheMeet ?? throw new ArgumentNullException(nameof(enterTheMeet));
        }

        public WhereAreYou.Core.Requests.EnterTheMeet EnterTheMeet { get; }
    }
}