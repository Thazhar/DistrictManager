import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { DistrictsComponent } from './districts/districts.component';
import {DistrictDetailComponent} from './district-detail/district-detail.component';

const routes: Routes = [
  { path: 'districts', component: DistrictsComponent},
  { path: 'districts/:id', component: DistrictDetailComponent },
  { path: '', redirectTo: '/districts', pathMatch: 'full'}
]

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})

export class AppRoutingModule { }
