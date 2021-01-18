﻿using BO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL.PO
{
    class LinePO : INotifyPropertyChanged
    {
        Line line;
        public LinePO(Line line)
        {
            this.line = line;
            this.Id = line.Id;
            this.Code = line.Code;
            this.Area = line.Area;
            this.FirstStation = line.FirstStation;
            this.LastStation = line.LastStation;
            this.listOfStationInLine = line.listOfStationInLine;
        }
        protected void RaisePropertyChanged(string propertyname)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyname));
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public Line getLine()
        {
            return line;
        }
        public int Id
        {
            get => line.Id;
            set
            {
                line.Id = value;
                RaisePropertyChanged("Id");
            }
        }
        public int Code
        {
            get => line.Code;
            set
            {
                line.Code = value;
                RaisePropertyChanged("Code");
            }
        }
        public Areas Area
        {
            get => line.Area;
            set
            {
                line.Area = value;
                RaisePropertyChanged("Area");
            }
        }
        public string FirstStation
        {
            get => line.FirstStation;
            set
            {
                line.FirstStation = value;
                RaisePropertyChanged("FirstStation");
            }
        }
        public string LastStation
        {
            get => line.LastStation;
            set
            {
                line.LastStation = value;
                RaisePropertyChanged("LastStation");
            }
        }
        public IEnumerable<Station> listOfStationInLine
        {
            get => line.listOfStationInLine;
            set
            {
                line.listOfStationInLine = value;
                RaisePropertyChanged("listOfStationInLine");
            }
        }
    }
}
