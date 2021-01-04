﻿using DLAPI;
using DO;
using DS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL
{
    sealed class DLObject : IDL
    {
        #region singelton
        static readonly DLObject instance = new DLObject();
        static DLObject() { }// static ctor to ensure instance init is done just before first usage
        DLObject() { } // default => private
        public static DLObject Instance { get => instance; }// The public Instance property to use
        #endregion

        #region bus
        public void addBus(Bus bus)
        {
            if ((DataSource.listBus.FirstOrDefault(p => p.LicenseNum == bus.LicenseNum) != null))
                throw new badIdBusexeption(bus);
            DataSource.listBus.Add(bus.Clone());
        }
        public void updateBus(Bus bus)
        {
            Bus sBus = DataSource.listBus.Find(p => p.LicenseNum == bus.LicenseNum);
            if (sBus != null)
            {
                DataSource.listBus.Remove(sBus);
                DataSource.listBus.Add(bus.Clone());
            }
            else
                throw new badIdBusexeption(bus.LicenseNum);
        }
        public void removeBus(int id)
        {
            if ((DataSource.listBus.FirstOrDefault(p => p.LicenseNum == id) == null))
                throw new badIdBusexeption(id);
            DataSource.listBus.RemoveAll(p => p.LicenseNum == id);
        }
        public Bus GetBus(int id)
        {
            Bus sBus = DataSource.listBus.Find(p => p.LicenseNum == id);
            if (sBus != null)
                return sBus.Clone();
            else
                throw new badIdBusexeption(id);
        }
        public IEnumerable<Bus> GetAllBus()
        {
            return from bus in DataSource.listBus
                   select bus.Clone();
        }
        #endregion

        #region line
        public void addLine(Line line)
        {
            if ((DataSource.listLine.FirstOrDefault(p => p.Id == line.Id) != null))
                throw new badIdLineexeption(line);
            DataSource.listLine.Add(line.Clone());
        }
        public void updateLine(Line line)
        {
            Line sLine = DataSource.listLine.Find(p => p.Id == line.Id);
            if (sLine != null)
            {
                DataSource.listLine.Remove(sLine);
                DataSource.listLine.Add(line.Clone());
            }
            else
                throw new badIdLineexeption(line.Id);
        }
        public void removeLine(int id)
        {
            if ((DataSource.listLine.FirstOrDefault(p => p.Id == id) == null))
                throw new badIdLineexeption(id);
            DataSource.listLine.RemoveAll(p => p.Id == id);
        }
        public Line getLine(int id)
        {
            Line sLine = DataSource.listLine.Find(p => p.Id == id);
            if (sLine != null)
                return sLine.Clone();
            else
                throw new badIdLineexeption(id);
        }
        public IEnumerable<Line> getAllLine()
        {
            return from line in DataSource.listLine
                   select line.Clone();
        }
        #endregion

        #region station
        public void addStation(Station station)
        {
            if ((DataSource.listStation.FirstOrDefault(p => p.Code == station.Code) != null))
                throw new badIDStationexeption(station);
            DataSource.listStation.Add(station.Clone());
        }
        public void updateStation(Station station)
        {
            Station sStation = DataSource.listStation.Find(p => p.Code == station.Code);
            if (sStation != null)
            {
                DataSource.listStation.Remove(sStation);
                DataSource.listStation.Add(station.Clone());
            }
            else
                throw new badIDStationexeption(station.Code);
        }
        public void removeStation(int id)
        {
            if ((DataSource.listStation.FirstOrDefault(p => p.Code == id) == null))
                throw new badIDStationexeption(id);
            DataSource.listStation.RemoveAll(p => p.Code == id);
        }
        public Station getStation(int id)
        {
            Station sStation = DataSource.listStation.Find(p => p.Code == id);
            if (sStation != null)
                return sStation.Clone();
            else
                throw new badIDStationexeption(id);
        }
        public IEnumerable<Station> getAllStation()
        {
            return from station in DataSource.listStation
                   select station.Clone();
        }
        #endregion
    }
}