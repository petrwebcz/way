using System;
using WhereAreYou.Core.Responses;

namespace WhereAreYou.MobileApp.ViewModels
{
    public class MeetViewModel : BaseViewModel
    {
        public MeetViewModel()
        {
        }

        public MeetViewModel(MeetResponse meetResponse)
        {
            MeetResponse = meetResponse ?? throw new ArgumentNullException(nameof(meetResponse));
        }

        public MeetResponse MeetResponse { get; }
    }
}