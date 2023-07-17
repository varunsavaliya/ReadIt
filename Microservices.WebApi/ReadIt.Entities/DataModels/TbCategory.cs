using System;
using System.Collections.Generic;

namespace ReadIt.Entities.Models;

public partial class TbCategory
{
    public long Id { get; set; }

    public string Name { get; set; } = null!;

    public DateTime CreatedOn { get; set; }

    public DateTime? UpdatedOn { get; set; }

    public bool? IsActive { get; set; }

    public virtual ICollection<TbBlog> TbBlogs { get; set; } = new List<TbBlog>();
}
