namespace ToDo_List.Entieties
{
	public class Shopping
	{
		public int Id { get; set; }
		public string ShoppingListName { get; set; }
		public bool IsCompleted { get; set; }
		public List<Products>? Products { get; set; }
		public int? ProductsId { get; set; }
		public int ToDoId { get; set; }
	}
}