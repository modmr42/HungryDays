import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HungryListComponent } from './components/hungry-list/hungry-list.component';
import { HttpClientModule } from '@angular/common/http';
import { HungryNavbarComponent } from './components/shared/hungry-navbar/hungry-navbar.component';

@NgModule({
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule
  ],
  declarations: [
    AppComponent,
    HungryListComponent,
    HungryNavbarComponent,
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
