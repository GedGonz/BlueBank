import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { AngularFontAwesomeModule } from 'angular-font-awesome';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { AccountComponent } from './components/account/account.component';
import { ConsultAccountComponent } from './components/consult-account/consult-account.component';
import { NewAccountComponent } from './components/new-account/new-account.component';
import { MoveAccountComponent } from './components/move-account/move-account.component';
import { HistoriMoveAccountComponent } from './components/histori-move-account/histori-move-account.component';
import { NewClientComponent } from './components/new-client/new-client.component';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ToastrModule } from 'ngx-toastr';
@NgModule({
  declarations: [
    AppComponent,
    AccountComponent,
    ConsultAccountComponent,
    NewAccountComponent,
    MoveAccountComponent,
    HistoriMoveAccountComponent,
    NewClientComponent
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
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
