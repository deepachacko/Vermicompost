namespace VermiCompost.Controllers {

    //When you want to display all Products
    export class ProductsController {
        public products;
        public canEdit;

        constructor(
            private compostersServices: VermiCompost.Services.CompostersServices,
            private accountService: VermiCompost.Services.AccountService) {

            this.getProducts();
            this.canEdit = accountService.getUserInfo();
        }

        getProducts() {
            this.products = this.compostersServices.getProducts()
        }
    }

    //When you want to show a list of composters under the selected product
    export class ProductsDetailController {
        public productId;
        public product;
        public composters;
        
        constructor(private compostersServices: VermiCompost.Services.CompostersServices,
            private $state: angular.ui.IStateService,
            private $stateParams: angular.ui.IStateParamsService) {

            this.productId = $stateParams["id"];
            this.getAllComposters();
            this.getProductName();
        }

        getAllComposters() {
            this.composters = this.compostersServices.getAllComposters(this.productId);
        }

        getProductName() {
            this.product = this.compostersServices.getProductName(this.productId);
        }

        editProduct() {
            this.compostersServices.editProduct(this.product)
                .then(() => {
                    this.$state.go("products")
                });
        }

        deleteProduct() {
            this.compostersServices.deleteProduct(this.productId).then(() => {
                this.$state.go("products")
            })
        }

        cancel() {
            this.$state.go("products");
        }
    }
}

