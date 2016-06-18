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

        public composter;

        constructor(
            private compostersServices: VermiCompost.Services.CompostersServices,
            private $state: angular.ui.IStateService) { }

        saveComposter() {
            this.compostersServices.saveComposter(this.composter)
                .then(() => {
                    this.$state.go('composters');
                });
        }

        cancel() {
            this.$state.go('composters');
        }
    }

    //When you want to show a detailed view of the products of the selected Composter
    export class CompostersDetailController {
        public composterId;
        public composter;
        public products;

        constructor(private compostersServices: VermiCompost.Services.CompostersServices,
            private $state: angular.ui.IStateService,
            private $stateParams: angular.ui.IStateParamsService) {
            
            this.composterId = $stateParams["id"];
            this.getAllProducts();
        }

        //getComposter() {
        //    this.composter = this.compostersServices.getComposter(this.composterId);
        //}

        getAllProducts() {
            this.products = this.compostersServices.getAllProducts(this.composterId);
        }

        //saveProduct() {
        //    this.compostersServices.saveProduct(this.composterId, this.product)
        //        .then(() => {
        //            this.getComposter();
        //        })
        //}

        cancel() {
            this.$state.go('composters');
        }
    }
}