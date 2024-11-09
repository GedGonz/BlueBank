(window["webpackJsonp"] = window["webpackJsonp"] || []).push([["components-client-module-client-module-module"],{

/***/ "./node_modules/raw-loader/index.js!./src/app/components/client-module/new-client/new-client.component.html":
/*!*********************************************************************************************************!*\
  !*** ./node_modules/raw-loader!./src/app/components/client-module/new-client/new-client.component.html ***!
  \*********************************************************************************************************/
/*! no static exports found */
/***/ (function(module, exports) {

module.exports = "<br/>\n<div class=\"row\">\n    <div class=\"col-md-12\">\n        <h4 class=\"text-center style-font\">Register New Client</h4>\n    </div>\n</div>\n<br>\n<div class=\"card\">\n    <div class=\"row\">\n        <div class=\"col-md-12 \">\n            <form [formGroup]=\"clientForm\">\n                <div class=\"form-group\">\n                    <label for=\"NameText\">Name</label>\n                    <input type=\"text\" class=\"form-control inputFind\" id=\"Name\" formControlName=\"name\">\n                    <label for=\"NameText\">LastName</label>\n                    <input type=\"text\" class=\"form-control inputFind\" id=\"LastName\" formControlName=\"lastname\">\n                </div>\n                <div *ngIf=\"clientForm.controls['name'].invalid && (clientForm.controls['name'].dirty || clientForm.controls['name'].touched)\" class=\"alert alert-danger\">\n                    <div *ngIf=\"clientForm.controls['name'].errors.required\">\n                        Name is required.\n                    </div>\n                </div>\n                <div *ngIf=\"clientForm.controls['lastname'].invalid && (clientForm.controls['lastname'].dirty || clientForm.controls['lastname'].touched)\" class=\"alert alert-danger\">\n                    <div *ngIf=\"clientForm.controls['lastname'].errors.required\">\n                        LastName is required.\n                    </div>\n                </div>\n                <br>\n                <div class=\"row\">\n                    <div class=\"col-md-6\">\n                        <button class=\"btn btn-success btn-lg  btn-block\" (click)=\"newClient()\" [disabled]=\"clientForm.pristine || clientForm.invalid\">\n                            <fa name=\"send\" style=\"color: rgb(251, 251, 251); font-size: 20px;\"></fa>\n                        </button>\n                    </div>\n                    <div class=\"col-md-6\">\n                        <button class=\"btn btn-danger btn-lg  btn-block\" [routerLink]=\"['/account/menu']\">\n                            <fa name=\"undo\" style=\"color: rgb(251, 251, 251); font-size: 20px;\"></fa>\n                        </button>\n                    </div>\n\n                </div>\n            </form>\n        </div>\n    </div>\n</div>\n<ngx-loading [show]=\"loading\" [config]=\"{ backdropBorderRadius: '3px' }\"></ngx-loading>"

/***/ }),

/***/ "./src/app/components/client-module/client-module-routing.module.ts":
/*!**************************************************************************!*\
  !*** ./src/app/components/client-module/client-module-routing.module.ts ***!
  \**************************************************************************/
/*! exports provided: ClientModuleRoutingModule */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "ClientModuleRoutingModule", function() { return ClientModuleRoutingModule; });
/* harmony import */ var tslib__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! tslib */ "./node_modules/tslib/tslib.es6.js");
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! @angular/core */ "./node_modules/@angular/core/fesm2015/core.js");
/* harmony import */ var _angular_router__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! @angular/router */ "./node_modules/@angular/router/fesm2015/router.js");
/* harmony import */ var _share_module_layout_layout_component__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! ../share-module/layout/layout.component */ "./src/app/components/share-module/layout/layout.component.ts");
/* harmony import */ var _share_module_share_module_module__WEBPACK_IMPORTED_MODULE_4__ = __webpack_require__(/*! ../share-module/share-module.module */ "./src/app/components/share-module/share-module.module.ts");
/* harmony import */ var _new_client_new_client_component__WEBPACK_IMPORTED_MODULE_5__ = __webpack_require__(/*! ./new-client/new-client.component */ "./src/app/components/client-module/new-client/new-client.component.ts");






const routes = [
    {
        path: '',
        component: _share_module_layout_layout_component__WEBPACK_IMPORTED_MODULE_3__["LayoutComponent"],
        children: [
            { path: 'new', component: _new_client_new_client_component__WEBPACK_IMPORTED_MODULE_5__["NewClientComponent"] }
        ]
    }
];
let ClientModuleRoutingModule = class ClientModuleRoutingModule {
};
ClientModuleRoutingModule = tslib__WEBPACK_IMPORTED_MODULE_0__["__decorate"]([
    Object(_angular_core__WEBPACK_IMPORTED_MODULE_1__["NgModule"])({
        imports: [_angular_router__WEBPACK_IMPORTED_MODULE_2__["RouterModule"].forChild(routes),
            _share_module_share_module_module__WEBPACK_IMPORTED_MODULE_4__["ShareModuleModule"]
        ],
        exports: [_angular_router__WEBPACK_IMPORTED_MODULE_2__["RouterModule"]]
    })
], ClientModuleRoutingModule);



/***/ }),

/***/ "./src/app/components/client-module/client-module.module.ts":
/*!******************************************************************!*\
  !*** ./src/app/components/client-module/client-module.module.ts ***!
  \******************************************************************/
/*! exports provided: ClientModuleModule */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "ClientModuleModule", function() { return ClientModuleModule; });
/* harmony import */ var tslib__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! tslib */ "./node_modules/tslib/tslib.es6.js");
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! @angular/core */ "./node_modules/@angular/core/fesm2015/core.js");
/* harmony import */ var _angular_common__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! @angular/common */ "./node_modules/@angular/common/fesm2015/common.js");
/* harmony import */ var _angular_forms__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! @angular/forms */ "./node_modules/@angular/forms/fesm2015/forms.js");
/* harmony import */ var angular_font_awesome__WEBPACK_IMPORTED_MODULE_4__ = __webpack_require__(/*! angular-font-awesome */ "./node_modules/angular-font-awesome/dist/angular-font-awesome.js");
/* harmony import */ var ngx_loading__WEBPACK_IMPORTED_MODULE_5__ = __webpack_require__(/*! ngx-loading */ "./node_modules/ngx-loading/fesm2015/ngx-loading.js");
/* harmony import */ var _share_module_share_module_module__WEBPACK_IMPORTED_MODULE_6__ = __webpack_require__(/*! ../share-module/share-module.module */ "./src/app/components/share-module/share-module.module.ts");
/* harmony import */ var _client_module_routing_module__WEBPACK_IMPORTED_MODULE_7__ = __webpack_require__(/*! ./client-module-routing.module */ "./src/app/components/client-module/client-module-routing.module.ts");
/* harmony import */ var _new_client_new_client_component__WEBPACK_IMPORTED_MODULE_8__ = __webpack_require__(/*! ./new-client/new-client.component */ "./src/app/components/client-module/new-client/new-client.component.ts");










let ClientModuleModule = class ClientModuleModule {
};
ClientModuleModule = tslib__WEBPACK_IMPORTED_MODULE_0__["__decorate"]([
    Object(_angular_core__WEBPACK_IMPORTED_MODULE_1__["NgModule"])({
        declarations: [
            _new_client_new_client_component__WEBPACK_IMPORTED_MODULE_8__["NewClientComponent"]
        ],
        imports: [
            _angular_common__WEBPACK_IMPORTED_MODULE_2__["CommonModule"],
            _client_module_routing_module__WEBPACK_IMPORTED_MODULE_7__["ClientModuleRoutingModule"],
            _angular_forms__WEBPACK_IMPORTED_MODULE_3__["FormsModule"],
            _angular_forms__WEBPACK_IMPORTED_MODULE_3__["ReactiveFormsModule"],
            _share_module_share_module_module__WEBPACK_IMPORTED_MODULE_6__["ShareModuleModule"],
            angular_font_awesome__WEBPACK_IMPORTED_MODULE_4__["AngularFontAwesomeModule"],
            ngx_loading__WEBPACK_IMPORTED_MODULE_5__["NgxLoadingModule"]
        ]
    })
], ClientModuleModule);



/***/ }),

/***/ "./src/app/components/client-module/new-client/new-client.component.css":
/*!******************************************************************************!*\
  !*** ./src/app/components/client-module/new-client/new-client.component.css ***!
  \******************************************************************************/
/*! no static exports found */
/***/ (function(module, exports) {

module.exports = ".inputFind {\n    font-size: 30px;\n    font-weight: bold;\n    margin-bottom: 5px;\n}\n\nh4 {\n    color: white;\n    font-size: 30px;\n}\n/*# sourceMappingURL=data:application/json;base64,eyJ2ZXJzaW9uIjozLCJzb3VyY2VzIjpbInNyYy9hcHAvY29tcG9uZW50cy9jbGllbnQtbW9kdWxlL25ldy1jbGllbnQvbmV3LWNsaWVudC5jb21wb25lbnQuY3NzIl0sIm5hbWVzIjpbXSwibWFwcGluZ3MiOiJBQUFBO0lBQ0ksZUFBZTtJQUNmLGlCQUFpQjtJQUNqQixrQkFBa0I7QUFDdEI7O0FBRUE7SUFDSSxZQUFZO0lBQ1osZUFBZTtBQUNuQiIsImZpbGUiOiJzcmMvYXBwL2NvbXBvbmVudHMvY2xpZW50LW1vZHVsZS9uZXctY2xpZW50L25ldy1jbGllbnQuY29tcG9uZW50LmNzcyIsInNvdXJjZXNDb250ZW50IjpbIi5pbnB1dEZpbmQge1xuICAgIGZvbnQtc2l6ZTogMzBweDtcbiAgICBmb250LXdlaWdodDogYm9sZDtcbiAgICBtYXJnaW4tYm90dG9tOiA1cHg7XG59XG5cbmg0IHtcbiAgICBjb2xvcjogd2hpdGU7XG4gICAgZm9udC1zaXplOiAzMHB4O1xufSJdfQ== */"

/***/ }),

/***/ "./src/app/components/client-module/new-client/new-client.component.ts":
/*!*****************************************************************************!*\
  !*** ./src/app/components/client-module/new-client/new-client.component.ts ***!
  \*****************************************************************************/
/*! exports provided: NewClientComponent */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "NewClientComponent", function() { return NewClientComponent; });
/* harmony import */ var tslib__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! tslib */ "./node_modules/tslib/tslib.es6.js");
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! @angular/core */ "./node_modules/@angular/core/fesm2015/core.js");
/* harmony import */ var _model_client__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! ../../../model/client */ "./src/app/model/client.ts");
/* harmony import */ var _services_client_service__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! ../../../services/client.service */ "./src/app/services/client.service.ts");
/* harmony import */ var ngx_toastr__WEBPACK_IMPORTED_MODULE_4__ = __webpack_require__(/*! ngx-toastr */ "./node_modules/ngx-toastr/fesm2015/ngx-toastr.js");
/* harmony import */ var _angular_forms__WEBPACK_IMPORTED_MODULE_5__ = __webpack_require__(/*! @angular/forms */ "./node_modules/@angular/forms/fesm2015/forms.js");






let NewClientComponent = class NewClientComponent {
    constructor(service, toastr, _fb) {
        this.service = service;
        this.toastr = toastr;
        this._fb = _fb;
        this.model = new _model_client__WEBPACK_IMPORTED_MODULE_2__["client"]();
        this.createForm();
    }
    newClient() {
        this.loading = true;
        this.model.name = this.clientForm.value.name;
        this.model.lastname = this.clientForm.value.lastname;
        this.service.newClientService(this.model).subscribe((res) => {
            this.model = new _model_client__WEBPACK_IMPORTED_MODULE_2__["client"]();
            this.loading = false;
            this.toastr.success(res.message, 'Success!');
        }, (err) => {
            this.loading = false;
            if (err.status == 400)
                this.toastr.warning('error sending data!', 'Error!');
            if (err.status == 500)
                this.toastr.error('Internal Error!', 'Error!');
            if (err.status == 0 && err.ok === false)
                this.toastr.warning('Impossible to connect to the server!', 'Waringi!');
        });
        this.clientForm.setValue({ name: '', lastname: '' });
    }
    createForm() {
        this.clientForm = this._fb.group({
            name: ['', _angular_forms__WEBPACK_IMPORTED_MODULE_5__["Validators"].required],
            lastname: ['', _angular_forms__WEBPACK_IMPORTED_MODULE_5__["Validators"].required]
        });
    }
    ngOnInit() {
    }
};
NewClientComponent.ctorParameters = () => [
    { type: _services_client_service__WEBPACK_IMPORTED_MODULE_3__["ClientService"] },
    { type: ngx_toastr__WEBPACK_IMPORTED_MODULE_4__["ToastrService"] },
    { type: _angular_forms__WEBPACK_IMPORTED_MODULE_5__["FormBuilder"] }
];
NewClientComponent = tslib__WEBPACK_IMPORTED_MODULE_0__["__decorate"]([
    Object(_angular_core__WEBPACK_IMPORTED_MODULE_1__["Component"])({
        selector: 'app-new-client',
        template: __webpack_require__(/*! raw-loader!./new-client.component.html */ "./node_modules/raw-loader/index.js!./src/app/components/client-module/new-client/new-client.component.html"),
        styles: [__webpack_require__(/*! ./new-client.component.css */ "./src/app/components/client-module/new-client/new-client.component.css")]
    })
], NewClientComponent);



/***/ })

}]);
//# sourceMappingURL=components-client-module-client-module-module-es2015.js.map