using System;
using System.Collections.Generic;

namespace ReadIt.Entities.Models;

public partial class TbUser
{
    public long Id { get; set; }

    public string Name { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string? Bio { get; set; }

    public string? Avatar { get; set; }

    public DateTime CreatedOn { get; set; }

    public DateTime? UpdatedOn { get; set; }

    public bool? IsActive { get; set; }

    public virtual ICollection<TbBlog> TbBlogs { get; set; } = new List<TbBlog>();

    public virtual ICollection<TbComment> TbComments { get; set; } = new List<TbComment>();
}
