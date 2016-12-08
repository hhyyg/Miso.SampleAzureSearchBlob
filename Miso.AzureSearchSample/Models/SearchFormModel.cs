using Microsoft.Azure.Search.Models;

namespace Miso.AzureSearchSample.Models
{
    public class SearchFormModel
    {
        public DocumentSearchResult SearchResultLucene { get; set; }
        /// <summary>
        /// ユーザーが入力する検索テキスト
        /// </summary>
        public string SearchText { get; set; }   
    }
}
