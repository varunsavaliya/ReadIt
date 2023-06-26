using System;
using System.Collections.Generic;

namespace ReadIt.Models;

public partial class TbComment
{
    public long Id { get; set; }

    public string Text { get; set; }

    public long BlogId { get; set; }

    public long CreatedBy { get; set; }

    public DateTime CreatedOn { get; set; }

    public DateTime? UpdatedOn { get; set; }

    public bool? IsActive { get; set; }

    public virtual TbBlog Blog { get; set; }

    public virtual TbUser CreatedByNavigation { get; set; }
}
