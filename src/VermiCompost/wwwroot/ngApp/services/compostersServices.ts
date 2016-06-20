namespace VermiCompost.Services {

    export class CompostersServices {

        private compostersResources;
        private productsResources;

        constructor($resource: angular.resource.IResourceService) {
            this.compostersResources = $resource("/api/composters/:id");

            this.compostersResources = $resource("/api/composters/:id", null, {

                getComposter: {
                    method: 'GET',
                    url: '/api/composters/getComposter/:id',
                    isArray: false
                }
            });

            this.productsResources = $resource("/api/products/:id", null, {
                getProductName: {
                    method: 'GET',
                    url: '/api/products/getProductName/:id',
                    isArray: false
                }
            });
        }

        //CRUD: Read all Composters
        getComposters() {
            return this.compostersResources.query();
        }

        getComposter(composterId) {
            return this.compostersResources.getComposter({ id: composterId });
        }

        //CRUD: Read all Products that belong to the same Composter
        getAllProducts(composterId) {
            return this.compostersResources.query({ id: composterId });
        }

        //CRUD: Read all Products
        getProducts() {
            return this.productsResources.query();
        }

        //CRUD: Read all Composters that belong to the same Product
        getAllComposters(productId) {
            return this.productsResources.query({ id: productId });
        }

        //CRUD: Read Product Name from Product Id
        getProductName(productId) {
            return this.productsResources.getProductName({ id: productId });
        }

        //CRUD: Create Composter
        saveComposter(composter) {
            return this.compostersResources.save(composter).$promise;
        }

        //CRUD: Create a new Product and associate it with an existing Composter
        //ComposterId comes through the stateParams
        saveProduct(composterId, product) {
            return this.compostersResources.save({ id: composterId }, product).$promise;
        }

        //CRUD: Update a Product
        editProduct(product) {
            return this.productsResources.save(product).$promise;
        }

        //CRUD: delete Composter
        deleteComposter(composterId) {
            return this.compostersResources.delete({ id: composterId }).$promise;
        }

        //CRUD: delete Product
        deleteProduct(productId) {
            return this.productsResources.delete({ id: productId }).$promise;
        }
    }
    angular.module("VermiCompost").service("compostersServices", CompostersServices);
}

