import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AccountComponent } from "./components/account/account.component";
import { ConsultAccountComponent } from "./components/consult-account/consult-account.component";
import { NewAccountComponent } from "./components/new-account/new-account.component";
import { MoveAccountComponent } from "./components/move-account/move-account.component";
import { HistoriMoveAccountComponent } from "./components/histori-move-account/histori-move-account.component";



const routes: Routes = [
  {path:'account',component:AccountComponent},
  {path:'consult',component:ConsultAccountComponent},
  {path:'new',component:NewAccountComponent},
  {path:'move',component:MoveAccountComponent},
  {path:'history',component:HistoriMoveAccountComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
