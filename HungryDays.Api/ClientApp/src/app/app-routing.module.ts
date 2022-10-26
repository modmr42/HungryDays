import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HungryListComponent } from './components/hungry-list/hungry-list.component';

const routes: Routes = [
  { path: '', redirectTo: '/hungrylist', pathMatch: 'full' },
  { path: 'hungrylist/:id', component: HungryListComponent, children: [
    {path: 'grocery-list', component: HungryListComponent}] },

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
