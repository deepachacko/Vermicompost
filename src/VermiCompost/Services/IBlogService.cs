using System.Collections.Generic;
using VermiCompost.Models;

namespace VermiCompost.Services
{
    public interface IBlogService
    {
        List<Blog> GetAllBlogs();
    }
}