namespace VermiCompost.Controllers {

    //When you want to display all Composters
    export class CompostersController {
        public composters;

        constructor(private compostersServices: VermiCompost.Services.CompostersServices) {
            this.getComposters();
        }

        getComposters() {
            this.composters = this.compostersServices.getComposters();
        }
    }

    //When you want to create a Composter
    export class CompostersCreateController {

        public composter;

        constructor(
            private composterServices: VermiCompost.Services.CompostersServices,
            private $state: angular.ui.IStateService) { }

        saveComposter() {
            this.composterServices.saveComposter(this.composter)
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
        public product;

        constructor(private compostersServices: VermiCompost.Services.CompostersServices,
            private $state: angular.ui.IStateService,
            private $stateParams: angular.ui.IStateParamsService) {

            this.composterId = $stateParams["id"];
            this.getComposter();
        }

        getComposter() {
            this.composter = this.compostersServices.getComposter(this.composterId);
        }

        saveProduct() {
            this.compostersServices.saveProduct(this.composterId, this.product)
                .then(() => {
                    this.getComposter();
                })
        }

        cancel() {
            this.$state.go('composters');
        }

    }
}