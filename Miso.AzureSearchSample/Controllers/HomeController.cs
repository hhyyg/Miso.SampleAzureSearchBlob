using Microsoft.Azure.Search;
using Microsoft.Azure.Search.Models;
using Miso.AzureSearchSample.Models;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Miso.AzureSearchSample.Controllers
{
    public class HomeController : Controller
    {      
        public async Task<ActionResult> Search(SearchFormModel model)
        {
            if (model == null)
            {
                model = new SearchFormModel();
            }
            
            model.SearchResultLucene = await SearchIndex(indexName: "booksindex", model: model);

            return View(model);
        }

        private Task<DocumentSearchResult> SearchIndex(string indexName, SearchFormModel model)
        {
            SearchIndexClient indexClient = AzureSearchHelper.CreateSearchIndexClient(indexName: indexName);
            SearchParameters searchParameter = CreateSearchParameters();
                        
            return indexClient.Documents.SearchAsync(
                searchText: model.SearchText,
                searchParameters: searchParameter,
                searchRequestOptions: null);
        }

        private static SearchParameters CreateSearchParameters()
        {
            return new SearchParameters()
            {
                SearchMode = SearchMode.Any,
                IncludeTotalResultCount = true,
                HighlightFields = new string[] { "content" },
                Top = 20
            };
        }
    }
}