using System.Collections.Generic;

namespace WTnote
{
    public class NationData
    {
        public Nation Nation { get; set; }

        public NationData(Nation nation)
        {
            Nation = nation;

            CrewString = new Dictionary<int, string>();
            CrewLevel = new Dictionary<int, int>();
            CrewGunner = new Dictionary<int, int>();
            CrewTraining = new Dictionary<int, CrewTraining>();
            for (var x = 1; x < 10; x++)
            {
                CrewString.Add(x,"");
                CrewLevel.Add(x, 1);
                CrewGunner.Add(x, 1);
                CrewTraining.Add(x, WTnote.CrewTraining.Normal);
            }
        }

        public Dictionary<int, string> CrewString { get; set; }
        public Dictionary<int, int> CrewLevel { get; set; }
        public Dictionary<int, int> CrewGunner { get; set; }
        public Dictionary<int, CrewTraining> CrewTraining { get; set; }
    }

    public enum CrewTraining
    {
        Normal = 0,
        Expert = 1,
        Ace = 2
    }
}
