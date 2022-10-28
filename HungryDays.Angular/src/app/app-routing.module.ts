import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { GroceryListComponent } from './components/grocery-list/grocery-list.component';
import { HungryListComponent } from './components/hungry-list/hungry-list.component';
import { StoreListComponent } from './components/store-list/store-list.component';

const routes: Routes = [
  { path: '', redirectTo: '/hungrylist', pathMatch: 'full' },
  { path: 'hungrylist/:id', component: HungryListComponent, children: []},
  {path: 'grocerylist', component: GroceryListComponent},
  {path: 'storelist', component: StoreListComponent}] ;

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
