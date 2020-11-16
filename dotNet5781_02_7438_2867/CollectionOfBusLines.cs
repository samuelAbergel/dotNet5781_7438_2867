using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace dotNet5781_02_7438_2867
{
    class CollectionOfBusLines : IEnumerable
    {
        public List<BusLine> lines { get; set; }
        public CollectionOfBusLines()
        {
            lines = new List<BusLine>();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return (IEnumerator)GetEnumerator();
        }

        public CollectionOfBusLines GetEnumerator()
        {
            return new CollectionOfBusLines();
        }
        public void AddLine(BusLine busLine1)
        {
            bool flag = true;
            foreach(BusLine bus in lines)
            {
                if (bus.LineNumber == busLine1.LineNumber)
                    flag = false;
            }
            if (flag)
            {
                lines.Add(busLine1);
                return;
            }
            throw new ArgumentException("this bus line already exists");
        }
        public void RemoveLine(int key)
        {
            foreach (BusLine bus in lines)
                if (bus.LineNumber == key)
                {
                    lines.Remove(bus);
                    return;
                }
            throw new ArgumentException("this bus line does not exist");
        }

        public void displayLine(int key)
        {
            bool flag = true;
            foreach (BusLine bus in lines)
            {
                foreach (BusLineStation busLine in bus.Line)
                    if (busLine.BusKey == key)
                    {
                        Console.WriteLine("Line number: "+ bus.LineNumber);
                        flag = false;
                        continue;
                    }
            }
            if (flag)
                throw new ArgumentException("this line does not pass through any station");
        }

        public string displayAllLine()
        {
            string tostring ="";
            int i = 1;
            foreach (BusLine bus in lines)
            {
                tostring += "line" + i.ToString()+" "+ bus.ToString() + "\n\n";
                ++i;
            }
            return tostring;
        }
        public BusLine this[int index]
        {
            get
            {
                foreach(BusLine bus in lines)
                    if(bus.LineNumber == index)
                    {
                        return bus;
                    }
                throw new ArgumentException("this number does not correspond to any bus line");
            }
        }


    }
    }
