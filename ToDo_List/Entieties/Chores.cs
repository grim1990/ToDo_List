namespace ToDo_List.Entieties
{
	public class Chores
	{
		public int Id { get; set; }
		public string? Cleaning { get; set; }
		public string? Loundry { get; set; }
		public string? Cooking { get; set; }
		public new DateTime DateTime { get; set; }
		public int ToDoId { get; set; }
	}
}
