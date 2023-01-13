using Microsoft.AspNetCore.Mvc.RazorPages;
using ToDo_List.Data;
using Xunit;
using FluentAssertions;

namespace ToDo_List_UnitTests
{
	public class ToDoUnitTests : PageModel
	{
		private ApplicationDbContext _sut;
		public ToDoUnitTests()
		{
			_sut = new ApplicationDbContext();
		}

		[Fact]
		public void ToDoPage_IndexModel_OnGetAsync_Should_NotBeNull()
		{
			var pageModel = new ToDo_List.Pages.ToDoPage.IndexModel(_sut);

			var result = pageModel.OnGetAsync();

			result.Should().NotBeNull();
		}

		[Fact]
		public void ToDoPage_CreateModel_OnPostAsync_Should_NotBeNull()
		{
			var pageModel = new ToDo_List.Pages.ToDoPage.CreateModel(_sut);

			var result = pageModel.OnPostAsync();

			result.Should().NotBeNull();
		}
	}
}