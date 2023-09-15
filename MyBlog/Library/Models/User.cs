using System;
using System.Collections.Generic;

namespace MyBlog.Library.Models;

public partial class User
{
    public int Userid { get; set; }

    public string Firstname { get; set; }

    public string Lastname { get; set; }

    public string Username { get; set; }

    public string Passwordhash { get; set; }

    public virtual ICollection<Blog> Blogs { get; set; } = new List<Blog>();

    public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();
}
