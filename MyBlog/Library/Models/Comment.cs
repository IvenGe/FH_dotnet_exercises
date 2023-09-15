using System;
using System.Collections.Generic;

namespace MyBlog.Library.Models;

public partial class Comment
{
    public int Commentid { get; set; }

    public string Title { get; set; }

    public string Content { get; set; }

    public int? Authorid { get; set; }

    public int? Blogid { get; set; }

    public DateTime? Createdat { get; set; }

    public virtual User Author { get; set; }

    public virtual Blog Blog { get; set; }
}
