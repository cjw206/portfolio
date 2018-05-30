import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { ModalModule, BsModalRef } from 'ngx-bootstrap/modal';
import { BsDropdownModule } from 'ngx-bootstrap/dropdown';
import { TooltipModule } from 'ngx-bootstrap/tooltip';

import { AppComponent } from './app.component';
import { AboutModal } from './modals/app.aboutmodal';
import { AboutModalContent } from './modals/app.aboutmodalcontent';


@NgModule({
  declarations: [
    AppComponent,
    AboutModal,
    AboutModalContent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    ModalModule.forRoot(),
    BsDropdownModule.forRoot(),
    TooltipModule.forRoot()
  ],
  entryComponents: [AboutModalContent],
  providers: [BsModalRef, AboutModal],
  bootstrap: [AppComponent]
})
export class AppModule { }
