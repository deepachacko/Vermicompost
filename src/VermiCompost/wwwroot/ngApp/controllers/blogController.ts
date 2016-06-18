namespace VermiCompost.Controllers {

    export class BlogController {

        public blogs;
        constructor(private blogService: VermiCompost.Services.BlogService) {
            this.getBlogs();
        }

        //CRUD: Read all blogs
        getBlogs() {
            this.blogs = this.blogService.getBlogs();
        }
    }
}