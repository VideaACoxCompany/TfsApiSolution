using System.Collections.Generic;

namespace TfsApiService.Entities
{
    public class Project
    {
        public int Count { get; set; }
        public List<ProjectItem> Value { get; set; }
    }

    public class ProjectItem
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
    }
}
