namespace Lodash.Stats
{
    public class CharStatsEngine
    {
        public struct CharFrequency
        {
            public char Char { get; set; }

            public ulong Frequency { get; set; }
        }

        private Dictionary<char, ulong> stats = new();

        public void Add(string str)
        {
            foreach (var c in str)
            {
                if (stats.ContainsKey(c))
                {
                    stats[c]++;
                }
                else
                {
                    stats[c] = 1;
                }
            }
        }

        public List<CharFrequency> GetAllFrequencies()
        {
            return stats
                .Select(pair => new CharFrequency 
                { 
                    Char = pair.Key, 
                    Frequency = pair.Value 
                })
                .ToList();
        }
    }
}
