using System.ComponentModel.DataAnnotations;

namespace ToDo_List.Entieties
{
	public class ToDo
	{
        public int Id { get; set; }
        public string Name { get; set; }
        public int Priority { get; set; }
        public bool IsCompleted { get; set; }
        public string CategoryName { get; set; }
        public int CategoryId { get; set; }
        public Category? Category { get; set; }
    }
}
