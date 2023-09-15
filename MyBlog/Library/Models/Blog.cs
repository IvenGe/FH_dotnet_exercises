using System;
using System.Collections.Generic;

namespace MyBlog.Library.Models;

public partial class Blog
{
    public int Blogid { get; set; }

    public string Title { get; set; }

    public string Content { get; set; }

    public int? Authorid { get; set; }

    public DateTime? Createdat { get; set; }

    public virtual User Author { get; set; }

    public virtual Blogcommentcount Blogcommentcount { get; set; }

    public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();
}
