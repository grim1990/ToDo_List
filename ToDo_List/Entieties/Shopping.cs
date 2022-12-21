namespace ToDo_List.Entieties
{
	public class Shopping
	{
		public int Id { get; set; }
		public List<Groceries>? Groceries { get; set; }
		public int? GroceriesId { get; set; }
		public List<OtherProducts>? OtherProducts { get; set; }
		public int? OtherProductsId { get; set; }
		public int ToDoId { get; set; }
	}
}