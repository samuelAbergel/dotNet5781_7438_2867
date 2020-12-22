using System;

namespace dotNet5781_01_7438_2867
{
    public class Bus
    {
        private string registration;
        private DateTime aliya;
        private DateTime currentAlya;
        private int km = 1200;
        private int kmT = 0;


        public Bus(string registration, DateTime aliya,int km=1200,int kmT=0)
        {
            this.aliya = aliya;
            this.Registration = registration;
            this.km = km;
            this.kmT = kmT;
            this.currentAlya = aliya;
        }
 
        public int KM
        {
            get => km;

            set => km = value;
        }
        public int KMT
        {
            get => kmT;
            set => kmT = value;
        }
        public DateTime Aliya
        {
            get { return aliya; }
            set { aliya = new DateTime(); }
        }
        public DateTime CURRENTALYA
        {
            get { return currentAlya; }
            set { currentAlya = new DateTime(); }
        }
        public string Registration
        {
            //  get => regisration;
            get
            {
                return registration;
            }

            private set
            {
                if (aliya.Year >= 2018 && value.Length == 8)
                {
                    //checks
                    registration = value;
                }
                else if (value.Length == 7)
                {
                    registration = value;
                }
                else
                {
                    throw new Exception("taarich lo takin");
                }
            }
        }

        public override string ToString()
        {
            string prefix, middle, suffix;
            string registrationString;
            if (registration.Length == 7)
            {
                // xx-xxx-xx
                prefix = registration.Substring(0, 2);
                middle = registration.Substring(2, 3);
                suffix = registration.Substring(5, 2);
                registrationString =  String.Format("{0}-{1}-{2}", prefix, middle, suffix);
            }
            else
            {
                // xxx-xx-xxx
                prefix = registration.Substring(0, 3);
                middle = registration.Substring(3, 2);
                suffix = registration.Substring(5, 3);
                registrationString = String.Format("{0}-{1}-{2}", prefix, middle, suffix);
            }
            return String.Format("[ {0} , {1} ]", registrationString, aliya.ToShortDateString());
        }

    }
}
