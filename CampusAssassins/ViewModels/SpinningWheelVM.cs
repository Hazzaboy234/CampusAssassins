﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using CampusAssassins.Models;

namespace CampusAssassins.ViewModels
{
    public class SpinningWheelVM : INotifyPropertyChanged
    {

        #region INotifyPropertyChanged
        protected bool SetProperty<T>(ref T backingStore, T value,
          [CallerMemberName] string propertyName = "",
          Action onChanged = null)
        {
            if (EqualityComparer<T>.Default.Equals(backingStore, value))
                return false;

            backingStore = value;
            onChanged?.Invoke();
            OnPropertyChanged(propertyName);
            return true;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            var changed = PropertyChanged;

            changed?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion

        #region Events
        public event EventHandler DataReady;

        #endregion

        #region Properties
        private double _refershRate;
        public double RefreshRate
        {
            get => _refershRate; set
            {
                SetProperty(ref _refershRate, value);
            }
        }
        private bool _isSpinning;
        public bool IsSpinning
        {
            get => _isSpinning; set
            {
                SetProperty(ref _isSpinning, value);
            }
        }

        private bool _enableHaptic;
        public bool EnableHaptic
        {
            get => _enableHaptic; set
            {
                SetProperty(ref _enableHaptic, value);
            }
        }


        private RotaryModel _rotaryModel;
        public RotaryModel RotaryModel
        {
            get => _rotaryModel; set
            {
                SetProperty(ref _rotaryModel, value);
            }
        }
        private RotarySector _prize;
        public RotarySector Prize
        {
            get => _prize; set
            {
                SetProperty(ref _prize, value);
            }
        }
        private List<ChartData> _chartData;
        public List<ChartData> ChartData
        {
            get => _chartData; set
            {
                SetProperty(ref _chartData, value);
            }
        }
        private List<string> _colors;
        public List<string> Colors
        {
            get => _colors; set
            {
                SetProperty(ref _colors, value);
            }
        }
        private List<int> _invalidPoints;
        public List<int> InvalidPoints
        {
            get => _invalidPoints; set
            {
                SetProperty(ref _invalidPoints, value);
            }
        }

        #endregion
        public SpinningWheelVM()
        {
            LoadData();
        }

        #region Methods

        private void LoadData()
        {
            Colors = new List<string>() { "#107C10", "#FF5A5F", "#4267B2", "#4285F4", "#DB4437", "#F4B400", "#0F9D58", "#737373", "#FFB900", "#00A4EF", "#7FBA00", "#F25022" }; //tips from Google and Microsoft Colors
            RotaryModel = new RotaryModel
            {
                Sectors = new List<RotarySector>()
            };
            //replace with actual API Call.
            RotaryModel.Sectors.Add(new RotarySector()
            {
                Color = Colors[0],
                Game = "Connect 4"
            });
            RotaryModel.Sectors.Add(new RotarySector()
            {
                Color = Colors[1],
                Game = "R, P, S"
            });
            RotaryModel.Sectors.Add(new RotarySector()
            {
                Color = Colors[2],
                Game = "Tic Tac Toe"
            });
            RotaryModel.Sectors.Add(new RotarySector()
            {
                Color = Colors[3],
                Game = "Dots & Boxes"
            });
            RotaryModel.Sectors.Add(new RotarySector()
            {
                Color = Colors[4],
                Game = "Battleships"
            });
            RotaryModel.Sectors.Add(new RotarySector()
            {
                Color = Colors[5],
                Game = "SOS"
            });
            ChartData = new List<ChartData>();
            foreach (var sector in RotaryModel.Sectors)
                ChartData.Add(new ChartData() { Sector = sector });

            int total = 360;
            int sides = ChartData.Count;
            double divisor = total / sides;
            double counter = divisor;
            InvalidPoints = new List<int>();
            while (counter <= total)
            {
                InvalidPoints.Add((int)Math.Round(counter, MidpointRounding.AwayFromZero));
                counter += divisor;
            }

            DataReady?.Invoke(this, null);
        }

        #endregion
    }
}
