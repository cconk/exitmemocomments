namespace ExitMemoComments.Controllers {

    export class HomeController {
        public message = 'You can search exit memo comments by entering text below.';
        private EMCResource;
        public searchTerm;
        public exitMemoComments;
        public allExitMemoComments;

        public getAllExitMemoComments() {
            this.allExitMemoComments = this.EMCResource.query();
        }

        public getExitMemoComments() {
            console.log(this.searchTerm);
            this.exitMemoComments = this.EMCResource.query({ id: this.searchTerm });
            console.log(this.exitMemoComments);
        }

        constructor(public $state: ng.ui.IStateService, private $resource: angular.resource.IResourceService) {
            this.EMCResource = $resource('/api/exitMemoComments/:id');
        }

    }

    export class AddController {
        public message = 'You can add exit memo comments by completing the information below.';
        private EMCResource;
        public newExitMemoComment;
        public currentUserName;
        

        public addNewExitMemoComment() {
            console.log(this.newExitMemoComment);
            this.currentUserName = this.accountService.getUserName();
            console.log(this.currentUserName);
            this.EMCResource.save({ id: this.currentUserName }, this.newExitMemoComment).$promise;
            this.newExitMemoComment = null;
        }

        constructor(public $state: ng.ui.IStateService, private accountService: ExitMemoComments.Services.AccountService, private $resource: angular.resource.IResourceService) {
            this.EMCResource = $resource('/api/exitMemoComments/:id');
        }

    }

}
