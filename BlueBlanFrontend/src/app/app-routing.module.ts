import { NgModule } from '@angular/core';
import { Routes, RouterModule, CanActivate } from '@angular/router';
import { LoginComponent } from "./components/login/login.component";
import { AuthenticateGuard } from './guards/authenticate.guard';


const routes: Routes = [
  {path:'',component:LoginComponent},
  {path:'login',component:LoginComponent},
  {
    path:'account',
    canActivate:[AuthenticateGuard],
    loadChildren: ()=> import('./components/account-module/account.module').then(m => m.AccountModule)
  },
  {
    path:'client',
    canActivate:[AuthenticateGuard],
    loadChildren: ()=> import('./components/client-module/client-module.module').then(m=>m.ClientModuleModule)
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
