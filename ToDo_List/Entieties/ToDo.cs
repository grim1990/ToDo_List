using System.ComponentModel.DataAnnotations;

namespace ToDo_List.Entieties
{
	public class ToDo
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public bool? IsCompleted { get; set; }
		[Range(0,3)]
		public int Priority { get; set; }
	}
}
