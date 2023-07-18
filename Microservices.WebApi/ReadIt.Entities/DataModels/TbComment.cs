using System;
using System.Collections.Generic;

namespace ReadIt.Entities.Models;

public partial class TbComment
{
    public long Id { get; set; }

    public string Text { get; set; } = null!;

    public long BlogId { get; set; }

    public long? CreatedBy { get; set; }

    public string Name { get; set; }

    public string Email { get; set; }

    public string Website { get; set; }

    public DateTime CreatedOn { get; set; }

    public DateTime UpdatedOn { get; set; }

    public bool IsActive { get; set; }

    public virtual TbBlog Blog { get; set; } = null!;

    public virtual TbUser CreatedByNavigation { get; set; }
}
