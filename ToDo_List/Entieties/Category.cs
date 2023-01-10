namespace ToDo_List.Entieties
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public ICollection<ToDo>? ToDos { get; set; }
    }
}
