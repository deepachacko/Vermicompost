namespace VermiCompost.Services {

    export class BlogService {

        
        private blogResource;

        constructor(private $resource: ng.resource.IResourceService) {
            this.blogResource = $resource("/api/blog/:id");
        }

        //CRUD: Read all Blogs
        getBlogs() {
            return this.blogResource.query();
        }
    }
    angular.module("VermiCompost").service("blogService", BlogService);
}