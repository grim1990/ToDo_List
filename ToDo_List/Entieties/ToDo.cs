using Microsoft.AspNetCore.Identity;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ToDo_List.Entieties
{
	public class ToDo
	{
        public int Id { get; set; }
        public string Name { get; set; }
        [Range(1,5)]
        public int Priority { get; set; }
        [DisplayName("Is Completed?")]
        public bool IsCompleted { get; set; }
        [DisplayName("Category Name")]
        public string CategoryName { get; set; }
        public int CategoryId { get; set; }
        public Category? Category { get; set; }

    }
}
