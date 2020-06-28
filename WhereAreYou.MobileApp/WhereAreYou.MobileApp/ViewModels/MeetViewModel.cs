﻿using System.Collections.ObjectModel;
using WhereAreYou.Core.Responses;
using WhereAreYou.MobileApp.Models;
using Xamarin.Forms.Maps;

namespace WhereAreYou.MobileApp.ViewModels
{
    public class MeetViewModel : BaseViewModel
    {
        private MapSpan centerPoint;

        public MeetViewModel()
        {
            CenterPoint = new MapSpan(new Xamarin.Forms.Maps.Position(50.19385934655583, 14.66693449958008), 0.01, 0.01);
            MeetUsers = new ObservableCollection<MeetUser>()
            {
                new MeetUser()
                {
                    Nickname = "Petr",
                    Position = new Xamarin.Forms.Maps.Position(50.19385934655583, 14.66693449958008)
                }
            };
        }

        public MeetViewModel(MeetResponse meetResponse)
        {
        }

        public MapSpan CenterPoint
        {
            get => centerPoint;
            
            set
            {
                SetProperty(ref centerPoint, value);
            }
        }

        public ObservableCollection<MeetUser> MeetUsers { get; set; }
    }
}