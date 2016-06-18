namespace VermiCompost.Controllers {

    export class CompostersEditController {

        public composter;
        private composterId;

        constructor(private compostersServices: VermiCompost.Services.CompostersServices,
            private $stateParams: angular.ui.IStateService,
        private $state: angular.ui.IStateService) {

            this.composterId = $stateParams['id'];
            //this.getComposter();
        }

        //getComposter() {
        //    this.composter = this.compostersServices.getComposter(this.composterId);
        //}

        saveComposter() {
            this.compostersServices.saveComposter(this.composter)
                .then(() => {
                    this.$state.go("composters")
                });
        }

        deleteComposter() {
            this.compostersServices.deleteComposter(this.composterId)
                .then(() => {
                    this.$state.go("composters")
                })
        }

        cancel() {
            this.$state.go("composters");
        }
    }
}