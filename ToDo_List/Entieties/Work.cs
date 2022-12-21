namespace ToDo_List.Entieties
{
	public class Work
	{
		public int Id { get; set; }
		public string WorkName { get; set; }
		public new DateTime StartDateTime { get; set; }
		public new DateTime EndDateTime { get; set; }
		public bool IsCompleted { get; set; }
		public int ToDoId { get; set; }
	}
}
