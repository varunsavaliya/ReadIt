using System;
using System.Collections.Generic;

namespace ReadIt.Models;

public partial class TbBlogMedium
{
    public long Id { get; set; }

    public string MediaPath { get; set; }

    public long BlogId { get; set; }

    public DateTime CreatedOn { get; set; }

    public DateTime? UpdatedOn { get; set; }

    public bool? IsActive { get; set; }

    public virtual TbBlog IdNavigation { get; set; }
}
