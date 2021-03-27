import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { AngularFontAwesomeModule } from 'angular-font-awesome';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { AccountComponent } from './components/account/account.component';
import { ConsultAccountComponent } from './components/consult-account/consult-account.component';
import { NewAccountComponent } from './components/new-account/new-account.component';
import { MoveAccountComponent } from './components/move-account/move-account.component';
import { NewClientComponent } from './components/new-client/new-client.component';
import { HttpClientModule ,HTTP_INTERCEPTORS} from '@angular/common/http';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ToastrModule } from 'ngx-toastr';
import { NewMoveWithdrawComponent } from './components/new-move-withdraw/new-move-withdraw.component';
import { NewMoveConsignComponent } from './components/new-move-consign/new-move-consign.component';
import { LayoutComponent } from './components/layout/layout.component';
import { LoginComponent } from './components/login/login.component';
import { AuthInterceptorService } from "./services/auth-interceptor.service";

@NgModule({
  declarations: [
    AppComponent,
    AccountComponent,
    ConsultAccountComponent,
    NewAccountComponent,
    MoveAccountComponent,
    NewClientComponent,
    NewMoveWithdrawComponent,
    NewMoveConsignComponent,
    LayoutComponent,
    LoginComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    AngularFontAwesomeModule,
    HttpClientModule,
    FormsModule,
    CommonModule,
    BrowserAnimationsModule,
    ToastrModule.forRoot({
      timeOut: 10000,
      positionClass: 'toast-bottom-full-width',
      preventDuplicates: true,
      
    })
  ],
  providers: [
    {
      provide:HTTP_INTERCEPTORS,
      useClass:AuthInterceptorService,
      multi:true
    }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
