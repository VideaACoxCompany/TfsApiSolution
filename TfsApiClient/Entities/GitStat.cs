using System.Collections.Generic;

namespace TfsApiService.Entities
{
    public class GitStat
    {
        public int Count { get; set; }
        public List<StatItem> Value { get; set; }
    }

    public class StatItem
    {
        //public CommitItem Commit { get; set; }
        public string Name { get; set; }
        public string AheadCount { get; set; }
        public string BehindCount { get; set; }
    }
}
