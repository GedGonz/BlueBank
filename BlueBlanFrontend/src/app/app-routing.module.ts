import { NgModule } from '@angular/core';
import { Routes, RouterModule, CanActivate } from '@angular/router';
import { AccountComponent } from "./components/account/account.component";
import { ConsultAccountComponent } from "./components/consult-account/consult-account.component";
import { NewAccountComponent } from "./components/new-account/new-account.component";
import { MoveAccountComponent } from "./components/move-account/move-account.component";
import { NewClientComponent } from "./components/new-client/new-client.component";
import { NewMoveConsignComponent } from "./components/new-move-consign/new-move-consign.component";
import { NewMoveWithdrawComponent } from "./components/new-move-withdraw/new-move-withdraw.component";
import { LayoutComponent } from './components/layout/layout.component';
import { LoginComponent } from "./components/login/login.component";
import { AuthenticateGuard } from "./guards/authenticate.guard";
const routes: Routes = [
  {path:'',component:LoginComponent},
  {path:'accounts',component:AccountComponent, 
  canActivate:[AuthenticateGuard]
  },
  {path:'login',component:LoginComponent},
  {
    path:'',
    component: LayoutComponent,
    canActivate:[AuthenticateGuard],
    children:[
      {path:'consult',component:ConsultAccountComponent},
      {path:'new',component:NewAccountComponent},
      {path:'move',component:MoveAccountComponent},
      {path:'cliente',component:NewClientComponent},
      {path:'consign',component:NewMoveConsignComponent},
      {path:'withdraw',component:NewMoveWithdrawComponent}
    ]
  }

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
