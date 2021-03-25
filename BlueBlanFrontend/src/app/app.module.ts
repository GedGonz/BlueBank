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

@NgModule({
  declarations: [
    AppComponent,
    AccountComponent,
    ConsultAccountComponent,
    NewAccountComponent,
    MoveAccountComponent,
    HistoriMoveAccountComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    AngularFontAwesomeModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
