﻿namespace SearchEngine.API.Core.Domain.Pagination {
	public class PaginationRequest {
		public int PageNumber { get; set; }
		public int PageCount { get; set; }
		public int PageSize { get; set; }
	}
}
