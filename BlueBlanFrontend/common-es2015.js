(window["webpackJsonp"] = window["webpackJsonp"] || []).push([["common"],{

/***/ "./node_modules/raw-loader/index.js!./src/app/components/share-module/layout/layout.component.html":
/*!************************************************************************************************!*\
  !*** ./node_modules/raw-loader!./src/app/components/share-module/layout/layout.component.html ***!
  \************************************************************************************************/
/*! no static exports found */
/***/ (function(module, exports) {

module.exports = "<div class=\"back_container\">\n    <div class=\"container\">\n        <router-outlet></router-outlet>\n    </div>\n</div>"

/***/ }),

/***/ "./src/app/components/share-module/layout/layout.component.css":
/*!*********************************************************************!*\
  !*** ./src/app/components/share-module/layout/layout.component.css ***!
  \*********************************************************************/
/*! no static exports found */
/***/ (function(module, exports) {

module.exports = "\n/*# sourceMappingURL=data:application/json;base64,eyJ2ZXJzaW9uIjozLCJzb3VyY2VzIjpbXSwibmFtZXMiOltdLCJtYXBwaW5ncyI6IiIsImZpbGUiOiJzcmMvYXBwL2NvbXBvbmVudHMvc2hhcmUtbW9kdWxlL2xheW91dC9sYXlvdXQuY29tcG9uZW50LmNzcyJ9 */"

/***/ }),

/***/ "./src/app/components/share-module/layout/layout.component.ts":
/*!********************************************************************!*\
  !*** ./src/app/components/share-module/layout/layout.component.ts ***!
  \********************************************************************/
/*! exports provided: LayoutComponent */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "LayoutComponent", function() { return LayoutComponent; });
/* harmony import */ var tslib__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! tslib */ "./node_modules/tslib/tslib.es6.js");
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! @angular/core */ "./node_modules/@angular/core/fesm2015/core.js");


let LayoutComponent = class LayoutComponent {
    constructor(elementRef, renderer) {
        this.elementRef = elementRef;
        this.renderer = renderer;
    }
    ngOnInit() {
    }
    ngAfterViewInit() {
        console.log('Layout');
        let body = document.getElementsByClassName('body')[0];
        let footer = document.getElementsByClassName('footer')[0];
        footer.style.color = 'white';
        body.style.background = 'linear-gradient(to right, #0395ff, #a53398)';
    }
    ngOnDestroy() {
        let body = document.getElementsByClassName('body')[0];
        let footer = document.getElementsByClassName('footer')[0];
        footer.removeAttribute("color");
        footer.setAttribute("color", 'rgb(82, 80, 80)');
        footer.style.color = 'rgb(82, 80, 80)';
        body.style.background = 'white';
    }
};
LayoutComponent.ctorParameters = () => [
    { type: _angular_core__WEBPACK_IMPORTED_MODULE_1__["ElementRef"] },
    { type: _angular_core__WEBPACK_IMPORTED_MODULE_1__["Renderer2"] }
];
LayoutComponent = tslib__WEBPACK_IMPORTED_MODULE_0__["__decorate"]([
    Object(_angular_core__WEBPACK_IMPORTED_MODULE_1__["Component"])({
        selector: 'app-layout',
        template: __webpack_require__(/*! raw-loader!./layout.component.html */ "./node_modules/raw-loader/index.js!./src/app/components/share-module/layout/layout.component.html"),
        styles: [__webpack_require__(/*! ./layout.component.css */ "./src/app/components/share-module/layout/layout.component.css")]
    })
], LayoutComponent);



/***/ }),

/***/ "./src/app/components/share-module/share-module.module.ts":
/*!****************************************************************!*\
  !*** ./src/app/components/share-module/share-module.module.ts ***!
  \****************************************************************/
/*! exports provided: ShareModuleModule */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "ShareModuleModule", function() { return ShareModuleModule; });
/* harmony import */ var tslib__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! tslib */ "./node_modules/tslib/tslib.es6.js");
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! @angular/core */ "./node_modules/@angular/core/fesm2015/core.js");
/* harmony import */ var _angular_common__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! @angular/common */ "./node_modules/@angular/common/fesm2015/common.js");
/* harmony import */ var _share_module_layout_layout_component__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! ../share-module/layout/layout.component */ "./src/app/components/share-module/layout/layout.component.ts");
/* harmony import */ var _angular_router__WEBPACK_IMPORTED_MODULE_4__ = __webpack_require__(/*! @angular/router */ "./node_modules/@angular/router/fesm2015/router.js");





let ShareModuleModule = class ShareModuleModule {
};
ShareModuleModule = tslib__WEBPACK_IMPORTED_MODULE_0__["__decorate"]([
    Object(_angular_core__WEBPACK_IMPORTED_MODULE_1__["NgModule"])({
        declarations: [
            _share_module_layout_layout_component__WEBPACK_IMPORTED_MODULE_3__["LayoutComponent"]
        ],
        imports: [
            _angular_router__WEBPACK_IMPORTED_MODULE_4__["RouterModule"],
            _angular_common__WEBPACK_IMPORTED_MODULE_2__["CommonModule"]
        ],
        exports: [
            _share_module_layout_layout_component__WEBPACK_IMPORTED_MODULE_3__["LayoutComponent"]
        ]
    })
], ShareModuleModule);



/***/ }),

/***/ "./src/app/model/client.ts":
/*!*********************************!*\
  !*** ./src/app/model/client.ts ***!
  \*********************************/
/*! exports provided: client */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "client", function() { return client; });
class client {
}


/***/ }),

/***/ "./src/app/services/client.service.ts":
/*!********************************************!*\
  !*** ./src/app/services/client.service.ts ***!
  \********************************************/
/*! exports provided: ClientService */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "ClientService", function() { return ClientService; });
/* harmony import */ var tslib__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! tslib */ "./node_modules/tslib/tslib.es6.js");
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! @angular/core */ "./node_modules/@angular/core/fesm2015/core.js");
/* harmony import */ var _angular_common_http__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! @angular/common/http */ "./node_modules/@angular/common/fesm2015/http.js");
/* harmony import */ var _environments_environment__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! ../../environments/environment */ "./src/environments/environment.ts");




let ClientService = class ClientService {
    constructor(http) {
        this.http = http;
        this.uri = _environments_environment__WEBPACK_IMPORTED_MODULE_3__["environment"].API_URL;
    }
    newClientService(_client) {
        const url = `${this.uri}/client`;
        return this.http.post(url, _client);
    }
    getClient() {
        const url = `${this.uri}/client`;
        return this.http.get(url);
    }
    findClient(_id) {
        const url = `${this.uri}/client/${_id}`;
        return this.http.get(url);
    }
};
ClientService.ctorParameters = () => [
    { type: _angular_common_http__WEBPACK_IMPORTED_MODULE_2__["HttpClient"] }
];
ClientService = tslib__WEBPACK_IMPORTED_MODULE_0__["__decorate"]([
    Object(_angular_core__WEBPACK_IMPORTED_MODULE_1__["Injectable"])({
        providedIn: 'root'
    })
], ClientService);



/***/ })

}]);
//# sourceMappingURL=common-es2015.js.map