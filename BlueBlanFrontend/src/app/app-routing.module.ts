import { NgModule } from '@angular/core';
import { Routes, RouterModule, CanActivate } from '@angular/router';
import { NewClientComponent } from "./components/new-client/new-client.component";
import { LoginComponent } from "./components/login/login.component";
import { AuthenticateGuard } from './guards/authenticate.guard';


const routes: Routes = [
  {path:'',component:LoginComponent},
  {path:'login',component:LoginComponent},
  {
    path:'account',
    canActivate:[AuthenticateGuard],
    loadChildren: ()=> import('./components/account-module/account.module').then(m => m.AccountModule)
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
