import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { ReactiveFormsModule } from '@angular/forms';
import { AngularFontAwesomeModule } from 'angular-font-awesome';
import { NgxLoadingModule } from 'ngx-loading';
import { LoginComponent } from './login/login.component';
import { SecurityRoutingModule } from './security-routing.module';




@NgModule({
  declarations: [LoginComponent],
  imports: [
    CommonModule,
    FormsModule,
    SecurityRoutingModule,
    ReactiveFormsModule,
    AngularFontAwesomeModule,
    NgxLoadingModule
  ]
})
export class SecurityModule { }
