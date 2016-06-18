namespace VermiCompost.Controllers {

    export class HomeController {
        
        public file;

        constructor(private filepickerService: any, private $scope: ng.IScope) { }

        public pickFile() {
            this.filepickerService.pick(
                { mimetype: 'image/*' },
                this.fileUploaded.bind(this) 
            );
        }

        public fileUploaded(file) {
            this.file = file;
            console.log(this.file);
            //write the logic to send the url info of the image to database

            this.$scope.$apply(); //refreshes the page
        }

    }


    export class SecretController {
        public secrets;

        constructor($http: ng.IHttpService) {
            $http.get('/api/secrets').then((results) => {
                this.secrets = results.data;
            });
        }
    }


    export class AboutController {
        public message = 'Hello from the about page!';

        public userType;
        constructor(accountService: VermiCompost.Services.AccountService) {
            this.userType = accountService.getUserInfo();
            console.log(this.userType);
        }
    }

}
