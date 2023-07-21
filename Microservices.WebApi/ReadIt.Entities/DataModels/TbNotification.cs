using System;
using System.Collections.Generic;

namespace ReadIt.Core.DataModels;

public partial class TbNotification
{
    public long Id { get; set; }

    public long ToUserId { get; set; }

    public long FromUserId { get; set; }

    public long CommentId { get; set; }

    public DateTime CreatedOn { get; set; }

    public DateTime? UpdatedOn { get; set; }

    public bool? IsRead { get; set; }
}
