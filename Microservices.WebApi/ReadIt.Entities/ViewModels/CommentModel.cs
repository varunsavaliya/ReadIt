﻿using ReadIt.Core.ViewModels.Common;

namespace ReadIt.Core.ViewModels
{
    public class CommentModel: BaseModel
    {

        public string Text { get; set; }

        public long BlogId { get; set; }

        public long? CreatedBy { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Website { get; set; }
        public UserModel? User { get; set; }
    }
}
