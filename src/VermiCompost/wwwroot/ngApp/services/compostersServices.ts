namespace VermiCompost.Services {

    export class CompostersServices {

        private compostersResources;
        private productsResources;

        constructor($resource: angular.resource.IResourceService)
        {
            this.compostersResources = $resource("/api/composters/:id");
            this.productsResources = $resource("/api/products/:id");
        }

        //CRUD: Read all
        getComposters()   {
            return this.compostersResources.query();
        }

        getProducts() {
            return this.productsResources.query();
        }

        getAllProducts(composterId) {
            return this.compostersResources.query({ id: composterId });
        }

        //CRUD: Get only one
        //getComposter(composterId)  {
        //    return this.compostersResources.get({id: composterId});
        //}

        //CRUD: Create Composter
        saveComposter(composter) {
            return this.compostersResources.save(composter).$promise;
        }

        //CRUD: Create Product and associate it with the Composter
        saveProduct(composterId, product) {
            return this.productsResources.save(composterId, product).$promise;
        }

        //CRUD: delete Composter
        deleteComposter(composterId) {
            return this.compostersResources.delete({id:composterId}).$promise;
        }

        //CRUD: delete Product
        deleteProduct(productId) {
            return this.productsResources.delete({ id: productId }).$promise;
        }
    }
    angular.module("VermiCompost").service("compostersServices", CompostersServices);
}

