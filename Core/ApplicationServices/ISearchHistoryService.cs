using System.Collections.Generic;

namespace SearchEngine.API.Core.ApplicationServices
{

    public interface ISearchHistoryService
    {
        IEnumerable<string> GetHistory(string keyword, int maxAmount = 10);
        void SaveHistory(string keyword);
        void DeleteKeywordFromHistory(string keyword);
    }
}
