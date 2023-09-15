using System;
using System.Collections.Generic;

namespace MyBlog.Library.Models;

public partial class Publicblogpost
{
    public int? Blogid { get; set; }

    public string Title { get; set; }

    public DateTime? Publicationdate { get; set; }

    public int? Commentcount { get; set; }
}
