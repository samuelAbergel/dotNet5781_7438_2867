using DO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DS
{
    /// <summary>
    /// init all list 
    /// </summary>
    public static class DataSource
    {
        static int id = 0;
        public static List<Bus> listBus;
        public static List<Line> listLine;
        public static List<Station> listStation;
        public static List<AdjacentStations> listAdjacentStations;
        public static List<LineStation> listLineStation;
        public static List<LineTrip> listLineTrip;
        public static List<User> listUser;


        static DataSource()
        {
            intitStation();
            initList();
        }
        private static void intitStation()
        {
            listStation = new List<Station>
            {
                new Station
                {
                    Code= 38831,
                    Name= "בי''ס בר לב/בן יהודה",
                    Lattitude=32.183921.ToString(),
                    Longitude=34.917806.ToString(),

                },
                new Station
                {
                    Code= 38832,
                    Name= "הרצל/צומת בילו",
                    Lattitude=31.8734.ToString(),
                    Longitude=34.819541.ToString(),

                },
                new Station
                {
                    Code= 38833,
                    Name= "הנחשול/הדייגים",
                    Lattitude=31.746998.ToString(),
                    Longitude=35.2364.ToString(),

                },
                new Station
                {
                    Code= 38834,
                    Name= "פריד/ששת הימים",
                    Lattitude=31.746921.ToString(),
                    Longitude=35.2167.ToString(),

                },
                new Station
                {
                    Code= 38836,
                    Name= "ת. מרכזית לוד/הורדה",
                    Lattitude=31.746341.ToString(),
                    Longitude=35.2376.ToString(),

                },
                new Station
                {
                    Code= 38837,
                    Name= "חנה אברך/וולקני",
                    Lattitude=31.727231.ToString(),
                    Longitude=35.251990.ToString(),

                },
                new Station
                {
                    Code= 38838,
                    Name= "הרצל/משה שרת",
                    Lattitude=31.746976.ToString(),
                    Longitude=35.251897.ToString(),

                },
                new Station
                {
                    Code= 38839,
                    Name= "הבנים/אלי כהן",
                    Lattitude=31.712961.ToString(),
                    Longitude=35.251721.ToString(),

                },
                new Station
                {
                    Code= 38840,
                    Name= "ויצמן/הבנים",
                    Lattitude=31.748165.ToString(),
                    Longitude=35.251675.ToString(),

                },
                new Station
                {
                    Code= 38841,
                    Name= "האירוס/הכלנית",
                    Lattitude=31.748098.ToString(),
                    Longitude=35.251586.ToString(),

                },
                new Station
                {
                    Code= 38842,
                    Name= "הכלנית/הנרקיס",
                    Lattitude=31.748076.ToString(),
                    Longitude=35.251450.ToString(),

                },
                new Station
                {
                    Code= 38844,
                    Name= "אלי כהן/לוחמי הגטאות",
                    Lattitude=31.748081.ToString(),
                    Longitude=35.251365.ToString(),

                },
                new Station
                {
                    Code= 38845,
                    Name= "שבזי/שבת אחים",
                    Lattitude=31.748067.ToString(),
                    Longitude=35.251274.ToString(),

                },
                new Station
                {
                    Code= 38846,
                    Name= "שבזי/ויצמן ",
                    Lattitude=31.7480514.ToString(),
                    Longitude=35.251189.ToString(),

                },
                new Station
                {
                    Code= 38847,
                    Name= "חיים בר לב/שדרות יצחק רבין",
                    Lattitude=31.7480489.ToString(),
                    Longitude=35.192666.ToString(),

                },
                new Station
                {
                    Code= 38848,
                    Name= "מרכז לבריאות הנפש לב השרון",
                    Lattitude=31.748034.ToString(),
                    Longitude=35.25166.ToString(),

                },
                new Station
                {
                    Code= 38849,
                    Name= "מרכז לבריאות הנפש לב השרון",
                    Lattitude=31.780296.ToString(),
                    Longitude=35.251247.ToString(),

                },
                new Station
                {
                    Code= 38852,
                    Name= "הולצמן/המדע",
                    Lattitude=31.748013.ToString(),
                    Longitude=35.19529.ToString(),

                },
                new Station
                {
                    Code= 38854,
                    Name= "מחנה צריפין/מועדון",
                    Lattitude=31.748351.ToString(),
                    Longitude=35.19534.ToString(),

                },
                new Station
                {
                    Code= 38855,
                    Name= "הרצל/גולני",
                    Lattitude=31.770868.ToString(),
                    Longitude=35.192666.ToString(),

                },
                new Station
                {
                    Code= 38856,
                    Name= "הרותם/הדגניות",
                    Lattitude=31.748349.ToString(),
                    Longitude=35.19561.ToString(),

                },
                new Station
                {
                    Code= 38859,
                    Name= "הערבה",
                    Lattitude=31.728791.ToString(),
                    Longitude=35.19573.ToString(),

                },
                new Station
                {
                    Code= 38860,
                    Name= "מבוא הגפן/מורד התאנה",
                    Lattitude=31.728098.ToString(),
                    Longitude=35.195790.ToString(),

                },
                new Station
                {
                    Code= 38861,
                    Name= "מבוא הגפן/ההרחבה",
                    Lattitude=31.728091.ToString(),
                    Longitude=35.19589.ToString(),

                },
                new Station
                {
                    Code= 38862,
                    Name= "ההרחבה א",
                    Lattitude=31.728089.ToString(),
                    Longitude=35.19507.ToString(),

                },
                new Station
                {
                    Code= 38863,
                    Name= "ההרחבה ב",
                    Lattitude=31.728072.ToString(),
                    Longitude=35.19509.ToString(),

                },
                new Station
                {
                    Code= 38864,
                    Name= "ההרחבה/הותיקים",
                    Lattitude=31.728076.ToString(),
                    Longitude=35.195666.ToString(),

                },
                new Station
                {
                    Code= 38865,
                    Name= "רשות שדות התעופה/העליה",
                    Lattitude=31.728062.ToString(),
                    Longitude=35.19541.ToString(),

                },
                new Station
                {
                    Code= 38866,
                    Name= "כנף/ברוש",
                    Lattitude=31.728059.ToString(),
                    Longitude=35.231903.ToString(),

                },
                new Station
                {
                    Code= 38867,
                    Name= "החבורה/דב הוז",
                    Lattitude=31.728047.ToString(),
                    Longitude=35.231894.ToString(),

                },
                new Station
                {
                    Code= 38869,
                    Name= "בית הלוי ה",
                    Lattitude=31.728039.ToString(),
                    Longitude=35.231759.ToString(),

                },
                new Station
                {
                    Code= 38870,
                    Name= "הראשונים/כביש 5700",
                    Lattitude=31.728028.ToString(),
                    Longitude=35.231684.ToString(),

                },
                new Station
                {
                    Code= 38872,
                    Name= "הגאון בן איש חי/צאלון",
                    Lattitude=31.728011.ToString(),
                    Longitude=35.231520.ToString(),

                },
                new Station
                {
                    Code= 38873,
                    Name= "עוקשי/לוי אשכול",
                    Lattitude=31.815421.ToString(),
                    Longitude=35.231387.ToString(),

                },
                new Station
                {
                    Code= 38875,
                    Name= "מנוחה ונחלה/יהודה גורודיסקי",
                    Lattitude=31.81090.ToString(),
                    Longitude=35.23131.ToString(),

                },
                new Station
                {
                    Code= 38876,
                    Name= "גורודסקי/יחיאל פלדי",
                    Lattitude=31.810822.ToString(),
                    Longitude=35.231295.ToString(),

                },
                new Station
                {
                    Code= 38877,
                    Name= "דרך מנחם בגין/יעקב חזן",
                    Lattitude=31.810762.ToString(),
                    Longitude=35.231142.ToString(),

                },
                new Station
                {
                    Code= 38878,
                    Name= "דרך הפארק/הרב נריה",
                    Lattitude=31.810698.ToString(),
                    Longitude=35.231094.ToString(),

                },
                new Station
                {
                    Code= 38879,
                    Name= "התאנה/הגפן",
                    Lattitude=31.813421.ToString(),
                    Longitude=35.231666.ToString(),

                },
                new Station
                {
                    Code= 38880,
                    Name= "התאנה/האלון",
                    Lattitude=31.810386.ToString(),
                    Longitude=35.231583.ToString(),

                },
            };
            listAdjacentStations = new List<AdjacentStations>
            {
                new AdjacentStations
                {
                  Station1 = 38831,
                  Station2 = 38832,
                  Distance = 1,
                  Time = TimeSpan.FromMinutes(55),
                },
                new AdjacentStations
                {
                  Station1 = 38832,
                  Station2 = 38833,
                  Distance = 1,
                  Time = TimeSpan.FromMinutes(30),
                },
                new AdjacentStations
                {
                  Station1 = 38833,
                  Station2 = 38834,
                  Distance = 1,
                  Time = TimeSpan.FromMinutes(25),
                },
                new AdjacentStations
                {
                  Station1 = 38834,
                  Station2 = 38836,
                  Distance = 2,
                  Time = TimeSpan.FromMinutes(15),
                },
                new AdjacentStations
                {
                  Station1 = 38836,
                  Station2 = 38837,
                  Distance = 2,
                  Time = TimeSpan.FromMinutes(45),
                },
                new AdjacentStations
                {
                  Station1 = 38837,
                  Station2 = 38838,
                  Distance = 2,
                  Time = TimeSpan.FromMinutes(53),
                },
                new AdjacentStations
                {
                  Station1 = 38838,
                  Station2 = 38839,
                  Distance = 3,
                  Time = TimeSpan.FromMinutes(50),
                },
                new AdjacentStations
                {
                  Station1 = 38839,
                  Station2 = 38840,
                  Distance = 3,
                  Time = TimeSpan.FromMinutes(40),
                },
                new AdjacentStations
                {
                  Station1 = 38840,
                  Station2 = 38852,
                  Distance = 3,
                  Time = TimeSpan.FromMinutes(42),
                },
                new AdjacentStations
                {
                  Station1 = 38852,
                  Station2 = 38849,
                  Distance = 4,
                  Time = TimeSpan.FromMinutes(35),
                },
                new AdjacentStations
                {
                  Station1 = 38849,
                  Station2 = 38832,
                  Distance = 4,
                  Time = TimeSpan.FromMinutes(33),
                },
                new AdjacentStations
                {
                  Station1 = 38832,
                  Station2 = 38831,
                  Distance = 4,
                  Time = TimeSpan.FromMinutes(31),
                },
                new AdjacentStations
                {
                  Station1 = 38831,
                  Station2 = 38844,
                  Distance = 5,
                  Time = TimeSpan.FromMinutes(41),
                },
                new AdjacentStations
                {
                  Station1 = 38844,
                  Station2 = 38848,
                  Distance = 5,
                  Time = TimeSpan.FromMinutes(42),
                },
                new AdjacentStations
                {
                  Station1 = 38848,
                  Station2 = 38842,
                  Distance = 5,
                  Time = TimeSpan.FromMinutes(43),
                },
                new AdjacentStations
                {
                  Station1 = 38842,
                  Station2 = 38838,
                  Distance = 6,
                  Time = TimeSpan.FromMinutes(50),
                },
                new AdjacentStations
                {
                  Station1 = 38838,
                  Station2 = 38833,
                  Distance = 6,
                  Time = TimeSpan.FromMinutes(52),
                },
                new AdjacentStations
                {
                  Station1 = 38833,
                  Station2 = 38845,
                  Distance = 6,
                  Time = TimeSpan.FromMinutes(51),
                },
                new AdjacentStations
                {
                  Station1 = 38833,
                  Station2 = 38852,
                  Distance = 7,
                  Time = TimeSpan.FromMinutes(15),
                },
                new AdjacentStations
                {
                  Station1 = 38852,
                  Station2 = 38842,
                  Distance = 7,
                  Time = TimeSpan.FromMinutes(16),
                },
                new AdjacentStations
                {
                  Station1 = 38842,
                  Station2 = 38859,
                  Distance = 7,
                  Time = TimeSpan.FromMinutes(18),
                },
                new AdjacentStations
                {
                  Station1 = 38859,
                  Station2 = 38864,
                  Distance = 8,
                  Time = TimeSpan.FromMinutes(26),
                },
                new AdjacentStations
                {
                  Station1 = 38864,
                  Station2 = 38866,
                  Distance = 8,
                  Time = TimeSpan.FromMinutes(29),
                },
                new AdjacentStations
                {
                  Station1 = 38866,
                  Station2 = 38856,
                  Distance = 8,
                  Time = TimeSpan.FromMinutes(27),
                },
                new AdjacentStations
                {
                  Station1 = 38856,
                  Station2 = 38832,
                  Distance = 9,
                  Time = TimeSpan.FromMinutes(39),
                },
                new AdjacentStations
                {
                  Station1 = 38832,
                  Station2 = 38837,
                  Distance = 9,
                  Time = TimeSpan.FromMinutes(35),
                },
                new AdjacentStations
                {
                  Station1 = 38837,
                  Station2 = 38840,
                  Distance = 9,
                  Time = TimeSpan.FromMinutes(37),
                },
                new AdjacentStations
                {
                  Station1 = 38834,
                  Station2 = 38852,
                  Distance = 10,
                  Time = TimeSpan.FromMinutes(53),
                },
                new AdjacentStations
                {
                  Station1 = 38852,
                  Station2 = 38862,
                  Distance = 10,
                  Time = TimeSpan.FromMinutes(54),
                },
                new AdjacentStations
                {
                  Station1 = 38862,
                  Station2 = 38863,
                  Distance = 10,
                  Time = TimeSpan.FromMinutes(59),
                },
                new AdjacentStations
                {
                  Station1 = 38863,
                  Station2 = 38834,
                  Distance = 10,
                  Time = TimeSpan.FromMinutes(59),
                },
                new AdjacentStations
                {
                  Station1 = 38834,
                  Station2 = 38856,
                  Distance = 10,
                  Time = TimeSpan.FromMinutes(59),
                },
                new AdjacentStations
                {
                  Station1 = 38856,
                  Station2 = 38859,
                  Distance = 10,
                  Time = TimeSpan.FromMinutes(59),
                },
                new AdjacentStations
                {
                  Station1 = 38859,
                  Station2 = 38838,
                  Distance = 10,
                  Time = TimeSpan.FromMinutes(59),
                },
                new AdjacentStations
                {
                  Station1 = 38838,
                  Station2 = 38833,
                  Distance = 10,
                  Time = TimeSpan.FromMinutes(59),
                },
                new AdjacentStations
                {
                  Station1 = 38833,
                  Station2 = 38840,
                  Distance = 10,
                  Time = TimeSpan.FromMinutes(59),
                },
                new AdjacentStations
                {
                  Station1 = 38839,
                  Station2 = 38847,
                  Distance = 10,
                  Time = TimeSpan.FromMinutes(59),
                },
                new AdjacentStations
                {
                  Station1 = 38847,
                  Station2 = 38862,
                  Distance = 10,
                  Time = TimeSpan.FromMinutes(59),
                },
                new AdjacentStations
                {
                  Station1 = 38862,
                  Station2 = 38833,
                  Distance = 10,
                  Time = TimeSpan.FromMinutes(59),
                },
                new AdjacentStations
                {
                  Station1 = 38833,
                  Station2 = 38841,
                  Distance = 10,
                  Time = TimeSpan.FromMinutes(59),
                },
                new AdjacentStations
                {
                  Station1 = 38841,
                  Station2 = 38846,
                  Distance = 10,
                  Time = TimeSpan.FromMinutes(59),
                },
                new AdjacentStations
                {
                  Station1 = 38846,
                  Station2 = 38860,
                  Distance = 10,
                  Time = TimeSpan.FromMinutes(59),
                },
                new AdjacentStations
                {
                  Station1 = 38860,
                  Station2 = 38838,
                  Distance = 10,
                  Time = TimeSpan.FromMinutes(59),
                },
                new AdjacentStations
                {
                  Station1 = 38838,
                  Station2 = 38859,
                  Distance = 10,
                  Time = TimeSpan.FromMinutes(59),
                },
                new AdjacentStations
                {
                  Station1 = 38859,
                  Station2 = 38834,
                  Distance = 10,
                  Time = TimeSpan.FromMinutes(59),
                },
                new AdjacentStations
                {
                  Station1 = 38849,
                  Station2 = 38831,
                  Distance = 10,
                  Time = TimeSpan.FromMinutes(59),
                },
                new AdjacentStations
                {
                  Station1 = 38831,
                  Station2 = 38862,
                  Distance = 10,
                  Time = TimeSpan.FromMinutes(59),
                },
                new AdjacentStations
                {
                  Station1 = 38862,
                  Station2 = 38863,
                  Distance = 10,
                  Time = TimeSpan.FromMinutes(59),
                },
                new AdjacentStations
                {
                  Station1 = 38863,
                  Station2 = 38841,
                  Distance = 10,
                  Time = TimeSpan.FromMinutes(59),
                },
                new AdjacentStations
                {
                  Station1 = 38841,
                  Station2 = 38836,
                  Distance = 10,
                  Time = TimeSpan.FromMinutes(59),
                },
                new AdjacentStations
                {
                  Station1 = 38836,
                  Station2 = 38840,
                  Distance = 10,
                  Time = TimeSpan.FromMinutes(59),
                },
                new AdjacentStations
                {
                  Station1 = 38840,
                  Station2 = 38859,
                  Distance = 10,
                  Time = TimeSpan.FromMinutes(59),
                },
                new AdjacentStations
                {
                  Station1 = 38859,
                  Station2 = 38839,
                  Distance = 10,
                  Time = TimeSpan.FromMinutes(59),
                },
                new AdjacentStations
                {
                  Station1 = 38839,
                  Station2 = 38844,
                  Distance = 10,
                  Time = TimeSpan.FromMinutes(59),
                },
                new AdjacentStations
                {
                  Station1 = 38834,
                  Station2 = 38837,
                  Distance = 10,
                  Time = TimeSpan.FromMinutes(59),
                },
                new AdjacentStations
                {
                  Station1 = 38837,
                  Station2 = 38842,
                  Distance = 10,
                  Time = TimeSpan.FromMinutes(59),
                },
                new AdjacentStations
                {
                  Station1 = 38842,
                  Station2 = 38854,
                  Distance = 10,
                  Time = TimeSpan.FromMinutes(59),
                },
                new AdjacentStations
                {
                  Station1 = 38854,
                  Station2 = 38841,
                  Distance = 10,
                  Time = TimeSpan.FromMinutes(59),
                },
                new AdjacentStations
                {
                  Station1 = 38841,
                  Station2 = 38836,
                  Distance = 10,
                  Time = TimeSpan.FromMinutes(59),
                },
                new AdjacentStations
                {
                  Station1 = 38836,
                  Station2 = 38864,
                  Distance = 10,
                  Time = TimeSpan.FromMinutes(59),
                },
                new AdjacentStations
                {
                  Station1 = 38864,
                  Station2 = 38867,
                  Distance = 10,
                  Time = TimeSpan.FromMinutes(59),
                },
                new AdjacentStations
                {
                  Station1 = 38867,
                  Station2 = 38849,
                  Distance = 10,
                  Time = TimeSpan.FromMinutes(59),
                },
                new AdjacentStations
                {
                  Station1 = 38849,
                  Station2 = 38837,
                  Distance = 10,
                  Time = TimeSpan.FromMinutes(59),
                },
                new AdjacentStations
                {
                  Station1 = 38839,
                  Station2 = 38859,
                  Distance = 10,
                  Time = TimeSpan.FromMinutes(59),
                },
                new AdjacentStations
                {
                  Station1 = 38859,
                  Station2 = 38832,
                  Distance = 10,
                  Time = TimeSpan.FromMinutes(59),
                },
                new AdjacentStations
                {
                  Station1 = 38832,
                  Station2 = 38863,
                  Distance = 10,
                  Time = TimeSpan.FromMinutes(59),
                },
                new AdjacentStations
                {
                  Station1 = 38863,
                  Station2 = 38854,
                  Distance = 10,
                  Time = TimeSpan.FromMinutes(59),
                },
                new AdjacentStations
                {
                  Station1 = 38854,
                  Station2 = 38846,
                  Distance = 10,
                  Time = TimeSpan.FromMinutes(59),
                },
                new AdjacentStations
                {
                  Station1 = 38846,
                  Station2 = 38840,
                  Distance = 10,
                  Time = TimeSpan.FromMinutes(59),
                },
                new AdjacentStations
                {
                  Station1 = 38840,
                  Station2 = 38848,
                  Distance = 10,
                  Time = TimeSpan.FromMinutes(59),
                },
                new AdjacentStations
                {
                  Station1 = 38848,
                  Station2 = 38859,
                  Distance = 10,
                  Time = TimeSpan.FromMinutes(59),
                },
                new AdjacentStations
                {
                  Station1 = 38859,
                  Station2 = 38864,
                  Distance = 10,
                  Time = TimeSpan.FromMinutes(59),
                },
                new AdjacentStations
                {
                  Station1 = 38839,
                  Station2 = 38847,
                  Distance = 10,
                  Time = TimeSpan.FromMinutes(59),
                },
                new AdjacentStations
                {
                  Station1 = 38847,
                  Station2 = 38862,
                  Distance = 10,
                  Time = TimeSpan.FromMinutes(59),
                },
                new AdjacentStations
                {
                  Station1 = 38862,
                  Station2 = 38833,
                  Distance = 10,
                  Time = TimeSpan.FromMinutes(59),
                },
                new AdjacentStations
                {
                  Station1 = 38833,
                  Station2 = 38841,
                  Distance = 10,
                  Time = TimeSpan.FromMinutes(59),
                },
                new AdjacentStations
                {
                  Station1 = 38841,
                  Station2 = 38846,
                  Distance = 10,
                  Time = TimeSpan.FromMinutes(59),
                },
                new AdjacentStations
                {
                  Station1 = 38846,
                  Station2 = 38860,
                  Distance = 10,
                  Time = TimeSpan.FromMinutes(59),
                },
                new AdjacentStations
                {
                  Station1 = 38860,
                  Station2 = 38838,
                  Distance = 10,
                  Time = TimeSpan.FromMinutes(59),
                },
                new AdjacentStations
                {
                  Station1 = 38838,
                  Station2 = 38859,
                  Distance = 10,
                  Time = TimeSpan.FromMinutes(59),
                },
                new AdjacentStations
                {
                  Station1 = 38859,
                  Station2 = 38834,
                  Distance = 10,
                  Time = TimeSpan.FromMinutes(59),
                },
               
                new AdjacentStations
                {
                  Station1 = 38838,
                  Station2 = 38856,
                  Distance = 10,
                  Time = TimeSpan.FromMinutes(59),
                },
                new AdjacentStations
                {
                  Station1 = 38856,
                  Station2 = 38852,
                  Distance = 10,
                  Time = TimeSpan.FromMinutes(59),
                },
                new AdjacentStations
                {
                  Station1 = 38852,
                  Station2 = 38831,
                  Distance = 10,
                  Time = TimeSpan.FromMinutes(59),
                },
                new AdjacentStations
                {
                  Station1 = 38831,
                  Station2 = 38841,
                  Distance = 10,
                  Time = TimeSpan.FromMinutes(59),
                },
                new AdjacentStations
                {
                  Station1 = 38841,
                  Station2 = 38836,
                  Distance = 10,
                  Time = TimeSpan.FromMinutes(59),
                },
                new AdjacentStations
                {
                  Station1 = 38836,
                  Station2 = 38863,
                  Distance = 10,
                  Time = TimeSpan.FromMinutes(59),
                },
                new AdjacentStations
                {
                  Station1 = 38863,
                  Station2 = 38848,
                  Distance = 10,
                  Time = TimeSpan.FromMinutes(59),
                },
                new AdjacentStations
                {
                  Station1 = 38848,
                  Station2 = 38859,
                  Distance = 10,
                  Time = TimeSpan.FromMinutes(59),
                },
                new AdjacentStations
                {
                  Station1 = 38859,
                  Station2 = 38864,
                  Distance = 10,
                  Time = TimeSpan.FromMinutes(59),
                },
                new AdjacentStations
                {
                  Station1 = 38852,
                  Station2 = 38837,
                  Distance = 10,
                  Time = TimeSpan.FromMinutes(59),
                },
                new AdjacentStations
                {
                  Station1 = 38837,
                  Station2 = 38866,
                  Distance = 10,
                  Time = TimeSpan.FromMinutes(59),
                },
                new AdjacentStations
                {
                  Station1 = 38866,
                  Station2 = 38833,
                  Distance = 10,
                  Time = TimeSpan.FromMinutes(59),
                },
                new AdjacentStations
                {
                  Station1 = 38833,
                  Station2 = 38841,
                  Distance = 10,
                  Time = TimeSpan.FromMinutes(59),
                },
                new AdjacentStations
                {
                  Station1 = 38841,
                  Station2 = 38840,
                  Distance = 10,
                  Time = TimeSpan.FromMinutes(59),
                },
                new AdjacentStations
                {
                  Station1 = 38840,
                  Station2 = 38832,
                  Distance = 10,
                  Time = TimeSpan.FromMinutes(59),
                },
                new AdjacentStations
                {
                  Station1 = 38832,
                  Station2 = 38852,
                  Distance = 10,
                  Time = TimeSpan.FromMinutes(59),
                },
                new AdjacentStations
                {
                  Station1 = 38852,
                  Station2 = 38839,
                  Distance = 10,
                  Time = TimeSpan.FromMinutes(59),
                },
                new AdjacentStations
                {
                  Station1 = 38839,
                  Station2 = 38864,
                  Distance = 10,
                  Time = TimeSpan.FromMinutes(59),
                },
            };
        }
        private static void initList()
        {
            listBus = new List<Bus>()
            {
               new Bus
               {
                   FromDate = DateTime.Now.AddMonths(-10),
                   FuelRemain = 1050,
                   LicenseNum = 12345678,
                   Status = BusStatus.ReadyToGo,
                   TotalTrip = 2345,
                   BusOfLine =1,
                   previewTreatmentDate = DateTime.Now.AddMonths(-9)

               },
               new Bus
               {
                   FromDate = DateTime.Now.AddMonths(-20),
                   FuelRemain = 1200,
                   LicenseNum = 98765432,
                   Status = BusStatus.ReadyToGo,
                   TotalTrip = 4567,
                   BusOfLine = 1,
                   previewTreatmentDate = DateTime.Now.AddMonths(-19)

               },
               new Bus
               {
                   FromDate = DateTime.Now.AddMonths(-167),
                   FuelRemain = 1200,
                   LicenseNum = 6494,
                   Status = BusStatus.ReadyToGo,
                   TotalTrip = 9876,
                   BusOfLine = 2,
                   previewTreatmentDate = DateTime.Now.AddMonths(-160)
               },
               new Bus
               {
                   FromDate = DateTime.Now.AddMonths(-7890),
                   FuelRemain = 1200,
                   LicenseNum = 6756366,
                   Status = BusStatus.ReadyToGo,
                   TotalTrip = 6278,
                   BusOfLine =2,
                   previewTreatmentDate = DateTime.Now.AddMonths(-7889)
               },
               new Bus
               {
                   FromDate = DateTime.Now.AddMonths(-7896),
                   FuelRemain = 1200,
                   LicenseNum = 1236789,
                   Status = BusStatus.ReadyToGo,
                   TotalTrip = 9278,
                   BusOfLine = 3,
                   previewTreatmentDate = DateTime.Now.AddMonths(-780)
               },
               new Bus
               {
                   FromDate = DateTime.Now.AddMonths(-56),
                   FuelRemain = 1200,
                   LicenseNum = 8755342,
                   Status = BusStatus.ReadyToGo,
                   TotalTrip = 8765,
                   BusOfLine = 3,
                   previewTreatmentDate = DateTime.Now.AddMonths(-9)
               },
               new Bus
               {
                   FromDate = DateTime.Now.AddMonths(-526),
                   FuelRemain = 1200,
                   LicenseNum = 0985432,
                   Status = BusStatus.ReadyToGo,
                   TotalTrip = 2562,
                   BusOfLine = 4,
                   previewTreatmentDate = DateTime.Now.AddMonths(-15)
               },
               new Bus
               {
                   FromDate = DateTime.Now.AddMonths(-98),
                   FuelRemain = 1200,
                   LicenseNum = 8766534,
                   Status = BusStatus.ReadyToGo,
                   TotalTrip = 2765,
                   BusOfLine = 4,
                   previewTreatmentDate = DateTime.Now.AddMonths(-12)
               },
               new Bus
               {
                   FromDate = DateTime.Now.AddMonths(-257),
                   FuelRemain = 1200,
                   LicenseNum = 98765326,
                   Status = BusStatus.ReadyToGo,
                   TotalTrip = 25522,
                   BusOfLine = 5,
                   previewTreatmentDate = DateTime.Now.AddMonths(-42)
               },
               new Bus
               {
                   FromDate = DateTime.Now.AddMonths(-82),
                   FuelRemain = 1200,
                   LicenseNum = 09876423,
                   Status = BusStatus.ReadyToGo,
                   TotalTrip = 727,
                   BusOfLine = 5,
                   previewTreatmentDate = DateTime.Now.AddMonths(-24)
               },
               new Bus
               {
                   FromDate = DateTime.Now.AddMonths(-16),
                   FuelRemain = 1200,
                   LicenseNum = 09875432,
                   Status = BusStatus.ReadyToGo,
                   TotalTrip = 26725,
                   BusOfLine = 6,
                   previewTreatmentDate = DateTime.Now.AddMonths(-10)
               },
               new Bus
               {
                   FromDate = DateTime.Now.AddMonths(-267),
                   FuelRemain = 1200,
                   LicenseNum = 2426568,
                   Status = BusStatus.ReadyToGo,
                   TotalTrip = 2562,
                   BusOfLine = 6,
                   previewTreatmentDate = DateTime.Now.AddMonths(-15)
               },
               new Bus
               {
                   FromDate = DateTime.Now.AddMonths(-76),
                   FuelRemain = 1200,
                   LicenseNum = 2752202,
                   Status = BusStatus.ReadyToGo,
                   TotalTrip = 25790,
                   BusOfLine = 7,
                   previewTreatmentDate = DateTime.Now.AddMonths(-12)
               },
               new Bus
               {
                   FromDate = DateTime.Now.AddMonths(-566),
                   FuelRemain = 1200,
                   LicenseNum = 76756463,
                   Status = BusStatus.ReadyToGo,
                   TotalTrip = 6382,
                   BusOfLine = 7,
                   previewTreatmentDate = DateTime.Now.AddMonths(-23)
               },
               new Bus
               {
                   FromDate = DateTime.Now.AddMonths(-209),
                   FuelRemain = 1200,
                   LicenseNum = 2867296,
                   Status = BusStatus.ReadyToGo,
                   TotalTrip = 6286,
                   BusOfLine = 8,
                   previewTreatmentDate = DateTime.Now.AddMonths(-30)
               },
               new Bus
               {
                   FromDate = DateTime.Now.AddMonths(-256),
                   FuelRemain = 1200,
                   LicenseNum = 7292972,
                   Status = BusStatus.ReadyToGo,
                   TotalTrip = 2517,
                   BusOfLine = 8,
                   previewTreatmentDate = DateTime.Now.AddMonths(-2)
               },
               new Bus
               {
                   FromDate = DateTime.Now.AddMonths(-123),
                   FuelRemain = 1200,
                   LicenseNum = 9999999,
                   Status = BusStatus.ReadyToGo,
                   TotalTrip = 12345,
                   BusOfLine = 9,
                   previewTreatmentDate = DateTime.Now.AddMonths(-3)
               },
               new Bus
               {
                   FromDate = DateTime.Now.AddMonths(-78),
                   FuelRemain = 1200,
                   LicenseNum = 2682982,
                   Status = BusStatus.ReadyToGo,
                   TotalTrip = 8079,
                   BusOfLine = 9,
                   previewTreatmentDate = DateTime.Now.AddMonths(-7)
               },
               new Bus
               {
                   FromDate = DateTime.Now.AddMonths(-526),
                   FuelRemain = 1200,
                   LicenseNum = 41642462,
                   Status = BusStatus.ReadyToGo,
                   TotalTrip = 897,
                   BusOfLine = 10,
                   previewTreatmentDate = DateTime.Now.AddMonths(-9)
               },
               new Bus
               {
                   FromDate = DateTime.Now.AddMonths(-567),
                   FuelRemain = 1200,
                   LicenseNum = 9786556,
                   Status = BusStatus.ReadyToGo,
                   TotalTrip = 09878,
                   BusOfLine = 10,
                   previewTreatmentDate = DateTime.Now.AddMonths(-23)
               },
            };
            listLine = new List<Line>
            {
                new Line
                {
                    Code = 1,
                    FirstStation = 38830.ToString(),
                    LastStation = 38840.ToString(),
                    Area = Areas.center,

                },
                new Line
                {
                    Code = 21,
                    FirstStation = 38852.ToString(),
                    LastStation = 38845.ToString(),
                    Area = Areas.center,
                },
                new Line
                {
                    Code = 39,
                    FirstStation = 38833.ToString(),
                    LastStation = 38840.ToString(),
                    Area = Areas.east,
                },
                new Line
                {
                    Code =75,
                    FirstStation = 38834.ToString(),
                    LastStation = 38840.ToString(),
                    Area = Areas.north,
                },
                new Line
                {
                    Code = 42,
                    FirstStation = 38839.ToString(),
                    LastStation = 38834.ToString(),
                    Area = Areas.south,
                },
                new Line
                {
                    Code = 71,
                    FirstStation = 38849.ToString(),
                    LastStation = 38844.ToString(),
                    Area = Areas.west,
                },
                new Line
                {
                    Code = 67,
                    FirstStation = 38834.ToString(),
                    LastStation = 38837.ToString(),
                    Area = Areas.north,
                },
                new Line
                {
                    Code = 92,
                    FirstStation = 38839.ToString(),
                    LastStation = 38864.ToString(),
                    Area = Areas.south,
                },
                new Line
                {
                    Code = 6,
                    FirstStation = 38838.ToString(),
                    LastStation = 38864.ToString(),
                    Area = Areas.west,
                },
                new Line
                {
                    Code = 4,
                    FirstStation = 38839.ToString(),
                    LastStation = 38834.ToString(),
                    Area = Areas.east,
                },
                 new Line
                {
                    Code = 5,
                    FirstStation = 38852.ToString(),
                    LastStation = 38864.ToString(),
                    Area = Areas.north,
                },
            };
            listLineStation = new List<LineStation>()
            {
                new LineStation
                {
                   id = id++,
                   LineId = 1,
                   LineStationIndex=0,
                   Station = 38831
                },
                new LineStation
                {
                   id = id++,
                   LineId = 1,
                   LineStationIndex=1,
                   Station = 38852
                },
                new LineStation
                {
                   id = id++,
                   LineId = 1,
                   LineStationIndex=2,
                   Station = 38832
                },
                new LineStation
                {
                   id = id++,
                   LineId = 1,
                   LineStationIndex=3,
                   Station = 38833
                },
                new LineStation
                {
                   id = id++,
                   LineId = 1,
                   LineStationIndex=4,
                   Station = 38834
                },
                new LineStation
                {
                   id = id++,
                   LineId = 1,
                   LineStationIndex=5,
                   Station = 38836
                },
                new LineStation
                {
                   id = id++,
                   LineId = 1,
                   LineStationIndex=6,
                   Station = 38837
                },
                new LineStation
                {
                   id = id++,
                   LineId = 1,
                   LineStationIndex=7,
                   Station = 38838
                },
                new LineStation
                {
                   id = id++,
                   LineId = 1,
                   LineStationIndex=8,
                   Station = 38839
                },
                new LineStation
                {
                   id = id++,
                   LineId = 1,
                   LineStationIndex=9,
                   Station = 38840
                },


                new LineStation
                {
                   id = id++,
                   LineId = 21,
                   LineStationIndex=0,
                   Station = 38852
                },
                new LineStation
                {
                   id = id++,
                   LineId = 21,
                   LineStationIndex=1,
                   Station = 38849
                },
                new LineStation
                {
                   id = id++,
                   LineId = 21,
                   LineStationIndex=2,
                   Station = 38832
                },
                new LineStation
                {
                   id = id++,
                   LineId = 21,
                   LineStationIndex=3,
                   Station = 38831
                },
                new LineStation
                {
                   id = id++,
                   LineId = 21,
                   LineStationIndex=4,
                   Station = 38844
                },
                new LineStation
                {
                   id = id++,
                   LineId = 21,
                   LineStationIndex=5,
                   Station = 38848
                },
                new LineStation
                {
                   id = id++,
                   LineId = 21,
                   LineStationIndex=6,
                   Station = 38842
                },
                new LineStation
                {
                   id = id++,
                   LineId = 21,
                   LineStationIndex=7,
                   Station = 38838
                },
                new LineStation
                {
                   id = id++,
                   LineId = 21,
                   LineStationIndex=8,
                   Station = 38833
                },
                new LineStation
                {
                   id = id++,
                   LineId = 21,
                   LineStationIndex=9,
                   Station = 38845
                },


                new LineStation
                {
                   id = id++,
                   LineId = 39,
                   LineStationIndex=0,
                   Station = 38833
                },
                new LineStation
                {
                   id = id++,
                   LineId = 39,
                   LineStationIndex=1,
                   Station = 38852
                },
                new LineStation
                {
                   id = id++,
                   LineId = 39,
                   LineStationIndex=2,
                   Station = 38842
                },
                new LineStation
                {
                   id = id++,
                   LineId = 39,
                   LineStationIndex=3,
                   Station = 38859
                },
                new LineStation
                {
                   id = id++,
                   LineId = 39,
                   LineStationIndex=4,
                   Station = 38864
                },
                new LineStation
                {
                   id = id++,
                   LineId = 39,
                   LineStationIndex=5,
                   Station = 38866
                },
                new LineStation
                {
                   id = id++,
                   LineId = 39,
                   LineStationIndex=6,
                   Station = 38856
                },
                new LineStation
                {
                   id = id++,
                   LineId = 39,
                   LineStationIndex=7,
                   Station = 38832
                },
                new LineStation
                {
                   id = id++,
                   LineId = 39,
                   LineStationIndex=8,
                   Station = 38837
                },
                new LineStation
                {
                   id = id++,
                   LineId = 39,
                   LineStationIndex=9,
                   Station = 38840
                },


                new LineStation
                {
                   id = id++,
                   LineId = 75,
                   LineStationIndex=0,
                   Station = 38834
                },
                new LineStation
                {
                   id = id++,
                   LineId = 75,
                   LineStationIndex=1,
                   Station = 38852
                },
                new LineStation
                {
                   id = id++,
                   LineId = 75,
                   LineStationIndex=2,
                   Station = 38862
                },
                new LineStation
                {
                   id = id++,
                   LineId = 75,
                   LineStationIndex=3,
                   Station = 38863
                },
                new LineStation
                {
                   id = id++,
                   LineId = 75,
                   LineStationIndex=4,
                   Station = 38834
                },
                new LineStation
                {
                   id = id++,
                   LineId = 75,
                   LineStationIndex=5,
                   Station = 38856
                },
                new LineStation
                {
                   id = id++,
                   LineId = 75,
                   LineStationIndex=6,
                   Station = 38859
                },
                new LineStation
                {
                   id = id++,
                   LineId = 75,
                   LineStationIndex=7,
                   Station = 38838
                },
                new LineStation
                {
                   id = id++,
                   LineId = 75,
                   LineStationIndex=8,
                   Station = 38833
                },
                new LineStation
                {
                   id = id++,
                   LineId = 75,
                   LineStationIndex=9,
                   Station = 38840
                },


                new LineStation
                {
                   id = id++,
                   LineId = 42,
                   LineStationIndex=0,
                   Station = 38839
                },
                new LineStation
                {
                   id = id++,
                   LineId = 42,
                   LineStationIndex=1,
                   Station = 38847
                },
                new LineStation
                {
                   id = id++,
                   LineId = 42,
                   LineStationIndex=2,
                   Station = 38862
                },
                new LineStation
                {
                   id = id++,
                   LineId = 42,
                   LineStationIndex=3,
                   Station = 38833
                },
                new LineStation
                {
                   id = id++,
                   LineId = 42,
                   LineStationIndex=4,
                   Station = 38841
                },
                new LineStation
                {
                   id = id++,
                   LineId = 42,
                   LineStationIndex=5,
                   Station = 38846
                },
                new LineStation
                {
                   id = id++,
                   LineId = 42,
                   LineStationIndex=6,
                   Station = 38860
                },
                new LineStation
                {
                   id = id++,
                   LineId = 42,
                   LineStationIndex=7,
                   Station = 38838
                },
                new LineStation
                {
                   id = id++,
                   LineId = 42,
                   LineStationIndex=8,
                   Station = 38859
                },
                new LineStation
                {
                   id = id++,
                   LineId = 42,
                   LineStationIndex=9,
                   Station = 38834
                },


                new LineStation
                {
                   id = id++,
                   LineId = 71,
                   LineStationIndex=0,
                   Station = 38849
                },
                new LineStation
                {
                   id = id++,
                   LineId = 71,
                   LineStationIndex=1,
                   Station = 38831
                },
                new LineStation
                {
                   id = id++,
                   LineId = 71,
                   LineStationIndex=2,
                   Station = 38862
                },
                new LineStation
                {
                   id = id++,
                   LineId = 71,
                   LineStationIndex=3,
                   Station = 38863
                },
                new LineStation
                {
                   id = id++,
                   LineId = 71,
                   LineStationIndex=4,
                   Station = 38841
                },
                new LineStation
                {
                   id = id++,
                   LineId = 71,
                   LineStationIndex=5,
                   Station = 38836
                },
                new LineStation
                {
                   id = id++,
                   LineId = 71,
                   LineStationIndex=6,
                   Station = 38840
                },
                new LineStation
                {
                   id = id++,
                   LineId = 71,
                   LineStationIndex=7,
                   Station = 38859
                },
                new LineStation
                {
                   id = id++,
                   LineId = 71,
                   LineStationIndex=8,
                   Station = 38839
                },
                new LineStation
                {
                   id = id++,
                   LineId = 71,
                   LineStationIndex=9,
                   Station = 38844
                },


                new LineStation
                {
                   id = id++,
                   LineId = 67,
                   LineStationIndex=0,
                   Station = 38834
                },
                new LineStation
                {
                   id = id++,
                   LineId = 67,
                   LineStationIndex=1,
                   Station = 38837
                },
                new LineStation
                {
                   id = id++,
                   LineId = 67,
                   LineStationIndex=2,
                   Station = 38842
                },
                new LineStation
                {
                   id = id++,
                   LineId = 67,
                   LineStationIndex=3,
                   Station = 38854
                },
                new LineStation
                {
                   id = id++,
                   LineId = 67,
                   LineStationIndex=4,
                   Station = 38841
                },
                new LineStation
                {
                   id = id++,
                   LineId = 67,
                   LineStationIndex=5,
                   Station = 38836
                },
                new LineStation
                {
                   id = id++,
                   LineId = 67,
                   LineStationIndex=6,
                   Station = 38864
                },
                new LineStation
                {
                   id = id++,
                   LineId = 67,
                   LineStationIndex=7,
                   Station = 38867
                },
                new LineStation
                {
                   id = id++,
                   LineId = 67,
                   LineStationIndex=8,
                   Station = 38849
                },
                new LineStation
                {
                   id = id++,
                   LineId = 67,
                   LineStationIndex=9,
                   Station = 38837
                },


                new LineStation
                {
                   id = id++,
                   LineId = 92,
                   LineStationIndex=0,
                   Station = 38839
                },
                new LineStation
                {
                   id = id++,
                   LineId = 92,
                   LineStationIndex=1,
                   Station = 38859
                },
                new LineStation
                {
                   id = id++,
                   LineId = 92,
                   LineStationIndex=2,
                   Station = 38832
                },
                new LineStation
                {
                   id = id++,
                   LineId = 92,
                   LineStationIndex=3,
                   Station = 38863
                },
                new LineStation
                {
                   id = id++,
                   LineId = 92,
                   LineStationIndex=4,
                   Station = 38854
                },
                new LineStation
                {
                   id = id++,
                   LineId = 92,
                   LineStationIndex=5,
                   Station = 38846
                },
                new LineStation
                {
                   id = id++,
                   LineId = 92,
                   LineStationIndex=6,
                   Station = 38840
                },
                new LineStation
                {
                   id = id++,
                   LineId = 92,
                   LineStationIndex=7,
                   Station = 38848
                },
                new LineStation
                {
                   id = id++,
                   LineId = 92,
                   LineStationIndex=8,
                   Station = 38859
                },
                new LineStation
                {
                   id = id++,
                   LineId = 92,
                   LineStationIndex=9,
                   Station = 38864
                },


                new LineStation
                {
                   id = id++,
                   LineId = 4,
                   LineStationIndex=0,
                   Station = 38839
                },
                new LineStation
                {
                   id = id++,
                   LineId = 4,
                   LineStationIndex=1,
                   Station = 38847
                },
                new LineStation
                {
                   id = id++,
                   LineId = 4,
                   LineStationIndex=2,
                   Station = 38862
                },
                new LineStation
                {
                   id = id++,
                   LineId = 4,
                   LineStationIndex=3,
                   Station = 38833
                },
                new LineStation
                {
                   id = id++,
                   LineId = 4,
                   LineStationIndex=4,
                   Station = 38841
                },
                new LineStation
                {
                   id = id++,
                   LineId = 4,
                   LineStationIndex=5,
                   Station = 38846
                },
                new LineStation
                {
                   id = id++,
                   LineId = 4,
                   LineStationIndex=6,
                   Station = 38860
                },
                new LineStation
                {
                   id = id++,
                   LineId = 4,
                   LineStationIndex=7,
                   Station = 38838
                },
                new LineStation
                {
                   id = id++,
                   LineId = 4,
                   LineStationIndex=8,
                   Station = 38859
                },
                new LineStation
                {
                   id = id++,
                   LineId = 4,
                   LineStationIndex=9,
                   Station = 38834
                },


                new LineStation
                {
                   id = id++,
                   LineId = 6,
                   LineStationIndex=0,
                   Station = 38838
                },  
                new LineStation
                {
                   id = id++,
                   LineId = 6,
                   LineStationIndex=1,
                   Station = 38856
                },
                new LineStation
                {
                   id = id++,
                   LineId = 6,
                   LineStationIndex=2,
                   Station = 38852
                },
                new LineStation
                {
                   id = id++,
                   LineId = 6,
                   LineStationIndex=3,
                   Station = 38831
                },
                new LineStation
                {
                   id = id++,
                   LineId = 6,
                   LineStationIndex=4,
                   Station = 38841
                },
                new LineStation
                {
                   id = id++,
                   LineId = 6,
                   LineStationIndex=5,
                   Station = 38836
                },
                new LineStation
                {
                   id = id++,
                   LineId = 6,
                   LineStationIndex=6,
                   Station = 38863
                },
                new LineStation
                {
                   id = id++,
                   LineId = 6,
                   LineStationIndex=7,
                   Station = 38848
                },
                new LineStation
                {
                   id = id++,
                   LineId = 6,
                   LineStationIndex=8,
                   Station = 38859
                },
                new LineStation
                {
                   id = id++,
                   LineId = 6,
                   LineStationIndex=9,
                   Station = 38864
                },


                new LineStation
                {
                   id = id++,
                   LineId = 5,
                   LineStationIndex=0,
                   Station = 38852
                },
                new LineStation
                {
                   id = id++,
                   LineId = 5,
                   LineStationIndex=1,
                   Station = 38837
                },
                new LineStation
                {
                   id = id++,
                   LineId = 5,
                   LineStationIndex=2,
                   Station = 38866
                },
                new LineStation
                {
                   id = id++,
                   LineId = 5,
                   LineStationIndex=3,
                   Station = 38833
                },
                new LineStation
                {
                   id = id++,
                   LineId = 42,
                   LineStationIndex=4,
                   Station = 38841
                },
                new LineStation
                {
                   id = id++,
                   LineId = 5,
                   LineStationIndex=5,
                   Station = 38840
                },
                new LineStation
                {
                   id = id++,
                   LineId = 5,
                   LineStationIndex=6,
                   Station = 38832
                },
                new LineStation
                {
                   id = id++,
                   LineId = 5,
                   LineStationIndex=7,
                   Station = 38852
                },
                new LineStation
                {
                   id = id++,
                   LineId = 5,
                   LineStationIndex=8,
                   Station = 38839
                },
                new LineStation
                {
                   id = id++,
                   LineId = 5,
                   LineStationIndex=9,
                   Station = 38864
                },

            };
            listLineTrip = new List<LineTrip>
            {
                new LineTrip
                {
                    LineId = 1,
                    StartAt = new TimeSpan(6,0,0),
                    FinishAt = new TimeSpan(22,0,0),
                    Frequency = new TimeSpan(0,10,0)
                },


                  new LineTrip
                  {
                      LineId = 21,
                      StartAt = new TimeSpan(6, 0, 0),
                      FinishAt = new TimeSpan(22, 0, 0),
                      Frequency = new TimeSpan(0, 17, 0)
                  },

  new LineTrip
  {
      LineId = 39,
      StartAt = new TimeSpan(6, 0, 0),
      FinishAt = new TimeSpan(22, 0, 0),
      Frequency = new TimeSpan(0, 12, 0)
  },

  new LineTrip
  {
      LineId = 75,
      StartAt = new TimeSpan(6, 0, 0),
      FinishAt = new TimeSpan(22, 0, 0),
      Frequency = new TimeSpan(0, 21, 0)
  },

  new LineTrip
  {
      LineId = 42,
      StartAt = new TimeSpan(6, 0, 0),
      FinishAt = new TimeSpan(22, 0, 0),
      Frequency = new TimeSpan(0, 07, 0)
  },

  new LineTrip
  {
      LineId = 71,
      StartAt = new TimeSpan(6, 0, 0),
      FinishAt = new TimeSpan(22, 0, 0),
      Frequency = new TimeSpan(0, 14, 0)
  },

  new LineTrip
  {
      LineId = 67,
      StartAt = new TimeSpan(6, 0, 0),
      FinishAt = new TimeSpan(22, 0, 0),
      Frequency = new TimeSpan(0, 17, 0)
  },

  new LineTrip
  {
      LineId = 92,
      StartAt = new TimeSpan(6, 0, 0),
      FinishAt = new TimeSpan(22, 0, 0),
      Frequency = new TimeSpan(0, 30, 0)
  },

  new LineTrip
  {
      LineId = 5,
      StartAt = new TimeSpan(6, 0, 0),
      FinishAt = new TimeSpan(22, 0, 0),
      Frequency = new TimeSpan(0, 24, 0)
  },

  new LineTrip
  {
      LineId = 4,
      StartAt = new TimeSpan(6, 0, 0),
      FinishAt = new TimeSpan(22, 0, 0),
      Frequency = new TimeSpan(0, 04, 0)
  },
    new LineTrip
  {
      LineId = 6,
      StartAt = new TimeSpan(6, 0, 0),
      FinishAt = new TimeSpan(22, 0, 0),
      Frequency = new TimeSpan(0, 14, 0)
  },




            };
            listUser = new List<User>
            {
                new User
                {
                    Password ="To8bTY9",
                    UserName = "samuelabergel123@gmail.com"
                }
            };
        }
    }
}
