using System;
using System.Collections.Generic;

namespace ReadIt.Core.DataModels;

public partial class TbBlog
{
    public long Id { get; set; }

    public string Title { get; set; }

    public string Description { get; set; }

    public string Tags { get; set; }

    public long CreatedBy { get; set; }

    public long CategoryId { get; set; }

    public DateTime CreatedOn { get; set; }

    public DateTime? UpdatedOn { get; set; }

    public bool? IsActive { get; set; }

    public virtual TbCategory Category { get; set; }

    public virtual TbUser CreatedByNavigation { get; set; }

    public virtual ICollection<TbBlogMedium> TbBlogMedia { get; set; } = new List<TbBlogMedium>();

    public virtual ICollection<TbComment> TbComments { get; set; } = new List<TbComment>();
}
