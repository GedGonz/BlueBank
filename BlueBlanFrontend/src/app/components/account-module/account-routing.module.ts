import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import {ShareModuleModule } from "../share-module/share-module.module";
import { LayoutComponent } from '../share-module/layout/layout.component';
import { AccountComponent } from './account/account.component';
import { ConsultAccountComponent } from './consult-account/consult-account.component';
import { MoveAccountComponent } from './move-account/move-account.component';
import { NewAccountComponent } from './new-account/new-account.component';
import { NewMoveConsignComponent } from './new-move-consign/new-move-consign.component';
import { NewMoveWithdrawComponent } from './new-move-withdraw/new-move-withdraw.component';

const routes: Routes = [
  {path:'menu',component:AccountComponent}, 
  {
    path:'',
    component:LayoutComponent,
    children:[
      {path:'consult',component:ConsultAccountComponent},
      {path:'new',component:NewAccountComponent},
      {path:'move',component:MoveAccountComponent},
      {path:'consign',component:NewMoveConsignComponent},
      {path:'withdraw',component:NewMoveWithdrawComponent},


    ]
  }

];



@NgModule({
  declarations: [],
  imports: [
    RouterModule.forChild(routes),
    ShareModuleModule
  ],
  exports:[
    RouterModule
  ]
})
export class AccountRoutingModule { }
