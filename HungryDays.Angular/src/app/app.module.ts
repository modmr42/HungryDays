import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HungryListComponent } from './components/hungry-list/hungry-list.component';
import { HttpClientModule } from '@angular/common/http';
import { HungryNavbarComponent } from './components/shared/hungry-navbar/hungry-navbar.component';
import { GroceryListComponent } from './components/grocery-list/grocery-list.component';
import { StoreListComponent } from './components/store-list/store-list.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { ServiceWorkerModule } from '@angular/service-worker';
import { environment } from '../environments/environment';

@NgModule({
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    ServiceWorkerModule.register('ngsw-worker.js', {
      enabled: environment.production,
      // Register the ServiceWorker as soon as the application is stable
      // or after 30 seconds (whichever comes first).
      registrationStrategy: 'registerWhenStable:30000'
    })
  ],
  declarations: [
    AppComponent,
    HungryListComponent,
    HungryNavbarComponent,
    GroceryListComponent,
    StoreListComponent,
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
