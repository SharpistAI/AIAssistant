namespace AIAssistant.Model
{
    public class NavItem
    {
        public string Text { get; set; }
        public string Href { get; set; }
        public bool HasSubmenu { get; set; }
        public List<NavItem> SubItems { get; set; } = new List<NavItem>();
    }
}
