namespace ToDo_List.Entieties
{
	public class ToDo
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public List<Shopping>? Shopping { get; set; }
		public int? ShoppingId { get; set; }
		public List<Chores>? Chores { get; set; }
		public int? ChoresId { get; set; }
		public List<Work>? Work { get; set; }
		public int? WorkId { get; set; }
		public bool IsCompleted { get; set; }
	}
}
