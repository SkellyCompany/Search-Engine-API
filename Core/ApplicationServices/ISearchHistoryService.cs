using System.Collections.Generic;

namespace SearchEngine.API.Core.ApplicationServices {

	public interface ISearchHistoryService {
		IEnumerable<string> Read(string keyword, int maxAmount = 10);
		void SaveAsync(string keyword);
		void DeleteAsync(string keyword);
	}
}
