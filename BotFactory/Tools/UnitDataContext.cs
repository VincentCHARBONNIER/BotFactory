﻿using BotFactory.Common.Tools;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using BotFactory.Factories;
using BotFactory.Common.Interface;

namespace BotFactory.Tools
{
    public class UnitDataContext : INotifyPropertyChanged
    {
        private ITestingUnit _ibot = null;
        private bool _response = false;
        private bool _working = false;
        private ObservableCollection<string> _reporting = new ObservableCollection<string>();

        #region Properties
        
        public ITestingUnit IBot
        {
            get { return _ibot; }
            set
            {
                if (_ibot != null)
                {
                    _ibot.UnitStatusChanged -= _ibot_UnitStatusChanged;
                }
                SetField(ref _ibot, value, nameof(IBot));
                _ibot.UnitStatusChanged += _ibot_UnitStatusChanged;
                Reports.Clear();
                ForceUpdate();
            }
        }

        public ObservableCollection<string> Reports
        {
            get
            {
                return _reporting;
            }
            set
            {
                SetField(ref _reporting, value, nameof(Reports));
                ForceUpdate();
            }
        }

        private void _ibot_UnitStatusChanged(object sender, EventArgs e)
        {
            Reports.Add(((IStatusChangedEventArgs)e).NewStatus);
        }

        private void ForceUpdate()
        {
            Working = _ibot.IsWorking;
            BuildTime = 0;
            CurrentPos = null;
            Response = false;
        }

        public bool Response
        {
            get { return _response; }
            set { SetField(ref _response, value, nameof(Response)); }
        }

        public bool Working
        {
            get { return _working; }
            set { SetField(ref _working, value, nameof(Working)); }
        }

        public string Model
        {
            get { return _ibot.GetType().Name; }
            set { OnPropertyChanged("Model"); }
        }

        public double BuildTime
        {
            get { return _ibot.BuildTime; }
            set { OnPropertyChanged("BuildTime"); }
        }

        public Coordinates CurrentPos
        {
            get { return _ibot.CurrentPos; }
            set { OnPropertyChanged("CurrentPos"); }
        }

        #endregion

        #region INotifyPropertyChanged Interface Methods

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }

        protected bool SetField<T>(ref T field, T value, string propertyName)
        {
            if (EqualityComparer<T>.Default.Equals(field, value)) return false;
            field = value;
            OnPropertyChanged(propertyName);
            return true;
        }

        #endregion
    }
}
