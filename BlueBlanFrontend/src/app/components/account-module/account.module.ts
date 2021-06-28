import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { AccountRoutingModule } from './account-routing.module';
import { AngularFontAwesomeModule } from 'angular-font-awesome';
import { ReactiveFormsModule } from '@angular/forms';
import { NgxLoadingModule } from 'ngx-loading';
import { AccountComponent } from './account/account.component';
import { ConsultAccountComponent } from './consult-account/consult-account.component';
import { NewAccountComponent } from './new-account/new-account.component';
import { MoveAccountComponent } from './move-account/move-account.component';
import { NewMoveWithdrawComponent } from './new-move-withdraw/new-move-withdraw.component';
import { NewMoveConsignComponent } from './new-move-consign/new-move-consign.component';
import { ShareModuleModule } from '../share-module/share-module.module';
import { UpercasePipe } from 'src/app/pipes/upercase.pipe';




@NgModule({
  declarations: [
    AccountComponent,
    ConsultAccountComponent,
    NewAccountComponent,
    MoveAccountComponent,
    NewMoveWithdrawComponent,
    NewMoveConsignComponent,
    UpercasePipe
  ],
  imports: [
    CommonModule,
    FormsModule,
    AccountRoutingModule,
    AngularFontAwesomeModule,
    ReactiveFormsModule,
    NgxLoadingModule,
    ShareModuleModule
  ]
})
export class AccountModule { }
