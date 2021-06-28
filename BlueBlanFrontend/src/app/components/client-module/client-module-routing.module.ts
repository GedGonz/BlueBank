import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { LayoutComponent } from '../share-module/layout/layout.component';
import { ShareModuleModule } from '../share-module/share-module.module';
import { NewClientComponent } from './new-client/new-client.component';


const routes: Routes = [
  {
    path:'',
    component:LayoutComponent,
    children:[
      {path:'new',component:NewClientComponent}
    ]
  }
    
];

@NgModule({
  imports: [RouterModule.forChild(routes),
    ShareModuleModule
  ],
  exports: [RouterModule]
})
export class ClientModuleRoutingModule { }
