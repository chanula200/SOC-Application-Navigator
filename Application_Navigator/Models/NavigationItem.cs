namespace ApplicationNavigator.Models
{
    public class NavigationItem
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Url { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string IconSvg { get; set; } = string.Empty;

        public NavigationItem()
        {
        }

        public NavigationItem(int id, string name, string url, string description = "", string iconSvg = "")
        {
            Id = id;
            Name = name;
            Url = url;
            Description = description;
            IconSvg = iconSvg;
        }
    }
}
