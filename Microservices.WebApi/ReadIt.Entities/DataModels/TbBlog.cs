using System;
using System.Collections.Generic;

namespace ReadIt.Entities.Models;

public partial class TbBlog
{
    public long Id { get; set; }

    public string Title { get; set; } = null!;

    public string Description { get; set; } = null!;

    public string? Tags { get; set; }

    public long CreatedBy { get; set; }

    public long CategoryId { get; set; }

    public DateTime CreatedOn { get; set; }

    public DateTime? UpdatedOn { get; set; }

    public bool? IsActive { get; set; }

    public virtual TbCategory Category { get; set; } = null!;

    public virtual TbUser CreatedByNavigation { get; set; } = null!;

    public virtual ICollection<TbBlogMedium> TbBlogMedia { get; set; } = new List<TbBlogMedium>();

    public virtual ICollection<TbComment> TbComments { get; set; } = new List<TbComment>();
}
