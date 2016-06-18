using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VermiCompost.Models;
using VermiCompost.Repositories;

namespace VermiCompost.Services
{
    public class BlogService: IBlogService
    {
        private IGenericRepository _repo;
        
        public BlogService(IGenericRepository repo)
        {
            _repo = repo;
        }

        //Get All Blogs
        public List<Blog> GetAllBlogs()
        {
            var blogs = _repo.Query<Blog>().ToList();
            return blogs;
        }

        //Get all Blogs associated with the logged in user
        public List<Blog> GetUserBlogs(string userId)
        {
            var user = _repo.Query<ApplicationUser>().Where(u => u.Id == userId).Include(u => u.Blogs).FirstOrDefault();
            var blogs = user.Blogs.ToList();
            return blogs;
        }

        //Create a Blog and save it with the logged in user credentials
        public void SaveBlog(Blog blog, string userId)
        {
            var user = _repo.Query<ApplicationUser>().Where(u => u.Id == userId).Include(u => u.Blogs).FirstOrDefault();
            user.Blogs.Add(blog);
            _repo.SaveChanges();
        }

        //Create a Comment and associate it with the Blog and the logged in user
        public void SaveComment(Comment comment, int blogId, string userId)
        {
            comment.UserId = userId;

            var blog = _repo.Query<Blog>().Where(b => b.Id == blogId).Include(c => c.Comments).FirstOrDefault();
            blog.Comments.Add(comment);
            _repo.SaveChanges();
        }


        //Delete a Blog that only the user created
        public void DeleteBlog(Blog blog, string userId)
        {
            var user = _repo.Query<ApplicationUser>().Where(u => u.Id == userId).Include(u => u.Blogs).FirstOrDefault();
            user.Blogs.Remove(blog);
            _repo.SaveChanges();
        }


    }
}
