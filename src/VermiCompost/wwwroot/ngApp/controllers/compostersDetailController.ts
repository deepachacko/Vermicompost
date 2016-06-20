namespace VermiCompost.Controllers {

    //When you want to display all Composters
    export class CompostersController {
        public composters;
        public canEdit;

        constructor(
            private compostersServices: VermiCompost.Services.CompostersServices,
            private accountService: VermiCompost.Services.AccountService) {

            this.getComposters();
            this.canEdit = accountService.getUserInfo();
        }

        getComposters() {
            this.composters = this.compostersServices.getComposters()
        }
    }

    //When you want to create a Composter
    export class CompostersCreateController {

        public composterToSave;

        constructor(
            private compostersServices: VermiCompost.Services.CompostersServices,
            private $state: angular.ui.IStateService) { }

        saveComposter() {
            debugger;
            this.compostersServices.saveComposter(this.composterToSave)
                .then(() => {
                    this.$state.go('composters');
                });
        }

        cancel() {
            this.$state.go('composters');
        }
    }

    //When you want to show a list of products under the selected Composter
    export class CompostersDetailController {
        public composterId;
        public composter;
        public products;
        public productToSave;
        
        constructor(private compostersServices: VermiCompost.Services.CompostersServices,
            private $state: angular.ui.IStateService,
            private $stateParams: angular.ui.IStateParamsService) {
            
            this.composterId = $stateParams["id"];
            this.getAllProducts();
            this.getComposter();
        }

        getComposter() {
            this.composter = this.compostersServices.getComposter(this.composterId);
        }

        getAllProducts() {
            this.products = this.compostersServices.getAllProducts(this.composterId);
        }

        saveProduct() {
            this.compostersServices.saveProduct(this.composterId, this.productToSave)
                .then(() => {
                    this.getAllProducts();
                })
        }

        deleteComposter() {
            this.compostersServices.deleteComposter(this.composterId).then(() => {
                this.$state.go("composters");
            })
        }

        cancel() {
            this.$state.go('composters');
        }
    }


    
}