using System.Collections.Generic;

namespace TfsApiService.Entities
{
    public class Repo
    {
        public List<RepoItem> Value { get; set; }
    }

    public class RepoItem
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public ProjectItem Project { get; set; }

    }
}
