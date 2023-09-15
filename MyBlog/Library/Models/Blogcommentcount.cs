using System;
using System.Collections.Generic;

namespace MyBlog.Library.Models;

public partial class Blogcommentcount
{
    public int Blogid { get; set; }

    public int Commentcount { get; set; }

    public virtual Blog Blog { get; set; }
}
