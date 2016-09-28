

var app = angular.module('order', [])
    .controller('OrderController', ['$scope', '$http', function ($scope, $http) {
      
        $scope.personName = "";
        $scope.orderDesc = "";
        $scope.address = "";
        $scope.zipcode = "";
        $scope.state = "";
        $scope.foodItem = null;
        $scope.foodItems = [];
        $scope.imagePath = "";
        $scope.Notes = "";
        $scope.selectedFoods = null;
        $scope.selectFoodList = [];
        $scope.gridOptions = {

            data:'menuFoodLists'

        }

        $scope.showSelectedFood = false;

        $scope.dataFoodList = null;

        this.showdelivery = false;
        this.showpickup = false;
        this.showOptions = true;
        this.showRegister = false;
        this.showDHeader = true;
        this.showRHeader = false;
        this.showFoodGrid = false;
        this.showSignIn = false;
        this.showProcessOrder = false;
        $scope.customHeaderInfo = "";
        $scope.viewFoodList = false;
        this.showSignInHeader = false;
        this.menuTypeIDSelected = null;
        
        $scope.menuFoodLists = [];


         $http({
            method: 'GET',
            url: 'api/MenuTypes',
            data: { }
        }).success(function (result) {
            $scope.selectFoodList = result;
        });

        
        $scope.phone = "111-1111-111";


        
        /** 
          Load All Foods for MenuType 
        **/

        $scope.loadFoodDescription = function () {
            var foodId = $scope.foodItem;

            $http({
                method: 'GET',
                url: ("api/foods/" + foodId),
                data: { id: foodId }
            }).
             success(function (result) {
                 $scope.imagePath = result.imagePath;
                 $scope.Notes = result.Notes.replace(/^\s+|\s+$/g, "");
                 $scope.showSelectedFood = true;
                 this.showDHeader = false;
                 $scope.viewFoodList = true;
                 $scope.customHeaderInfo = "Select Your Food";

             });





        };


       $scope.getAllFoodsByMenuType = function () {
           var menuTypeId = $scope.selectedFoods;
      
           $http({
               method:'GET',
               url:("menutypes/foods/" + menuTypeId) ,
               data:{id: menuTypeId}
           }).
            success(function (result) {
                 $scope.foodItems = result;
           });


          

           
       };


           // use $scope.selectedItem.code and $scope.selectedItem.name here
           // for other stuff ...
       

        



        $scope.submit = function () {
            if ($scope.Name) {
               
                var order = {

                    "OrderDescription": "",
                    "OrderPerson": "",
                    "DeliveryAddress": "",
                    "OrderPersonPhone": ""

                }
                $http.post('api/Orders', order).success
                (function (data, status, headers, config) {

                    alert("hello");
                }).error(function (data, status, headers, config) {

                    alert("hello err");
                });

            }

        };

        $scope.reset = function () {
            $scope.form.$setPristine();
        };


        this.showNewUserInfo = function showNewUserInfo() {

            this.showOptions = false;
            this.showRegister = true;
            this.showdelivery = false;
            this.showpickup = false;
            this.showDHeader = false;
            this.showRHeader = true;



        };



        this.goBack = function goBack() {

            this.showOptions = true;
            this.showRegister = false;
            this.showdelivery = false;
            this.showpickup = false;
            this.showDHeader = true;
            this.showRHeader = false;
            this.showSignIn = false;
            this.showSignInHeader = false;
         


        };



        this.showSignInInfo = function showSignInInfo() {

            this.showOptions = false;
            this.showRegister = false;
            this.showdelivery = false;
            this.showpickup = false;
            this.showDHeader = false;
            this.showSignIn = true;
            this.showRHeader = false;
            this.showSignInHeader = true;



        };


        this.showPersonInfoEditor = function showPersonInfoEditor () {
             this.showdelivery = true;
             this.showpickup = false;
             this.showRegister = false;


        };

        

        this.dontSignIn = function dontSignIn() {
            this.showdelivery = false;
            this.showpickup = false;
            this.showRegister = false;
            this.showOptions = true;
            this.showDHeader = true;
            this.showRHeader = false;
            this.showSignIn = false;
            this.showSignInHeader = false;
        };
            
        this.dontRegister = function dontRegister() {
            this.showdelivery = false;
            this.showpickup = false;
            this.showRegister = false;
            this.showOptions = true;
            this.showDHeader = true;
            this.showRHeader = false;

        };


        this.showPickUpOnly = function showPickUpOnly() {
            this.showdelivery = false;
            this.showpickup = true;
            this.showRegister = false;

          

        };

        this.showProcessOrderInfo = function showProcessOrderInfo() {
            this.showProcessOrder = true;
            this.showDHeader = false;

            this.showdelivery = false;
            this.showpickup = false;
            this.showRegister = false;
            this.showOptions = false;
            this.showDHeader = true;
            this.showRHeader = false;
            this.showSignIn = false;


        };



    }]);

app.controller('FoodsController', function ($scope, $http) {
    $scope.selectedFood = null;
    $scope.selectFoods = [];

    this.showFoodProcess = false;

    $http.get(
           'Foods/GetFoods'
        
    ).success(function (result) {
        $scope.selectFoods = result;
    })

});


app.directive('phone',function() {

    return {
        restrict: 'E',
        templateUrl: 'phone.html'
    };


});
    


        



        

