import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LayoutComponent } from '../share-module/layout/layout.component';
import { RouterModule } from '@angular/router';




@NgModule({
  declarations: [
    LayoutComponent
  ],
  imports: [
    RouterModule,
    CommonModule
  ],
  exports:[
    LayoutComponent
  ]
})
export class ShareModuleModule { }
