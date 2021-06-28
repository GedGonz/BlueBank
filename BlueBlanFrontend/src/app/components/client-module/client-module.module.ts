import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { ReactiveFormsModule } from '@angular/forms';
import { AngularFontAwesomeModule } from 'angular-font-awesome';
import { NgxLoadingModule } from 'ngx-loading';
import { ShareModuleModule } from "../share-module/share-module.module";
import { ClientModuleRoutingModule } from './client-module-routing.module';
import { NewClientComponent } from './new-client/new-client.component';

@NgModule({
  declarations: [
    NewClientComponent
  ],
  imports: [
    CommonModule,
    ClientModuleRoutingModule,
    FormsModule,
    ReactiveFormsModule,
    ShareModuleModule,
    AngularFontAwesomeModule,
    NgxLoadingModule
  ]
})
export class ClientModuleModule { }
